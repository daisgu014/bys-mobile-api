using System.ComponentModel.DataAnnotations;

namespace BYS.Mobile.API.Shared.Request.Customer;

public class CustomerRequest
{
    [Required]
    public string ArcustomerName { get; set; }
    public string Address { get; set; }
    [Required]
    public string ArcustomerContactName { get; set; }
    [Required]
    public string ArcustomerContactPhone { get; set; }

    public string ArcustomerTypeCombo { get; set; }
}