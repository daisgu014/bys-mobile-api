using BYS.Mobile.API.Business.Abstractions;
using BYS.Mobile.API.Shared.Models.Commons.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BYS.Mobile.API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase<IArcustomerBusiness>
    {
        public CustomerController(IArcustomerBusiness business) : base(business)
        {
        }
        [HttpGet]
        [ProducesResponseType(typeof(ActionResponse<PagedResult<string>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailActionResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] string search)
        {
            return this.CreateOkForResponse("Hello");
        }
    }
}
