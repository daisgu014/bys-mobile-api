using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BYS.Mobile.API.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Data.Models;

[Table("ICMeasureUnits")]
public partial class IcmeasureUnit : IIdentity<int>
{
    [Key]
    [Column("ICMeasureUnitID")]
    public int IcmeasureUnitId { get; set; }
    [NotMapped]                         
    public int Id
    {
        get => IcmeasureUnitId;
        set => IcmeasureUnitId = value;
    }

    [Column("AAStatus")]
    [StringLength(50)]
    [Unicode(false)]
    public string Aastatus { get; set; }

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

    [Required]
    [Column("ICMeasureUnitNo")]
    [StringLength(50)]
    public string IcmeasureUnitNo { get; set; }

    [Required]
    [Column("ICMeasureUnitName")]
    [StringLength(50)]
    public string IcmeasureUnitName { get; set; }

    [Column("ICMeasureUnitDesc")]
    [StringLength(512)]
    public string IcmeasureUnitDesc { get; set; }

    [Column("ICMeasureUnitRoundNum")]
    public int? IcmeasureUnitRoundNum { get; set; }

    [Column("ICMeasureUnitRoundNumInBatchProduct")]
    public int? IcmeasureUnitRoundNumInBatchProduct { get; set; }

    [InverseProperty("FkIcmeasureUnit")]
    public virtual ICollection<ArpriceSheetItem> ArpriceSheetItems { get; set; } = new List<ArpriceSheetItem>();

    [InverseProperty("FkIcmeasureUnit")]
    public virtual ICollection<ArproposalItem> ArproposalItems { get; set; } = new List<ArproposalItem>();

    [InverseProperty("FkIcproductBasicUnit")]
    public virtual ICollection<Icproduct> IcproductFkIcproductBasicUnits { get; set; } = new List<Icproduct>();

    [InverseProperty("FkIcproductPurchaseUnit")]
    public virtual ICollection<Icproduct> IcproductFkIcproductPurchaseUnits { get; set; } = new List<Icproduct>();

    [InverseProperty("FkIcproductSaleUnit")]
    public virtual ICollection<Icproduct> IcproductFkIcproductSaleUnits { get; set; } = new List<Icproduct>();
}
