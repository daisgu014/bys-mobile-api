using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BYS.Mobile.API.Shared.Models;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace BYS.Mobile.API.Data.Models;

[Table("ARCustomers")]
[Index("ArcustomerNo", "FkBrbranchId", "ArcustomerTypeCombo", Name = "Idx_ARCustomers")]
public partial class Arcustomer : IIdentity<int>
{
    [Key]
    [Column("ARCustomerID")]
    public int ArcustomerId { get; set; }
    [NotMapped]                         
    public int Id
    {
        get => ArcustomerId;
        set => ArcustomerId = value;
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

    [Column("FK_GECurrencyID")]
    public int FkGecurrencyId { get; set; }

    [Column("FK_GEShippingMethodID")]
    public int? FkGeshippingMethodId { get; set; }

    [Column("FK_ARSellerID")]
    public int? FkArsellerId { get; set; }

    [Column("FK_ARPriceListID1")]
    public int? FkArpriceListId1 { get; set; }

    [Column("FK_ARPriceListID2")]
    public int? FkArpriceListId2 { get; set; }

    [Column("FK_ARPriceListID3")]
    public int? FkArpriceListId3 { get; set; }

    [Column("FK_ARPriceListID4")]
    public int? FkArpriceListId4 { get; set; }

    [Column("FK_ARPriceLevelID")]
    public int? FkArpriceLevelId { get; set; }

    [Column("FK_GELocationID")]
    public int? FkGelocationId { get; set; }

    [Column("FK_BRBranchID")]
    public int? FkBrbranchId { get; set; }

    [Column("ARPaymentMethodCombo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArpaymentMethodCombo { get; set; }

    [Column("ARCustomerPaymentTerm")]
    [StringLength(50)]
    public string ArcustomerPaymentTerm { get; set; }

    [Required]
    [Column("ARCustomerNo")]
    [StringLength(50)]
    public string ArcustomerNo { get; set; }

    [Column("ARCustomerName")]
    [StringLength(4000)]
    public string ArcustomerName { get; set; }

    [Column("ARCustomerName1")]
    [StringLength(100)]
    public string ArcustomerName1 { get; set; }

    [Column("ARCustomerName2")]
    [StringLength(100)]
    public string ArcustomerName2 { get; set; }

    [Column("ARCustomerName3")]
    [StringLength(100)]
    public string ArcustomerName3 { get; set; }

    [Column("ARCustomerDesc")]
    [StringLength(255)]
    public string ArcustomerDesc { get; set; }

    [Column("ARCustomerActiveCheck")]
    public bool ArcustomerActiveCheck { get; set; }

    [Column("ARCustomerWebsite")]
    [StringLength(100)]
    public string ArcustomerWebsite { get; set; }

    [Column("ARCustomerTaxNumber")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerTaxNumber { get; set; }

    [Column("ARCustomerDiscount", TypeName = "decimal(18, 5)")]
    public decimal? ArcustomerDiscount { get; set; }

    [Column("ARCustomerCreditLimit", TypeName = "decimal(18, 5)")]
    public decimal? ArcustomerCreditLimit { get; set; }

    [Column("ARCustomerOwing", TypeName = "decimal(18, 5)")]
    public decimal? ArcustomerOwing { get; set; }

    [Column("ARCustomerDueDays")]
    public int? ArcustomerDueDays { get; set; }

    [Column("ARCustomerMatchCode01Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerMatchCode01Combo { get; set; }

    [Column("ARCustomerMatchCode02Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerMatchCode02Combo { get; set; }

    [Column("ARCustomerMatchCode03Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerMatchCode03Combo { get; set; }

    [Column("ARCustomerMatchCode04Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerMatchCode04Combo { get; set; }

    [Column("ARCustomerMatchCode05Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerMatchCode05Combo { get; set; }

    [Column("ARCustomerMatchCode06Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerMatchCode06Combo { get; set; }

    [Column("ARCustomerMatchCode07Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerMatchCode07Combo { get; set; }

    [Column("ARCustomerMatchCode08Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerMatchCode08Combo { get; set; }

    [Column("ARCustomerMatchCode09Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerMatchCode09Combo { get; set; }

    [Column("ARCustomerMatchCode10Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerMatchCode10Combo { get; set; }

    [Column("ARCustomerMatchCode11Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerMatchCode11Combo { get; set; }

    [Column("ARCustomerMatchCode12Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerMatchCode12Combo { get; set; }

    [Column("ARCustomerMatchCode13Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerMatchCode13Combo { get; set; }

    [Column("ARCustomerMatchCode14Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerMatchCode14Combo { get; set; }

    [Column("ARCustomerMatchCode15Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerMatchCode15Combo { get; set; }

    [Column("ARCustomerMatchCode16Combo")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerMatchCode16Combo { get; set; }

    [Required]
    [Column("ARCustomerTypeCombo")]
    [StringLength(50)]
    public string ArcustomerTypeCombo { get; set; }

    [Column("ARCustomerStartDate", TypeName = "datetime")]
    public DateTime? ArcustomerStartDate { get; set; }

    [Column("ARCustomerTel1")]
    [StringLength(50)]
    public string ArcustomerTel1 { get; set; }

    [Column("ARCustomerTel2")]
    [StringLength(50)]
    public string ArcustomerTel2 { get; set; }

    [Column("ARCustomerTel3")]
    [StringLength(50)]
    public string ArcustomerTel3 { get; set; }

    [Column("ARCustomerContactName")]
    [StringLength(50)]
    public string ArcustomerContactName { get; set; }

    [Column("ARCustomerContactBirthday", TypeName = "datetime")]
    public DateTime? ArcustomerContactBirthday { get; set; }

    [Column("ARCustomerContactFirstName")]
    [StringLength(50)]
    public string ArcustomerContactFirstName { get; set; }

    [Column("ARCustomerContactLastName")]
    [StringLength(50)]
    public string ArcustomerContactLastName { get; set; }

    [Column("ARCustomerContactTitle")]
    [StringLength(50)]
    public string ArcustomerContactTitle { get; set; }

    [Column("ARCustomerContactHeaderLetter")]
    [StringLength(100)]
    public string ArcustomerContactHeaderLetter { get; set; }

    [Column("ARCustomerContactHeaderMessage")]
    [StringLength(255)]
    public string ArcustomerContactHeaderMessage { get; set; }

    [Column("ARCustomerContactEmail1")]
    [StringLength(100)]
    public string ArcustomerContactEmail1 { get; set; }

    [Column("ARCustomerContactEmail2")]
    [StringLength(100)]
    public string ArcustomerContactEmail2 { get; set; }

    [Column("ARCustomerContactWebsite")]
    [StringLength(100)]
    public string ArcustomerContactWebsite { get; set; }

    [Column("ARCustomerContactPhonePrivate")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerContactPhonePrivate { get; set; }

    [Column("ARCustomerContactPhone")]
    [StringLength(50)]
    public string ArcustomerContactPhone { get; set; }

    [Column("ARCustomerContactPhone1")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerContactPhone1 { get; set; }

    [Column("ARCustomerContactCellPhone1")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerContactCellPhone1 { get; set; }

    [Column("ARCustomerContactCellPhone")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerContactCellPhone { get; set; }

    [Column("ARCustomerContactFax")]
    [StringLength(50)]
    public string ArcustomerContactFax { get; set; }

    [Column("ARCustomerContactInformation")]
    [StringLength(2000)]
    public string ArcustomerContactInformation { get; set; }

    [Column("ARCustomerContactDepartment")]
    [StringLength(50)]
    public string ArcustomerContactDepartment { get; set; }

    [Column("ARCustomerContactRoom")]
    [StringLength(30)]
    [Unicode(false)]
    public string ArcustomerContactRoom { get; set; }

    [Column("ARCustomerContactAddressLine1")]
    [StringLength(200)]
    public string ArcustomerContactAddressLine1 { get; set; }

    [Column("ARCustomerContactAddressLine2")]
    [StringLength(200)]
    public string ArcustomerContactAddressLine2 { get; set; }

    [Column("ARCustomerContactAddressLine3")]
    [StringLength(200)]
    public string ArcustomerContactAddressLine3 { get; set; }

    [Column("ARCustomerContactAddressCity")]
    [StringLength(50)]
    public string ArcustomerContactAddressCity { get; set; }

    [Column("ARCustomerContactAddressStateProvince")]
    [StringLength(50)]
    public string ArcustomerContactAddressStateProvince { get; set; }

    [Column("ARCustomerContactAddressCountry")]
    [StringLength(50)]
    public string ArcustomerContactAddressCountry { get; set; }

    [Column("ARCustomerContactAddressPostalCode")]
    [StringLength(50)]
    public string ArcustomerContactAddressPostalCode { get; set; }

    [Column("ARCustomerInvoiceAddressStreet")]
    [StringLength(200)]
    public string ArcustomerInvoiceAddressStreet { get; set; }

    [Column("ARCustomerInvoiceAddressLine1")]
    [StringLength(200)]
    public string ArcustomerInvoiceAddressLine1 { get; set; }

    [Column("ARCustomerInvoiceAddressLine2")]
    [StringLength(200)]
    public string ArcustomerInvoiceAddressLine2 { get; set; }

    [Column("ARCustomerInvoiceAddressLine3")]
    [StringLength(200)]
    public string ArcustomerInvoiceAddressLine3 { get; set; }

    [Column("ARCustomerInvoiceAddressCity")]
    [StringLength(50)]
    public string ArcustomerInvoiceAddressCity { get; set; }

    [Column("ARCustomerInvoiceAddressPostalCode")]
    [StringLength(50)]
    public string ArcustomerInvoiceAddressPostalCode { get; set; }

    [Column("ARCustomerInvoiceAddressStateProvince")]
    [StringLength(50)]
    public string ArcustomerInvoiceAddressStateProvince { get; set; }

    [Column("ARCustomerInvoiceAddressZipCode")]
    [StringLength(50)]
    public string ArcustomerInvoiceAddressZipCode { get; set; }

    [Column("ARCustomerInvoiceAddressCountry")]
    [StringLength(50)]
    public string ArcustomerInvoiceAddressCountry { get; set; }

    [Column("ARCustomerDeliveryAddressStreet")]
    [StringLength(200)]
    public string ArcustomerDeliveryAddressStreet { get; set; }

    [Column("ARCustomerDeliveryAddressLine1")]
    [StringLength(200)]
    public string ArcustomerDeliveryAddressLine1 { get; set; }

    [Column("ARCustomerDeliveryAddressLine2")]
    [StringLength(200)]
    public string ArcustomerDeliveryAddressLine2 { get; set; }

    [Column("ARCustomerDeliveryAddressLine3")]
    [StringLength(200)]
    public string ArcustomerDeliveryAddressLine3 { get; set; }

    [Column("ARCustomerDeliveryAddressCity")]
    [StringLength(50)]
    public string ArcustomerDeliveryAddressCity { get; set; }

    [Column("ARCustomerDeliveryAddressPostalCode")]
    [StringLength(50)]
    public string ArcustomerDeliveryAddressPostalCode { get; set; }

    [Column("ARCustomerDeliveryAddressStateProvince")]
    [StringLength(50)]
    public string ArcustomerDeliveryAddressStateProvince { get; set; }

    [Column("ARCustomerDeliveryAddressZipCode")]
    [StringLength(50)]
    public string ArcustomerDeliveryAddressZipCode { get; set; }

    [Column("ARCustomerDeliveryAddressCountry")]
    [StringLength(50)]
    public string ArcustomerDeliveryAddressCountry { get; set; }

    [Column("ARCustomerPaymentAddressStreet")]
    [StringLength(200)]
    public string ArcustomerPaymentAddressStreet { get; set; }

    [Column("ARCustomerPaymentAddressLine1")]
    [StringLength(200)]
    public string ArcustomerPaymentAddressLine1 { get; set; }

    [Column("ARCustomerPaymentAddressLine2")]
    [StringLength(200)]
    public string ArcustomerPaymentAddressLine2 { get; set; }

    [Column("ARCustomerPaymentAddressLine3")]
    [StringLength(200)]
    public string ArcustomerPaymentAddressLine3 { get; set; }

    [Column("ARCustomerPaymentAddressCity")]
    [StringLength(50)]
    public string ArcustomerPaymentAddressCity { get; set; }

    [Column("ARCustomerPaymentAddressPostalCode")]
    [StringLength(50)]
    public string ArcustomerPaymentAddressPostalCode { get; set; }

    [Column("ARCustomerPaymentAddressStateProvince")]
    [StringLength(50)]
    public string ArcustomerPaymentAddressStateProvince { get; set; }

    [Column("ARCustomerPaymentAddressZipCode")]
    [StringLength(50)]
    public string ArcustomerPaymentAddressZipCode { get; set; }

    [Column("ARCustomerPaymentAddressCountry")]
    [StringLength(50)]
    public string ArcustomerPaymentAddressCountry { get; set; }

    [Column("ARCustomerBankCode")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerBankCode { get; set; }

    [Column("ARCustomerBankAccount1")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerBankAccount1 { get; set; }

    [Column("ARCustomerBankAccountCurrency1")]
    public int? ArcustomerBankAccountCurrency1 { get; set; }

    [Column("ARCustomerBankAccount2")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerBankAccount2 { get; set; }

    [Column("ARCustomerBankAccountCurrency2")]
    public int? ArcustomerBankAccountCurrency2 { get; set; }

    [Column("ARCustomerBankAccount3")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerBankAccount3 { get; set; }

    [Column("ARCustomerBankAccountCurrency3")]
    public int? ArcustomerBankAccountCurrency3 { get; set; }

    [Column("ARCustomerBankAccount4")]
    [StringLength(50)]
    [Unicode(false)]
    public string ArcustomerBankAccount4 { get; set; }

    [Column("ARCustomerBankAccountCurrency4")]
    public int? ArcustomerBankAccountCurrency4 { get; set; }

    [Column("ARCustomerBankName")]
    [StringLength(50)]
    public string ArcustomerBankName { get; set; }

    public bool? IsBuyingLocked { get; set; }

    public bool? IsTransferred { get; set; }

    [Column("ARCustomerTransferredDate", TypeName = "datetime")]
    public DateTime? ArcustomerTransferredDate { get; set; }

    [Column("FK_GELocationID1")]
    public int? FkGelocationId1 { get; set; }

    [Column("FK_GELocationID2")]
    public int? FkGelocationId2 { get; set; }

    [Column("FK_GELocationID3")]
    public int? FkGelocationId3 { get; set; }

    [Column("FK_GEPaymentTermID")]
    public int? FkGepaymentTermId { get; set; }

    [Column("ARCustomerLevel")]
    [StringLength(100)]
    public string ArcustomerLevel { get; set; }

    [Column("ARCustomerNoOfOldSys")]
    [StringLength(50)]
    public string ArcustomerNoOfOldSys { get; set; }

    [Column("ARCustomerInvoiceAddressTaxCode")]
    [StringLength(50)]
    public string ArcustomerInvoiceAddressTaxCode { get; set; }

    [Column("ARCustomerInvoiceAddressTel")]
    [StringLength(50)]
    public string ArcustomerInvoiceAddressTel { get; set; }

    [Column("ARCustomerInvoiceAddressFax")]
    [StringLength(50)]
    public string ArcustomerInvoiceAddressFax { get; set; }

    [Column("ARCustomerDeliveryAddressTaxCode")]
    [StringLength(50)]
    public string ArcustomerDeliveryAddressTaxCode { get; set; }

    [Column("ARCustomerDeliveryAddressTel")]
    [StringLength(50)]
    public string ArcustomerDeliveryAddressTel { get; set; }

    [Column("ARCustomerDeliveryAddressFax")]
    [StringLength(50)]
    public string ArcustomerDeliveryAddressFax { get; set; }

    [Column("ARCustomerPaymentAddressTaxCode")]
    [StringLength(50)]
    public string ArcustomerPaymentAddressTaxCode { get; set; }

    [Column("ARCustomerPaymentAddressTel")]
    [StringLength(50)]
    public string ArcustomerPaymentAddressTel { get; set; }

    [Column("ARCustomerPaymentAddressFax")]
    [StringLength(50)]
    public string ArcustomerPaymentAddressFax { get; set; }

    [Column("FK_ACAccountID")]
    public int? FkAcaccountId { get; set; }

    [Column("ARCustomerCMND")]
    [StringLength(50)]
    public string ArcustomerCmnd { get; set; }

    [Column("ARCustomerDeliveryContactName")]
    [StringLength(256)]
    public string ArcustomerDeliveryContactName { get; set; }

    [Column("ARCustomerSex")]
    [StringLength(256)]
    [Unicode(false)]
    public string ArcustomerSex { get; set; }

    [Column("ARCustomerStatus")]
    [StringLength(256)]
    [Unicode(false)]
    public string ArcustomerStatus { get; set; }

    [Column("FK_ACAccountSaleID")]
    public int? FkAcaccountSaleId { get; set; }

    [Column("FK_ACAccountPurchaseID")]
    public int? FkAcaccountPurchaseId { get; set; }

    [Column("FK_ACAccountDepositID")]
    public int? FkAcaccountDepositId { get; set; }

    [Column("ARCustomerPaymentAddressWard")]
    [StringLength(256)]
    public string ArcustomerPaymentAddressWard { get; set; }

    [Column("FK_GEDeliveryDistrictID")]
    public int? FkGedeliveryDistrictId { get; set; }

    [Column("FK_GEDeliveryStateProvinceID")]
    public int? FkGedeliveryStateProvinceId { get; set; }

    [Column("FK_GEDeliveryWardID")]
    public int? FkGedeliveryWardId { get; set; }

    [Column("FK_GEDeliveryStreetID")]
    public int? FkGedeliveryStreetId { get; set; }

    [Column("ARCustomerDeliveryHomeNumber")]
    [StringLength(128)]
    public string ArcustomerDeliveryHomeNumber { get; set; }

    [Column("FK_GEDeliveryCountryID")]
    public int? FkGedeliveryCountryId { get; set; }

    [Column("FK_ARCustomerTypeAccountConfigID")]
    public int FkArcustomerTypeAccountConfigId { get; set; }

    [Column("FK_ARCustomerResourceID")]
    public int? FkArcustomerResourceId { get; set; }

    [Column("ARCustomerAssignedTo")]
    [StringLength(2000)]
    public string ArcustomerAssignedTo { get; set; }

    [Column("ARCustomerBonusScore")]
    public int? ArcustomerBonusScore { get; set; }

    [Column("ARCustomerBusiness")]
    [StringLength(2000)]
    public string ArcustomerBusiness { get; set; }

    [Column("ARCustomerChangedUser")]
    [StringLength(50)]
    public string ArcustomerChangedUser { get; set; }

    [Column("ARCustomerClassify")]
    [StringLength(2000)]
    public string ArcustomerClassify { get; set; }

    [Column("ARCustomerCompanyEstablishmentDay", TypeName = "datetime")]
    public DateTime? ArcustomerCompanyEstablishmentDay { get; set; }

    [Column("CreatedUserID")]
    public int? CreatedUserId { get; set; }

    [Column("ARCustomerGroupCombo")]
    [StringLength(255)]
    [Unicode(false)]
    public string ArcustomerGroupCombo { get; set; }

    [Column("ARCustomerContactAddressDistrict")]
    [StringLength(2000)]
    public string ArcustomerContactAddressDistrict { get; set; }

    [Column("FK_HRGroupID")]
    public int? FkHrgroupId { get; set; }

    [Column("FK_HREmployeeID")]
    public int? FkHremployeeId { get; set; }

    [Column("ARCustomerEvaluate")]
    public int? ArcustomerEvaluate { get; set; }

    [Column("ARGender")]
    [StringLength(255)]
    [Unicode(false)]
    public string Argender { get; set; }

    [Column("ARCustomerGroup")]
    [StringLength(500)]
    public string ArcustomerGroup { get; set; }

    [Column("REV")]
    public int? Rev { get; set; }

    [Column("REVTYPE")]
    public int? Revtype { get; set; }

    [Column("ARCustomerRevenueDueYear", TypeName = "decimal(18, 5)")]
    public decimal? ArcustomerRevenueDueYear { get; set; }

    [Column("ARCustomerStockCode")]
    [StringLength(500)]
    [Unicode(false)]
    public string ArcustomerStockCode { get; set; }

    [Column("UpdatedUserID")]
    public int? UpdatedUserId { get; set; }

    [Column("FK_ARProspectCustomerID")]
    public int? FkArprospectCustomerId { get; set; }

    [Column("FK_ADFengShuisColorID")]
    public int? FkAdfengShuisColorId { get; set; }

    [Column("FK_ADFengShuisGenaralID")]
    public int? FkAdfengShuisGenaralId { get; set; }

    [Column("FK_ADFengShuisDirectionID")]
    public int? FkAdfengShuisDirectionId { get; set; }

    [Column("ARCustomerLunarBirthday")]
    [StringLength(50)]
    public string ArcustomerLunarBirthday { get; set; }

    [Column("ARCustomerCRMType")]
    [StringLength(50)]
    public string ArcustomerCrmtype { get; set; }

    [Column("FK_ADUserGroupID")]
    public int? FkAduserGroupId { get; set; }

    [Column("ARCustomerAvailableCredit", TypeName = "decimal(18, 5)")]
    public decimal? ArcustomerAvailableCredit { get; set; }

    [Column("ARCustomerInvoiceContactName")]
    [StringLength(256)]
    public string ArcustomerInvoiceContactName { get; set; }

    [Column("ARCustomerPaymentContactName")]
    [StringLength(256)]
    public string ArcustomerPaymentContactName { get; set; }

    [Column("ARCustomerDeliveryAddressEmail")]
    [StringLength(50)]
    public string ArcustomerDeliveryAddressEmail { get; set; }

    [Column("ARCustomerPaymentAddressEmail")]
    [StringLength(50)]
    public string ArcustomerPaymentAddressEmail { get; set; }

    [Column("FK_HREmployeeManagementID")]
    public int? FkHremployeeManagementId { get; set; }

    [Column("FK_ARCustomerBusinessTypeID")]
    public int? FkArcustomerBusinessTypeId { get; set; }

    [Column("ARCustomerInvoiceAddressEmail")]
    [StringLength(50)]
    public string ArcustomerInvoiceAddressEmail { get; set; }
}
