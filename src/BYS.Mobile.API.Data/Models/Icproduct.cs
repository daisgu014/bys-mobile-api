using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BYS.Mobile.API.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Data.Models;

[Table("ICProducts")]
public partial class Icproduct : IIdentity<int>
{
    [Key]
    [Column("ICProductID")]
    public int IcproductId { get; set; }
    [NotMapped]                         
    public int Id
    {
        get => IcproductId;
        set => IcproductId = value;
    }

    [Column("AACreatedUser")]
    [StringLength(50)]
    public string AacreatedUser { get; set; }

    [Column("AACreatedDate", TypeName = "datetime")]
    public DateTime? AacreatedDate { get; set; }

    [Column("AAUpdatedUser")]
    [StringLength(50)]
    public string AaupdatedUser { get; set; }

    [Column("AAUpdatedDate", TypeName = "datetime")]
    public DateTime? AaupdatedDate { get; set; }

    [Column("AAStatus")]
    [StringLength(10)]
    [Unicode(false)]
    public string Aastatus { get; set; }

    [Column("FK_ICDepartmentID")]
    public int? FkIcdepartmentId { get; set; }

    [Column("FK_ICProductGroupID")]
    public int FkIcproductGroupId { get; set; }

    [Column("FK_APSupplierID")]
    public int? FkApsupplierId { get; set; }

    [Column("FK_GEVATID")]
    public int? FkGevatid { get; set; }

    [Column("FK_ICProductBasicUnitID")]
    public int FkIcproductBasicUnitId { get; set; }

    [Column("FK_ICProductSaleUnitID")]
    public int? FkIcproductSaleUnitId { get; set; }

    [Column("FK_ICProductPurchaseUnitID")]
    public int? FkIcproductPurchaseUnitId { get; set; }

    [Column("ICProductAttributeKey")]
    [StringLength(50)]
    [Unicode(false)]
    public string IcproductAttributeKey { get; set; }

    [Column("ICProductAttribute")]
    [StringLength(200)]
    public string IcproductAttribute { get; set; }

    [Column("ICProductAttributeNo")]
    [StringLength(50)]
    public string IcproductAttributeNo { get; set; }

    [Column("ICProductSupplierPrice", TypeName = "decimal(18, 5)")]
    public decimal? IcproductSupplierPrice { get; set; }

    [Column("ICProductSupplierNumber")]
    [StringLength(50)]
    public string IcproductSupplierNumber { get; set; }

    [Required]
    [Column("ICProductNo")]
    [StringLength(50)]
    public string IcproductNo { get; set; }

    [Required]
    [Column("ICProductName")]
    [StringLength(256)]
    public string IcproductName { get; set; }

    [Required]
    [Column("ICProductDesc")]
    [StringLength(512)]
    public string IcproductDesc { get; set; }

    [Column("ICProductActiveCheck")]
    public bool IcproductActiveCheck { get; set; }

    [Column("ICProductLength", TypeName = "decimal(18, 5)")]
    public decimal? IcproductLength { get; set; }

    [Column("ICProductHeight", TypeName = "decimal(18, 5)")]
    public decimal? IcproductHeight { get; set; }

    [Column("ICProductWidth", TypeName = "decimal(18, 5)")]
    public decimal? IcproductWidth { get; set; }

    [Column("ICProductWeight", TypeName = "decimal(18, 5)")]
    public decimal? IcproductWeight { get; set; }

    [Column("ICProductBarCode")]
    [StringLength(50)]
    [Unicode(false)]
    public string IcproductBarCode { get; set; }

    [Column("ICProductStockMin", TypeName = "decimal(18, 5)")]
    public decimal? IcproductStockMin { get; set; }

    [Column("ICProductStockMinDateFrom", TypeName = "datetime")]
    public DateTime? IcproductStockMinDateFrom { get; set; }

    [Column("ICProductStockMinDateTo", TypeName = "datetime")]
    public DateTime? IcproductStockMinDateTo { get; set; }

