using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BYS.Mobile.API.Shared.Models;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace BYS.Mobile.API.Data.Models;

[Table("ARProposals")]
[Index("ArproposalNo", "ArproposalDate", "FkArcustomerId", "ArproposalTypeCombo", Name = "Idx_ARProposals")]
public partial class Arproposal : IIdentity<int>
{
    [Key]
    [Column("ARProposalID")]
    
    public int ArproposalId { get; set; }
    [NotMapped]                         
    public int Id
    {
        get => ArproposalId;
        set => ArproposalId = value;
    }

    [Column("AAStatus")]
    [StringLength(10)]
    [Unicode(false)]
    public string Aastatus { get; set; }

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

    [Column("FK_ARCustomerID")]
    public int? FkArcustomerId { get; set; }

    [Column("FK_HREmployeeID")]
    public int FkHremployeeId { get; set; }

    [Column("FK_GECurrencyID")]
    public int? FkGecurrencyId { get; set; }

    [Column("FK_ARPriceLevelID")]
    public int? FkArpriceLevelId { get; set; }

    [Column("FK_GEShippingMethodID")]
    public int? FkGeshippingMethodId { get; set; }

    [Column("FK_ICStockID")]
    public int? FkIcstockId { get; set; }

    [Column("FK_ICStockSlotID")]
    public int? FkIcstockSlotId { get; set; }

    [Required]
    [Column("ARProposalNo")]
    [StringLength(50)]
    public string ArproposalNo { get; set; }

    [Column("ARProposalName")]
    [StringLength(256)]
    public string ArproposalName { get; set; }

    [Column("ARProposalDate", TypeName = "datetime")]
    public DateTime? ArproposalDate { get; set; }

    [Column("ARProposalValidateDate", TypeName = "datetime")]
    public DateTime? ArproposalValidateDate { get; set; }

    [Column("ARProposalDeliveryDate", TypeName = "datetime")]
    public DateTime? ArproposalDeliveryDate { get; set; }

    [Column("ARProposalStatus")]
    [StringLength(50)]
    public string ArproposalStatus { get; set; }

    [Column("ARProposalTypeCombo")]
    [StringLength(50)]
    public string ArproposalTypeCombo { get; set; }

    [Column("ARProposalPaymentTerm")]
    [StringLength(50)]
    public string ArproposalPaymentTerm { get; set; }

    [Column("ARPaymentMethodCombo")]
    [StringLength(50)]
    public string ArpaymentMethodCombo { get; set; }

