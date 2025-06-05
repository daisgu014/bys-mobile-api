using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BYS.Mobile.API.Shared.Models;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace BYS.Mobile.API.Data.Models;

[Table("ADUsers")]
[Index("FkHremployeeId", Name = "Idx_ADUsers")]
public partial class Aduser : IIdentity<int>
{
    [Key]
    [Column("ADUserID")]
    public int AduserId { get; set; }
    [NotMapped]
    public int Id
    {
        get => AduserId;
        set => AduserId = value;
    }

    [Column("AANumberString")]
    [StringLength(50)]
    [Unicode(false)]
    public string AanumberString { get; set; }

    [Column("AANumberInt")]
    public int? AanumberInt { get; set; }

    [Column("AAStatus")]
    [StringLength(10)]
    [Unicode(false)]
    public string Aastatus { get; set; }

    [Column("ADUserGroupID")]
    public int AduserGroupId { get; set; }

    [Column("FK_HREmployeeID")]
    public int? FkHremployeeId { get; set; }

    [Column("ADContactID")]
    public int? AdcontactId { get; set; }

    [Required]
    [Column("ADUserName")]
    [StringLength(50)]
    public string AduserName { get; set; }

    [Required]
    [Column("ADPassword")]
    [StringLength(100)]
    [Unicode(false)]
    public string Adpassword { get; set; }

    [Column("ADProfileDirectory")]
    [StringLength(255)]
    public string AdprofileDirectory { get; set; }

    [Column("ADUserStyle")]
    [StringLength(50)]
    [Unicode(false)]
    public string AduserStyle { get; set; }

    [Column("ADUserStyleSkin")]
    [StringLength(50)]
    [Unicode(false)]
    public string AduserStyleSkin { get; set; }

    [Column("ADUserActiveCheck")]
    public bool? AduserActiveCheck { get; set; }

    [Column("AACreatedDate")]
    public DateTime? AacreatedDate { get; set; }

    [Column("AAUpdatedDate")]
    public DateTime? AaupdatedDate { get; set; }

    [Column("ADUserResetToken")]
    [StringLength(50)]
    public string AduserResetToken { get; set; }

    [Column("ADUserIsCustomizeColumn")]
    public bool? AduserIsCustomizeColumn { get; set; }

    [Column("ADUserIsAllowExportExcel")]
    public bool? AduserIsAllowExportExcel { get; set; }

    [Column("ADUserIsExceptionalSalePermission")]
    public bool? AduserIsExceptionalSalePermission { get; set; }

    [ForeignKey("AduserGroupId")]
    [InverseProperty("Adusers")]
    public virtual AduserGroup AduserGroup { get; set; }

    [ForeignKey("FkHremployeeId")]
    [InverseProperty("Adusers")]
    public virtual Hremployee FkHremployee { get; set; }
}
