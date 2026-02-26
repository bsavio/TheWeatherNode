using Autofac;
using Serilog;
using TheWeatherNode.Core.Config;
using TheWeatherNode.Core.Interfaces;
using TheWeatherNode.WeatherService.OpenMeteo.Client;
using TheWeatherNode.WeatherService.OpenMeteo.Services;
using Module = Autofac.Module;

namespace TheWeatherNode.Server.IoC
{
    public class TheWeatherNodeModule : Module
    {
        private const string SettingsParam = "settings";

        private readonly AppSettingsProvider _appSettingsProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="TheWeatherNodeModule"/> class.
        /// </summary>
        public TheWeatherNodeModule()
        {
            _appSettingsProvider = new AppSettingsProvider();

        }

        protected override void Load(ContainerBuilder builder)
        {
            #region Common Services
            // Register Microsoft ILogger factory so ILogger<T> works too
            builder.RegisterGeneric(typeof(Logger<>))
                   .As(typeof(ILogger<>))
                   .SingleInstance();
            #endregion

            #region Weather Services
            builder.RegisterType<OpenMeteoClient>()
                .As<IOpenMeteoClient>()
                .WithParameter(SettingsParam, _appSettingsProvider.GetAppSetting<OpenMeteoClientSettings>())
                .InstancePerLifetimeScope();
            builder.RegisterType<OpenMeteoWeatherService>()
                .As<IWeatherService>()
                .InstancePerLifetimeScope();
            #endregion
            Log.Information("TheWeatherNodeModule loaded successfully.");
        }

    }
}
