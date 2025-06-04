using BYS.Mobile.API.Share.Request;
using BYS.Mobile.API.Shared.Dtos.Pagination;
using BYS.Mobile.API.Shared.Response;

namespace BYS.Mobile.API.Business.Abstractions;

public interface IIcproductBusiness : IBusiness
{
    Task<List<ProductResponse>> GetAll(string search);
    Task<PagedResult<ProductResponse>> GetAllPaged(BaseGetAllRequest request);
}