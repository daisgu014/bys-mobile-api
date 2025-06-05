using BYS.Mobile.API.Shared.Models;
using BYS.Mobile.API.Shared.Models.Commons.Responses;
using BYS.Mobile.API.Shared.Request.Customer;
using BYS.Mobile.API.Shared.Response;

namespace BYS.Mobile.API.Business.Abstractions
{
    public interface IArcustomerBusiness : IBusiness
    {
        Task<List<CustomerResponse>> GetAllCustomers(string query);
        Task<PagedResult<CustomerResponse>> GetAllCustomersPaging(BaseGetAllRequest request);
        Task<CustomerResponse> Create(CustomerRequest request);
    }
}