    [Column("ICProductStockMax", TypeName = "decimal(18, 5)")]
    public decimal? IcproductStockMax { get; set; }

    [Column("ICProductStockMaxDateFrom", TypeName = "datetime")]
    public DateTime? IcproductStockMaxDateFrom { get; set; }

    [Column("ICProductStockMaxDateTo", TypeName = "datetime")]
    public DateTime? IcproductStockMaxDateTo { get; set; }

    [Column("ICProductPicture")]
    public byte[] IcproductPicture { get; set; }

    [Column("ICProductPrice01", TypeName = "decimal(18, 5)")]
    public decimal? IcproductPrice01 { get; set; }

    [Required]
    [Column("ICProductType")]
    [StringLength(50)]
    [Unicode(false)]
    public string IcproductType { get; set; }

    public bool? HasComponent { get; set; }

    [Column("ICProductModelNo")]
    [StringLength(50)]
    public string IcproductModelNo { get; set; }

    [Column("ICProductGuaranteeTerm")]
    [StringLength(512)]
    public string IcproductGuaranteeTerm { get; set; }

    [Column("ICProductGuaranteeMonths")]
    public int? IcproductGuaranteeMonths { get; set; }

    [Column("ICProductDepreciationMethod")]
    [StringLength(50)]
    [Unicode(false)]
    public string IcproductDepreciationMethod { get; set; }

    [Column("ICProductDepreciationMonths")]
    public int? IcproductDepreciationMonths { get; set; }

    [Column("ICProductComment")]
    [StringLength(512)]
    public string IcproductComment { get; set; }

    [Column("FK_ACAccountID")]
    public int FkAcaccountId { get; set; }

    [Column("ICProductHavePaint")]
    public bool? IcproductHavePaint { get; set; }

    [Column("FK_ICProductAttributeWoodTypeID")]
    public int? FkIcproductAttributeWoodTypeId { get; set; }

    [Column("ICProductCheckCarcass")]
    public bool? IcproductCheckCarcass { get; set; }

    [Column("FK_ICProductAttributeColorID")]
    public int? FkIcproductAttributeColorId { get; set; }

    [Column("ICProductPaintNoOfManufacture")]
    [StringLength(100)]
    public string IcproductPaintNoOfManufacture { get; set; }

    [Column("FK_ICProductAttributeFinishingID")]
    public int? FkIcproductAttributeFinishingId { get; set; }

    [Column("ICProductJoinery")]
    [StringLength(50)]
    public string IcproductJoinery { get; set; }

    [Column("ICProductSizeAndSpecifiCations")]
    [StringLength(256)]
    public string IcproductSizeAndSpecifiCations { get; set; }

    [Column("ICProductPurchaseType")]
    [StringLength(50)]
    public string IcproductPurchaseType { get; set; }

    [Column("ICProductCode")]
    [StringLength(50)]
    public string IcproductCode { get; set; }

    [Column("ICProductNoOfOldSys")]
    [StringLength(100)]
    public string IcproductNoOfOldSys { get; set; }

    [Column("ICProductCustomerNumber")]
    [StringLength(50)]
    public string IcproductCustomerNumber { get; set; }

    [Column("FK_GECountryID")]
    public int? FkGecountryId { get; set; }

    [Column("FK_ICProductGroupParentID")]
    public int? FkIcproductGroupParentId { get; set; }

    [Column("ICProductName2")]
    [StringLength(256)]
    public string IcproductName2 { get; set; }

    [Column("ICProductWoodTypeAttribute")]
    [StringLength(512)]
    public string IcproductWoodTypeAttribute { get; set; }

    [Column("ICProductColorAttribute")]
    [StringLength(512)]
    public string IcproductColorAttribute { get; set; }

    [Column("FK_ICProdAttPackingMaterialSpecialityID")]
    public int? FkIcprodAttPackingMaterialSpecialityId { get; set; }

