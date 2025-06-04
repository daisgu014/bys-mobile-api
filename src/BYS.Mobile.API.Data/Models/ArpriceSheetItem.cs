using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BYS.Mobile.API.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Data.Models;

[Table("ARPriceSheetItems")]
public partial class ArpriceSheetItem : IIdentity<int>
{
    [Key]
    [Column("ARPriceSheetItemID")]
    public int ArpriceSheetItemId { get; set; }
    [NotMapped]                         
    public int Id
    {
        get => ArpriceSheetItemId;
        set => ArpriceSheetItemId = value;
    }

    [Column("AACreatedDate", TypeName = "datetime")]
    public DateTime? AacreatedDate { get; set; }

    [Column("AACreatedUser")]
    [StringLength(50)]
    public string AacreatedUser { get; set; }

    [Column("AAUpdatedDate", TypeName = "datetime")]
    public DateTime? AaupdatedDate { get; set; }

    [Column("AAUpdatedUser")]
    [StringLength(50)]
    public string AaupdatedUser { get; set; }

    [Column("AAStatus")]
    [StringLength(10)]
    [Unicode(false)]
    public string Aastatus { get; set; }

    [Column("FK_ARPriceSheetID")]
    public int? FkArpriceSheetId { get; set; }

    [Column("FK_ICProductID")]
    public int? FkIcproductId { get; set; }

    [Column("ARPriceSheetItemProductNo")]
    [StringLength(50)]
    public string ArpriceSheetItemProductNo { get; set; }

    [Column("ARPriceSheetItemProductName")]
    [StringLength(50)]
    public string ArpriceSheetItemProductName { get; set; }

    [Column("ARPriceSheetItemProductDesc")]
    [StringLength(512)]
    public string ArpriceSheetItemProductDesc { get; set; }

    [Column("ARPriceSheetItemProductLength", TypeName = "decimal(18, 5)")]
    public decimal? ArpriceSheetItemProductLength { get; set; }

    [Column("ARPriceSheetItemProductWidth", TypeName = "decimal(18, 5)")]
    public decimal? ArpriceSheetItemProductWidth { get; set; }

    [Column("ARPriceSheetItemProductHeight", TypeName = "decimal(18, 5)")]
    public decimal? ArpriceSheetItemProductHeight { get; set; }

    [Column("ARPriceSheetItemQty", TypeName = "decimal(18, 5)")]
    public decimal? ArpriceSheetItemQty { get; set; }

    [Column("ARPriceSheetItemPrice", TypeName = "decimal(18, 5)")]
    public decimal? ArpriceSheetItemPrice { get; set; }

    [Column("ARPriceSheetItemTotalAmount", TypeName = "decimal(18, 5)")]
    public decimal? ArpriceSheetItemTotalAmount { get; set; }

    [Column("FK_ICMeasureUnitID")]
    public int? FkIcmeasureUnitId { get; set; }

    [Column("FK_ICProductParentID")]
    public int? FkIcproductParentId { get; set; }

    [Column("ARPriceSheetItemCommand")]
    [StringLength(512)]
    public string ArpriceSheetItemCommand { get; set; }

    [Column("ARPriceSheetItemDiscountPercent", TypeName = "decimal(18, 5)")]
    public decimal? ArpriceSheetItemDiscountPercent { get; set; }

    [Column("ARPriceSheetItemDiscountAmount", TypeName = "decimal(18, 5)")]
    public decimal? ArpriceSheetItemDiscountAmount { get; set; }

    [Column("ARPriceSheetItemTaxPercent", TypeName = "decimal(18, 5)")]
    public decimal? ArpriceSheetItemTaxPercent { get; set; }

    [Column("ARPriceSheetItemTaxAmount", TypeName = "decimal(18, 5)")]
    public decimal? ArpriceSheetItemTaxAmount { get; set; }

    [Column("ARPriceSheetItemBasicPrice", TypeName = "decimal(18, 5)")]
    public decimal? ArpriceSheetItemBasicPrice { get; set; }

    [Column("ARPriceSheetItemProductNoOfOldSys")]
    [StringLength(100)]
    public string ArpriceSheetItemProductNoOfOldSys { get; set; }

    [Column("ARPriceSheetItemProductCustomerNumber")]
    [StringLength(100)]
    public string ArpriceSheetItemProductCustomerNumber { get; set; }

    [Column("ARPriceSheetItemNetPrice", TypeName = "decimal(18, 5)")]
    public decimal? ArpriceSheetItemNetPrice { get; set; }

    [Column("ARPriceSheetItemCostingPrice", TypeName = "decimal(18, 5)")]
    public decimal? ArpriceSheetItemCostingPrice { get; set; }

    [Column("ARPriceSheetItemSOQ")]
    public bool? ArpriceSheetItemSoq { get; set; }

    [Column("ARPriceSheetItemSortOrder")]
    public int? ArpriceSheetItemSortOrder { get; set; }

    [Column("ARPriceSheetItemSpecificQty", TypeName = "decimal(18, 5)")]
    public decimal? ArpriceSheetItemSpecificQty { get; set; }

    [Column("ARPriceSheetItemSpecificPrice", TypeName = "decimal(18, 5)")]
    public decimal? ArpriceSheetItemSpecificPrice { get; set; }

    [Column("ARPriceSheetItemLowerSpecificPrice", TypeName = "decimal(18, 5)")]
    public decimal? ArpriceSheetItemLowerSpecificPrice { get; set; }

    [Column("ARPriceSheetItemUpperSpecificPrice", TypeName = "decimal(18, 5)")]
    public decimal? ArpriceSheetItemUpperSpecificPrice { get; set; }

    [ForeignKey("FkArpriceSheetId")]
    [InverseProperty("ArpriceSheetItems")]
    public virtual ArpriceSheet FkArpriceSheet { get; set; }

    [ForeignKey("FkIcmeasureUnitId")]
    [InverseProperty("ArpriceSheetItems")]
    public virtual IcmeasureUnit FkIcmeasureUnit { get; set; }

    [ForeignKey("FkIcproductId")]
    [InverseProperty("ArpriceSheetItems")]
    public virtual Icproduct FkIcproduct { get; set; }
}
