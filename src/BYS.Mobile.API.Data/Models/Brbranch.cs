using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BYS.Mobile.API.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Data.Models;

[Table("BRBranchs")]
[Microsoft.EntityFrameworkCore.Index("BrbranchNo", Name = "Idx_BRBranchs")]
public partial class Brbranch : IIdentity<int>
{
    [Key]
    [Column("BRBranchID")]
    public int BrbranchId { get; set; }
    [NotMapped]
    public int Id
    {
        get => BrbranchId;
        set => BrbranchId = value;
    }

    [Column("AACreatedUser")]
    [StringLength(50)]
    public string AacreatedUser { get; set; }

    [Column("AAUpdatedUser")]
    [StringLength(50)]
    public string AaupdatedUser { get; set; }

    [Column("AACreatedDate", TypeName = "datetime")]
    public DateTime? AacreatedDate { get; set; }

    [Column("AAUpdatedDate", TypeName = "datetime")]
    public DateTime? AaupdatedDate { get; set; }

    [Column("AAStatus")]
    [StringLength(10)]
    [Unicode(false)]
    public string Aastatus { get; set; }

    [Column("FK_GELocationID")]
    public int? FkGelocationId { get; set; }

    [Column("BRBranchServerName")]
    [StringLength(50)]
    public string BrbranchServerName { get; set; }

    [Column("BRBranchServerAliasName")]
    [StringLength(50)]
    public string BrbranchServerAliasName { get; set; }

    [Column("BRBranchDatabase")]
    [StringLength(50)]
    public string BrbranchDatabase { get; set; }

    [Column("BRBranchDatabaseUser")]
    [StringLength(50)]
    public string BrbranchDatabaseUser { get; set; }

    [Column("BRBranchDatabasePassword")]
    [StringLength(50)]
    public string BrbranchDatabasePassword { get; set; }

    [Column("BRBranchRemoteUserName")]
    [StringLength(50)]
    public string BrbranchRemoteUserName { get; set; }

    [Column("BRBranchRemotePassword")]
    [StringLength(50)]
    public string BrbranchRemotePassword { get; set; }

    [Required]
    [Column("BRBranchNo")]
    [StringLength(50)]
    public string BrbranchNo { get; set; }

    [Required]
    [Column("BRBranchName")]
    [StringLength(100)]
    public string BrbranchName { get; set; }

    [Column("BRBranchDesc")]
    [StringLength(512)]
    public string BrbranchDesc { get; set; }

    [Required]
    [Column("BRBranchType")]
    [StringLength(50)]
    [Unicode(false)]
    public string BrbranchType { get; set; }

    [Column("BRBranchActiveCheck")]
    public bool? BrbranchActiveCheck { get; set; }