    [Column("FK_ICProdAttPackingMaterialSizeID")]
    public int? FkIcprodAttPackingMaterialSizeId { get; set; }

    [Column("FK_ICProdAttPackingMaterialWeightPerVolumeID")]
    public int? FkIcprodAttPackingMaterialWeightPerVolumeId { get; set; }

    [Column("FK_ICProductAttributeSemiProductSpecialityID")]
    public int? FkIcproductAttributeSemiProductSpecialityId { get; set; }

    [Column("FK_ACDepreciationCostAccountID")]
    public int? FkAcdepreciationCostAccountId { get; set; }

    [Column("ICProductOriginalAmount", TypeName = "decimal(18, 5)")]
    public decimal? IcproductOriginalAmount { get; set; }

    [Column("ICProductDepreciatedAmount", TypeName = "decimal(18, 5)")]
    public decimal? IcproductDepreciatedAmount { get; set; }

    [Column("FK_ACDepreciationAccountID")]
    public int? FkAcdepreciationAccountId { get; set; }

    [Column("ICProductAttributeFinishing")]
    [StringLength(50)]
    public string IcproductAttributeFinishing { get; set; }

    [Column("ICProductAttributeFinishingText")]
    [StringLength(512)]
    public string IcproductAttributeFinishingText { get; set; }

    [Column("ICProductWoodGroup")]
    [StringLength(50)]
    public string IcproductWoodGroup { get; set; }

    [Column("FK_ICProductWorkGroupID")]
    public int? FkIcproductWorkGroupId { get; set; }

    [Column("ICProductWorkType")]
    [StringLength(50)]
    public string IcproductWorkType { get; set; }

    [Column("ICProductWorkUnitPrice", TypeName = "decimal(18, 5)")]
    public decimal? IcproductWorkUnitPrice { get; set; }

    [Column("ICProductMaterialUnitPrice", TypeName = "decimal(18, 5)")]
    public decimal? IcproductMaterialUnitPrice { get; set; }

    [Column("ICProductEquipmentUnitPrice", TypeName = "decimal(18, 5)")]
    public decimal? IcproductEquipmentUnitPrice { get; set; }

    [Column("ICProductOriginOfProduct")]
    [StringLength(256)]
    public string IcproductOriginOfProduct { get; set; }

    [Column("ICProductChargeCheck")]
    public bool? IcproductChargeCheck { get; set; }

    [Column("ICProductLockedPurchaseOrder")]
    public bool? IcproductLockedPurchaseOrder { get; set; }

    [Column("ICProductMinLength", TypeName = "decimal(18, 5)")]
    public decimal? IcproductMinLength { get; set; }

    [Column("ICProductMaxHeight", TypeName = "decimal(18, 5)")]
    public decimal? IcproductMaxHeight { get; set; }

    [Column("ICProductTargetType")]
    [StringLength(50)]
    public string IcproductTargetType { get; set; }

    [Column("ICProductOrigin")]
    [StringLength(100)]
    public string IcproductOrigin { get; set; }

    [Column("FK_ICModelID")]
    public int? FkIcmodelId { get; set; }

    [Column("ICProductOtherSize")]
    [StringLength(256)]
    public string IcproductOtherSize { get; set; }

    [Column("ICProductImageFileName")]
    [StringLength(50)]
    public string IcproductImageFileName { get; set; }

    [Column("FK_ICProductParentID")]
    public int? FkIcproductParentId { get; set; }

    [Column("ICProductFixedNorm")]
    public bool? IcproductFixedNorm { get; set; }

    [Column("FK_MMProductionNormItemID")]
    public int? FkMmproductionNormItemId { get; set; }

    [Column("FK_ACAccountRevenueInternalID")]
    public int? FkAcaccountRevenueInternalId { get; set; }

    [Column("FK_ACAccountCostPriceID")]
    public int? FkAcaccountCostPriceId { get; set; }

    [Column("FK_ACAccountRevenueID")]
    public int? FkAcaccountRevenueId { get; set; }

