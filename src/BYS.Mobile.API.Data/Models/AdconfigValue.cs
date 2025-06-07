using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BYS.Mobile.API.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Data.Models;

[Table("ADConfigValues")]
public partial class AdconfigValue : IIdentity<int>
{
    [Key]
    [Column("ADConfigValueID")]
    public int AdconfigValueId { get; set; }
    [NotMapped]                         
    public int Id
    {
        get => AdconfigValueId;
        set => AdconfigValueId = value;
    }

    [Column("AAStatus")]
    [StringLength(10)]
    [Unicode(false)]
    public string Aastatus { get; set; }

    [Required]
    [Column("ADConfigKey")]
    [StringLength(100)]
    public string AdconfigKey { get; set; }

    [Required]
    [Column("ADConfigKeyValue")]
    [StringLength(100)]
    public string AdconfigKeyValue { get; set; }

    [Column("ADConfigText")]
    [StringLength(1000)]
    public string AdconfigText { get; set; }

    [Column("ADConfigKeyDesc")]
    [StringLength(500)]
    public string AdconfigKeyDesc { get; set; }

    [Required]
    [Column("ADConfigKeyGroup")]
    [StringLength(50)]
    public string AdconfigKeyGroup { get; set; }

    public bool? IsActive { get; set; }
}
