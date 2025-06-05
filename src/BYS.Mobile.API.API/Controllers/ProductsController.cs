using System.Net;
using BYS.Mobile.API.Business.Abstractions;
using BYS.Mobile.API.Business.Implements;
using BYS.Mobile.API.Shared.Models;
using BYS.Mobile.API.Shared.Models.Commons.Responses;
using BYS.Mobile.API.Shared.Response;
using Microsoft.AspNetCore.Mvc;

namespace BYS.Mobile.API.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase<IIcproductBusiness>
{
    public ProductsController(IIcproductBusiness business) : base(business)
    {
    }
    [HttpGet]
    [ProducesResponseType(typeof(ActionResponse<List<ProductResponse>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(FailActionResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll([FromQuery] string search)
    {
        return CreateOkForResponse(await _business.GetAll(search));
    }

    [HttpGet("paging")]
    [ProducesResponseType(typeof(ActionResponse<PagedResult<ProductResponse>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(FailActionResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAllPaging([FromQuery] BaseGetAllRequest request)
    {
        return CreateOkForResponse(await _business.GetAllPaged(request));
    }
}