    [Column("FK_ACAccountSaleReturnID")]
    public int? FkAcaccountSaleReturnId { get; set; }

    [Column("FK_ACAccountDiscountID")]
    public int? FkAcaccountDiscountId { get; set; }

    [Column("ICProductLicensePlate")]
    [StringLength(100)]
    public string IcproductLicensePlate { get; set; }

    [Column("ICProductBulk", TypeName = "decimal(18, 5)")]
    public decimal? IcproductBulk { get; set; }

    [Column("ICProductCapacity", TypeName = "decimal(18, 5)")]
    public decimal? IcproductCapacity { get; set; }

    [Column("ICProductDepth", TypeName = "decimal(18, 5)")]
    public decimal? IcproductDepth { get; set; }

    [Column("ICProductRadius", TypeName = "decimal(18, 5)")]
    public decimal? IcproductRadius { get; set; }

    [Column("ICProductDiameter", TypeName = "decimal(18, 5)")]
    public decimal? IcproductDiameter { get; set; }

    [Column("ICProductThickness", TypeName = "decimal(18, 5)")]
    public decimal? IcproductThickness { get; set; }

    [Column("FK_ICProductGroupHeightID")]
    public int? FkIcproductGroupHeightId { get; set; }

    [Column("FK_ICProductFormulaPriceConfigID")]
    public int? FkIcproductFormulaPriceConfigId { get; set; }

    [Column("ICProductGuaranteeMonth", TypeName = "decimal(18, 5)")]
    public decimal? IcproductGuaranteeMonth { get; set; }

    [Column("FK_HREmployeeID")]
    public int? FkHremployeeId { get; set; }

    [Column("ICProductTemplateType")]
    [StringLength(50)]
    public string IcproductTemplateType { get; set; }

    [Column("ICProductPromotionCheck")]
    public bool? IcproductPromotionCheck { get; set; }

    [Column("FK_ICProductTypeAccountConfigID")]
    public int FkIcproductTypeAccountConfigId { get; set; }

    [Column("ICProductUses")]
    [StringLength(50)]
    public string IcproductUses { get; set; }

    [Column("ICProductNonRetail")]
    public bool? IcproductNonRetail { get; set; }

    [Column("ICProductIsShowWeb")]
    public bool? IcproductIsShowWeb { get; set; }

    [Column("ICProductTrademark")]
    [StringLength(50)]
    public string IcproductTrademark { get; set; }

    [Column("ICProductDepartmentGroup")]
    [StringLength(255)]
    public string IcproductDepartmentGroup { get; set; }

    [Column("FK_BRBranchID")]
    public int? FkBrbranchId { get; set; }

    [Column("FK_ACCostCenterID")]
    public int? FkAccostCenterId { get; set; }

    [Column("FK_ACSegmentID")]
    public int? FkAcsegmentId { get; set; }

    [Column("FK_ACEquipmentTypeAccountConfigID")]
    public int? FkAcequipmentTypeAccountConfigId { get; set; }

    [Column("ICProductAlternativeCheck")]
    public bool? IcproductAlternativeCheck { get; set; }

    [Column("FK_ICPriceCalculationMethodID")]
    public int? FkIcpriceCalculationMethodId { get; set; }

    [Column("ICProductImageFile")]
    [StringLength(524)]
    public string IcproductImageFile { get; set; }

    [Column("ICProductBlock", TypeName = "decimal(18, 5)")]
    public decimal? IcproductBlock { get; set; }

    [Column("ICProductVolume", TypeName = "decimal(18, 5)")]
    public decimal? IcproductVolume { get; set; }

    [Column("ICProductImageName")]
    [StringLength(500)]
    public string IcproductImageName { get; set; }

    [Column("FK_MMFormulaIDPaintA")]
    public int? FkMmformulaIdpaintA { get; set; }

    [Column("FK_MMFormulaIDPaintB")]
    public int? FkMmformulaIdpaintB { get; set; }

