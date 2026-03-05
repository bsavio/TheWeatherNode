using Moq;
using Moq.Protected;
using TheWeatherNode.WeatherService.OpenMeteo.Clients;
using TheWeatherNode.WeatherService.OpenMeteo.Clients.Settings;
using System.Net;

namespace TheWeatherNode.WeatherService.OpenMeteo.Tests.Clients
{
    public class OpenMeteoGeocodingClientTests
    {
        private readonly OpenMeteoGeocodingClientSettings _settings;

        public OpenMeteoGeocodingClientTests()
        {
            _settings = new OpenMeteoGeocodingClientSettings
            {
                BaseUrl = "https://geocoding-api.open-meteo.com/v1/",
                SearchEndPoint = "search",
                Timeout = 30
            };
        }

        [Fact]
        public void Constructor_WithValidSettings_ShouldInitialize()
        {
            // Arrange
            var mockHandler = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(mockHandler.Object);

            // Act
            var client = new OpenMeteoGeocodingClient(httpClient, _settings);

            // Assert
            Assert.NotNull(client);
        }

        [Fact]
        public async Task GetLocationsAsync_WithValidSearch_ShouldReturnLocations()
        {
            // Arrange
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("""
                {
                    "results": [
                        {
                            "id": 1,
                            "name": "New York",
                            "latitude": 40.7128,
                            "longitude": -74.0060,
                            "country": "United States",
                            "country_code": "US",
                            "admin1": "New York",
                            "timezone": "America/New_York"
                        }
                    ]
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
            var client = new OpenMeteoGeocodingClient(httpClient, _settings);

            // Act
            var result = await client.GetLocationsAsync("New York");

            // Assert
            Assert.NotEmpty(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task GetLocationsAsync_WithEmptySearch_ShouldStillMakeRequest()
        {
            // Arrange
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("""
                {
                    "results": []
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
            var client = new OpenMeteoGeocodingClient(httpClient, _settings);

            // Act
            var result = await client.GetLocationsAsync("");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetLocationsAsync_WithHttpErrorStatus_ShouldThrowHttpRequestException()
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
            var client = new OpenMeteoGeocodingClient(httpClient, _settings);

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => 
                client.GetLocationsAsync("New York"));
        }
    }
}