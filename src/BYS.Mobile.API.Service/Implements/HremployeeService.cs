using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.Repositories.Abtractions;
using BYS.Mobile.API.Service.Abtractions;
using BYS.Mobile.API.Shared.Providers.Abstractions;

namespace BYS.Mobile.API.Service.Implements;

public class HremployeeService : ServiceBase<Hremployee, int>, IHremployeeService
{
    public HremployeeService(IHremployeeRepository repository, ICoreProvider coreProvider) : base(repository, coreProvider)
    {
    }
}