    [Column("FK_ICProductAttributeQualityID")]
    public int? FkIcproductAttributeQualityId { get; set; }

    [Column("ICProductDepreciationRate", TypeName = "decimal(18, 5)")]
    public decimal? IcproductDepreciationRate { get; set; }

    [Column("ICProductDepreciationQty", TypeName = "decimal(18, 5)")]
    public decimal? IcproductDepreciationQty { get; set; }

    [Column("FK_ARCustomerID")]
    public int? FkArcustomerId { get; set; }

    [Column("FK_MMFormulaIDPaintC")]
    public int? FkMmformulaIdpaintC { get; set; }

    [Column("ICProductCartonBlock", TypeName = "decimal(18, 5)")]
    public decimal? IcproductCartonBlock { get; set; }

    [Column("ICProductInsideDimensionLength", TypeName = "decimal(18, 5)")]
    public decimal? IcproductInsideDimensionLength { get; set; }

    [Column("ICProductInsideDimensionWidth", TypeName = "decimal(18, 5)")]
    public decimal? IcproductInsideDimensionWidth { get; set; }

    [Column("ICProductInsideDimensionHeight", TypeName = "decimal(18, 5)")]
    public decimal? IcproductInsideDimensionHeight { get; set; }

    [Column("ICProductOverallDimensionLength", TypeName = "decimal(18, 5)")]
    public decimal? IcproductOverallDimensionLength { get; set; }

    [Column("ICProductOverallDimensionWidth", TypeName = "decimal(18, 5)")]
    public decimal? IcproductOverallDimensionWidth { get; set; }

    [Column("ICProductOverallDimensionHeight", TypeName = "decimal(18, 5)")]
    public decimal? IcproductOverallDimensionHeight { get; set; }

    [Column("ICProductQtyInBox")]
    public int? IcproductQtyInBox { get; set; }

    [Column("ICProductNetWeight", TypeName = "decimal(18, 5)")]
    public decimal? IcproductNetWeight { get; set; }

    [Column("ICProductGrossWeight", TypeName = "decimal(18, 5)")]
    public decimal? IcproductGrossWeight { get; set; }

    [Column("ICProductLeadTime", TypeName = "decimal(18, 5)")]
    public decimal? IcproductLeadTime { get; set; }

    [Column("ICProductBoxArea", TypeName = "decimal(18, 5)")]
    public decimal? IcproductBoxArea { get; set; }

    [Column("ICProductBoxUnitPrice", TypeName = "decimal(18, 5)")]
    public decimal? IcproductBoxUnitPrice { get; set; }

    [Column("FK_ICProductCarcassID")]
    public int? FkIcproductCarcassId { get; set; }

    [Column("FK_ICProductStockSaveID")]
    public int? FkIcproductStockSaveId { get; set; }

    [Column("ICProductStockSaveDate")]
    public int? IcproductStockSaveDate { get; set; }

    [Column("FK_ICPerimeterGroupID")]
    public int? FkIcperimeterGroupId { get; set; }

    [Column("FK_ICLengthGroupID")]
    public int? FkIclengthGroupId { get; set; }

    [Column("FK_ICStockGroupID")]
    public int? FkIcstockGroupId { get; set; }

    [Column("FK_ICProductWoodIngredientID")]
    public int? FkIcproductWoodIngredientId { get; set; }

    [Column("FK_MMProcessID")]
    public int? FkMmprocessId { get; set; }

    [Column("ICProductIsFollowInventoryStock")]
    public bool? IcproductIsFollowInventoryStock { get; set; }

    [Column("ICProductConsumable", TypeName = "decimal(18, 5)")]
    public decimal? IcproductConsumable { get; set; }

    [Column("ICProductResourceType")]
    [StringLength(50)]
    public string IcproductResourceType { get; set; }

    [Column("FK_ICProductThickGroupID")]
    public int? FkIcproductThickGroupId { get; set; }

    [Column("ICProductStorageDay")]
    public int? IcproductStorageDay { get; set; }

