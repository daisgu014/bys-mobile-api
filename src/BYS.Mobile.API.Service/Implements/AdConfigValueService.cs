using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.Repositories.Abtractions;
using BYS.Mobile.API.Service.Abtractions;
using BYS.Mobile.API.Shared.Providers.Abstractions;

namespace BYS.Mobile.API.Service.Implements;

public class AdConfigValueService : ServiceBase<AdconfigValue, int>, IAdConfigValueService
{
    public AdConfigValueService(IAdConfigValueRepository repository, ICoreProvider coreProvider) : base(repository, coreProvider)
    {
    }
}