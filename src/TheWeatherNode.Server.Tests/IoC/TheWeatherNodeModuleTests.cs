using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheWeatherNode.Core.Interfaces;
using TheWeatherNode.Server.IoC;
using TheWeatherNode.WeatherService.OpenMeteo.Clients;
using TheWeatherNode.WeatherService.OpenMeteo.Clients.Interfaces;

namespace TheWeatherNode.Server.Tests.IoC
{
    public class TheWeatherNodeModuleTests
    {
        private ContainerBuilder SetupContainerBuilder()
        {
            var builder = new ContainerBuilder();
            
            // Register IServiceCollection for ASP.NET Core services
            var services = new ServiceCollection();
            
            // Register typed HttpClients the same way Program.cs does
            services.AddHttpClient<OpenMeteoWeatherClient>();
            services.AddHttpClient<OpenMeteoGeocodingClient>();
            
            // Build the service provider for ASP.NET Core services
            var serviceProvider = services.BuildServiceProvider();
            
            // Populate Autofac with ASP.NET Core services
            builder.Populate(services);
            
            return builder;
        }

        [Fact]
        public void TheWeatherNodeModule_ShouldRegisterWeatherService()
        {
            // Arrange
            var builder = SetupContainerBuilder();
            var module = new TheWeatherNodeModule();

            // Act
            builder.RegisterModule(module);
            var container = builder.Build();

            // Assert
            Assert.True(container.IsRegistered<IWeatherService>());
        }

        [Fact]
        public void TheWeatherNodeModule_ShouldRegisterGeocodingService()
        {
            // Arrange
            var builder = SetupContainerBuilder();
            var module = new TheWeatherNodeModule();

            // Act
            builder.RegisterModule(module);
            var container = builder.Build();

            // Assert
            Assert.True(container.IsRegistered<IGeocodingService>());
        }

        [Fact]
        public void TheWeatherNodeModule_ShouldRegisterOpenMeteoWeatherClient()
        {
            // Arrange
            var builder = SetupContainerBuilder();
            var module = new TheWeatherNodeModule();

            // Act
            builder.RegisterModule(module);
            var container = builder.Build();

            // Assert
            Assert.True(container.IsRegistered<IOpenMeteoWeatherClient>());
        }

        [Fact]
        public void TheWeatherNodeModule_ShouldRegisterOpenMeteoGeocodingClient()
        {
            // Arrange
            var builder = SetupContainerBuilder();
            var module = new TheWeatherNodeModule();

            // Act
            builder.RegisterModule(module);
            var container = builder.Build();

            // Assert
            Assert.True(container.IsRegistered<IOpenMeteoGeocodingClient>());
        }

        [Fact]
        public void TheWeatherNodeModule_ShouldResolveWeatherService()
        {
            // Arrange
            var builder = SetupContainerBuilder();
            var module = new TheWeatherNodeModule();

            // Act
            builder.RegisterModule(module);
            var container = builder.Build();
            var weatherService = container.Resolve<IWeatherService>();

            // Assert
            Assert.NotNull(weatherService);
        }

        [Fact]
        public void TheWeatherNodeModule_ShouldResolveGeocodingService()
        {
            // Arrange
            var builder = SetupContainerBuilder();
            var module = new TheWeatherNodeModule();

            // Act
            builder.RegisterModule(module);
            var container = builder.Build();
            var geocodingService = container.Resolve<IGeocodingService>();

            // Assert
            Assert.NotNull(geocodingService);
        }

        [Fact]
        public void TheWeatherNodeModule_ShouldResolveOpenMeteoWeatherClient()
        {
            // Arrange
            var builder = SetupContainerBuilder();
            var module = new TheWeatherNodeModule();

            // Act
            builder.RegisterModule(module);
            var container = builder.Build();
            var weatherClient = container.Resolve<IOpenMeteoWeatherClient>();

            // Assert
            Assert.NotNull(weatherClient);
        }

        [Fact]
        public void TheWeatherNodeModule_ShouldResolveOpenMeteoGeocodingClient()
        {
            // Arrange
            var builder = SetupContainerBuilder();
            var module = new TheWeatherNodeModule();

            // Act
            builder.RegisterModule(module);
            var container = builder.Build();
            var geocodingClient = container.Resolve<IOpenMeteoGeocodingClient>();

            // Assert
            Assert.NotNull(geocodingClient);
        }

        [Fact]
        public void TheWeatherNodeModule_WeatherServiceShouldBeInstancePerLifetimeScope()
        {
            // Arrange
            var builder = SetupContainerBuilder();
            var module = new TheWeatherNodeModule();

            // Act
            builder.RegisterModule(module);
            var container = builder.Build();
            var service1 = container.Resolve<IWeatherService>();
            var service2 = container.Resolve<IWeatherService>();

            // Assert
            Assert.NotNull(service1);
            Assert.NotNull(service2);
            Assert.Same(service1, service2);
        }

        [Fact]
        public void TheWeatherNodeModule_GeocodingServiceShouldBeInstancePerLifetimeScope()
        {
            // Arrange
            var builder = SetupContainerBuilder();
            var module = new TheWeatherNodeModule();

            // Act
            builder.RegisterModule(module);
            var container = builder.Build();
            var service1 = container.Resolve<IGeocodingService>();
            var service2 = container.Resolve<IGeocodingService>();

            // Assert
            Assert.NotNull(service1);
            Assert.NotNull(service2);
            Assert.Same(service1, service2);
        }

        [Fact]
        public void TheWeatherNodeModule_ShouldRegisterLoggerFactory()
        {
            // Arrange
            var builder = SetupContainerBuilder();
            var module = new TheWeatherNodeModule();

            // Act
            builder.RegisterModule(module);
            var container = builder.Build();

            // Assert
            var logger = container.Resolve<ILogger<TheWeatherNodeModuleTests>>();
            Assert.NotNull(logger);
        }

        [Fact]
        public void TheWeatherNodeModule_CanResolveMultipleLoggerInstances()
        {
            // Arrange
            var builder = SetupContainerBuilder();
            var module = new TheWeatherNodeModule();

            // Act
            builder.RegisterModule(module);
            var container = builder.Build();
            var logger1 = container.Resolve<ILogger<TheWeatherNodeModuleTests>>();
            var logger2 = container.Resolve<ILogger<string>>();

            // Assert
            Assert.NotNull(logger1);
            Assert.NotNull(logger2);
        }
    }
}