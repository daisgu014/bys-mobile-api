using BYS.Mobile.API.Data.Contexts;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.Repositories.Abtractions;

namespace BYS.Mobile.API.Data.Repositories.Implements;

public class ArpriceSheetRepository : RepositoryBase<ArpriceSheet, int>, IArpriceSheetRepository
{
    public ArpriceSheetRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}