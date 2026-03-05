using Microsoft.AspNetCore.Mvc;
using Moq;
using TheWeatherNode.Core.Interfaces;
using TheWeatherNode.Core.Models.Requests;
using TheWeatherNode.Core.Models.Responses;
using TheWeatherNode.Server.Controllers;
using Microsoft.Extensions.Logging;

namespace TheWeatherNode.Server.Tests.Controllers
{
    public class WeatherForecastControllerTests
    {
        private readonly Mock<IWeatherService> _mockWeatherService;
        private readonly Mock<ILogger<WeatherForecastController>> _mockLogger;
        private readonly WeatherForecastController _controller;

        public WeatherForecastControllerTests()
        {
            _mockWeatherService = new Mock<IWeatherService>();
            _mockLogger = new Mock<ILogger<WeatherForecastController>>();
            _controller = new WeatherForecastController(_mockWeatherService.Object, _mockLogger.Object);
        }

        #region GetCurrentWeather Tests

        [Fact]
        public async Task GetCurrentWeather_WithValidParameters_ShouldReturnOkWithCurrentWeather()
        {
            // Arrange
            var latitude = 40.3025;
            var longitude = 74.3038;
            var temperatureUnit = "celsius";
            var windSpeedUnit = "kmh";
            var precipitationUnit = "millimeters";

            var mockCurrentWeather = new CurrentWeather
            {
                Temperature = 20.5,
                FeelsLike = 19.2,
                DewPoint = 10.5,
                Humidity = 65,
                WindSpeed = 10.5,
                WindDirection = 180,
                WindGusts = 15.0,
                Precipitation = 0.0,
                Pressure = 1013.25,
                Visibility = 10000,
                UvIndex = 5,
                CloudCover = 30,
                WeatherCode = 0,
                IsDay = true,
                Time = DateTime.Now
            };

            _mockWeatherService
                .Setup(x => x.GetCurrentWeatherAsync(It.IsAny<WeatherRequest>()))
                .ReturnsAsync(mockCurrentWeather);

            // Act
            var result = await _controller.GetCurrentWeather(latitude, longitude, temperatureUnit, windSpeedUnit, precipitationUnit);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            var returnedWeather = Assert.IsType<CurrentWeather>(okResult.Value);
            Assert.Equal(20.5, returnedWeather.Temperature);
            Assert.Equal(65, returnedWeather.Humidity);
            Assert.True(returnedWeather.IsDay);
        }

        [Fact]
        public async Task GetCurrentWeather_WithDefaultParameters_ShouldUseDefaults()
        {
            // Arrange
            var mockCurrentWeather = new CurrentWeather
            {
                Temperature = 20.5,
                Humidity = 65,
                IsDay = true,
                Time = DateTime.Now
            };

            _mockWeatherService
                .Setup(x => x.GetCurrentWeatherAsync(It.IsAny<WeatherRequest>()))
                .ReturnsAsync(mockCurrentWeather);

            // Act
            var result = await _controller.GetCurrentWeather();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            _mockWeatherService.Verify(x => x.GetCurrentWeatherAsync(It.Is<WeatherRequest>(
                r => r.Latitude == 40.3025 && r.Longitude == 74.3038)), Times.Once);
        }

        [Fact]
        public async Task GetCurrentWeather_WhenServiceThrowsException_ShouldReturnInternalServerError()
        {
            // Arrange
            _mockWeatherService
                .Setup(x => x.GetCurrentWeatherAsync(It.IsAny<WeatherRequest>()))
                .ThrowsAsync(new InvalidOperationException("Service error"));

            // Act
            var result = await _controller.GetCurrentWeather();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.NotNull(statusCodeResult.Value);
        }

        [Fact]
        public async Task GetCurrentWeather_WhenServiceThrowsException_ShouldLogError()
        {
            // Arrange
            var exception = new InvalidOperationException("Service error");
            _mockWeatherService
                .Setup(x => x.GetCurrentWeatherAsync(It.IsAny<WeatherRequest>()))
                .ThrowsAsync(exception);

            // Act
            await _controller.GetCurrentWeather();

            // Assert
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }

