using Moq;
using TheWeatherNode.Core.Models.Responses;
using TheWeatherNode.WeatherService.OpenMeteo.Clients.Interfaces;
using TheWeatherNode.WeatherService.OpenMeteo.DTOs;
using TheWeatherNode.WeatherService.OpenMeteo.Services;
using Microsoft.Extensions.Logging;

namespace TheWeatherNode.WeatherService.OpenMeteo.Tests.Services
{
    public class OpenMeteoGeocodingServiceTests
    {
        private readonly Mock<IOpenMeteoGeocodingClient> _mockGeocodingClient;
        private readonly Mock<ILogger<OpenMeteoGeocodingService>> _mockLogger;
        private readonly OpenMeteoGeocodingService _service;

        public OpenMeteoGeocodingServiceTests()
        {
            _mockGeocodingClient = new Mock<IOpenMeteoGeocodingClient>();
            _mockLogger = new Mock<ILogger<OpenMeteoGeocodingService>>();
            _service = new OpenMeteoGeocodingService(_mockGeocodingClient.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task SearchLocationsAsync_WithValidQuery_ShouldReturnLocations()
        {
            // Arrange
            var mockDtos = new List<OpenMeteoGeocodingDto>
            {
                new()
                {
                    Name = "New York",
                    Latitude = 40.7128,
                    Longitude = -74.0060,
                    Country = "United States",
                    CountryCode = "US",
                    Admin1 = "New York",
                    Postcodes = ["10001", "10002"],
                    Population = 8336817,
                    Timezone = "America/New_York"
                }
            };

            _mockGeocodingClient
                .Setup(x => x.GetLocationsAsync(It.IsAny<string>()))
                .ReturnsAsync(mockDtos);

            // Act
            var result = await _service.SearchLocationsAsync("New York");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            var location = result.First();
            Assert.Equal("New York", location.Name);
            Assert.Equal(40.7128, location.Latitude);
            Assert.Equal(-74.0060, location.Longitude);
            Assert.Equal("United States", location.Country);
            Assert.Equal("US", location.CountryCode);
        }

        [Fact]
        public async Task SearchLocationsAsync_WithEmptyResults_ShouldReturnEmptyCollection()
        {
            // Arrange
            _mockGeocodingClient
                .Setup(x => x.GetLocationsAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<OpenMeteoGeocodingDto>());

            // Act
            var result = await _service.SearchLocationsAsync("NonExistent");

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task SearchLocationsAsync_WithMultipleResults_ShouldReturnAllLocations()
        {
            // Arrange
            var mockDtos = new List<OpenMeteoGeocodingDto>
            {
                new()
                {
                    Name = "New York",
                    Latitude = 40.7128,
                    Longitude = -74.0060,
                    Country = "United States",
                    CountryCode = "US",
                    Admin1 = "New York",
                    Timezone = "America/New_York"
                },
                new()
                {
                    Name = "York",
                    Latitude = 53.9581,
                    Longitude = -1.0873,
                    Country = "United Kingdom",
                    CountryCode = "GB",
                    Admin1 = "England",
                    Timezone = "Europe/London"
                }
            };

            _mockGeocodingClient
                .Setup(x => x.GetLocationsAsync(It.IsAny<string>()))
                .ReturnsAsync(mockDtos);

            // Act
            var result = await _service.SearchLocationsAsync("York");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetLocationAsync_WithExactMatch_ShouldReturnLocation()
        {
            // Arrange
            var mockDtos = new List<OpenMeteoGeocodingDto>
            {
                new()
                {
                    Name = "New York",
                    Latitude = 40.7128,
                    Longitude = -74.0060,
                    Country = "United States",
                    CountryCode = "US",
                    Admin1 = "New York",
                    Timezone = "America/New_York"
                }
            };

            _mockGeocodingClient
                .Setup(x => x.GetLocationsAsync(It.IsAny<string>()))
                .ReturnsAsync(mockDtos);

            // Act
            var result = await _service.GetLocationAsync("New York");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New York", result.Name);
            Assert.Equal("United States", result.Country);
        }

        [Fact]
        public async Task GetLocationAsync_WithCity_ShouldReturnFirstMatch()
        {
            // Arrange
            var mockDtos = new List<OpenMeteoGeocodingDto>
            {
                new()
                {
                    Name = "New York",
                    Latitude = 40.7128,
                    Longitude = -74.0060,
                    Country = "United States",
                    CountryCode = "US",
                    Admin1 = "New York",
                    Timezone = "America/New_York"
                }
            };

            _mockGeocodingClient
                .Setup(x => x.GetLocationsAsync("New York"))
                .ReturnsAsync(mockDtos);

            // Act
            var result = await _service.GetLocationAsync("New York");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New York", result.Name);
        }

        [Fact]
        public async Task GetLocationAsync_WithCityAndCountry_ShouldFilterByBoth()
        {
            // Arrange
            var mockDtos = new List<OpenMeteoGeocodingDto>
            {
                new()
                {
                    Name = "New York",
                    Latitude = 40.7128,
                    Longitude = -74.0060,
                    Country = "United States",
                    CountryCode = "US",
                    Admin1 = "New York",
                    Timezone = "America/New_York"
                }
            };

            _mockGeocodingClient
                .Setup(x => x.GetLocationsAsync("New York, United States"))
                .ReturnsAsync(mockDtos);

            // Act
            var result = await _service.GetLocationAsync("New York", "United States");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New York", result.Name);
            Assert.Equal("United States", result.Country);
        }

        [Fact]
        public async Task GetLocationAsync_WithNonexistentLocation_ShouldReturnNull()
        {
            // Arrange
            _mockGeocodingClient
                .Setup(x => x.GetLocationsAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<OpenMeteoGeocodingDto>());

            // Act
            var result = await _service.GetLocationAsync("NonExistent");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task SearchLocationsAsync_WithNullAdminField_ShouldUseEmptyString()
        {
            // Arrange
            var mockDtos = new List<OpenMeteoGeocodingDto>
            {
                new()
                {
                    Name = "Test City",
                    Latitude = 0,
                    Longitude = 0,
                    Country = "Test Country",
                    CountryCode = "TC",
                    Admin1 = null,
                    Timezone = "UTC"
                }
            };

            _mockGeocodingClient
                .Setup(x => x.GetLocationsAsync(It.IsAny<string>()))
                .ReturnsAsync(mockDtos);

            // Act
            var result = await _service.SearchLocationsAsync("Test");

            // Assert
            Assert.NotNull(result);
            var location = result.First();
            Assert.Equal(string.Empty, location.State);
        }

        [Fact]
        public async Task SearchLocationsAsync_WithNullPostcodes_ShouldUseEmptyEnumerable()
        {
            // Arrange
            var mockDtos = new List<OpenMeteoGeocodingDto>
            {
                new()
                {
                    Name = "Test City",
                    Latitude = 0,
                    Longitude = 0,
                    Country = "Test Country",
                    CountryCode = "TC",
                    Admin1 = "Test",
                    Postcodes = null,
                    Timezone = "UTC"
                }
            };

            _mockGeocodingClient
                .Setup(x => x.GetLocationsAsync(It.IsAny<string>()))
                .ReturnsAsync(mockDtos);

            // Act
            var result = await _service.SearchLocationsAsync("Test");

            // Assert
            Assert.NotNull(result);
            var location = result.First();
            Assert.Empty(location.PostalCodes);
        }
    }
}