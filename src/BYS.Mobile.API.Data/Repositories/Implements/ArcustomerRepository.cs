using BYS.Mobile.API.Data.Contexts;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.Repositories.Abtractions;

namespace BYS.Mobile.API.Data.Repositories.Implements
{
    public class ArcustomerRepository : RepositoryBase<Arcustomer, int>, IArcustomerRepository
    {
        public ArcustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