    [Column("ICProductUsingMethod")]
    [StringLength(50)]
    [Unicode(false)]
    public string IcproductUsingMethod { get; set; }

    [Column("ICProductCreateNumber")]
    public int? IcproductCreateNumber { get; set; }

    [Column("FK_ACAccountRevenueHinterLandID")]
    public int? FkAcaccountRevenueHinterLandId { get; set; }

    [Column("ICProductContType")]
    [StringLength(50)]
    public string IcproductContType { get; set; }

    [Column("ICProductInRadius", TypeName = "decimal(18, 5)")]
    public decimal? IcproductInRadius { get; set; }

    [Column("ICProductInDiameter", TypeName = "decimal(18, 5)")]
    public decimal? IcproductInDiameter { get; set; }

    [Column("ICProductWarping", TypeName = "decimal(18, 5)")]
    public decimal? IcproductWarping { get; set; }

    [Column("ICProductNumberSign")]
    [StringLength(50)]
    public string IcproductNumberSign { get; set; }

    [Column("ICProductIsInventory")]
    public bool? IcproductIsInventory { get; set; }

    [Column("ICProductProductionComment")]
    [StringLength(512)]
    public string IcproductProductionComment { get; set; }

    [Column("ICProductPackagingDetail")]
    [StringLength(512)]
    public string IcproductPackagingDetail { get; set; }

    [Column("ICProductStorageCondition")]
    [StringLength(1000)]
    public string IcproductStorageCondition { get; set; }

    [Column("ICProductExpiryDay", TypeName = "decimal(18, 5)")]
    public decimal? IcproductExpiryDay { get; set; }

    [Column("FK_ICWidthGroupID")]
    public int? FkIcwidthGroupId { get; set; }

    [Column("ICProductCollection")]
    [StringLength(100)]
    public string IcproductCollection { get; set; }

    [Column("ICProductPackagingDetailEnglish")]
    [StringLength(256)]
    public string IcproductPackagingDetailEnglish { get; set; }

    [InverseProperty("FkIcproduct")]
    public virtual ICollection<ArpriceSheetItem> ArpriceSheetItems { get; set; } = new List<ArpriceSheetItem>();

    [InverseProperty("FkIcproduct")]
    public virtual ICollection<ArproposalItem> ArproposalItemFkIcproducts { get; set; } = new List<ArproposalItem>();

    [InverseProperty("FkIcsectionProduct")]
    public virtual ICollection<ArproposalItem> ArproposalItemFkIcsectionProducts { get; set; } = new List<ArproposalItem>();

    [ForeignKey("FkIcproductBasicUnitId")]
    [InverseProperty("IcproductFkIcproductBasicUnits")]
    public virtual IcmeasureUnit FkIcproductBasicUnit { get; set; }

    [ForeignKey("FkIcproductCarcassId")]
    [InverseProperty("InverseFkIcproductCarcass")]
    public virtual Icproduct FkIcproductCarcass { get; set; }

    [ForeignKey("FkIcproductParentId")]
    [InverseProperty("InverseFkIcproductParent")]
    public virtual Icproduct FkIcproductParent { get; set; }

    [ForeignKey("FkIcproductPurchaseUnitId")]
    [InverseProperty("IcproductFkIcproductPurchaseUnits")]
    public virtual IcmeasureUnit FkIcproductPurchaseUnit { get; set; }

    [ForeignKey("FkIcproductSaleUnitId")]
    [InverseProperty("IcproductFkIcproductSaleUnits")]
    public virtual IcmeasureUnit FkIcproductSaleUnit { get; set; }

    [InverseProperty("FkIcproductCarcass")]
    public virtual ICollection<Icproduct> InverseFkIcproductCarcass { get; set; } = new List<Icproduct>();

    [InverseProperty("FkIcproductParent")]
    public virtual ICollection<Icproduct> InverseFkIcproductParent { get; set; } = new List<Icproduct>();
}