    [Column("ARProposalMatchCode01Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArproposalMatchCode01Combo { get; set; }

    [Column("ARProposalMatchCode02Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArproposalMatchCode02Combo { get; set; }

    [Column("ARProposalMatchCode03Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArproposalMatchCode03Combo { get; set; }

    [Column("ARProposalMatchCode04Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArproposalMatchCode04Combo { get; set; }

    [Column("ARProposalMatchCode05Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArproposalMatchCode05Combo { get; set; }

    [Column("ARProposalMatchCode06Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArproposalMatchCode06Combo { get; set; }

    [Column("ARProposalMatchCode07Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArproposalMatchCode07Combo { get; set; }

    [Column("ARProposalMatchCode08Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArproposalMatchCode08Combo { get; set; }

    [Column("ARProposalMatchCode09Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArproposalMatchCode09Combo { get; set; }

    [Column("ARProposalMatchCode10Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArproposalMatchCode10Combo { get; set; }

    [Column("ARProposalMatchCode11Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArproposalMatchCode11Combo { get; set; }

    [Column("ARProposalMatchCode12Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArproposalMatchCode12Combo { get; set; }

    [Column("ARProposalDiscountPerCent", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalDiscountPerCent { get; set; }

    [Column("ARProposalDiscountFix", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalDiscountFix { get; set; }

    [Column("ARProposalNetAmount", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalNetAmount { get; set; }

    [Column("ARProposalTaxAmount", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalTaxAmount { get; set; }

    [Column("ARProposalSubTotalAmount", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalSubTotalAmount { get; set; }

    [Column("ARProposalTotalAmount", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalTotalAmount { get; set; }

    [Column("FK_PMProjectID")]
    public int? FkPmprojectId { get; set; }

    [Column("FK_AREstimateID")]
    public int? FkArestimateId { get; set; }

    [Column("ARProposalTaxPercent", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalTaxPercent { get; set; }

    [Column("ARProposalSOCommissionPercent", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalSocommissionPercent { get; set; }

    [Column("ARProposalSOCommissionAmount", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalSocommissionAmount { get; set; }

    [Column("ARProposalTotalCost", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalTotalCost { get; set; }

    [Column("FK_ACObjectID")]
    public int? FkAcobjectId { get; set; }

    [Column("ARObjectType")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArobjectType { get; set; }

    [Column("FK_GEPaymentTermID")]
    public int FkGepaymentTermId { get; set; }

    [Column("FK_BRBranchID")]
    public int? FkBrbranchId { get; set; }

    [Column("FK_ARPriceSheetID")]
    public int? FkArpriceSheetId { get; set; }

    [Column("ARProposalQuotationType")]
    [StringLength(50)]
    public string ArproposalQuotationType { get; set; }

    [Column("FK_AROpportunityID")]
    public int? FkAropportunityId { get; set; }

    [Column("ARProposalWarrantyNumber", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalWarrantyNumber { get; set; }

    [Column("FK_ARSaleContractID")]
    public int? FkArsaleContractId { get; set; }

    [Column("FK_ACCostCenterID")]
    public int? FkAccostCenterId { get; set; }

    [Column("FK_PMTemplateID")]
    public int? FkPmtemplateId { get; set; }

    [Column("ARProposalTransportFee", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalTransportFee { get; set; }

    [Required]
    [Column("ARProposalSaleType")]
    [StringLength(50)]
    public string ArproposalSaleType { get; set; }

    [Column("ARProposalDiscountPerCentForItem", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalDiscountPerCentForItem { get; set; }

    [Column("FK_CSCompanyBankID")]
    public int? FkCscompanyBankId { get; set; }

    [Column("ARProposalExchangeRate", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalExchangeRate { get; set; }

    [Column("FK_GECurrencyID2")]
    public int? FkGecurrencyId2 { get; set; }

    [Column("ARProposalExchangeRate2", TypeName = "decimal(18, 5)")]
    public decimal? ArproposalExchangeRate2 { get; set; }

    [Column("ARProposalSourceSellingPriceMethod")]
    [StringLength(50)]
    public string ArproposalSourceSellingPriceMethod { get; set; }

    [Column("ARProposalProject")]
    [StringLength(100)]
    public string ArproposalProject { get; set; }

    [Column("ARProposalPaymentTermDesc")]
    [StringLength(512)]
    public string ArproposalPaymentTermDesc { get; set; }

    [Column("ARProposalRemarksDesc")]
    [StringLength(512)]
    public string ArproposalRemarksDesc { get; set; }

    [Column("ARProposalPaymentDesc")]
    [StringLength(512)]
    public string ArproposalPaymentDesc { get; set; }

    [Column("ARProposalDeliveryDesc")]
    [StringLength(512)]
    public string ArproposalDeliveryDesc { get; set; }

    [Column("ARProposalValidityDesc")]
    [StringLength(512)]
    public string ArproposalValidityDesc { get; set; }

    [Column("ARProposalEmployeeCreate")]
    [StringLength(512)]
    public string ArproposalEmployeeCreate { get; set; }

    [Column("ARProposalNote1")]
    [StringLength(512)]
    public string ArproposalNote1 { get; set; }

    [Column("ARProposalNote2")]
    [StringLength(512)]
    public string ArproposalNote2 { get; set; }

    [Column("ARProposalDesc")]
    public byte[] ArproposalDesc { get; set; }

    [Column("ARShippingType")]
    [StringLength(50)]
    public string ArshippingType { get; set; }

    [Column("FK_GETerminalID")]
    public int? FkGeterminalId { get; set; }

    [Column("ARProposalPortOFDischarge")]
    [StringLength(256)]
    public string ArproposalPortOfdischarge { get; set; }

    [InverseProperty("FkArproposal")]
    public virtual ICollection<ArproposalItem> ArproposalItems { get; set; } = new List<ArproposalItem>();

    [ForeignKey("FkArcustomerId")]
    [InverseProperty("Arproposals")]
    public virtual Arcustomer FkArcustomer { get; set; }
}
