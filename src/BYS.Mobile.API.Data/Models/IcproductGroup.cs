using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BYS.Mobile.API.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Data.Models;

[Table("ICProductGroups")]
public partial class IcproductGroup : IIdentity<int>
{
    [Key]
    [Column("ICProductGroupID")]
    public int IcproductGroupId { get; set; }
    [NotMapped]
    public int Id
    {
        get => IcproductGroupId;
        set => IcproductGroupId = value;
    }

    [Column("AAStatus")]
    [StringLength(50)]
    [Unicode(false)]
    public string Aastatus { get; set; }

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

    [Required]
    [Column("ICProductGroupNo")]
    [StringLength(50)]
    public string IcproductGroupNo { get; set; }

    [Column("ICProductGroupName")]
    [StringLength(512)]
    public string IcproductGroupName { get; set; }

    [Column("ICProductGroupDesc")]
    [StringLength(512)]
    public string IcproductGroupDesc { get; set; }

    [Column("ICProductGroupParentID")]
    public int? IcproductGroupParentId { get; set; }

    [Column("FK_ICDepartmentID")]
    public int? FkIcdepartmentId { get; set; }

    [Column("ICProductGroupIsShowWeb")]
    public bool? IcproductGroupIsShowWeb { get; set; }

    [Column("ICProductGroupType")]
    [StringLength(50)]
    public string IcproductGroupType { get; set; }

    [Column("FK_ICProductTypeAccountConfigID")]
    public int? FkIcproductTypeAccountConfigId { get; set; }

    [Column("ICProductGroupConfigStart")]
    public int? IcproductGroupConfigStart { get; set; }

    [Column("ICProductGroupConfigLength")]
    public int? IcproductGroupConfigLength { get; set; }

    [Column("ICProductGroupConfigGroupNoLength")]
    public int? IcproductGroupConfigGroupNoLength { get; set; }

    [Column("FK_GEVATID")]
    public int? FkGevatid { get; set; }

    [Column("ICProductGroupAbbreviation")]
    [StringLength(50)]
    public string IcproductGroupAbbreviation { get; set; }

    [InverseProperty("FkIcproductGroup")]
    public virtual ICollection<ArproposalItem> ArproposalItems { get; set; } = new List<ArproposalItem>();

    [InverseProperty("FkIcproductGroup")]
    public virtual ICollection<Icproduct> Icproducts { get; set; } = new List<Icproduct>();
}
