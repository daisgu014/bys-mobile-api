using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using BYS.Mobile.API.Shared.Models;

namespace BYS.Mobile.API.Data.Models;

[Table("ADUserGroups")]
public partial class AduserGroup : IIdentity<int>
{
    [Key]
    [Column("ADUserGroupID")]
    public int AduserGroupId { get; set; }
    [NotMapped]
    public int Id
    {
        get => AduserGroupId;
        set => AduserGroupId = value;
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

    [Column("ADLanguageIDCombo")]
    public int AdlanguageIdcombo { get; set; }

    [Column("ADUserGroupSkinCombo")]
    [StringLength(50)]
    public string AduserGroupSkinCombo { get; set; }

    [Required]
    [Column("ADUserGroupName")]
    [StringLength(50)]
    public string AduserGroupName { get; set; }

    [Column("ADUserGroupDesc")]
    [StringLength(255)]
    public string AduserGroupDesc { get; set; }

    [Column("ADUserGroupActiveCheck")]
    public bool? AduserGroupActiveCheck { get; set; }

    [Column("ADUserGroupCreatedDate", TypeName = "datetime")]
    public DateTime? AduserGroupCreatedDate { get; set; }

    [Column("ADUserGroupCode")]
    [StringLength(50)]
    [Unicode(false)]
    public string AduserGroupCode { get; set; }

    [Column("ADUserGroupCanBeModify")]
    public bool? AduserGroupCanBeModify { get; set; }

    [Column("ADUserGroupSystem")]
    [StringLength(10)]
    [Unicode(false)]
    public string AduserGroupSystem { get; set; }

    [InverseProperty("AduserGroup")]
    public virtual ICollection<Aduser> Adusers { get; set; } = new List<Aduser>();
}
