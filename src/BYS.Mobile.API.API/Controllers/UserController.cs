using BYS.Mobile.API.Business.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BYS.Mobile.API.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase<IAduserBusiness>
{
    public UserController(IAduserBusiness business) : base(business)
    {
    }
}