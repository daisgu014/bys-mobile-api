using BYS.Mobile.API.Shared.Extensions;
using BYS.Mobile.API.Shared.Models;
using BYS.Mobile.API.Shared.Policies;
using AutoMapper;
using BYS.Mobile.API.Shared.Providers.Abstractions;
using BYS.Mobile.API.Shared.Settings;
using Serilog;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BYS.Mobile.API.Shared.Providers.Implements
{
    public class CoreProvider : ICoreProvider
    {
        public IMapper Mapper { get; set; }
        public IIdentityProvider IdentityProvider { get; set; }
        public BysMobileAPISetting Setting { get; set; }
#if !DEBUG
        public ILogger Logger { get; set; }
#endif

        public CoreProvider(IMapper mapper,
            IIdentityProvider identityProvider,
#if !DEBUG
            ILogger logger,
#endif
            BysMobileAPISetting setting)
        {
            Mapper = mapper;
            IdentityProvider = identityProvider;
            Setting = setting;
#if !DEBUG
            Logger = logger;
#endif
        }

        public virtual IEnumerable<IDataPolicy> CreatePolicies<T, TKey>()
        {
            var entityType = typeof(T);
            var keyType = typeof(TKey);
            var policies = new List<IDataPolicy>();

            if (typeof(IBaseActionEntity<TKey>).IsAssignableFrom(entityType))
            {
                policies.Add(Activator.CreateInstance(typeof(BaseActionEntityPolicy<,>).MakeGenericType(entityType, keyType)) as IDataPolicy);
            }

            if (typeof(IIdentity<string>).IsAssignableFrom(entityType))
            {
                policies.Add(Activator.CreateInstance(typeof(StringIdentityPolicy<>).MakeGenericType(entityType)) as IDataPolicy);
            }

            if (typeof(IBaseEntity<TKey>).IsAssignableFrom(entityType))
            {
                policies.Add(Activator.CreateInstance(typeof(BaseEntityPolicy<,>).MakeGenericType(entityType, keyType)) as IDataPolicy);
            }

            return policies;
        }
        public void LogInformation(string message, object data = null, [CallerMemberName] string methodName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            var logInfo = new List<string>()
            {
                $"file: {Path.GetFileNameWithoutExtension(filePath)}",
                $"method: {methodName}",
                $"line: {lineNumber}",
                $"message: {message}"
            };

            if (data is not null)
            {
#if !DEBUG
                logInfo.Add("data: {data}");
#else
                logInfo.Add($"data: {data.TrySerializeObject()}");
#endif
            }

            var logMessage = string.Join(", ", logInfo);
#if !DEBUG
            Logger.Information(logMessage, data?.TrySerializeObject());
#else
            Debug.WriteLine(logMessage);
#endif
        }
    }
}
