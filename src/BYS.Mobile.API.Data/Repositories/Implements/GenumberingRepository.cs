using BYS.Mobile.API.Data.Contexts;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.Repositories.Abtractions;

namespace BYS.Mobile.API.Data.Repositories.Implements;

public class GenumberingRepository : RepositoryBase<Genumbering, int>, IGenumberingRepository
{
    public GenumberingRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}