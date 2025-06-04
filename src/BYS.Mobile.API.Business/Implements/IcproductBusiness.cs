using System.Linq.Expressions;
using BYS.Mobile.API.Business.Abstractions;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.UnitOfWorks;
using BYS.Mobile.API.Service.Abtractions;
using BYS.Mobile.API.Share.Request;
using BYS.Mobile.API.Shared.Constants;
using BYS.Mobile.API.Shared.Dtos.Pagination;
using BYS.Mobile.API.Shared.Enums;
using BYS.Mobile.API.Shared.Exceptions;
using BYS.Mobile.API.Shared.Providers.Abstractions;
using BYS.Mobile.API.Shared.Response;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Business.Implements;

public class IcproductBusiness : BusinessBase, IIcproductBusiness
{
    private readonly IIcproductService _icproductService;
    public IcproductBusiness(ICoreProvider coreProvider
        , IIcproductService icproductService
        , IUnitOfWorkService unitOfWorkService) : base(coreProvider, unitOfWorkService)
    {
        _icproductService = icproductService;
    }

    public async Task<List<ProductResponse>> GetAll(string search)
    {
        try
        {
            var normalizedQuery = search?.Trim().ToLower() ?? string.Empty;

            Expression<Func<Icproduct, bool>> predicate = x =>
                EF.Functions.Like(x.Aastatus.ToLower(), Status.ALIVE.ToLower())&&(
                (!string.IsNullOrEmpty(x.IcproductName) &&
                 EF.Functions.Like(x.IcproductName.ToLower(), $"%{normalizedQuery}%")) ||
                (!string.IsNullOrEmpty(x.IcproductNoOfOldSys) &&
                 EF.Functions.Like(x.IcproductNoOfOldSys.ToLower(), $"%{normalizedQuery}%")));

            var entities = await _icproductService
                .Find(predicate)
                .Include(p => p.FkIcproductAttributeWoodType)
                .Include(p=> p.ArpriceSheetItems).ThenInclude(ar=>ar.FkArpriceSheet)
                .AsNoTracking()
                .ToListAsync();
            var result = new List<ProductResponse>();
            foreach (var entity in entities)
            {
                var productResponse = _mapper.Map<ProductResponse>(entity);

                var defaultItems = entity.ArpriceSheetItems
                    .Where(x => x.FkArpriceSheet.ArPriceSheetIsDefault == true)
                    .ToList();

                if (defaultItems.Count > 0)
                {
                    var defaultSoqItem = defaultItems.FirstOrDefault(x => x.ArpriceSheetItemSoq == true);
                    var defaultNoSoqItem = defaultItems.FirstOrDefault(x => x.ArpriceSheetItemSoq == false);

                    productResponse.SoqPcsSets = defaultSoqItem?.ArpriceSheetItemQty ?? 0;
                    productResponse.AboveSoq     = defaultSoqItem?.ArpriceSheetItemPrice ?? 0;
                    productResponse.BelowSoq     = defaultNoSoqItem?.ArpriceSheetItemPrice ?? 0;
                }

                result.Add(productResponse);
            }

            
            return result;
        }
        catch (Exception e)
        {
            _coreProvider.LogInformation($"[GET PRODUCTS NO PAGING ERROR]: {e.Message} - {e.StackTrace}");
            throw new DomainException(ErrorCode.System,$"GET PRODUCTS NO PAGING ERROR: {e.Message}");
        }
    }

