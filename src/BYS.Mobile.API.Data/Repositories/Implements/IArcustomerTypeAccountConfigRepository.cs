using BYS.Mobile.API.Data.Contexts;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.Repositories.Abtractions;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Data.Repositories.Implements;

public class ArcustomerTypeAccountConfigRepository : RepositoryBase<ArcustomerTypeAccountConfig, int>, IArcustomerTypeAccountConfigRepository
{
    public ArcustomerTypeAccountConfigRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}