using System.Linq.Expressions;
using BYS.Mobile.API.Business.Abstractions;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.Repositories.Abtractions;
using BYS.Mobile.API.Data.UnitOfWorks;
using BYS.Mobile.API.Share.Request;
using BYS.Mobile.API.Shared.Constants;
using BYS.Mobile.API.Shared.Enums;
using BYS.Mobile.API.Shared.Exceptions;
using BYS.Mobile.API.Shared.Models.Commons.Responses;
using BYS.Mobile.API.Shared.Providers.Abstractions;
using BYS.Mobile.API.Shared.Request.Customer;
using BYS.Mobile.API.Shared.Response;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Business.Implements
{
    public class ArcustomerBusiness : BusinessBase, IArcustomerBusiness
    {
        private readonly IArcustomerRepository _arcustomerRepository;
        public ArcustomerBusiness(ICoreProvider coreProvider
            , IUnitOfWorkService unitOfWorkService
            , IArcustomerRepository arcustomerRepository
            ) : base(coreProvider, unitOfWorkService)
        {
            _arcustomerRepository = arcustomerRepository;
        }

        public async Task<List<CustomerResponse>> GetAllCustomers(string query)
        {
            try
            {
                var normalizedQuery = query?.Trim().ToLower() ?? string.Empty;

                Expression<Func<Arcustomer, bool>> predicate = x =>
                    (!string.IsNullOrEmpty(x.ArcustomerName) &&
                     EF.Functions.Like(x.ArcustomerName.ToLower(), $"%{normalizedQuery}%")) ||
                    (!string.IsNullOrEmpty(x.ArcustomerName1) &&
                     EF.Functions.Like(x.ArcustomerName1.ToLower(), $"%{normalizedQuery}%")) ||
                    (!string.IsNullOrEmpty(x.ArcustomerName2) &&
                     EF.Functions.Like(x.ArcustomerName2.ToLower(), $"%{normalizedQuery}%")) ||
                    (!string.IsNullOrEmpty(x.ArcustomerName3) &&
                     EF.Functions.Like(x.ArcustomerName3.ToLower(), $"%{normalizedQuery}%"));

                var entities = await _arcustomerRepository
                    .Find(predicate)
                    .AsNoTracking()
                    .ToListAsync();

                var result = _mapper.Map<List<CustomerResponse>>(entities);
                return result;
            }
            catch (Exception e)
            {
                _coreProvider.LogInformation($"[GET CUSTOMER NO PAGING ERROR]: {e.Message} - {e.StackTrace}");
                throw new DomainException(ErrorCode.NullReference,$"GET CUSTOMER NO PAGING ERROR: {e.Message}");
            }
        }

        public async Task<PagedResult<CustomerResponse>> GetAllCustomersPaging(BaseGetAllRequest request)
        {
            try
            {
                if (request == null)
                {
                    throw new DomainException(ErrorCode.NullReference, "Request can not be null");
                } if(request.PageIndex < 1)
                {
                    request.PageIndex = Constant.MinPageIndexValue;
                }
                if(request.PageSize < 1)
                {
                    request.PageSize = Constant.MinPageSizeValue;
                }
                var predicate = PredicateBuilder.New<Arcustomer>(p => true);
                var query = _arcustomerRepository.Find();
                if (!string.IsNullOrEmpty(request.Search))
                {
                    var searchPattern = $"%{request.Search.ToLower()}%";
                    var filterPredicate = PredicateBuilder.New<Arcustomer>(p =>
                        (!string.IsNullOrEmpty(p.ArcustomerName) &&
                         EF.Functions.Like(p.ArcustomerName.ToLower(), searchPattern)) ||
                        (!string.IsNullOrEmpty(p.ArcustomerName1) &&
                         EF.Functions.Like(p.ArcustomerName1.ToLower(), searchPattern)) ||
                        (!string.IsNullOrEmpty(p.ArcustomerName2) &&
                         EF.Functions.Like(p.ArcustomerName2.ToLower(), searchPattern)) ||
                        (!string.IsNullOrEmpty(p.ArcustomerName3) &&
                         EF.Functions.Like(p.ArcustomerName3.ToLower(), searchPattern))
                    );
                   
                    predicate = predicate.And(filterPredicate);
                }

                if (!string.IsNullOrEmpty(request.SortField))
                {
                    bool isAscending = request.Asc ?? true;
                    query = request.SortField.ToLower() switch
                    {
                        "arcustomername" => isAscending
                            ? query.OrderBy(x => x.ArcustomerName)
                            : query.OrderByDescending(x => x.ArcustomerName),
                        "arcustomername1" => isAscending
                            ? query.OrderBy(x => x.ArcustomerName1)
                            : query.OrderByDescending(x => x.ArcustomerName1),
                        "arcustomername2" => isAscending
                            ? query.OrderBy(x => x.ArcustomerName2)
                            : query.OrderByDescending(x => x.ArcustomerName2),
                        "arcustomername3" => isAscending
                            ? query.OrderBy(x => x.ArcustomerName3)
                            : query.OrderByDescending(x => x.ArcustomerName3),
                        _ => isAscending ? query.OrderBy(x => x.AacreatedDate) : query.OrderByDescending(x => x.AacreatedDate)
                    };
                }
                else
                {
                    query = (request.Asc ?? false) ? query.OrderBy(x => x.AacreatedDate) : query.OrderByDescending(x => x.AacreatedDate);
                }

                query = query.AsNoTracking()
                    .Where(predicate);
                int totalRow = await query.CountAsync();
                request.PageIndex = Math.Max(Constant.MinPageIndexValue, request.PageIndex);
                request.PageSize = Math.Clamp(request.PageSize, Constant.MinPageSizeValue, Constant.MaxPageSizeValue);
                var paginatedQuery = query
                    .Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize);
                var result = await _mapper.ProjectTo<CustomerResponse>(paginatedQuery).ToListAsync();
                var paginationSet = new PagedResult<CustomerResponse>()
                {
                    Results = result,
                    CurrentPage = request.PageIndex,
                    RowCount = totalRow,
                    PageSize = request.PageSize
                };

                return paginationSet;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            throw new NotImplementedException();
        }

        public Task<CustomerResponse> Create(CustomerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
