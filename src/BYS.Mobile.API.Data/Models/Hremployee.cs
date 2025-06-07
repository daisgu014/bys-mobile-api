using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BYS.Mobile.API.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Data.Models;

[Table("HREmployees")]
public partial class Hremployee : IIdentity<int>
{
    [Key]
    [Column("HREmployeeID")]
    public int HremployeeId { get; set; }
    [NotMapped]
    public int Id
    {
        get => HremployeeId;
        set => HremployeeId = value;
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

    public bool? IsTransferred { get; set; }

    [Column("AATransferredDate", TypeName = "datetime")]
    public DateTime? AatransferredDate { get; set; }

    [Column("FK_HRDepartmentID")]
    public int FkHrdepartmentId { get; set; }

    [Column("FK_HRDepartmentRoomID")]
    public int FkHrdepartmentRoomId { get; set; }

    [Column("FK_HRLevelID")]
    public int? FkHrlevelId { get; set; }

    [Column("FK_HRTimeSheetScaleID")]
    public int? FkHrtimeSheetScaleId { get; set; }

    [Column("FK_BRBranchID")]
    public int FkBrbranchId { get; set; }

    [Required]
    [Column("HREmployeeNo")]
    [StringLength(50)]
    public string HremployeeNo { get; set; }

    [Column("HREmployeeName")]
    [StringLength(200)]
    public string HremployeeName { get; set; }

    [Column("HREmployeeGenderCombo")]
    [StringLength(50)]
    public string HremployeeGenderCombo { get; set; }

    [Column("HREmployeeDob", TypeName = "datetime")]
    public DateTime? HremployeeDob { get; set; }

    [Column("HREmployeeBirthPlace")]
    [StringLength(200)]
    public string HremployeeBirthPlace { get; set; }

    [Column("HREmployeeTypeCombo")]
    [StringLength(50)]
    public string HremployeeTypeCombo { get; set; }

    [Column("HREmployeeStatusCombo")]
    [StringLength(50)]
    public string HremployeeStatusCombo { get; set; }

    [Column("HREmployeeDesc")]
    [StringLength(255)]
    public string HremployeeDesc { get; set; }

    [Column("HREmployeePicture")]
    public byte[] HremployeePicture { get; set; }

    [Column("HREmployeeIDNumber")]
    [StringLength(50)]
    public string HremployeeIdnumber { get; set; }

    [Column("HREmployeeIDCardPlace")]
    [StringLength(150)]
    public string HremployeeIdcardPlace { get; set; }

    [Column("HREmployeeIDCardDate", TypeName = "datetime")]
    public DateTime? HremployeeIdcardDate { get; set; }

    [Column("HREmployeeCardNumber")]
    [StringLength(50)]
    public string HremployeeCardNumber { get; set; }

    [Column("HREmployeePassportNo")]
    [StringLength(50)]
    public string HremployeePassportNo { get; set; }

    [Column("HREmployeePassportIssuedDate", TypeName = "datetime")]
    public DateTime? HremployeePassportIssuedDate { get; set; }

    [Column("HREmployeePassportIssuedPlace", TypeName = "datetime")]
    public DateTime? HremployeePassportIssuedPlace { get; set; }

    [Column("HREmployeeSlrPmtMthdCombo")]
    [StringLength(50)]
    public string HremployeeSlrPmtMthdCombo { get; set; }

    [Column("HREmployeeWorkingSlrAmt", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeWorkingSlrAmt { get; set; }

    [Column("HREmployeeContractSlrAmt", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeContractSlrAmt { get; set; }

    [Column("HREmployeeReligion")]
    [StringLength(50)]
    public string HremployeeReligion { get; set; }

    [Column("HREmployeeTaxNumber")]
    [StringLength(50)]
    [Unicode(false)]
    public string HremployeeTaxNumber { get; set; }

    [Column("HREmployeeActiveCheck")]
    public bool? HremployeeActiveCheck { get; set; }

    [Column("HREmployeeStartWorkingDate", TypeName = "datetime")]
    public DateTime? HremployeeStartWorkingDate { get; set; }

    [Column("HREmployeeEndWorkingDate", TypeName = "datetime")]
    public DateTime? HremployeeEndWorkingDate { get; set; }

    [Column("HREmployeeStartWorkingTime", TypeName = "datetime")]
    public DateTime? HremployeeStartWorkingTime { get; set; }

    [Column("HREmployeeEndWorkingTime", TypeName = "datetime")]
    public DateTime? HremployeeEndWorkingTime { get; set; }

    [Column("HREmployeeTel1")]
    [StringLength(50)]
    public string HremployeeTel1 { get; set; }

    [Column("HREmployeeTel2")]
    [StringLength(50)]
    public string HremployeeTel2 { get; set; }

    [Column("HREmployeeTel3")]
    [StringLength(50)]
    public string HremployeeTel3 { get; set; }

    [Column("HREmployeeEmail1")]
    [StringLength(50)]
    public string HremployeeEmail1 { get; set; }

    [Column("HREmployeePassword1")]
    [StringLength(50)]
    public string HremployeePassword1 { get; set; }

    [Column("HREmployeeEmail2")]
    [StringLength(50)]
    public string HremployeeEmail2 { get; set; }

    [Column("HREmployeeFax")]
    [StringLength(50)]
    public string HremployeeFax { get; set; }

    [Column("HREmployeeContactAddressStreet")]
    [StringLength(200)]
    public string HremployeeContactAddressStreet { get; set; }

    [Column("HREmployeeContactAddressLine1")]
    [StringLength(200)]
    public string HremployeeContactAddressLine1 { get; set; }

    [Column("HREmployeeContactAddressLine2")]
    [StringLength(200)]
    public string HremployeeContactAddressLine2 { get; set; }

    [Column("HREmployeeContactAddressLine3")]
    [StringLength(200)]
    public string HremployeeContactAddressLine3 { get; set; }

    [Column("HREmployeeContactAddressCity")]
    [StringLength(50)]
    public string HremployeeContactAddressCity { get; set; }

    [Column("HREmployeeContactAddressPostalCode")]
    [StringLength(50)]
    public string HremployeeContactAddressPostalCode { get; set; }

    [Column("HREmployeeContactAddressStateProvince")]
    [StringLength(50)]
    public string HremployeeContactAddressStateProvince { get; set; }

    [Column("HREmployeeContactAddressZipCode")]
    [StringLength(50)]
    public string HremployeeContactAddressZipCode { get; set; }

    [Column("HREmployeeContactAddressCountry")]
    [StringLength(50)]
    public string HremployeeContactAddressCountry { get; set; }

    [Column("HREmployeeBankCode")]
    [StringLength(50)]
    [Unicode(false)]
    public string HremployeeBankCode { get; set; }

    [Column("HREmployeeBankName")]
    [StringLength(50)]
    public string HremployeeBankName { get; set; }

    [Column("HREmployeeBankAccount1")]
    [StringLength(50)]
    [Unicode(false)]
    public string HremployeeBankAccount1 { get; set; }

    [Column("HREmployeeBankAccountCurrency1")]
    public int? HremployeeBankAccountCurrency1 { get; set; }

    [Column("HREmployeeBankAccount2")]
    [StringLength(50)]
    [Unicode(false)]
    public string HremployeeBankAccount2 { get; set; }

    [Column("HREmployeeBankAccountCurrency2")]
    public int? HremployeeBankAccountCurrency2 { get; set; }

    [Column("HREmployeeBankAccount3")]
    [StringLength(50)]
    [Unicode(false)]
    public string HremployeeBankAccount3 { get; set; }

    [Column("HREmployeeBankAccountCurrency3")]
    public int? HremployeeBankAccountCurrency3 { get; set; }

    [Column("HREmployeeBankAccount4")]
    [StringLength(50)]
    [Unicode(false)]
    public string HremployeeBankAccount4 { get; set; }

    [Column("HREmployeeBankAccountCurrency4")]
    public int? HremployeeBankAccountCurrency4 { get; set; }

    [Column("HRInsCalculatedSalaryType")]
    [StringLength(50)]
    [Unicode(false)]
    public string HrinsCalculatedSalaryType { get; set; }

    [Column("HREmployeeSocialInsNo")]
    [StringLength(50)]
    public string HremployeeSocialInsNo { get; set; }

    [Column("HREmployeeSocialInsRegisteredDate", TypeName = "datetime")]
    public DateTime? HremployeeSocialInsRegisteredDate { get; set; }

    [Column("HREmployeeSocialInsExpiryDate", TypeName = "datetime")]
    public DateTime? HremployeeSocialInsExpiryDate { get; set; }

    [Column("HREmployeeSocialInsPaymentPercent", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeSocialInsPaymentPercent { get; set; }

    [Column("HREmployeeHealthInsNo")]
    [StringLength(50)]
    public string HremployeeHealthInsNo { get; set; }

    [Column("HREmployeeHealthInsRegisteredPlace")]
    [StringLength(50)]
    public string HremployeeHealthInsRegisteredPlace { get; set; }

    [Column("HREmployeeHealthInsRegisteredDate", TypeName = "datetime")]
    public DateTime? HremployeeHealthInsRegisteredDate { get; set; }

    [Column("HREmployeeHealthInsExpiryDate", TypeName = "datetime")]
    public DateTime? HremployeeHealthInsExpiryDate { get; set; }

    [Column("HREmployeeHealthInsPaymentPercent", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeHealthInsPaymentPercent { get; set; }

    [Column("HREmployeeOutOfWorkInsPaymentPercent", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeOutOfWorkInsPaymentPercent { get; set; }

    [Column("HREmployeeSyndicatePaymentPercent", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeSyndicatePaymentPercent { get; set; }

    [Column("HREmployeeTaxPaymentPercent", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeTaxPaymentPercent { get; set; }

    [Column("HREmployeeSalaryFactor", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeSalaryFactor { get; set; }

    [Column("HREmployeeExtraSalary1", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeExtraSalary1 { get; set; }

    [Column("HREmployeeExtraSalary2", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeExtraSalary2 { get; set; }

    [Column("HREmployeeExtraSalary3", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeExtraSalary3 { get; set; }

    [Column("HREmployeeExtraSalary4", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeExtraSalary4 { get; set; }

    [Column("HRPayRollCalculatedSalaryType")]
    [StringLength(50)]
    [Unicode(false)]
    public string HrpayRollCalculatedSalaryType { get; set; }

    [Column("HREmployeeHoursPerDay", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeHoursPerDay { get; set; }

    [Column("HREmployeeDaysPerMonth", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeDaysPerMonth { get; set; }

    [Column("HREmployeeWorkingHourlySalary", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeWorkingHourlySalary { get; set; }

    [Column("HREmployeeWorkingDailySalary", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeWorkingDailySalary { get; set; }

    [Column("HREmployeeContractHourlySalary", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeContractHourlySalary { get; set; }

    [Column("HREmployeeContractDailySalary", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeContractDailySalary { get; set; }

    [Column("FK_HREmployeePayrollFormulaID")]
    public int FkHremployeePayrollFormulaId { get; set; }

    [Column("FK_GENativeStateProvinceID")]
    public int? FkGenativeStateProvinceId { get; set; }

    [Column("HREmployeeMaritalStatusCombo")]
    [StringLength(512)]
    public string HremployeeMaritalStatusCombo { get; set; }

    [Column("HREmployeeEducation")]
    [StringLength(512)]
    public string HremployeeEducation { get; set; }

    [Column("FK_GEIDCardStateProvinceID")]
    public int? FkGeidcardStateProvinceId { get; set; }

    [Column("FK_GENationalityID")]
    public int? FkGenationalityId { get; set; }

    [Column("FK_GEReligionID")]
    public int? FkGereligionId { get; set; }

    [Column("FK_GEStateProvinceIDBHXH")]
    public int? FkGestateProvinceIdbhxh { get; set; }

    [Column("HREmployeeWorkingMonths", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeWorkingMonths { get; set; }

    [Column("HREmployeeUniform")]
    public bool? HremployeeUniform { get; set; }

    [Column("HREmployeeDobString")]
    [StringLength(50)]
    public string HremployeeDobString { get; set; }

    [Column("HREmployeeProbationaryMonth")]
    public int? HremployeeProbationaryMonth { get; set; }

    [Column("HREmployeeStopWorkingDate", TypeName = "datetime")]
    public DateTime? HremployeeStopWorkingDate { get; set; }

    [Column("HREmployeeLeaveDays", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeLeaveDays { get; set; }

    [Column("HREmployeeSyndicatePaymentAmount", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeSyndicatePaymentAmount { get; set; }

    [Column("HREmployeeIsUnionMember")]
    public bool? HremployeeIsUnionMember { get; set; }

    [Column("HREmployeeUnionMemberFee", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeUnionMemberFee { get; set; }

    [Column("FK_HRDepartmentRoomGroupItemID")]
    public int? FkHrdepartmentRoomGroupItemId { get; set; }

    [Column("HREmployeeTrainingCourseID")]
    [StringLength(500)]
    public string HremployeeTrainingCourseId { get; set; }

    [Column("HREmployeeTrainingCourseValue")]
    [StringLength(500)]
    public string HremployeeTrainingCourseValue { get; set; }

    [Column("HREmployeeAnnualLeaveRemain")]
    public int? HremployeeAnnualLeaveRemain { get; set; }

    [Column("HREmployeePictureFileName")]
    [StringLength(1000)]
    public string HremployeePictureFileName { get; set; }

    [Column("FK_ACAccountDepositID")]
    public int? FkAcaccountDepositId { get; set; }

    [Column("FK_ACAccountPurchaseID")]
    public int? FkAcaccountPurchaseId { get; set; }

    [Column("FK_ACAccountSaleID")]
    public int? FkAcaccountSaleId { get; set; }

    [Column("FK_MMWorkShopID")]
    public int? FkMmworkShopId { get; set; }

    [Column("HREmployeeBonusSale", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeBonusSale { get; set; }

    [Column("HREmployeeHaveInsurrance")]
    public bool? HremployeeHaveInsurrance { get; set; }

    [Column("HREmployeeProbationaryDateTo", TypeName = "datetime")]
    public DateTime? HremployeeProbationaryDateTo { get; set; }

    [Column("HREmployeeProbationaryDateFrom", TypeName = "datetime")]
    public DateTime? HremployeeProbationaryDateFrom { get; set; }

    [Column("HREmployeeProbationarySalaryAmount", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeProbationarySalaryAmount { get; set; }

    [Column("FK_HRWorkingShiftID")]
    public int? FkHrworkingShiftId { get; set; }

    [Column("HREmployeePayRollCalculatedWorkType")]
    [StringLength(50)]
    public string HremployeePayRollCalculatedWorkType { get; set; }

    [Column("FK_HRConfigRankID")]
    public int? FkHrconfigRankId { get; set; }

    [Column("FK_HRConfigScaleID")]
    public int? FkHrconfigScaleId { get; set; }

    [Column("HREmployeeOutOfWorkIns", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeOutOfWorkIns { get; set; }

    [Column("HREmployeeSalarySocialInsurance", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeSalarySocialInsurance { get; set; }

    [Column("HREmployeePercentContractSlrAmt", TypeName = "decimal(18, 5)")]
    public decimal? HremployeePercentContractSlrAmt { get; set; }

    [Column("HREmployeeApprenticeDay", TypeName = "datetime")]
    public DateTime? HremployeeApprenticeDay { get; set; }

    [Column("HREmployeeIsAllowedLeave")]
    public bool? HremployeeIsAllowedLeave { get; set; }

    [Column("HREmployeeStartPauseDate", TypeName = "datetime")]
    public DateTime? HremployeeStartPauseDate { get; set; }

    [Column("HREmployeeAllowanceHouse", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeAllowanceHouse { get; set; }

    [Column("HREmployeeAllowancePhone", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeAllowancePhone { get; set; }

    [Column("FK_HRDepartmentRoomGroupTeamItemID")]
    public int? FkHrdepartmentRoomGroupTeamItemId { get; set; }

    [Column("FK_HRTimeSheetParamID")]
    public int? FkHrtimeSheetParamId { get; set; }

    [Column("HREmployeeEndPauseDate", TypeName = "datetime")]
    public DateTime? HremployeeEndPauseDate { get; set; }

    [Column("HREmployeeSkillCoefficient", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeSkillCoefficient { get; set; }

    [Column("HREmployeeJobPerformanceAmt", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeJobPerformanceAmt { get; set; }

    [Column("HREmployeeAllowanceGas", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeAllowanceGas { get; set; }

    [Column("HREmployeeHaveOutOfWorkIns")]
    public bool? HremployeeHaveOutOfWorkIns { get; set; }

    [Column("HREmployeeMeasureUnitType")]
    [StringLength(50)]
    public string HremployeeMeasureUnitType { get; set; }

    [Column("HREmployeeIsPieceWage")]
    public bool? HremployeeIsPieceWage { get; set; }

    [Column("HREmployeeProbationarySalaryPercent", TypeName = "decimal(18, 5)")]
    public decimal? HremployeeProbationarySalaryPercent { get; set; }

    [Column("FK_HRAllowanceManageConfigID")]
    public int? FkHrallowanceManageConfigId { get; set; }

    [Column("FK_GEStateProvinceBirthPlaceID")]
    public int? FkGestateProvinceBirthPlaceId { get; set; }

    [InverseProperty("FkHremployee")]
    public virtual ICollection<Aduser> Adusers { get; set; } = new List<Aduser>();
}
