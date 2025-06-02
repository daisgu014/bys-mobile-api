using BYS.Mobile.API.Business.Abstractions;
using BYS.Mobile.API.Data.UnitOfWorks;
using BYS.Mobile.API.Shared.Providers.Abstractions;
using BYS.Mobile.API.Shared.Settings;
using AutoMapper;

namespace BYS.Mobile.API.Business.Implements
{
    public abstract class BusinessBase : IBusiness
    {
        protected readonly IUnitOfWorkService _unitOfWorkService;
        protected readonly ICoreProvider _coreProvider;
        protected readonly BysMobileAPISetting _setting;
        protected readonly IMapper _mapper;

        protected BusinessBase(ICoreProvider coreProvider, IUnitOfWorkService unitOfWorkService)
        {
            _coreProvider = coreProvider;
            _unitOfWorkService = unitOfWorkService;
            _mapper = coreProvider.Mapper;
            _setting = coreProvider.Setting;
        }
    }
}
