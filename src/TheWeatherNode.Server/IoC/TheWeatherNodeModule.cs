using Autofac;
using Autofac.Core;
using Microsoft.Extensions.Logging;
using Serilog;
using TheWeatherNode.Core.Config;
using TheWeatherNode.Core.Interfaces;
using TheWeatherNode.WeatherService.OpenMeteo.Clients;
using TheWeatherNode.WeatherService.OpenMeteo.Clients.Interfaces;
using TheWeatherNode.WeatherService.OpenMeteo.Clients.Settings;
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
            // The ILoggerFactory comes from the service provider (ASP.NET Core or tests)
            // Register generic ILogger<T> - resolves from the already-registered ILoggerFactory
            builder.RegisterGeneric(typeof(Logger<>))
                   .As(typeof(ILogger<>))
                   .InstancePerLifetimeScope();
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

            base.Load(builder);
            Log.Information("TheWeatherNodeModule loaded successfully.");
        }
    }
}
