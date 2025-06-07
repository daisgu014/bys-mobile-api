using System.Linq.Expressions;
using BYS.Mobile.API.Business.Abstractions;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.UnitOfWorks;
using BYS.Mobile.API.Service.Abtractions;
using BYS.Mobile.API.Shared.Constants;
using BYS.Mobile.API.Shared.Dtos.Pagination;
using BYS.Mobile.API.Shared.Enums;
using BYS.Mobile.API.Shared.Exceptions;
using BYS.Mobile.API.Shared.Models;
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

            // 1. Predicate mặc định: Alive + có PriceSheet mặc định Alive
            Expression<Func<Icproduct, bool>> baseFilter = x =>
                EF.Functions.Like(x.Aastatus.ToLower(), Status.ALIVE.ToLower()) &&
                x.ArpriceSheetItems.Any(item =>
                    item.FkArpriceSheet != null &&
                    EF.Functions.Like(item.FkArpriceSheet.Aastatus, Status.ALIVE) &&
                    item.FkArpriceSheet.ArPriceSheetIsDefault == true
                );

            // 2. Nếu có tìm kiếm, thêm điều kiện Like tên hoặc mã
            if (!string.IsNullOrEmpty(normalizedQuery))
            {
                Expression<Func<Icproduct, bool>> searchFilter = x =>
                    EF.Functions.Like(x.IcproductName.ToLower(), $"%{normalizedQuery}%") ||
                    EF.Functions.Like(x.IcproductNoOfOldSys.ToLower(), $"%{normalizedQuery}%");

                baseFilter = baseFilter.And(searchFilter);
            }

            // 3. Truy vấn DB
            var entities = await _icproductService
                .Find(baseFilter)
                .Include(p => p.FkIcproductAttributeWoodType)
                .Include(p => p.ArpriceSheetItems)
                    .ThenInclude(ar => ar.FkArpriceSheet)
                .AsNoTracking()
                .ToListAsync();

            // 4. Mapping + xử lý PriceSheet mặc định
            var result = new List<ProductResponse>();

            foreach (var entity in entities)
            {
                var productResponse = _mapper.Map<ProductResponse>(entity);

                var defaultItems = entity.ArpriceSheetItems
                    .Where(x => x.FkArpriceSheet?.ArPriceSheetIsDefault == true)
                    .ToList();

                if (defaultItems.Count > 0)
                {
                    var defaultSoqItem = defaultItems.FirstOrDefault(x => x.ArpriceSheetItemSoq == true);
                    var defaultNoSoqItem = defaultItems.FirstOrDefault(x => x.ArpriceSheetItemSoq == false);

                    productResponse.SoqPcsSets = defaultSoqItem?.ArpriceSheetItemQty ?? 0;
                    productResponse.AboveSoq   = defaultSoqItem?.ArpriceSheetItemPrice ?? 0;
                    productResponse.BelowSoq   = defaultNoSoqItem?.ArpriceSheetItemPrice ?? 0;
                }

                result.Add(productResponse);
            }

            return result;
        }
        catch (Exception e)
        {
            _coreProvider.LogInformation($"[GET PRODUCTS NO PAGING ERROR]: {e.Message} - {e.StackTrace}");
            throw new DomainException(ErrorCode.System, $"GET PRODUCTS NO PAGING ERROR: {e.Message}");
        }
    }


   public async Task<PagedResult<ProductResponse>> GetAllPaged(BaseGetAllRequest request)
{
    try
    {
        _coreProvider.LogInformation($"{_coreProvider.IdentityProvider.Identity.UserIdentity.Username}");

        if (request == null)
            throw new DomainException(ErrorCode.NullReference, "Request can not be null");

        request.PageIndex = Math.Max(Constant.MinPageIndexValue, request.PageIndex);
        request.PageSize = Math.Clamp(request.PageSize, Constant.MinPageSizeValue, Constant.MaxPageSizeValue);

        // 1. Predicate ban đầu luôn true
        var predicate = PredicateBuilder.New<Icproduct>(p => true);

        var defaultFilter = PredicateBuilder.New<Icproduct>(p =>
            EF.Functions.Like(p.Aastatus.ToLower(), Status.ALIVE.ToLower()) &&
            p.ArpriceSheetItems.Any(item =>
                item.FkArpriceSheet != null &&
                EF.Functions.Like(item.FkArpriceSheet.Aastatus, Status.ALIVE) &&
                item.FkArpriceSheet.ArPriceSheetIsDefault == true
            )
        );

        predicate = predicate.And(defaultFilter);
        
        var query = _icproductService.Find();

        // 2. Nếu có search → thêm filter ALIVE + PriceSheet mặc định + Like tên
        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var searchPattern = $"%{request.Search.Trim().ToLower()}%";

            var searchFilter = PredicateBuilder.New<Icproduct>(p =>
                EF.Functions.Like(p.IcproductName.ToLower(), searchPattern) ||
                EF.Functions.Like(p.IcproductNoOfOldSys.ToLower(), searchPattern)
            );

            predicate = predicate.And(searchFilter);
        }

        // 3. Sorting
        bool isAsc = request.Asc ?? true;
        query = request.SortField?.ToLower() switch
        {
            "name" => isAsc ? query.OrderBy(x => x.IcproductName) : query.OrderByDescending(x => x.IcproductName),
            "productnoofoldsys" => isAsc ? query.OrderBy(x => x.IcproductNoOfOldSys) : query.OrderByDescending(x => x.IcproductNoOfOldSys),
            _ => isAsc ? query.OrderBy(x => x.AacreatedDate) : query.OrderByDescending(x => x.AacreatedDate)
        };

        // 4. Where + Include + NoTracking
        query = query
            .Where(predicate)
            .Include(p => p.FkIcproductAttributeWoodType)
            .Include(p => p.ArpriceSheetItems)
                .ThenInclude(ar => ar.FkArpriceSheet)
            .AsNoTracking();

        // 5. Total count
        int totalRow = await query.CountAsync();

        // 6. Pagination
        var entities = await query
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        // 7. Mapping result
        var resultList = new List<ProductResponse>();

        foreach (var entity in entities)
        {
            var dto = _mapper.Map<ProductResponse>(entity);

            var defaultItems = entity.ArpriceSheetItems
                .Where(item => item.FkArpriceSheet?.ArPriceSheetIsDefault == true)
                .ToList();

            if (defaultItems.Any())
            {
                var soqItem = defaultItems.FirstOrDefault(x => x.ArpriceSheetItemSoq == true);
                var noSoqItem = defaultItems.FirstOrDefault(x => x.ArpriceSheetItemSoq == false);

                dto.SoqPcsSets = soqItem?.ArpriceSheetItemQty ?? 0;
                dto.AboveSoq   = soqItem?.ArpriceSheetItemPrice ?? 0;
                dto.BelowSoq   = noSoqItem?.ArpriceSheetItemPrice ?? 0;
            }

            resultList.Add(dto);
        }

        return new PagedResult<ProductResponse>
        {
            Results     = resultList,
            CurrentPage = request.PageIndex,
            RowCount    = totalRow,
            PageSize    = request.PageSize
        };
    }
    catch (Exception e)
    {
        throw new DomainException(ErrorCode.System, $"GET PRODUCTS ERROR: {e.Message}");
    }
}


}