using BYS.Mobile.API.Data.Contexts;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.Repositories.Abtractions;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Data.Repositories.Implements;

public class BrbranchRepository : RepositoryBase<Brbranch, int>, IBrbranchRepository
{
    public BrbranchRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}