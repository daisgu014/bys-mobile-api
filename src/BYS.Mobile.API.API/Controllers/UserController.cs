using System.Net;
using BYS.Mobile.API.Business.Abstractions;
using BYS.Mobile.API.Shared.Models.Commons.Responses;
using BYS.Mobile.API.Shared.Request;
using BYS.Mobile.API.Shared.Response;
using Microsoft.AspNetCore.Mvc;

namespace BYS.Mobile.API.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase<IAduserBusiness>
{
    public UserController(IAduserBusiness business) : base(business)
    {
    }
    [HttpPost("login")]
    [ProducesResponseType(typeof(ActionResponse<LoginResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(FailActionResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        return CreateOkForResponse(await _business.LoginAsync(request));
    }

}