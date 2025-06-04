using BYS.Mobile.API.Business.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BYS.Mobile.API.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProposalsController : ControllerBase<IArproposalBusiness>
{

    public ProposalsController(IArproposalBusiness business) : base(business)
    {
    }
} 