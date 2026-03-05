using Moq;
using TheWeatherNode.Core.Models;
using TheWeatherNode.Core.Models.Requests;
using TheWeatherNode.Core.Models.Responses;
using TheWeatherNode.WeatherService.OpenMeteo.Clients.Interfaces;
using TheWeatherNode.WeatherService.OpenMeteo.DTOs;
using TheWeatherNode.WeatherService.OpenMeteo.Services;
using Microsoft.Extensions.Logging;

namespace TheWeatherNode.WeatherService.OpenMeteo.Tests.Services
{
    public class OpenMeteoWeatherServiceTests
    {
        private readonly Mock<IOpenMeteoWeatherClient> _mockWeatherClient;
        private readonly Mock<ILogger<OpenMeteoWeatherService>> _mockLogger;
        private readonly OpenMeteoWeatherService _service;

        public OpenMeteoWeatherServiceTests()
        {
            _mockWeatherClient = new Mock<IOpenMeteoWeatherClient>();
            _mockLogger = new Mock<ILogger<OpenMeteoWeatherService>>();
            _service = new OpenMeteoWeatherService(_mockWeatherClient.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetCurrentWeatherAsync_WithValidRequest_ShouldReturnCurrentWeather()
        {
            // Arrange
            var weatherRequest = new WeatherRequest
            {
                Latitude = 40.7128,
                Longitude = -74.0060,
                TemperatureUnit = TemperatureUnit.Fahrenheit,
                WindSpeedUnit = WindSpeedUnit.Mph,
                PrecipitationUnit = PrecipitationUnit.Inches
            };

            var mockResponse = new OpenMeteoForecastResponseDto
            {
                Current = new OpenMeteoCurrentDto
                {
                    Temperature = 68,
                    FeelsLike = 66,
                    DewPoint = 55,
                    Humidity = 65,
                    WindSpeed = 10,
                    WindDirection = 180,
                    WindGusts = 15,
                    Precipitation = 0,
                    Pressure = 1013,
                    Visibility = 10000,
                    UvIndex = 5,
                    CloudCover = 30,
                    WeatherCode = 0,
                    IsDay = 1,
                    Time = "2024-01-15T12:00"
                }
            };

            _mockWeatherClient
                .Setup(x => x.GetForcastAsync<OpenMeteoForecastResponseDto>(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync(mockResponse);

            // Act
            var result = await _service.GetCurrentWeatherAsync(weatherRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(68, result.Temperature);
            Assert.Equal(66, result.FeelsLike);
            Assert.Equal(65, result.Humidity);
            Assert.True(result.IsDay);
        }

        [Fact]
        public async Task GetCurrentWeatherAsync_WithNullRequest_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => 
                _service.GetCurrentWeatherAsync(null!));
        }

        [Fact]
        public async Task GetCurrentWeatherAsync_WhenClientReturnsNull_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var weatherRequest = new WeatherRequest
            {
                Latitude = 40.7128,
                Longitude = -74.0060,
                TemperatureUnit = TemperatureUnit.Fahrenheit,
                WindSpeedUnit = WindSpeedUnit.Mph,
                PrecipitationUnit = PrecipitationUnit.Inches
            };

            _mockWeatherClient
                .Setup(x => x.GetForcastAsync<OpenMeteoForecastResponseDto>(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync((OpenMeteoForecastResponseDto?)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => 
                _service.GetCurrentWeatherAsync(weatherRequest));
        }

        [Fact]
        public async Task GetCurrentWeatherAsync_WhenCurrentDataIsNull_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var weatherRequest = new WeatherRequest
            {
                Latitude = 40.7128,
                Longitude = -74.0060,
                TemperatureUnit = TemperatureUnit.Fahrenheit,
                WindSpeedUnit = WindSpeedUnit.Mph,
                PrecipitationUnit = PrecipitationUnit.Inches
            };

            var mockResponse = new OpenMeteoForecastResponseDto
            {
                Current = null
            };

            _mockWeatherClient
                .Setup(x => x.GetForcastAsync<OpenMeteoForecastResponseDto>(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync(mockResponse);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => 
                _service.GetCurrentWeatherAsync(weatherRequest));
        }

        [Fact]
        public async Task GetHourlyForecastAsync_WithValidRequest_ShouldReturnHourlyForecasts()
        {
            // Arrange
            var weatherRequest = new WeatherRequest
            {
                Latitude = 40.7128,
                Longitude = -74.0060,
                TemperatureUnit = TemperatureUnit.Celsius,
                WindSpeedUnit = WindSpeedUnit.Kmh,
                PrecipitationUnit = PrecipitationUnit.Millimeters
            };

            var mockResponse = new OpenMeteoForecastResponseDto
            {
                Hourly = new OpenMeteoHourlyDto
                {
                    Time = ["2024-01-15T00:00", "2024-01-15T01:00"],
                    Temperature = [15.0, 14.5],
                    FeelsLike = [13.0, 12.5],
                    DewPoint = [10.0, 9.5],
                    Humidity = [65, 70],
                    WindSpeed = [10.0, 11.0],
                    WindDirection = [180, 190],
                    WindGusts = [15.0, 16.0],
                    Precipitation = [0.0, 0.5],
                    PrecipitationProbability = [0, 30],
                    Pressure = [1013, 1012],
                    CloudCover = [30, 40],
                    Visibility = [10000, 9500],
                    WeatherCode = [0, 51],
                    IsDay = [0, 0]
                }
            };

            _mockWeatherClient
                .Setup(x => x.GetForcastAsync<OpenMeteoForecastResponseDto>(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync(mockResponse);

            // Act
            var result = await _service.GetHourlyForecastAsync(weatherRequest);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
            var firstHourly = result.First();
            Assert.Equal(15.0, firstHourly.Temperature);
            Assert.Equal(65, firstHourly.Humidity);
        }

        [Fact]
        public async Task GetHourlyForecastAsync_WithNullRequest_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => 
                _service.GetHourlyForecastAsync(null!));
        }

        [Fact]
        public async Task GetHourlyForecastAsync_WhenHourlyDataIsNull_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var weatherRequest = new WeatherRequest
            {
                Latitude = 40.7128,
                Longitude = -74.0060,
                TemperatureUnit = TemperatureUnit.Celsius,
                WindSpeedUnit = WindSpeedUnit.Kmh,
                PrecipitationUnit = PrecipitationUnit.Millimeters
            };

            var mockResponse = new OpenMeteoForecastResponseDto
            {
                Hourly = null
            };

            _mockWeatherClient
                .Setup(x => x.GetForcastAsync<OpenMeteoForecastResponseDto>(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync(mockResponse);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => 
                _service.GetHourlyForecastAsync(weatherRequest));
        }

        [Fact]
        public async Task GetDailyForecastAsync_WithValidRequest_ShouldReturnDailyForecasts()
        {
            // Arrange
            var weatherRequest = new WeatherRequest
            {
                Latitude = 40.7128,
                Longitude = -74.0060,
                TemperatureUnit = TemperatureUnit.Fahrenheit,
                WindSpeedUnit = WindSpeedUnit.Mph,
                PrecipitationUnit = PrecipitationUnit.Inches
            };

            var mockResponse = new OpenMeteoForecastResponseDto
            {
                Daily = new OpenMeteoDailyDto
                {
                    Time = ["2024-01-15", "2024-01-16"],
                    TemperatureMax = [70.0, 72.0],
                    TemperatureMin = [50.0, 52.0],
                    FeelsLikeMax = [68.0, 70.0],
                    FeelsLikeMin = [48.0, 50.0],
                    HumidityMax = [80, 75],
                    HumidityMin = [50, 45],
                    PressureMean = [1013, 1012],
                    PrecipitationSum = [0.0, 0.2],
                    PrecipitationProbabilityMax = [0, 30],
                    WindSpeedMax = [15.0, 16.0],
                    WindGustsMax = [25.0, 26.0],
                    WindDirectionDominant = [180, 190],
                    UvIndexMax = [5, 4],
                    WeatherCode = [0, 51],
                    Sunrise = ["2024-01-15T07:00", "2024-01-16T07:00"],
                    Sunset = ["2024-01-15T17:00", "2024-01-16T17:00"]
                }
            };

            _mockWeatherClient
                .Setup(x => x.GetForcastAsync<OpenMeteoForecastResponseDto>(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync(mockResponse);

            // Act
            var result = await _service.GetDailyForecastAsync(weatherRequest);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
            var firstDaily = result.First();
            Assert.Equal(70.0, firstDaily.TemperatureMax);
            Assert.Equal(50.0, firstDaily.TemperatureMin);
        }

        [Fact]
        public async Task GetDailyForecastAsync_WithNullRequest_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => 
                _service.GetDailyForecastAsync(null!));
        }

        [Fact]
        public async Task GetDailyForecastAsync_WhenDailyDataIsNull_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var weatherRequest = new WeatherRequest
            {
                Latitude = 40.7128,
                Longitude = -74.0060,
                TemperatureUnit = TemperatureUnit.Fahrenheit,
                WindSpeedUnit = WindSpeedUnit.Mph,
                PrecipitationUnit = PrecipitationUnit.Inches
            };

            var mockResponse = new OpenMeteoForecastResponseDto
            {
                Daily = null
            };

            _mockWeatherClient
                .Setup(x => x.GetForcastAsync<OpenMeteoForecastResponseDto>(It.IsAny<Dictionary<string, object>>()))
                .ReturnsAsync(mockResponse);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => 
                _service.GetDailyForecastAsync(weatherRequest));
        }
    }
}