    [Column("BRBranchMatchCode01Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string BrbranchMatchCode01Combo { get; set; }

    [Column("BRBranchMatchCode02Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string BrbranchMatchCode02Combo { get; set; }

    [Column("BRBranchMatchCode03Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string BrbranchMatchCode03Combo { get; set; }

    [Column("BRBranchMatchCode04Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string BrbranchMatchCode04Combo { get; set; }

    [Column("BRBranchMatchCode05Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string BrbranchMatchCode05Combo { get; set; }

    [Column("BRBranchMatchCode06Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string BrbranchMatchCode06Combo { get; set; }

    [Column("BRBranchMatchCode07Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string BrbranchMatchCode07Combo { get; set; }

    [Column("BRBranchMatchCode08Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string BrbranchMatchCode08Combo { get; set; }

    [Column("BRBranchMatchCode09Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string BrbranchMatchCode09Combo { get; set; }

    [Column("BRBranchMatchCode10Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string BrbranchMatchCode10Combo { get; set; }

    [Column("BRBranchContactName")]
    [StringLength(50)]
    public string BrbranchContactName { get; set; }

    [Column("BRBranchContactBirthday", TypeName = "datetime")]
    public DateTime? BrbranchContactBirthday { get; set; }

    [Column("BRBranchContactFirstName")]
    [StringLength(50)]
    public string BrbranchContactFirstName { get; set; }

    [Column("BRBranchContactLastName")]
    [StringLength(50)]
    public string BrbranchContactLastName { get; set; }

    [Column("BRBranchContactTitle")]
    [StringLength(50)]
    public string BrbranchContactTitle { get; set; }

    /// <summary>
    /// fuer Umschlag: zB. Z.Hand Herrn Meyer
    /// </summary>
    [Column("BRBranchContactHeaderLetter")]
    [StringLength(100)]
    public string BrbranchContactHeaderLetter { get; set; }

    /// <summary>
    /// Anrede fuer Briefe
    /// </summary>
    [Column("BRBranchContactHeaderMessage")]
    [StringLength(255)]
    public string BrbranchContactHeaderMessage { get; set; }

    [Column("BRBranchContactEmail1")]
    [StringLength(100)]
    public string BrbranchContactEmail1 { get; set; }

    [Column("BRBranchContactEmail2")]
    [StringLength(100)]
    public string BrbranchContactEmail2 { get; set; }

    [Column("BRBranchContactWebsite")]
    [StringLength(100)]
    public string BrbranchContactWebsite { get; set; }

    [Column("BRBranchContactPhonePrivate")]
    [StringLength(50)]
    [Unicode(false)]
    public string BrbranchContactPhonePrivate { get; set; }

    [Column("BRBranchContactPhone")]
    [StringLength(50)]
    [Unicode(false)]
    public string BrbranchContactPhone { get; set; }

    [Column("BRBranchContactPhone1")]
    [StringLength(50)]
    [Unicode(false)]
    public string BrbranchContactPhone1 { get; set; }

    [Column("BRBranchContactCellPhone1")]
    [StringLength(50)]
    [Unicode(false)]
    public string BrbranchContactCellPhone1 { get; set; }

    [Column("BRBranchContactCellPhone")]
    [StringLength(50)]
    [Unicode(false)]
    public string BrbranchContactCellPhone { get; set; }

    [Column("BRBranchContactFax")]
    [StringLength(50)]
    public string BrbranchContactFax { get; set; }

    [Column("BRBranchContactInformation")]
    [StringLength(510)]
    [Unicode(false)]
    public string BrbranchContactInformation { get; set; }

    [Column("BRBranchContactDepartment")]
    [StringLength(50)]
    public string BrbranchContactDepartment { get; set; }

    [Column("BRBranchContactRoom")]
    [StringLength(30)]
    [Unicode(false)]
    public string BrbranchContactRoom { get; set; }

    [Column("BRBranchContactAddressStreet")]
    [StringLength(200)]
    public string BrbranchContactAddressStreet { get; set; }

    [Column("BRBranchContactAddressLine1")]
    [StringLength(200)]
    public string BrbranchContactAddressLine1 { get; set; }

    [Column("BRBranchContactAddressLine2")]
    [StringLength(200)]
    public string BrbranchContactAddressLine2 { get; set; }

    [Column("BRBranchContactAddressLine3")]
    [StringLength(200)]
    public string BrbranchContactAddressLine3 { get; set; }

    [Column("BRBranchContactAddressCity")]
    [StringLength(50)]
    public string BrbranchContactAddressCity { get; set; }

    [Column("BRBranchContactAddressPostalCode")]
    [StringLength(50)]
    public string BrbranchContactAddressPostalCode { get; set; }

    [Column("BRBranchContactAddressStateProvince")]
    [StringLength(50)]
    public string BrbranchContactAddressStateProvince { get; set; }

    [Column("BRBranchContactAddressZipCode")]
    [StringLength(50)]
    public string BrbranchContactAddressZipCode { get; set; }

    [Column("BRBranchContactAddressCountry")]
    [StringLength(50)]
    public string BrbranchContactAddressCountry { get; set; }

    [Column("BRBranchParentID")]
    public int? BrbranchParentId { get; set; }

    [Column("BRBranchCompanyName")]
    [StringLength(100)]
    public string BrbranchCompanyName { get; set; }

    [Column("BRBranchWarrantyPhone")]
    [StringLength(50)]
    public string BrbranchWarrantyPhone { get; set; }

    [Column("FK_ACAccountDepositID")]
    public int? FkAcaccountDepositId { get; set; }

    [Column("FK_ACAccountPurchaseID")]
    public int? FkAcaccountPurchaseId { get; set; }

    [Column("FK_ACAccountSaleID")]
    public int? FkAcaccountSaleId { get; set; }

    [Column("BRBranchBankCode")]
    [StringLength(255)]
    [Unicode(false)]
    public string BrbranchBankCode { get; set; }

    [Column("BRBranchBankName")]
    [StringLength(255)]
    [Unicode(false)]
    public string BrbranchBankName { get; set; }

    [Column("BRBranchContactLevel")]
    [StringLength(255)]
    [Unicode(false)]
    public string BrbranchContactLevel { get; set; }

    [Column("BRBranchTaxNumber")]
    [StringLength(255)]
    [Unicode(false)]
    public string BrbranchTaxNumber { get; set; }

    [ForeignKey("BrbranchParentId")]
    [InverseProperty("InverseBrbranchParent")]
    public virtual Brbranch BrbranchParent { get; set; }

    [InverseProperty("BrbranchParent")]
    public virtual ICollection<Brbranch> InverseBrbranchParent { get; set; } = new List<Brbranch>();
}
