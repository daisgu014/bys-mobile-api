namespace BYS.Mobile.API.Shared.Response;

public class ArproposalResponse
{
    public int ArproposalId { get; set; }
    public string Aastatus { get; set; }
    public string AacreatedUser { get; set; }
    public string AaupdatedUser { get; set; }
    public DateTime? AacreatedDate { get; set; }
    public DateTime? AaupdatedDate { get; set; }

    public int? FkArcustomerId { get; set; }
    public int FkHremployeeId { get; set; }
    public int? FkGecurrencyId { get; set; }
    public int? FkArpriceLevelId { get; set; }
    public int? FkGeshippingMethodId { get; set; }
    public int? FkIcstockId { get; set; }
    public int? FkIcstockSlotId { get; set; }

    public string ArproposalNo { get; set; }
    public string ArproposalName { get; set; }
    public DateTime? ArproposalDate { get; set; }
    public DateTime? ArproposalValidateDate { get; set; }
    public DateTime? ArproposalDeliveryDate { get; set; }

    public string ArproposalStatus { get; set; }
    public string ArproposalTypeCombo { get; set; }
    public string ArproposalPaymentTerm { get; set; }
    public string ArpaymentMethodCombo { get; set; }

    public decimal? ArproposalDiscountPerCent { get; set; }
    public decimal? ArproposalDiscountFix { get; set; }

    public decimal? ArproposalNetAmount { get; set; }
    public decimal? ArproposalTaxAmount { get; set; }
    public decimal? ArproposalSubTotalAmount { get; set; }
    public decimal? ArproposalTotalAmount { get; set; }
    public decimal? ArproposalTotalCost { get; set; }

    public decimal? ArproposalTaxPercent { get; set; }
    public decimal? ArproposalSocommissionPercent { get; set; }
    public decimal? ArproposalSocommissionAmount { get; set; }

    public decimal? ArproposalTransportFee { get; set; }
    public string ArproposalRemarksDesc { get; set; }
    public string ArproposalPaymentDesc { get; set; }
    public string ArproposalDeliveryDesc { get; set; }
    public string ArproposalValidityDesc { get; set; }

    public string ArproposalQuotationType { get; set; }
    public string ArproposalSaleType { get; set; }
    public string ArproposalProject { get; set; }

    public decimal? ArproposalExchangeRate { get; set; }
    public decimal? ArproposalExchangeRate2 { get; set; }

    public int? FkArpriceSheetId { get; set; }
    public int? FkPmprojectId { get; set; }
    public int? FkArestimateId { get; set; }
    public int? FkBrbranchId { get; set; }

    public int? FkArsaleContractId { get; set; }
    public int? FkAcobjectId { get; set; }
    public string ArobjectType { get; set; }

    public string ArproposalEmployeeCreate { get; set; }
    public string ArproposalNote1 { get; set; }
    public string ArproposalNote2 { get; set; }

    public string ArproposalPortOfdischarge { get; set; }
    public string ArshippingType { get; set; }

    public decimal? ArproposalWarrantyNumber { get; set; }

    // Danh sách Items và thông tin Customer
    public List<ArproposalItemResponse> ArproposalItems { get; set; }
    public CustomerResponse FkArcustomer { get; set; }
}
