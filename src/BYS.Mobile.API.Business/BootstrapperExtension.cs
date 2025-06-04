using BYS.Mobile.API.Business.Abstractions;
using BYS.Mobile.API.Business.Implements;
using Microsoft.Extensions.DependencyInjection;

namespace BYS.Mobile.API.Business
{
    public static class BootstrapperExtension
    {
        public static void RegisterBusinessDependencies(this IServiceCollection services)
        {
            services.AddScoped<IArcustomerBusiness, ArcustomerBusiness>();
            services.AddScoped<IIcproductBusiness, IcproductBusiness>();
        }
    }
}
