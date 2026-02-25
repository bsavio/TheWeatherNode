using Microsoft.Extensions.Configuration;

namespace TheWeatherNode.Core.Config
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        private readonly IConfigurationRoot _config;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AppSettingsProvider" /> class.
        /// </summary>
        public AppSettingsProvider()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();
        }

        public AppSettingsProvider(Stream appSettingsStream)
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonStream(appSettingsStream)
                .Build();
        }

        /// <summary>
        ///     Gets the application setting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetAppSetting<T>()
        {
            var appSetting = typeof(T).Name;
            return GetAppSetting<T>(appSetting);
        }

        /// <summary>
        ///     Gets the application setting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="appSetting">The application setting.</param>
        /// <returns></returns>
        public T GetAppSetting<T>(string appSetting)
        {
            var appSettingT = _config.GetSection(appSetting).Get<T>();
            if (appSettingT == null)
            {
                throw new InvalidOperationException(
                    $"App setting of type {typeof(T).FullName} not found in configuration.");
            }
            return appSettingT;
        }

        /// <summary>
        ///     Gets the configuration section.
        /// </summary>
        /// <param name="appSetting">The application setting.</param>
        /// <returns></returns>
        public IConfigurationSection GetConfigSection(string appSetting)
        {
            return _config.GetSection(appSetting);
        }

        /// <summary>
        ///     Gets the environment.
        /// </summary>
        /// <returns></returns>
        public string GetEnvironment()
        {
            return Environment.GetEnvironmentVariable("env") ?? "local";
        }
    }
}
