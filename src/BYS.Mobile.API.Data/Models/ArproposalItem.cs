using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BYS.Mobile.API.Shared.Models;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace BYS.Mobile.API.Data.Models;

[Table("ARProposalItems")]
[Index("FkIcproductId", "FkArproposalId", Name = "Idx_ARProposalItems")]
public partial class ArproposalItem : IIdentity<int>
{
    [Key]
    [Column("ARProposalItemID")]
    public int ArproposalItemId { get; set; }
    [NotMapped]                         
    public int Id
    {
        get => ArproposalItemId;
        set => ArproposalItemId = value;
    }

    [Column("AAStatus")]
    [StringLength(10)]
    [Unicode(false)]
    public string Aastatus { get; set; }

    [Column("AAIsCalculated")]
    public bool? AaisCalculated { get; set; }

    [Column("FK_ARProposalID")]
    public int FkArproposalId { get; set; }

    [Column("FK_ICDepartmentID")]
    public int? FkIcdepartmentId { get; set; }

    [Column("FK_ICProductGroupID")]
    public int? FkIcproductGroupId { get; set; }

    [Column("FK_ICProductID")]
    public int FkIcproductId { get; set; }

    [Column("FK_ICStockID")]
    public int? FkIcstockId { get; set; }

    [Column("FK_ICStockSlotID")]
    public int? FkIcstockSlotId { get; set; }

    [Column("ARProposalItemProductSerialNo")]
    [StringLength(50)]
    public string ArproposalItemProductSerialNo { get; set; }

    [Column("ARProposalItemProductAttribute")]
    [StringLength(200)]
    public string ArproposalItemProductAttribute { get; set; }

    [Column("ARProposalItemProductType")]
    [StringLength(50)]
    public string ArproposalItemProductType { get; set; }

    [Column("ARProposalItemSortOrder")]
    public int? ArproposalItemSortOrder { get; set; }

    [Column("ARProposalItemProductName")]
    [StringLength(256)]
    public string ArproposalItemProductName { get; set; }

    [Column("ARProposalItemProductDesc", TypeName = "ntext")]
    public string ArproposalItemProductDesc { get; set; }

    [Column("ARProposalItemProductSellUnit")]
    [StringLength(50)]
    public string ArproposalItemProductSellUnit { get; set; }

    [Column("ARProposalItemProductBasicUnit")]
    [StringLength(50)]
    public string ArproposalItemProductBasicUnit { get; set; }

    [Column("ARProposalItemProductPackagingUnit")]
    [StringLength(50)]
    public string ArproposalItemProductPackagingUnit { get; set; }

