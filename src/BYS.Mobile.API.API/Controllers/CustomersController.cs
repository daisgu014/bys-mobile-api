using BYS.Mobile.API.Business.Abstractions;
using BYS.Mobile.API.Shared.Models.Commons.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using BYS.Mobile.API.Share.Request;
using BYS.Mobile.API.Shared.Request.Customer;
using BYS.Mobile.API.Shared.Response;

namespace BYS.Mobile.API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase<IArcustomerBusiness>
    {
        public CustomersController(IArcustomerBusiness business) : base(business)
        {
        }
        [HttpGet]
        [ProducesResponseType(typeof(ActionResponse<List<CustomerResponse>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailActionResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] string search)
        {
            return CreateOkForResponse(_business.GetAllCustomers(search));
        }

        [HttpGet("paging")]
        [ProducesResponseType(typeof(ActionResponse<PagedResult<CustomerResponse>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailActionResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllPaging([FromQuery] BaseGetAllRequest request)
        {
            return CreateOkForResponse(_business.GetAllCustomersPaging(request));
        }
        [HttpPost]
        [ProducesResponseType(typeof(ActionResponse<CustomerResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailActionResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CustomerRequest request)
        {
            return CreateOkForResponse(_business.Create(request));
        }

    }
}