        #endregion

        #region GetHourlyForecast Tests

        [Fact]
        public async Task GetHourlyForecast_WithValidParameters_ShouldReturnOkWithHourlyForecasts()
        {
            // Arrange
            var latitude = 40.3025;
            var longitude = 74.3038;
            var temperatureUnit = "celsius";
            var windSpeedUnit = "kmh";
            var precipitationUnit = "millimeters";

            var mockHourlyForecasts = new List<HourlyForecast>
            {
                new()
                {
                    Time = DateTime.Now,
                    Temperature = 20.5,
                    FeelsLike = 19.2,
                    DewPoint = 10.5,
                    Humidity = 65,
                    WindSpeed = 10.5,
                    WindDirection = 180,
                    WindGusts = 15.0,
                    Precipitation = 0.0,
                    PrecipitationProbability = 0,
                    Pressure = 1013.25,
                    CloudCover = 30,
                    Visibility = 10000,
                    WeatherCode = 0,
                    IsDay = true
                },
                new()
                {
                    Time = DateTime.Now.AddHours(1),
                    Temperature = 19.8,
                    FeelsLike = 18.5,
                    DewPoint = 10.2,
                    Humidity = 68,
                    WindSpeed = 11.0,
                    WindDirection = 185,
                    WindGusts = 16.0,
                    Precipitation = 0.5,
                    PrecipitationProbability = 20,
                    Pressure = 1013.0,
                    CloudCover = 40,
                    Visibility = 9500,
                    WeatherCode = 51,
                    IsDay = true
                }
            };

            _mockWeatherService
                .Setup(x => x.GetHourlyForecastAsync(It.IsAny<WeatherRequest>()))
                .ReturnsAsync(mockHourlyForecasts);

            // Act
            var result = await _controller.GetHourlyForecast(latitude, longitude, temperatureUnit, windSpeedUnit, precipitationUnit);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            var returnedForecasts = Assert.IsAssignableFrom<IEnumerable<HourlyForecast>>(okResult.Value);
            Assert.Equal(2, returnedForecasts.Count());
        }

        [Fact]
        public async Task GetHourlyForecast_WithDefaultParameters_ShouldUseDefaults()
        {
            // Arrange
            var mockHourlyForecasts = new List<HourlyForecast>();
            _mockWeatherService
                .Setup(x => x.GetHourlyForecastAsync(It.IsAny<WeatherRequest>()))
                .ReturnsAsync(mockHourlyForecasts);

            // Act
            var result = await _controller.GetHourlyForecast();

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
            _mockWeatherService.Verify(x => x.GetHourlyForecastAsync(It.Is<WeatherRequest>(
                r => r.Latitude == 40.3025 && r.Longitude == 74.3038)), Times.Once);
        }

