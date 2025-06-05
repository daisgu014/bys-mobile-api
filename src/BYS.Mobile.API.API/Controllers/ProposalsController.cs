using System.Net;
using BYS.Mobile.API.Business.Abstractions;
using BYS.Mobile.API.Shared.Models.Commons.Responses;
using BYS.Mobile.API.Shared.Request;
using BYS.Mobile.API.Shared.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BYS.Mobile.API.API.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProposalsController : ControllerBase<IArproposalBusiness>
{

    public ProposalsController(IArproposalBusiness business) : base(business)
    {
    }
    [HttpGet]
    [ProducesResponseType(typeof(ActionResponse<List<ProposalResponse>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(FailActionResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll([FromQuery] ProposalFilterRequest request)
    {
        return CreateOkForResponse(await _business.GetAll(request));
    }

    [HttpGet("paging")]
    [ProducesResponseType(typeof(ActionResponse<PagedResult<ProposalResponse>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(FailActionResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAllPaging([FromQuery] ProposalFilterRequest request)
    {
        return CreateOkForResponse(await _business.GetAllPaging(request));
    }
} 