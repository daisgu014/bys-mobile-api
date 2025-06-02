namespace BYS.Mobile.API.API.Extensions
{
    public static class WebApplicationBuilderExtension
    {
        public static string SetConfigurationPath(this WebApplicationBuilder builder)
        {
            var basePath = Environment.GetEnvironmentVariable("BASE_PATH");
#if DEBUG
            if (string.IsNullOrWhiteSpace(basePath))
            {
                basePath = Directory.GetCurrentDirectory();
            }
#endif
            var appSetting = Environment.GetEnvironmentVariable("APP_SETTING");
#if DEBUG
            if (string.IsNullOrWhiteSpace(appSetting))
            {
                appSetting = "appsettings.json";
            }
#endif
            var settingPath = string.IsNullOrWhiteSpace(basePath)
                ? appSetting : Path.Combine(basePath, appSetting);
            builder.Configuration.SetBasePath(basePath)
                .AddJsonFile(settingPath, true, true);
            return settingPath;
        }
    }
}