    [Column("ARProposalItemProductSellFactor", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemProductSellFactor { get; set; }

    [Column("ARProposalItemProductPackagingFactor", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemProductPackagingFactor { get; set; }

    [Column("ARProposalItemProductUnitPrice", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemProductUnitPrice { get; set; }

    [Column("ARProposalItemProductInternalUnitPrice", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemProductInternalUnitPrice { get; set; }

    [Column("ARProposalItemProductUnitCost", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemProductUnitCost { get; set; }

    [Column("ARProposalItemProductGroupDiscount", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemProductGroupDiscount { get; set; }

    [Column("ARProposalItemProductDiscount", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemProductDiscount { get; set; }

    [Column("ARProposalItemProductTaxPercent", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemProductTaxPercent { get; set; }

    [Column("ARProposalItemProductQtyOld", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemProductQtyOld { get; set; }

    [Column("ARProposalItemProductQty", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemProductQty { get; set; }

    [Column("ARProposalItemProductBasicQty", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemProductBasicQty { get; set; }

    [Column("ARProposalItemProductPakagingQty", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemProductPakagingQty { get; set; }

    [Column("ARProposalItemQty1", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemQty1 { get; set; }

    [Column("ARProposalItemQty2", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemQty2 { get; set; }

    [Column("ARProposalItemQty3", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemQty3 { get; set; }

    [Column("ARProposalItemQty4", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemQty4 { get; set; }

    [Column("ARProposalItemQty5", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemQty5 { get; set; }

    [Column("ARProposalItemQty6", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemQty6 { get; set; }

    [Column("ARProposalItemComment")]
    [StringLength(50)]
    public string ArproposalItemComment { get; set; }

    [Column("ARProposalItemUnitVolumn", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemUnitVolumn { get; set; }

    [Column("ARProposalItemUnitWeight", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemUnitWeight { get; set; }

    [Column("ARProposalItemPrice", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemPrice { get; set; }

    [Column("ARProposalItemInternalPrice", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemInternalPrice { get; set; }

    [Column("ARProposalItemTaxAmount", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemTaxAmount { get; set; }

    [Column("ARProposalItemDiscountAmount", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemDiscountAmount { get; set; }

    [Column("ARProposalItemNetAmount", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemNetAmount { get; set; }

    [Column("ARProposalItemTotalAmount", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemTotalAmount { get; set; }

    [Column("ARProposalItemTotalCost", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemTotalCost { get; set; }

    [Column("FK_AREstimateItemID")]
    public int? FkArestimateItemId { get; set; }

    [Column("ARProposalItemParentID")]
    public int? ArproposalItemParentId { get; set; }

    [Column("FK_ICMeasureUnitID")]
    public int? FkIcmeasureUnitId { get; set; }

    [Column("FK_APSupplierID")]
    public int? FkApsupplierId { get; set; }

    [Column("ARProposalItemProductNo")]
    [StringLength(50)]
    public string ArproposalItemProductNo { get; set; }

    [Column("ARProposalItemType")]
    [StringLength(50)]
    public string ArproposalItemType { get; set; }

    [Column("ARProposalItemProductEquipmentUnitPrice", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemProductEquipmentUnitPrice { get; set; }

    [Column("ARProposalItemWorkTotalAmount", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemWorkTotalAmount { get; set; }

    [Column("ARProposalItemMaterialTotalAmount", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemMaterialTotalAmount { get; set; }

    [Column("ARProposalItemEquipmentTotalAmount", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemEquipmentTotalAmount { get; set; }

    [Column("ARProposalItemHeight", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemHeight { get; set; }

    [Column("ARProposalItemWidth", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemWidth { get; set; }

    [Column("ARProposalItemLength", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemLength { get; set; }

    [Column("FK_ICProductAttributeWoodTypeID")]
    public int? FkIcproductAttributeWoodTypeId { get; set; }

    [Column("FK_ICProductAttributeColorID")]
    public int? FkIcproductAttributeColorId { get; set; }

    [Column("ARProposalItemProductWoodTypeAttribute")]
    [StringLength(512)]
    public string ArproposalItemProductWoodTypeAttribute { get; set; }

    [Column("ARProposalItemProductColorAttribute")]
    [StringLength(512)]
    public string ArproposalItemProductColorAttribute { get; set; }

    [Column("ARProposalItemProductMaterialUnitPrice", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemProductMaterialUnitPrice { get; set; }

    [Column("ARProposalItemProductWorkUnitPrice", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemProductWorkUnitPrice { get; set; }

    [Column("FK_ICCollectionID")]
    public int? FkIccollectionId { get; set; }

    [Column("FK_ICCollectionItemID")]
    public int? FkIccollectionItemId { get; set; }

    [Column("ARProposalItemDiscountFix", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemDiscountFix { get; set; }

    [Column("ARProposalItemDesc")]
    [StringLength(512)]
    public string ArproposalItemDesc { get; set; }

    [Column("FK_ICProductFormulaPriceConfigID")]
    public int? FkIcproductFormulaPriceConfigId { get; set; }

    [Column("ARProposalItemFormulaPriceConfigQty", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemFormulaPriceConfigQty { get; set; }

    [Column("FK_ARPriceSheetID")]
    public int? FkArpriceSheetId { get; set; }

    [Column("FK_ARPriceSheetItemID")]
    public int? FkArpriceSheetItemId { get; set; }

    [Column("ARProposalItemOneLevelArea")]
    [StringLength(1024)]
    public string ArproposalItemOneLevelArea { get; set; }

    [Column("ARProposalItemTwoLevelArea")]
    [StringLength(1024)]
    public string ArproposalItemTwoLevelArea { get; set; }

    [Column("ARProposalItemThreeLevelArea")]
    [StringLength(1024)]
    public string ArproposalItemThreeLevelArea { get; set; }

    [Column("FK_ICSectionProductID")]
    public int? FkIcsectionProductId { get; set; }

    [Column("FK_ACCostCenterID")]
    public int? FkAccostCenterId { get; set; }

    [Column("FK_PMTemplateItemID")]
    public int? FkPmtemplateItemId { get; set; }

    [Column("FK_ARProposalTemplateItemID")]
    public int? FkArproposalTemplateItemId { get; set; }

    [Column("ARProposalTemplateItemProductName")]
    [StringLength(1024)]
    public string ArproposalTemplateItemProductName { get; set; }

    [Column("ICProductUnitPrice", TypeName = "decimal(18, 5)")]
    public decimal? IcproductUnitPrice { get; set; }

    [Column("ARProposalitemProductOverallDimensionLength", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalitemProductOverallDimensionLength { get; set; }

    [Column("ARProposalitemProductOverallDimensionWidth", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalitemProductOverallDimensionWidth { get; set; }

    [Column("ARProposalitemProductOverallDimensionHeight", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalitemProductOverallDimensionHeight { get; set; }

    [Column("ARProposalItemProductUnitPrice2", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemProductUnitPrice2 { get; set; }

    [Column("ARProposalItemTotalAmount2", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalItemTotalAmount2 { get; set; }

    [Column("ARProposalItemDeliveryDate", TypeName = "datetime")]
    public DateTime? ArproposalItemDeliveryDate { get; set; }

    public bool? IsInlandItemProductName { get; set; }

    [Column("ARProposalItemProductNoOfOldSys")]
    [StringLength(100)]
    public string ArproposalItemProductNoOfOldSys { get; set; }

    [Column("ARProposalItemProductCustomerNumber")]
    [StringLength(50)]
    public string ArproposalItemProductCustomerNumber { get; set; }

    [Column("ICContainerType")]
    [StringLength(100)]
    public string IccontainerType { get; set; }

    [ForeignKey("FkArproposalId")]
    [InverseProperty("ArproposalItems")]
    public virtual Arproposal FkArproposal { get; set; }

    [ForeignKey("FkIcmeasureUnitId")]
    [InverseProperty("ArproposalItems")]
    public virtual IcmeasureUnit FkIcmeasureUnit { get; set; }

    [ForeignKey("FkIcproductId")]
    [InverseProperty("ArproposalItemFkIcproducts")]
    public virtual Icproduct FkIcproduct { get; set; }

    [ForeignKey("FkIcproductAttributeColorId")]
    [InverseProperty("ArproposalItemFkIcproductAttributeColors")]
    public virtual IcproductAttribute FkIcproductAttributeColor { get; set; }

    [ForeignKey("FkIcproductAttributeWoodTypeId")]
    [InverseProperty("ArproposalItemFkIcproductAttributeWoodTypes")]
    public virtual IcproductAttribute FkIcproductAttributeWoodType { get; set; }

    [ForeignKey("FkIcsectionProductId")]
    [InverseProperty("ArproposalItemFkIcsectionProducts")]
    public virtual Icproduct FkIcsectionProduct { get; set; }
}
