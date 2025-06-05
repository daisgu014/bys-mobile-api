using System.Linq.Expressions;
using BYS.Mobile.API.Business.Abstractions;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.UnitOfWorks;
using BYS.Mobile.API.Service.Abtractions;
using BYS.Mobile.API.Shared.Constants;
using BYS.Mobile.API.Shared.Dtos.Pagination;
using BYS.Mobile.API.Shared.Enums;
using BYS.Mobile.API.Shared.Exceptions;
using BYS.Mobile.API.Shared.Providers.Abstractions;
using BYS.Mobile.API.Shared.Request;
using BYS.Mobile.API.Shared.Response;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Business.Implements;

public class ArproposalBusiness :  BusinessBase, IArproposalBusiness
{
    private readonly IArproposalService _arproposalService;
    public ArproposalBusiness(ICoreProvider coreProvider
        , IArproposalService arproposalService
        , IUnitOfWorkService unitOfWorkService) : base(coreProvider, unitOfWorkService)
    {
        _arproposalService = arproposalService;
    }

    public async Task<List<ProposalResponse>> GetAll(ProposalFilterRequest request)
{
    var predicate = PredicateBuilder.New<Arproposal>(p => p.Aastatus.ToLower() == Status.ALIVE.ToLower());

    if (!string.IsNullOrWhiteSpace(request.Search))
    {
        var normalizedQuery = request.Search.Trim().ToLower();
        predicate = predicate.And(p =>
            (p.ArproposalNo != null && EF.Functions.Like(p.ArproposalNo.ToLower(), $"%{normalizedQuery}%")) ||
            (p.FkArcustomer.ArcustomerContactPhone != null && EF.Functions.Like(p.FkArcustomer.ArcustomerContactPhone.ToLower(), $"%{normalizedQuery}%")) ||
            (p.FkArcustomer.ArcustomerName != null && EF.Functions.Like(p.FkArcustomer.ArcustomerName.ToLower(), $"%{normalizedQuery}%"))
        );
    }

    if (request.FromDate != null)
        predicate = predicate.And(p => p.AacreatedDate >= request.FromDate);

    if (request.ToDate != null)
        predicate = predicate.And(p => p.AacreatedDate <= request.ToDate);

    var query = _arproposalService.Find()
        .AsNoTracking()
        .Include(p => p.FkArcustomer)
        .Where(predicate);

    // Optional: Apply sorting nếu bạn vẫn muốn giữ
    if (!string.IsNullOrEmpty(request.SortField))
    {
        bool isAscending = request.Asc ?? true;
        query = request.SortField.ToLower() switch
        {
            "arproposalno" => isAscending
                ? query.OrderBy(x => x.ArproposalNo)
                : query.OrderByDescending(x => x.ArproposalNo),
            "arcustomercontactphone" => isAscending
                ? query.OrderBy(x => x.FkArcustomer.ArcustomerContactPhone)
                : query.OrderByDescending(x => x.FkArcustomer.ArcustomerContactPhone),
            "arcustomername" => isAscending
                ? query.OrderBy(x => x.FkArcustomer.ArcustomerName)
                : query.OrderByDescending(x => x.FkArcustomer.ArcustomerName),
            _ => isAscending
                ? query.OrderBy(x => x.AacreatedDate)
                : query.OrderByDescending(x => x.AacreatedDate)
        };
    }

    var entities = await query.ToListAsync();
    return _mapper.Map<List<ProposalResponse>>(entities);
}


    public async Task<PagedResult<ProposalResponse>> GetAllPaging(ProposalFilterRequest request)
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
            
            var predicate = PredicateBuilder.New<Arproposal>(p => true);
            var query = _arproposalService.Find();
            
            predicate  = predicate.And(PredicateBuilder.New<Arproposal>(p => EF.Functions.Like(p.Aastatus.ToLower(), Status.ALIVE.ToLower())));
            
            // 2. Nếu có search, thêm điều kiện Status == ALIVE và Like theo Name/NoOfOldSys
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var searchPattern = $"%{request.Search.Trim().ToLower()}%";
                predicate = predicate.And(p =>
                    (p.ArproposalNo != null && EF.Functions.Like(p.ArproposalNo.ToLower(), searchPattern)) ||
                    (p.FkArcustomer.ArcustomerContactPhone != null && EF.Functions.Like(p.FkArcustomer.ArcustomerContactPhone.ToLower(), searchPattern)) ||
                    (p.FkArcustomer.ArcustomerName != null && EF.Functions.Like(p.FkArcustomer.ArcustomerName.ToLower(), searchPattern))
                );
            }

            if (request.FromDate != null)
                predicate = predicate.And(p => p.AacreatedDate >= request.FromDate);

            if (request.ToDate != null)
                predicate = predicate.And(p => p.AacreatedDate <= request.ToDate); // FIXED
            
            query = query
                .AsNoTracking()
                .Include(p => p.FkArcustomer) // Include trước OrderBy
                .Where(predicate);
            // 3. Sorting
            if (!string.IsNullOrEmpty(request.SortField))
            {
                bool isAscending = request.Asc ?? true;
                query = request.SortField.ToLower() switch
                {
                    "arproposalno" => isAscending
                        ? query.OrderBy(x => x.ArproposalNo)
                        : query.OrderByDescending(x => x.ArproposalNo),
                    "arcustomercontactphone" => isAscending
                        ? query.OrderBy(x => x.FkArcustomer.ArcustomerContactPhone)
                        : query.OrderByDescending(x => x.FkArcustomer.ArcustomerContactPhone),
                    "arcustomername" => isAscending
                        ? query.OrderBy(x => x.FkArcustomer.ArcustomerName)
                        : query.OrderByDescending(x => x.FkArcustomer.ArcustomerName),
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
            var result = await _mapper.ProjectTo<ProposalResponse>(paginatedQuery).ToListAsync();

            // 9. Đóng gói PagedResult và trả về
            var paginationSet = new PagedResult<ProposalResponse>()
            {
                Results     = result,
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