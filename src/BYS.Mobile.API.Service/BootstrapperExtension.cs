using BYS.Mobile.API.Service.Abtractions;
using BYS.Mobile.API.Service.Implements;
using Microsoft.Extensions.DependencyInjection;

namespace BYS.Mobile.API.Service
{
    public static class BootstrapperExtension
    {
        public static void RegisterServiceDependencies(this IServiceCollection services)
        {
           services.AddScoped<IArcustomerService, ArcustomerService>();
           services.AddScoped<IArproposalService, ArproposalService>();
           services.AddScoped<IIcproductService, IcproductService>();
           services.AddScoped<IAduserService, AduserService>();
           services.AddScoped<IGenumberingService, GenumberingService>();
           services.AddScoped<IAdConfigValueService, AdConfigValueService>();
           services.AddScoped<IArcustomerTypeAccountConfigService, ArcustomerTypeAccountConfigService>();
        }
    }
}
