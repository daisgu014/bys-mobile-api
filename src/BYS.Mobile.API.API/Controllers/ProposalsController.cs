using System.Net;
using BYS.Mobile.API.Business.Abstractions;
using BYS.Mobile.API.Shared.Models.Commons.Responses;
using BYS.Mobile.API.Shared.Request;
using BYS.Mobile.API.Shared.Request.Proposal;
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
    [HttpPost]
    [ProducesResponseType(typeof(ActionResponse<bool>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(FailActionResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromBody] ProposalRequest request)
    {
        return CreateOkForResponse(await _business.Create(request));
    }
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ActionResponse<ArproposalResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(FailActionResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetDetails(int id)
    {
        return CreateOkForResponse(await _business.GetDetailsById(id));
    }
} 