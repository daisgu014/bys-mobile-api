using BYS.Mobile.API.Data.Contexts;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.Repositories.Abtractions;
using Microsoft.EntityFrameworkCore;

namespace BYS.Mobile.API.Data.Repositories.Implements;

public class HremployeeRepository : RepositoryBase<Hremployee, int>, IHremployeeRepository
{
    public HremployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}