using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BYS.Mobile.API.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Data.Models;

[Table("ICProductAttributes")]
public partial class IcproductAttribute : IIdentity<int>
{
    [Key]
    [Column("ICProductAttributeID")]
    public int IcproductAttributeId { get; set; }
    [NotMapped]
    public int Id
    {
        get => IcproductAttributeId;
        set => IcproductAttributeId = value;
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

    [Required]
    [Column("ICProductAttributeGroup")]
    [StringLength(50)]
    public string IcproductAttributeGroup { get; set; }

    [Column("ICProductAttributeNo")]
    [StringLength(50)]
    public string IcproductAttributeNo { get; set; }

    [Column("ICProductAttributeValue")]
    [StringLength(50)]
    public string IcproductAttributeValue { get; set; }

    [Column("ICProductAttributeParentID")]
    public int? IcproductAttributeParentId { get; set; }

    [Column("ICProductAttributeAbbreviation")]
    [StringLength(50)]
    public string IcproductAttributeAbbreviation { get; set; }

    [Column("FK_ICProductAttributeHTType")]
    public int? FkIcproductAttributeHttype { get; set; }

    [Column("FK_ICProductGroupID")]
    public int? FkIcproductGroupId { get; set; }

    [Column("FK_ARCustomerID")]
    public int? FkArcustomerId { get; set; }

    [Column("ICProductAttributeProductLine")]
    [StringLength(256)]
    public string IcproductAttributeProductLine { get; set; }

    [Column("ICProductAttributeFormulaCountBarrelA")]
    [StringLength(50)]
    public string IcproductAttributeFormulaCountBarrelA { get; set; }

    [Column("ICProductAttributeFormulaCountBarrelB")]
    [StringLength(50)]
    public string IcproductAttributeFormulaCountBarrelB { get; set; }

    [Column("ICProductAttributeFormulaCountSeparatelyValue", TypeName = "decimal(18, 5)")]
    public decimal? IcproductAttributeFormulaCountSeparatelyValue { get; set; }

    [Column("ICProductAttributeFormulaCountOperationA")]
    [StringLength(50)]
    public string IcproductAttributeFormulaCountOperationA { get; set; }

    [Column("ICProductAttributeFormulaCountOperationB")]
    [StringLength(50)]
    public string IcproductAttributeFormulaCountOperationB { get; set; }

    [Column("ICProductAttributeUnSpecifications")]
    public bool? IcproductAttributeUnSpecifications { get; set; }

    [InverseProperty("FkIcproductAttributeColor")]
    public virtual ICollection<ArproposalItem> ArproposalItemFkIcproductAttributeColors { get; set; } = new List<ArproposalItem>();

    [InverseProperty("FkIcproductAttributeWoodType")]
    public virtual ICollection<ArproposalItem> ArproposalItemFkIcproductAttributeWoodTypes { get; set; } = new List<ArproposalItem>();

    [ForeignKey("FkArcustomerId")]
    [InverseProperty("IcproductAttributes")]
    public virtual Arcustomer FkArcustomer { get; set; }

    [InverseProperty("FkIcprodAttPackingMaterialSize")]
    public virtual ICollection<Icproduct> IcproductFkIcprodAttPackingMaterialSizes { get; set; } = new List<Icproduct>();

    [InverseProperty("FkIcprodAttPackingMaterialSpeciality")]
    public virtual ICollection<Icproduct> IcproductFkIcprodAttPackingMaterialSpecialities { get; set; } = new List<Icproduct>();

    [InverseProperty("FkIcprodAttPackingMaterialWeightPerVolume")]
    public virtual ICollection<Icproduct> IcproductFkIcprodAttPackingMaterialWeightPerVolumes { get; set; } = new List<Icproduct>();

    [InverseProperty("FkIcproductAttributeColor")]
    public virtual ICollection<Icproduct> IcproductFkIcproductAttributeColors { get; set; } = new List<Icproduct>();

    [InverseProperty("FkIcproductAttributeFinishing")]
    public virtual ICollection<Icproduct> IcproductFkIcproductAttributeFinishings { get; set; } = new List<Icproduct>();

    [InverseProperty("FkIcproductAttributeQuality")]
    public virtual ICollection<Icproduct> IcproductFkIcproductAttributeQualities { get; set; } = new List<Icproduct>();

    [InverseProperty("FkIcproductAttributeSemiProductSpeciality")]
    public virtual ICollection<Icproduct> IcproductFkIcproductAttributeSemiProductSpecialities { get; set; } = new List<Icproduct>();

    [InverseProperty("FkIcproductAttributeWoodType")]
    public virtual ICollection<Icproduct> IcproductFkIcproductAttributeWoodTypes { get; set; } = new List<Icproduct>();

    [InverseProperty("FkIcproductThickGroup")]
    public virtual ICollection<Icproduct> IcproductFkIcproductThickGroups { get; set; } = new List<Icproduct>();
}
