using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.Repositories.Abtractions;
using BYS.Mobile.API.Service.Abtractions;
using BYS.Mobile.API.Shared.Providers.Abstractions;

namespace BYS.Mobile.API.Service.Implements;

public class GenumberingService : ServiceBase<Genumbering, int>, IGenumberingService
{
    public GenumberingService(IGenumberingRepository repository, ICoreProvider coreProvider) : base(repository, coreProvider)
    {
    }
}