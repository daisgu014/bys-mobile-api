using BYS.Mobile.API.Data.Contexts;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.Repositories.Abtractions;

namespace BYS.Mobile.API.Data.Repositories.Implements;

public class IcproductRepository : RepositoryBase<Icproduct,int>, IIcproductRepository
{
    public IcproductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}