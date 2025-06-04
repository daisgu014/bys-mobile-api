using BYS.Mobile.API.Business.Abstractions;
using BYS.Mobile.API.Data.UnitOfWorks;
using BYS.Mobile.API.Shared.Providers.Abstractions;

namespace BYS.Mobile.API.Business.Implements;

public class IcproductBusiness : BusinessBase, IIcproductBusiness
{
    public IcproductBusiness(ICoreProvider coreProvider, IUnitOfWorkService unitOfWorkService) : base(coreProvider, unitOfWorkService)
    {
    }
}