   public async Task<PagedResult<ProductResponse>> GetAllPaged(BaseGetAllRequest request)
    {
        try
        {
            if (request == null)
                throw new DomainException(ErrorCode.NullReference, "Request can not be null");

            if (request.PageIndex < 1)
                request.PageIndex = Constant.MinPageIndexValue;

            if (request.PageSize < 1)
                request.PageSize = Constant.MinPageSizeValue;

            // 1. Xây dựng predicate chung
            var predicate = PredicateBuilder.New<Icproduct>(p => true);
            var query = _icproductService.Find();

            // 2. Nếu có search, thêm điều kiện Status == ALIVE và Like theo Name/NoOfOldSys
            if (!string.IsNullOrEmpty(request.Search))
            {
                var searchPattern = $"%{request.Search.Trim().ToLower()}%";
                var filterPredicate = PredicateBuilder.New<Icproduct>(p =>
                    EF.Functions.Like(p.Aastatus.ToLower(), Status.ALIVE.ToLower())
                    && (
                        (!string.IsNullOrEmpty(p.IcproductName) &&
                         EF.Functions.Like(p.IcproductName.ToLower(), searchPattern))
                        ||
                        (!string.IsNullOrEmpty(p.IcproductNoOfOldSys) &&
                         EF.Functions.Like(p.IcproductNoOfOldSys.ToLower(), searchPattern))
                    )
                );
                predicate = predicate.And(filterPredicate);
            }

            // 3. Sorting
            if (!string.IsNullOrEmpty(request.SortField))
            {
                bool isAscending = request.Asc ?? true;
                query = request.SortField.ToLower() switch
                {
                    "name" => isAscending
                        ? query.OrderBy(x => x.IcproductName)
                        : query.OrderByDescending(x => x.IcproductName),
                    "productnoofoldsys" => isAscending
                        ? query.OrderBy(x => x.IcproductNoOfOldSys)
                        : query.OrderByDescending(x => x.IcproductNoOfOldSys),
                    _ => isAscending
                        ? query.OrderBy(x => x.AacreatedDate)
                        : query.OrderByDescending(x => x.AacreatedDate)
                };
            }
            else
            {
                query = (request.Asc ?? false)
                    ? query.OrderBy(x => x.AacreatedDate)
                    : query.OrderByDescending(x => x.AacreatedDate);
            }

            // 4. Áp predicate, Include ArPriceSheetItems → FkArPriceSheet, và AsNoTracking
            query = query
                .AsNoTracking()
                .Where(predicate)
                .Include(p => p.FkIcproductAttributeWoodType)
                .Include(p => p.ArpriceSheetItems)
                    .ThenInclude(ar => ar.FkArpriceSheet);

            // 5. Đếm tổng số dòng
            int totalRow = await query.CountAsync();

            // 6. Paginate – skip / take
            request.PageIndex = Math.Max(Constant.MinPageIndexValue, request.PageIndex);
            request.PageSize = Math.Clamp(request.PageSize, Constant.MinPageSizeValue, Constant.MaxPageSizeValue);

            var paginatedQuery = query
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            // 7. Lấy danh sách thực thể đã paginate
            var entities = await paginatedQuery.ToListAsync();

            // 8. Map thủ công từng Icproduct sang ProductResponse, đồng thời tính SoqPcsSets, AboveSoq, BelowSoq
            var resultList = new List<ProductResponse>();
            foreach (var entity in entities)
            {
                var dto = _mapper.Map<ProductResponse>(entity);

                // Lọc những ArPriceSheetItem thuộc PriceSheet mặc định
                var defaultItems = entity.ArpriceSheetItems
                    .Where(item => item.FkArpriceSheet.ArPriceSheetIsDefault == true)
                    .ToList();

                if (defaultItems.Count > 0)
                {
                    // Lấy item "SOQ == true" (nếu có)
                    var soqItem = defaultItems.FirstOrDefault(item => item.ArpriceSheetItemSoq == true);
                    // Lấy item "SOQ == false" (nếu có)
                    var noSoqItem = defaultItems.FirstOrDefault(item => item.ArpriceSheetItemSoq == false);

                    // Gán giá trị (có ?? 0 để tránh null)
                    dto.SoqPcsSets = soqItem?.ArpriceSheetItemQty ?? 0;
                    dto.AboveSoq     = soqItem?.ArpriceSheetItemPrice ?? 0;
                    dto.BelowSoq     = noSoqItem?.ArpriceSheetItemPrice ?? 0;
                }

                resultList.Add(dto);
            }

            // 9. Đóng gói PagedResult và trả về
            var paginationSet = new PagedResult<ProductResponse>()
            {
                Results     = resultList,
                CurrentPage = request.PageIndex,
                RowCount    = totalRow,
                PageSize    = request.PageSize
            };

            return paginationSet;
        }
        catch (Exception e)
        {
            throw new DomainException(ErrorCode.System, $"GET PRODUCTS ERROR: {e.Message}");
        }
    }

}