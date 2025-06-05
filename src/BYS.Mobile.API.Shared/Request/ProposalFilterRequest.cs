using BYS.Mobile.API.Shared.Models;

namespace BYS.Mobile.API.Shared.Request;

public class ProposalFilterRequest : BaseGetAllRequest
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}