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
using BYS.Mobile.API.Shared.Request.Proposal;
using BYS.Mobile.API.Shared.Response;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Business.Implements;

public class ArproposalBusiness :  BusinessBase, IArproposalBusiness
{
    private readonly IArproposalService _arproposalService;
    private readonly IArcustomerService _arcustomerService;
    private readonly IIcproductService _icproductService;
    private readonly IGenumberingService _genumberingService;
    private readonly IHremployeeService _hremployeeService;
    private readonly IBrbranchService _brbranchService;
    public ArproposalBusiness(ICoreProvider coreProvider
        , IArproposalService arproposalService
        , IArcustomerService arcustomerService
        , IIcproductService icproductService
        , IGenumberingService genumberingService
        , IHremployeeService hremployeeService
        , IBrbranchService brbranchService
        , IUnitOfWorkService unitOfWorkService) : base(coreProvider, unitOfWorkService)
    {
        _arproposalService = arproposalService;
        _arcustomerService = arcustomerService;
        _icproductService = icproductService;
        _genumberingService = genumberingService;
        _hremployeeService = hremployeeService;
        _brbranchService = brbranchService;
    }
        private async Task<string> GetNextNumberAsync()
        {
            var objGENumberingInfo = await _genumberingService.FirstOrDefaultAsync(x =>
                x.GenumberingName == GENumbering.PROPOSAL && x.Aastatus == Status.ALIVE);

            if (objGENumberingInfo == null)
                throw new Exception("Không tìm thấy cấu hình đánh số PROPOSAL");

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
                .Replace("{6}", "")
                .Replace("{7}", "");

            string prefixMatch = prefix.Replace("{7}", ""); // Giống như: "CUS240601-"

            var existingNos = await _arproposalService.FindAsync(x => x.ArproposalNo.StartsWith(prefixMatch));

            var existingNumbers = existingNos
                .Select(x => x.ArproposalNo.Substring(prefixMatch.Length))
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
            throw new DomainException(ErrorCode.System, $"GET PROPOSAL ERROR: {e.Message}");
        }
    }
    private void CalculateProposalTotals(Arproposal proposal)
    {
        if (proposal == null || proposal.ArproposalItems == null)
            return;

        decimal subTotal = 0;
        decimal netTotal = 0;
        decimal totalCost = 0;
        decimal totalAmount2 = 0;

        foreach (var item in proposal.ArproposalItems)
        {
            var qty = item.ArproposalItemProductQty ?? 0;
            var price = item.IcproductUnitPrice ?? 0;
            var unitPrice2 = item.ArproposalItemProductUnitPrice2 ?? 0;

            item.ArproposalItemPrice = qty * price;
            item.ArproposalItemNetAmount = qty * price;
            item.ArproposalItemTotalAmount = qty * price;
            item.ArproposalItemTotalAmount2 = qty * unitPrice2;

            subTotal += item.ArproposalItemTotalAmount ?? 0;
            netTotal += item.ArproposalItemNetAmount ?? 0;
            totalAmount2 += item.ArproposalItemTotalAmount2 ?? 0;
        }

        proposal.ArproposalSubTotalAmount = subTotal;
        proposal.ArproposalNetAmount = netTotal;
        proposal.ArproposalTotalCost = totalCost;

        // Chiết khấu cố định (DiscountFix) từ % (nếu có)
        proposal.ArproposalDiscountFix = proposal.ArproposalSubTotalAmount * (proposal.ArproposalDiscountPerCent ?? 0) / 100;

        // Hoa hồng bán hàng
        proposal.ArproposalSocommissionAmount =
            (proposal.ArproposalSubTotalAmount - proposal.ArproposalDiscountFix) * (proposal.ArproposalSocommissionPercent ?? 0) / 100;

        // Thuế
        proposal.ArproposalTaxAmount =
            (proposal.ArproposalSubTotalAmount + proposal.ArproposalTotalCost - proposal.ArproposalDiscountFix) * (proposal.ArproposalTaxPercent ?? 0) / 100;

        // Tổng cộng
        proposal.ArproposalTotalAmount =
            proposal.ArproposalSubTotalAmount + proposal.ArproposalTotalCost + proposal.ArproposalTaxAmount - proposal.ArproposalDiscountFix;

        // Gán tổng amount2 nếu bạn cần lưu
       // proposal.Amount2 = totalAmount2;
    }

    public async Task<bool> Create(ProposalRequest request)
{
    try
    {
        if (request == null)
            throw new DomainException(ErrorCode.NullReference, "Request can not be null");

        // 1. Lấy khách hàng
        var customer = await _arcustomerService.FirstOrDefaultAsync(x =>
            x.ArcustomerId == request.customerId &&
            x.Aastatus.ToLower() == Status.ALIVE.ToLower()
        );

        if (customer == null)
            throw new DomainException(ErrorCode.NullReference, "Customer not found or not active");

        var hrEmployee = await _hremployeeService.FirstOrDefaultAsync(x =>
            x.HremployeeId == _coreProvider.IdentityProvider.Identity.UserIdentity.HrEmployeeId)
            ?? throw new DomainException(ErrorCode.NullReference, "User not found or not active");
        var branchId = (await _brbranchService.FirstOrDefaultAsync(x =>
            x.BrbranchType.ToLower() == BranchType.Central && x.Aastatus.ToLower() == Status.ALIVE))?.BrbranchId ?? 0;
        // 2. Lấy danh sách sản phẩm
        var products = await _icproductService.Find()
            .Where(x => request.productIds.Contains(x.IcproductId))
            .Include(p => p.ArpriceSheetItems)
                .ThenInclude(art => art.FkArpriceSheet)
            .Include(p => p.FkIcproductBasicUnit)
            .ToListAsync();
        
        // 3. Tạo proposal
        var proposal = new Arproposal
        {
            AacreatedDate = DateTime.UtcNow,
            AacreatedUser = _coreProvider.IdentityProvider.Identity.UserIdentity.Username,
            FkArcustomerId = customer.ArcustomerId,
            FkHremployeeId = _coreProvider.IdentityProvider.Identity.UserIdentity.HrEmployeeId,
            ArproposalNo = await GetNextNumberAsync(),
            ArproposalItems = new List<ArproposalItem>(),
            ArproposalStatus = Status.NEW,
            FkBrbranchId = branchId,
            ArproposalSaleType = "National",
            Aastatus = Status.ALIVE,
        };

        // 4. Tạo proposal items
        foreach (var product in products)
        {
            var validItems = product.ArpriceSheetItems
                .Where(x =>
                    x.Aastatus == Status.ALIVE &&
                    x.FkArpriceSheet != null &&
                    x.FkArpriceSheet.Aastatus == Status.ALIVE &&
                    x.FkArpriceSheet.ArPriceSheetIsDefault == true
                );

            foreach (var item in validItems)
            {
                var proposalItem = new ArproposalItem
                {
                    FkIcproductId = product.IcproductId,
                    FkArpriceSheetItemId = item.ArpriceSheetItemId,
                    FkArpriceSheetId = item.FkArpriceSheet.ArpriceSheetId,
                    FkIcdepartmentId = hrEmployee.FkHrdepartmentId, 
                    FkIcproductGroupId = product.FkIcproductGroupId,
                    FkIcmeasureUnitId = item.FkIcmeasureUnitId,
                    ArproposalItemProductName = product.IcproductName,
                    ArproposalItemProductDesc = product.IcproductDesc,
                    ArproposalItemProductQty = item.ArpriceSheetItemQty,
                    Aastatus = Status.ALIVE,
                    ArproposalItemType = "Product",
                    ArproposalItemProductSellUnit = product.FkIcproductSaleUnitId.ToString(),
                    ArproposalItemProductBasicUnit = product.FkIcproductBasicUnitId.ToString(),
                    IcproductUnitPrice = item.ArpriceSheetItemPrice ?? 0,
                    ArproposalItemProductQtyOld = item.ArpriceSheetItemQty ?? 0,
                    ArproposalItemPrice = item.ArpriceSheetItemPrice * item.ArpriceSheetItemQty,
                    ArproposalItemNetAmount = item.ArpriceSheetItemPrice * item.ArpriceSheetItemQty,
                    ArproposalItemTotalAmount = item.ArpriceSheetItemPrice * item.ArpriceSheetItemQty,
                    ArproposalItemProductNo = product.IcproductNo,
                    ArproposalItemProductType = product.IcproductType,
                    ArproposalItemProductNoOfOldSys = product.IcproductNoOfOldSys,
                    ArproposalItemWidth = product.IcproductWidth,
                    ArproposalItemHeight = product.IcproductHeight,
                    ArproposalItemLength = product.IcproductLength,
                    FkIcproductAttributeWoodTypeId = product.FkIcproductAttributeWoodTypeId,
                    FkIcproductAttributeColorId = product.FkIcproductAttributeColorId,
                    ArproposalItemProductWoodTypeAttribute = product.IcproductWoodTypeAttribute,
                    ArproposalItemProductColorAttribute = product.IcproductColorAttribute,
                };

                proposal.ArproposalItems.Add(proposalItem);
            }
        }

        CalculateProposalTotals(proposal);
        // 5. Insert proposal
        await _unitOfWorkService.ExecuteInTransactionAsync(async () =>
        {
            await _arproposalService.InsertAsync(proposal);
        });

        return true;
    }
    catch (Exception e)
    {
        _coreProvider.LogInformation($"[CREATE PROPOSAL ERROR]: {e.Message}", e);
        throw new DomainException(ErrorCode.System, $"CREATE PROPOSAL ERROR: {e.Message}");
    }
}

    public async Task<ArproposalResponse> GetDetailsById(int id)
    {
        try
        {
            var query = _arproposalService.Find(x => x.ArproposalId == id)
                .Include(x => x.FkArcustomer)
                .Include(x => x.ArproposalItems)
                .AsNoTracking();

            var result = await query.FirstOrDefaultAsync();

            if (result == null)
                throw new DomainException(ErrorCode.NullReference, $"Proposal with ID {id} not found");

            return _mapper.Map<ArproposalResponse>(result);
        }
        catch (DomainException)
        {
            throw; // Giữ nguyên nếu đã là DomainException
        }
        catch (Exception ex)
        {
            // Log lỗi tại đây nếu cần
            throw new DomainException(ErrorCode.System, $"An error occurred while retrieving proposal details: {ex}");
        }
    }

}