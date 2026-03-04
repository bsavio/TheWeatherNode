using Autofac;
using Serilog;
using TheWeatherNode.Core.Config;
using TheWeatherNode.Core.Interfaces;
using TheWeatherNode.WeatherService.OpenMeteo.Client;
using TheWeatherNode.WeatherService.OpenMeteo.Client.Interfaces;
using TheWeatherNode.WeatherService.OpenMeteo.Client.Settings;
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
            builder.RegisterType<OpenMeteoWeatherClient>()
                .As<IOpenMeteoWeatherClient>()
                .WithParameter(SettingsParam, _appSettingsProvider.GetAppSetting<OpenMeteoWeatherClientSettings>())
                .InstancePerLifetimeScope();
            builder.RegisterType<OpenMeteoWeatherService>()
                .As<IWeatherService>()
                .InstancePerLifetimeScope();
            #endregion

            #region Geocoding Services
            builder.RegisterType<OpenMeteoGeocodingClient>()
                .As<IOpenMeteoGeocodingClient>()
                .WithParameter(SettingsParam, _appSettingsProvider.GetAppSetting<OpenMeteoGeocodingClientSettings>())
                .InstancePerLifetimeScope();
            builder.RegisterType<OpenMeteoGeocodingService>()
                .As<IGeocodingService>()
                .InstancePerLifetimeScope();
            #endregion
            Log.Information("TheWeatherNodeModule loaded successfully.");
        }

    }
}
