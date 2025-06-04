using System.Net;
using BYS.Mobile.API.Business.Implements;
using BYS.Mobile.API.Shared.Models.Commons.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BYS.Mobile.API.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase<IcproductBusiness>
{
    public ProductsController(IcproductBusiness business) : base(business)
    {
    }
    [HttpGet]
    [ProducesResponseType(typeof(ActionResponse<List<string>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(FailActionResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll([FromQuery] string search)
    {
        return CreateOkForResponse("Hello");
    }
}