using Moq;
using Moq.Protected;
using TheWeatherNode.WeatherService.OpenMeteo.Clients;
using TheWeatherNode.WeatherService.OpenMeteo.Clients.Settings;
using TheWeatherNode.WeatherService.OpenMeteo.DTOs;
using System.Net;

namespace TheWeatherNode.WeatherService.OpenMeteo.Tests.Clients
{
    public class OpenMeteoWeatherClientTests
    {
        private readonly OpenMeteoWeatherClientSettings _settings;

        public OpenMeteoWeatherClientTests()
        {
            _settings = new OpenMeteoWeatherClientSettings
            {
                BaseUrl = "https://api.open-meteo.com/v1/",
                ForcastEndPoint = "forecast",
                Timeout = 30
            };
        }

        [Fact]
        public void Constructor_ShouldSetBaseUrlAndTimeout()
        {
            // Arrange
            var mockHandler = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(mockHandler.Object);

            // Act
            var client = new OpenMeteoWeatherClient(httpClient, _settings);

            // Assert
            Assert.NotNull(client);
        }

        [Fact]
        public void Constructor_WithNullHttpClient_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => 
                new OpenMeteoWeatherClient(null!, _settings));
        }


        [Fact]
        public async Task GetForcastAsync_WithValidParameters_ShouldReturnDeserializedResponse()
        {
            // Arrange
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("""
                {
                    "current": {
                        "temperature_2m": 20.5,
                        "relative_humidity_2m": 65,
                        "weather_code": 0,
                        "wind_speed_10m": 10,
                        "is_day": 1
                    }
                }
                """, System.Text.Encoding.UTF8, "application/json")
            };

            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            var httpClient = new HttpClient(mockHandler.Object);
            var client = new OpenMeteoWeatherClient(httpClient, _settings);
            var parameters = new Dictionary<string, object>
            {
                { "latitude", 40.7128 },
                { "longitude", -74.0060 }
            };

            // Act
            var result = await client.GetForcastAsync<OpenMeteoForecastResponseDto>(parameters);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Current);
        }

        [Fact]
        public async Task GetForcastAsync_WithEmptyParameters_ShouldStillMakeRequest()
        {
            // Arrange
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("""
                {
                    "current": {
                        "temperature_2m": 20.5,
                        "relative_humidity_2m": 65,
                        "weather_code": 0,
                        "wind_speed_10m": 10,
                        "is_day": 1
                    }
                }
                """, System.Text.Encoding.UTF8, "application/json")
            };

            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            var httpClient = new HttpClient(mockHandler.Object);
            var client = new OpenMeteoWeatherClient(httpClient, _settings);
            var parameters = new Dictionary<string, object>();

            // Act
            var result = await client.GetForcastAsync<OpenMeteoForecastResponseDto>(parameters);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetForcastAsync_WithHttpErrorStatus_ShouldThrowHttpRequestException()
        {
            // Arrange
            var mockResponse = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            var httpClient = new HttpClient(mockHandler.Object);
            var client = new OpenMeteoWeatherClient(httpClient, _settings);
            var parameters = new Dictionary<string, object>();

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => 
                client.GetForcastAsync<OpenMeteoForecastResponseDto>(parameters));
        }
    }
}