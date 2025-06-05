using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Shared.Dtos.Pagination;
using BYS.Mobile.API.Shared.Request;
using BYS.Mobile.API.Shared.Response;

namespace BYS.Mobile.API.Business.Abstractions;

public interface IArproposalBusiness : IBusiness
{
    Task<List<ProposalResponse>> GetAll(ProposalFilterRequest request);
    Task<PagedResult<ProposalResponse>> GetAllPaging(ProposalFilterRequest request);
}