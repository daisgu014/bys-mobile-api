namespace BYS.Mobile.API.Shared.Response;

public class ProposalResponse
{
    public int ArproposalId { get; set; }
    public string ProposalNo { get; set; }
    public string CustomerName { get; set; }
    public string ContactInfo { get; set; }
    public DateTime ProposalDate { get; set; }
    public string Status { get; set; }
}