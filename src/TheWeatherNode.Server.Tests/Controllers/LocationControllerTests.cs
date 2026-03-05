using Microsoft.AspNetCore.Mvc;
using Moq;
using TheWeatherNode.Core.Interfaces;
using TheWeatherNode.Core.Models.Responses;
using TheWeatherNode.Server.Controllers;
using Microsoft.Extensions.Logging;

namespace TheWeatherNode.Server.Tests.Controllers
{
    public class LocationControllerTests
    {
        private readonly Mock<IGeocodingService> _mockGeocodingService;
        private readonly Mock<ILogger<LocationController>> _mockLogger;
        private readonly LocationController _controller;

        public LocationControllerTests()
        {
            _mockGeocodingService = new Mock<IGeocodingService>();
            _mockLogger = new Mock<ILogger<LocationController>>();
            _controller = new LocationController(_mockGeocodingService.Object, _mockLogger.Object);
        }

        #region SearchLocations Tests

        [Fact]
        public async Task SearchLocations_WithValidQuery_ShouldReturnOkWithLocations()
        {
            // Arrange
            var query = "New York";
            var mockLocations = new List<Location>
            {
                new()
                {
                    Name = "New York",
                    Latitude = 40.7128,
                    Longitude = -74.0060,
                    Country = "United States",
                    CountryCode = "US",
                    State = "New York",
                    PostalCodes = ["10001", "10002"],
                    Population = 8336817,
                    Timezone = "America/New_York"
                },
                new()
                {
                    Name = "New York",
                    Latitude = 42.9538,
                    Longitude = -76.2262,
                    Country = "United States",
                    CountryCode = "US",
                    State = "New York",
                    PostalCodes = ["13020"],
                    Population = 20000,
                    Timezone = "America/New_York"
                }
            };

            _mockGeocodingService
                .Setup(x => x.SearchLocationsAsync(query))
                .ReturnsAsync(mockLocations);

            // Act
            var result = await _controller.SearchLocations(query);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            var returnedLocations = Assert.IsAssignableFrom<IEnumerable<Location>>(okResult.Value);
            Assert.Equal(2, returnedLocations.Count());
        }

        [Fact]
        public async Task SearchLocations_WithEmptyResults_ShouldReturnOkWithEmptyList()
        {
            // Arrange
            var query = "NonExistent";
            var mockLocations = new List<Location>();

            _mockGeocodingService
                .Setup(x => x.SearchLocationsAsync(query))
                .ReturnsAsync(mockLocations);

            // Act
            var result = await _controller.SearchLocations(query);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedLocations = Assert.IsAssignableFrom<IEnumerable<Location>>(okResult.Value);
            Assert.Empty(returnedLocations);
        }

        [Fact]
        public async Task SearchLocations_WithNullQuery_ShouldReturnBadRequest()
        {
            // Act
            var result = await _controller.SearchLocations(null!);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.NotNull(badRequestResult.Value);
            _mockGeocodingService.Verify(x => x.SearchLocationsAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task SearchLocations_WithEmptyQuery_ShouldReturnBadRequest()
        {
            // Act
            var result = await _controller.SearchLocations("");

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
            _mockGeocodingService.Verify(x => x.SearchLocationsAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task SearchLocations_WithWhitespaceQuery_ShouldReturnBadRequest()
        {
            // Act
            var result = await _controller.SearchLocations("   ");

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async Task SearchLocations_WhenServiceThrowsException_ShouldReturnInternalServerError()
        {
            // Arrange
            var query = "New York";
            _mockGeocodingService
                .Setup(x => x.SearchLocationsAsync(query))
                .ThrowsAsync(new InvalidOperationException("Service error"));

            // Act
            var result = await _controller.SearchLocations(query);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.NotNull(statusCodeResult.Value);
        }

        [Fact]
        public async Task SearchLocations_WhenServiceThrowsException_ShouldLogError()
        {
            // Arrange
            var query = "New York";
            var exception = new InvalidOperationException("Service error");
            _mockGeocodingService
                .Setup(x => x.SearchLocationsAsync(query))
                .ThrowsAsync(exception);

            // Act
            await _controller.SearchLocations(query);

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

        [Fact]
        public async Task SearchLocations_WithValidQuery_ShouldCallGeocodingService()
        {
            // Arrange
            var query = "London";
            var mockLocations = new List<Location>();
            _mockGeocodingService
                .Setup(x => x.SearchLocationsAsync(query))
                .ReturnsAsync(mockLocations);

            // Act
            await _controller.SearchLocations(query);

            // Assert
            _mockGeocodingService.Verify(x => x.SearchLocationsAsync(query), Times.Once);
        }

        #endregion

    }
}