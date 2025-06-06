using System.Linq.Expressions;
using BYS.Mobile.API.Business.Abstractions;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.UnitOfWorks;
using BYS.Mobile.API.Service.Abtractions;
using BYS.Mobile.API.Shared.Constants;
using BYS.Mobile.API.Shared.Enums;
using BYS.Mobile.API.Shared.Exceptions;
using BYS.Mobile.API.Shared.Models;
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
        private readonly IArcustomerService _arcustomerService;
        private readonly IGenumberingService _genumberingService;
        public ArcustomerBusiness(ICoreProvider coreProvider
            , IUnitOfWorkService unitOfWorkService
            , IArcustomerService arcustomerService
            , IGenumberingService genumberingService
            ) : base(coreProvider, unitOfWorkService)
        {
            _arcustomerService = arcustomerService;
            _genumberingService = genumberingService;
        }

        private async Task<string> GetNextNumberAsync()
        {
            var objGENumberingInfo = await _genumberingService.FirstOrDefaultAsync(x =>
                x.GenumberingName == GENumbering.CUSTOMER && x.Aastatus == Status.ALIVE);

            if (objGENumberingInfo == null)
                throw new Exception("Không tìm thấy cấu hình đánh số CUSTOMER");

            var currentDate = DateTime.Now;

            // Reset lại nếu ngày thay đổi
            if ((objGENumberingInfo.AaupdatedDate?.Year < currentDate.Year && objGENumberingInfo.GenumberingPrefixHaveYear == true)
                || (objGENumberingInfo.AaupdatedDate?.Month < currentDate.Month && objGENumberingInfo.GenumberingPrefixHaveMonth == true)
                || (objGENumberingInfo.AaupdatedDate?.Day < currentDate.Day && objGENumberingInfo.GenumberingPrefixHaveDay == true))
            {
                objGENumberingInfo.GenumberingStart = 1;
            }

            string prefix = objGENumberingInfo.GenumberingFormat
                .Replace("{1}", objGENumberingInfo.GenumberingPrefix)
                .Replace("{2}", objGENumberingInfo.GenumberingPrefixHaveYear == true ? currentDate.Year.ToString().Substring(2, 2) : "")
                .Replace("{3}", objGENumberingInfo.GenumberingPrefixHaveMonth == true ? currentDate.Month.ToString().PadLeft(2, '0') : "")
                .Replace("{4}", objGENumberingInfo.GenumberingPrefixHaveDay == true ? currentDate.Day.ToString().PadLeft(2, '0') : "")
                .Replace("{5}", "")
                .Replace("{6}", "");

            string prefixMatch = prefix.Replace("{7}", ""); // Giống như: "CUS240601-"

            var existingNos = await _arcustomerService
                .FindAsync(x => x.ArcustomerNo.StartsWith(prefixMatch));

            var existingNumbers = existingNos
                .Select(x => x.ArcustomerNo.Substring(prefixMatch.Length))
                .Select(s =>
                {
                    int.TryParse(s, out var number);
                    return number;
                })
                .Where(n => n > 0)
                .ToHashSet();

            int nextNumber = objGENumberingInfo.GenumberingStart;
            while (existingNumbers.Contains(nextNumber))
            {
                nextNumber++;
            }

            objGENumberingInfo.GenumberingStart = nextNumber;
            string finalNumber = prefix + nextNumber.ToString().PadLeft(objGENumberingInfo.GenumberingLength, '0');

            return finalNumber;
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
                     EF.Functions.Like(x.ArcustomerName3.ToLower(), $"%{normalizedQuery}%")) ||
                    (!string.IsNullOrEmpty(x.ArcustomerContactPhone) &&
                     EF.Functions.Like(x.ArcustomerContactPhone.ToLower(), $"%{normalizedQuery}%"));
                var entities = await _arcustomerService
                    .Find(predicate)
                    .AsNoTracking()
                    .ToListAsync();

                var result = _mapper.Map<List<CustomerResponse>>(entities);
                return result;
            }
            catch (Exception e)
            {
                _coreProvider.LogInformation($"[GET CUSTOMER NO PAGING ERROR]: {e.Message} - {e.StackTrace}");
                throw new DomainException(ErrorCode.System,$"GET CUSTOMER NO PAGING ERROR: {e.Message}");
            }
        }

        public async Task<PagedResult<CustomerResponse>> GetAllCustomersPaging(BaseGetAllRequest request)
        {
            try
            {
                if (request == null)
                {
                    throw new DomainException(ErrorCode.NullReference, "Request can not be null");
                }

                if (request.PageIndex < 1)
                {
                    request.PageIndex = Constant.MinPageIndexValue;
                }

                if (request.PageSize < 1)
                {
                    request.PageSize = Constant.MinPageSizeValue;
                }

                var predicate = PredicateBuilder.New<Arcustomer>(p => true);
                var query = _arcustomerService.Find();
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
                         EF.Functions.Like(p.ArcustomerName3.ToLower(), searchPattern)) ||
                        (!string.IsNullOrEmpty(p.ArcustomerContactPhone) &&
                         EF.Functions.Like(p.ArcustomerContactPhone.ToLower(), searchPattern))
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
                throw new DomainException(ErrorCode.System, $"GET CUSTUMERS ERROR: {e.Message}");
            }
        }

        public async Task<CustomerResponse> Create(CustomerRequest request)
        {
            try
            {
                var data = _mapper.Map<Arcustomer>(request);
                data.AacreatedUser = _coreProvider.IdentityProvider.Identity.UserIdentity.Username;
                data.AacreatedDate = DateTime.UtcNow;
                data.ArcustomerNo = await GetNextNumberAsync();
                await _unitOfWorkService.ExecuteInTransactionAsync(async () =>
                {
                    await _arcustomerService.InsertAsync(data);
                });
                var result = _mapper.Map<CustomerResponse>(data);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString()); 
                if (e.InnerException != null)
                    Console.WriteLine("Inner: " + e.InnerException.Message);
                _coreProvider.LogInformation("Inner: " + e.InnerException.Message);
                throw; // đừng bọc để xem lỗi thực tế là gì
            }
        }
    }
}
