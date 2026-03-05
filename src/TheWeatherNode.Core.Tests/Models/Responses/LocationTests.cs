using TheWeatherNode.Core.Models.Responses;
using Xunit;

namespace TheWeatherNode.Core.Tests.Models.Responses
{
    /// <summary>
    /// Unit tests for the <see cref="Location"/> class.
    /// </summary>
    public class LocationTests
    {
        #region Constructor and Instantiation Tests

        [Fact]
        public void Constructor_CreatesInstanceWithDefaultValues()
        {
            // Act
            var location = new Location();

            // Assert
            Assert.NotNull(location);
            Assert.Equal(string.Empty, location.Name);
            Assert.Equal(0.0, location.Latitude);
            Assert.Equal(0.0, location.Longitude);
            Assert.Equal(string.Empty, location.Country);
            Assert.Equal(string.Empty, location.CountryCode);
            Assert.Equal(string.Empty, location.State);
            Assert.Equal(0, location.Population);
            Assert.Equal(string.Empty, location.Timezone);
            Assert.Empty(location.PostalCodes);
        }

        #endregion

        #region Name Tests

        [Theory]
        [InlineData("New York")]
        [InlineData("Paris")]
        [InlineData("Tokyo")]
        [InlineData("London")]
        public void Name_CanBeSetAndRetrieved(string name)
        {
            // Arrange
            var location = new Location();

            // Act
            location.Name = name;

            // Assert
            Assert.Equal(name, location.Name);
        }

        #endregion

        #region Latitude Tests

        [Theory]
        [InlineData(0.0)]
        [InlineData(40.7128)]
        [InlineData(-33.8688)]
        [InlineData(90.0)]
        [InlineData(-90.0)]
        public void Latitude_CanBeSetAndRetrieved(double latitude)
        {
            // Arrange
            var location = new Location();

            // Act
            location.Latitude = latitude;

            // Assert
            Assert.Equal(latitude, location.Latitude);
        }

        #endregion

        #region Longitude Tests

        [Theory]
        [InlineData(0.0)]
        [InlineData(-74.0060)]
        [InlineData(139.6917)]
        [InlineData(180.0)]
        [InlineData(-180.0)]
        public void Longitude_CanBeSetAndRetrieved(double longitude)
        {
            // Arrange
            var location = new Location();

            // Act
            location.Longitude = longitude;

            // Assert
            Assert.Equal(longitude, location.Longitude);
        }

        #endregion

        #region Country Tests

        [Theory]
        [InlineData("United States")]
        [InlineData("France")]
        [InlineData("Japan")]
        public void Country_CanBeSetAndRetrieved(string country)
        {
            // Arrange
            var location = new Location();

            // Act
            location.Country = country;

            // Assert
            Assert.Equal(country, location.Country);
        }

        #endregion

        #region Country Code Tests

        [Theory]
        [InlineData("US")]
        [InlineData("FR")]
        [InlineData("JP")]
        [InlineData("GB")]
        public void CountryCode_CanBeSetAndRetrieved(string code)
        {
            // Arrange
            var location = new Location();

            // Act
            location.CountryCode = code;

            // Assert
            Assert.Equal(code, location.CountryCode);
        }

        #endregion

        #region State Tests

        [Theory]
        [InlineData("New York")]
        [InlineData("California")]
        [InlineData("Nebraska")]
        public void State_CanBeSetAndRetrieved(string state)
        {
            // Arrange
            var location = new Location();

            // Act
            location.State = state;

            // Assert
            Assert.Equal(state, location.State);
        }

        #endregion

        #region Population Tests

        [Theory]
        [InlineData(0)]
        [InlineData(7864)]
        [InlineData(8_000_000)]
        public void Population_CanBeSetAndRetrieved(int population)
        {
            // Arrange
            var location = new Location();

            // Act
            location.Population = population;

            // Assert
            Assert.Equal(population, location.Population);
        }

        #endregion

        #region Timezone Tests

        [Theory]
        [InlineData("America/New_York")]
        [InlineData("Europe/London")]
        [InlineData("Asia/Tokyo")]
        [InlineData("America/Chicago")]
        public void Timezone_CanBeSetAndRetrieved(string timezone)
        {
            // Arrange
            var location = new Location();

            // Act
            location.Timezone = timezone;

            // Assert
            Assert.Equal(timezone, location.Timezone);
        }

        #endregion

        #region PostalCodes Tests

        [Fact]
        public void PostalCodes_DefaultsToEmptyCollection()
        {
            // Arrange & Act
            var location = new Location();

            // Assert
            Assert.NotNull(location.PostalCodes);
            Assert.Empty(location.PostalCodes);
        }

        [Fact]
        public void PostalCodes_CanBeSetWithSingleCode()
        {
            // Arrange
            var PostalCodes = new[] { "68467" };
            var location = new Location();

            // Act
            location.PostalCodes = PostalCodes;

            // Assert
            Assert.Single(location.PostalCodes);
            Assert.Contains("68467", location.PostalCodes);
        }

        [Fact]
        public void PostalCodes_CanBeSetWithMultipleCodes()
        {
            // Arrange
            var PostalCodes = new[] { "10001", "10002", "10003" };
            var location = new Location();

            // Act
            location.PostalCodes = PostalCodes;

            // Assert
            Assert.Equal(3, location.PostalCodes.Count());
            Assert.All(PostalCodes, code => Assert.Contains(code, location.PostalCodes));
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void Location_WithRealisticValues_CreatesValidInstance()
        {
            // Arrange & Act
            var location = new Location
            {
                Name = "York",
                Latitude = 40.86807,
                Longitude = -97.592,
                Country = "United States",
                CountryCode = "US",
                State = "Nebraska",
                Population = 7864,
                Timezone = "America/Chicago",
                PostalCodes = new[] { "68467" }
            };

            // Assert
            Assert.Equal("York", location.Name);
            Assert.Equal(40.86807, location.Latitude);
            Assert.Equal(-97.592, location.Longitude);
            Assert.Equal("United States", location.Country);
            Assert.Equal("US", location.CountryCode);
            Assert.Equal("Nebraska", location.State);
            Assert.Equal(7864, location.Population);
            Assert.Equal("America/Chicago", location.Timezone);
            Assert.Single(location.PostalCodes);
        }

        [Fact]
        public void Location_WithRealWorldCoordinates_Tokyo()
        {
            // Arrange & Act
            var location = new Location
            {
                Name = "Tokyo",
                Latitude = 35.6762,
                Longitude = 139.6503,
                Country = "Japan",
                CountryCode = "JP",
                Timezone = "Asia/Tokyo"
            };

            // Assert
            Assert.Equal("Tokyo", location.Name);
            Assert.Equal(35.6762, location.Latitude);
            Assert.Equal(139.6503, location.Longitude);
            Assert.Equal("Japan", location.Country);
        }

        [Fact]
        public void Location_MultipleInstances_AreIndependent()
        {
            // Arrange & Act
            var location1 = new Location 
            { 
                Name = "New York",
                CountryCode = "US"
            };
            var location2 = new Location 
            { 
                Name = "Paris",
                CountryCode = "FR"
            };

            // Assert
            Assert.NotEqual(location1.Name, location2.Name);
            Assert.NotEqual(location1.CountryCode, location2.CountryCode);
            Assert.NotSame(location1, location2);
        }

        #endregion
    }
}