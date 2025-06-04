using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Data.Repositories.Abtractions;
using BYS.Mobile.API.Service.Abtractions;
using BYS.Mobile.API.Shared.Providers.Abstractions;

namespace BYS.Mobile.API.Service.Implements;

public class ArproposalService : ServiceBase<Arproposal, int>, IArproposalService
{
    public ArproposalService(IArproposalRepository repository, ICoreProvider coreProvider) : base(repository, coreProvider)
    {
    }
}