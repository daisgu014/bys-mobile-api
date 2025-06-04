using BYS.Mobile.API.Data.Contexts;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.Repositories.Abtractions;

namespace BYS.Mobile.API.Data.Repositories.Implements;

public class ArproposalRepository : RepositoryBase<Arproposal, int>, IArproposalRepository
{
    public ArproposalRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}