using BYS.Mobile.API.Data.Repositories.Abtractions;
using BYS.Mobile.API.Data.Repositories.Implements;
using BYS.Mobile.API.Data.UnitOfWorks;
using BYS.Mobile.API.Shared.Providers.Abstractions;
using BYS.Mobile.API.Shared.Providers.Implements;
using Microsoft.Extensions.DependencyInjection;

namespace BYS.Mobile.API.Data
{
    public static class BootstrapperExtension
    {
        public static void RegisterRepositoryDependencies(this IServiceCollection services)
        {
            services.AddScoped<IIdentityProvider, IdentityProvider>();
            services.AddScoped<ICoreProvider, CoreProvider>();
            services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();
            services.AddScoped<IArcustomerRepository, ArcustomerRepository>();
            services.AddScoped<IIcproductRepository, IcproductRepository>();
            services.AddScoped<IArproposalRepository, ArproposalRepository>();
            services.AddScoped<IArpriceSheetRepository, ArpriceSheetRepository>();
            services.AddScoped<IAduserRepository, AduserRepository>();
            services.AddScoped<IGenumberingRepository, GenumberingRepository>();
        }
    }
}
