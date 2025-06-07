namespace BYS.Mobile.API.Shared.Request.Proposal;

public class ProposalRequest
{
    public int customerId { get; set; }
    public List<int> productIds { get; set; }
}