        [Fact]
        public async Task GetHourlyForecast_WhenServiceThrowsException_ShouldReturnInternalServerError()
        {
            // Arrange
            _mockWeatherService
                .Setup(x => x.GetHourlyForecastAsync(It.IsAny<WeatherRequest>()))
                .ThrowsAsync(new InvalidOperationException("Service error"));

            // Act
            var result = await _controller.GetHourlyForecast();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetHourlyForecast_WhenServiceReturnsEmpty_ShouldReturnOkWithEmptyList()
        {
            // Arrange
            var mockHourlyForecasts = new List<HourlyForecast>();
            _mockWeatherService
                .Setup(x => x.GetHourlyForecastAsync(It.IsAny<WeatherRequest>()))
                .ReturnsAsync(mockHourlyForecasts);

            // Act
            var result = await _controller.GetHourlyForecast();

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedForecasts = Assert.IsAssignableFrom<IEnumerable<HourlyForecast>>(okResult!.Value);
            Assert.Empty(returnedForecasts);
        }

        #endregion

        #region GetDailyForecast Tests

        [Fact]
        public async Task GetDailyForecast_WithValidParameters_ShouldReturnOkWithDailyForecasts()
        {
            // Arrange
            var latitude = 40.3025;
            var longitude = 74.3038;
            var temperatureUnit = "celsius";
            var windSpeedUnit = "kmh";
            var precipitationUnit = "millimeters";

            var mockDailyForecasts = new List<DailyForecast>
            {
                new()
                {
                    Date = DateTime.Now,
                    TemperatureMax = 25.0,
                    TemperatureMin = 15.0,
                    FeelsLikeMax = 24.0,
                    FeelsLikeMin = 14.0,
                    HumidityMax = 80,
                    HumidityMin = 50,
                    PressureMean = 1013.25,
                    PrecipitationSum = 0.0,
                    PrecipitationProbabilityMax = 0,
                    WindSpeedMax = 15.0,
                    WindGustsMax = 25.0,
                    WindDirectionDominant = 180,
                    UvIndexMax = 5,
                    WeatherCode = 0,
                    Sunrise = DateTime.Now.AddHours(-8),
                    Sunset = DateTime.Now.AddHours(8)
                },
                new()
                {
                    Date = DateTime.Now.AddDays(1),
                    TemperatureMax = 24.0,
                    TemperatureMin = 14.0,
                    FeelsLikeMax = 23.0,
                    FeelsLikeMin = 13.0,
                    HumidityMax = 75,
                    HumidityMin = 45,
                    PressureMean = 1012.0,
                    PrecipitationSum = 2.5,
                    PrecipitationProbabilityMax = 60,
                    WindSpeedMax = 16.0,
                    WindGustsMax = 26.0,
                    WindDirectionDominant = 190,
                    UvIndexMax = 4,
                    WeatherCode = 51,
                    Sunrise = DateTime.Now.AddHours(-8),
                    Sunset = DateTime.Now.AddHours(8)
                }
            };

            _mockWeatherService
                .Setup(x => x.GetDailyForecastAsync(It.IsAny<WeatherRequest>()))
                .ReturnsAsync(mockDailyForecasts);

            // Act
            var result = await _controller.GetDailyForecast(latitude, longitude, temperatureUnit, windSpeedUnit, precipitationUnit);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            var returnedForecasts = Assert.IsAssignableFrom<IEnumerable<DailyForecast>>(okResult.Value);
            Assert.Equal(2, returnedForecasts.Count());
        }

        [Fact]
        public async Task GetDailyForecast_WithDefaultParameters_ShouldUseDefaults()
        {
            // Arrange
            var mockDailyForecasts = new List<DailyForecast>();
            _mockWeatherService
                .Setup(x => x.GetDailyForecastAsync(It.IsAny<WeatherRequest>()))
                .ReturnsAsync(mockDailyForecasts);

            // Act
            var result = await _controller.GetDailyForecast();

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
            _mockWeatherService.Verify(x => x.GetDailyForecastAsync(It.Is<WeatherRequest>(
                r => r.Latitude == 40.3025 && r.Longitude == 74.3038)), Times.Once);
        }

        [Fact]
        public async Task GetDailyForecast_WhenServiceThrowsException_ShouldReturnInternalServerError()
        {
            // Arrange
            _mockWeatherService
                .Setup(x => x.GetDailyForecastAsync(It.IsAny<WeatherRequest>()))
                .ThrowsAsync(new InvalidOperationException("Service error"));

            // Act
            var result = await _controller.GetDailyForecast();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetDailyForecast_WhenServiceReturnsEmpty_ShouldReturnOkWithEmptyList()
        {
            // Arrange
            var mockDailyForecasts = new List<DailyForecast>();
            _mockWeatherService
                .Setup(x => x.GetDailyForecastAsync(It.IsAny<WeatherRequest>()))
                .ReturnsAsync(mockDailyForecasts);

            // Act
            var result = await _controller.GetDailyForecast();

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedForecasts = Assert.IsAssignableFrom<IEnumerable<DailyForecast>>(okResult!.Value);
            Assert.Empty(returnedForecasts);
        }

        #endregion
    }
}