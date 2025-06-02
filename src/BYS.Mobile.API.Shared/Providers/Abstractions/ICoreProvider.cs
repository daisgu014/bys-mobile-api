using BYS.Mobile.API.Shared.Policies;
using BYS.Mobile.API.Shared.Settings;
using AutoMapper;
using Serilog;
using System.Runtime.CompilerServices;

namespace BYS.Mobile.API.Shared.Providers.Abstractions
{
    public interface ICoreProvider
    {
        IIdentityProvider IdentityProvider { get; set; }
        BysMobileAPISetting Setting { get; set; }
        IMapper Mapper { get; set; }
#if !DEBUG
        ILogger Logger { get; set; }
#endif

        IEnumerable<IDataPolicy> CreatePolicies<T, TKey>();
        void LogInformation(string message, object data = null, [CallerMemberName] string methodName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0);
    }
}
