namespace BYS.Mobile.API.Shared.Response;

public class ArproposalItemResponse
{
    public int ArproposalItemId { get; set; }
    public string Aastatus { get; set; }

    public int FkArproposalId { get; set; }
    public int FkIcproductId { get; set; }

    public string ArproposalItemProductNo { get; set; }
    public string ArproposalItemProductName { get; set; }
    public string ArproposalItemProductType { get; set; }

    public string ArproposalItemProductSellUnit { get; set; }
    public decimal? ArproposalItemProductQty { get; set; }

    public decimal? ArproposalItemProductUnitPrice { get; set; }
    public decimal? ArproposalItemProductInternalUnitPrice { get; set; }
    public decimal? ArproposalItemProductUnitCost { get; set; }

    public decimal? ArproposalItemProductDiscount { get; set; }
    public decimal? ArproposalItemProductGroupDiscount { get; set; }
    public decimal? ArproposalItemDiscountFix { get; set; }

    public decimal? ArproposalItemProductTaxPercent { get; set; }
    public decimal? ArproposalItemTaxAmount { get; set; }

    public decimal? ArproposalItemDiscountAmount { get; set; }
    public decimal? ArproposalItemNetAmount { get; set; }
    public decimal? ArproposalItemTotalAmount { get; set; }
    public decimal? ArproposalItemTotalAmount2 { get; set; }
    public decimal? ArproposalItemTotalCost { get; set; }

    public decimal? ArproposalItemMaterialTotalAmount { get; set; }
    public decimal? ArproposalItemWorkTotalAmount { get; set; }
    public decimal? ArproposalItemEquipmentTotalAmount { get; set; }

    public decimal? ArproposalItemProductMaterialUnitPrice { get; set; }
    public decimal? ArproposalItemProductWorkUnitPrice { get; set; }
    public decimal? ArproposalItemProductEquipmentUnitPrice { get; set; }

    public int? FkArpriceSheetId { get; set; }
    public int? FkArpriceSheetItemId { get; set; }

    public string ArproposalItemProductColorAttribute { get; set; }
    public string ArproposalItemProductWoodTypeAttribute { get; set; }

    public string ArproposalItemProductDesc { get; set; }
    public string ArproposalItemDesc { get; set; }

    public DateTime? ArproposalItemDeliveryDate { get; set; }

    public string ArproposalItemProductNoOfOldSys { get; set; }
    public string ArproposalItemProductCustomerNumber { get; set; }

    public string ArproposalItemOneLevelArea { get; set; }
    public string ArproposalItemTwoLevelArea { get; set; }
    public string ArproposalItemThreeLevelArea { get; set; }

    public decimal? ArproposalItemLength { get; set; }
    public decimal? ArproposalItemWidth { get; set; }
    public decimal? ArproposalItemHeight { get; set; }

    public decimal? ArproposalitemProductOverallDimensionLength { get; set; }
    public decimal? ArproposalitemProductOverallDimensionWidth { get; set; }
    public decimal? ArproposalitemProductOverallDimensionHeight { get; set; }

    public string ArproposalTemplateItemProductName { get; set; }

    public string IccontainerType { get; set; }
}
