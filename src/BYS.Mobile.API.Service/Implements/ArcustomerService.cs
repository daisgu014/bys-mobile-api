using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.Repositories.Abtractions;
using BYS.Mobile.API.Service.Abtractions;
using BYS.Mobile.API.Shared.Providers.Abstractions;

namespace BYS.Mobile.API.Service.Implements
{
    public class ArcustomerService : ServiceBase<Arcustomer, int>, IArcustomerService
    {
        public ArcustomerService(IArcustomerRepository repository, ICoreProvider coreProvider) : base(repository, coreProvider)
        {
        }
    }
}
