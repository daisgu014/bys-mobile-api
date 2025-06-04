using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BYS.Mobile.API.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Data.Models;

[Table("ARPriceSheets")]
public partial class ArpriceSheet : IIdentity<int>
{
    [Key]
    [Column("ARPriceSheetID")]
    public int ArpriceSheetId { get; set; }
    [NotMapped]                         
    public int Id
    {
        get => ArpriceSheetId;
        set => ArpriceSheetId = value;
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

    [Column("FK_HREmployeeID")]
    public int FkHremployeeId { get; set; }

    [Required]
    [Column("ARPriceSheetNo")]
    [StringLength(50)]
    public string ArpriceSheetNo { get; set; }

    [Column("ARPriceSheetStatus")]
    [StringLength(50)]
    public string ArpriceSheetStatus { get; set; }

    [Column("ARPriceSheetDesc")]
    [StringLength(1000)]
    public string ArpriceSheetDesc { get; set; }

    [Column("ARPriceSheetDate", TypeName = "datetime")]
    public DateTime? ArpriceSheetDate { get; set; }

    [Column("ARPriceSheetEndDate", TypeName = "datetime")]
    public DateTime? ArpriceSheetEndDate { get; set; }

    [Column("ARCustomerType")]
    [StringLength(50)]
    public string ArcustomerType { get; set; }

    [Column("FK_BRBranchID")]
    public int FkBrbranchId { get; set; }

    [Column("ARPriceSheetName")]
    [StringLength(512)]
    public string ArpriceSheetName { get; set; }

    [Column("ARPriceSheetStartDate", TypeName = "datetime")]
    public DateTime? ArpriceSheetStartDate { get; set; }

    [Column("FK_ARCustomerID")]
    public int? FkArcustomerId { get; set; }

    [Column("FK_GECurrencyID")]
    public int FkGecurrencyId { get; set; }

    [Column("ARPriceSheetIsDefault")]
    public bool? ArpriceSheetIsDefault { get; set; }

    [InverseProperty("FkArpriceSheet")]
    public virtual ICollection<ArpriceSheetItem> ArpriceSheetItems { get; set; } = new List<ArpriceSheetItem>();
}
