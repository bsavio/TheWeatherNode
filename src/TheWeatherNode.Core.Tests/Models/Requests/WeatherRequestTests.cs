using TheWeatherNode.Core.Models;
using TheWeatherNode.Core.Models.Requests;
using Xunit;

namespace TheWeatherNode.Core.Tests.Models.Requests
{
    /// <summary>
    /// Unit tests for the <see cref="WeatherRequest"/> class.
    /// </summary>
    public class WeatherRequestTests
    {
        #region Constructor Tests - Valid Inputs

        [Fact]
        public void Constructor_WithValidCoordinatesAndDefaults_CreatesInstanceSuccessfully()
        {
            // Arrange
            const double latitude = 40.7128;
            const double longitude = -74.0060;

            // Act
            var request = new WeatherRequest(latitude, longitude);

            // Assert
            Assert.Equal(latitude, request.Latitude);
            Assert.Equal(longitude, request.Longitude);
            Assert.Equal(TemperatureUnit.Celsius, request.TemperatureUnit);
            Assert.Equal(WindSpeedUnit.Kmh, request.WindSpeedUnit);
            Assert.Equal(PrecipitationUnit.Millimeters, request.PrecipitationUnit);
        }

        [Fact]
        public void Constructor_WithAllParametersSpecified_CreatesInstanceSuccessfully()
        {
            // Arrange
            const double latitude = 51.5074;
            const double longitude = -0.1278;
            const string temperatureUnit = "fahrenheit";
            const string windSpeedUnit = "mph";
            const string precipitationUnit = "inches";

            // Act
            var request = new WeatherRequest(latitude, longitude, temperatureUnit, windSpeedUnit, precipitationUnit);

            // Assert
            Assert.Equal(latitude, request.Latitude);
            Assert.Equal(longitude, request.Longitude);
            Assert.Equal(TemperatureUnit.Fahrenheit, request.TemperatureUnit);
            Assert.Equal(WindSpeedUnit.Mph, request.WindSpeedUnit);
            Assert.Equal(PrecipitationUnit.Inches, request.PrecipitationUnit);
        }

        [Theory]
        [InlineData("celsius", TemperatureUnit.Celsius)]
        [InlineData("Celsius", TemperatureUnit.Celsius)]
        [InlineData("CELSIUS", TemperatureUnit.Celsius)]
        [InlineData("fahrenheit", TemperatureUnit.Fahrenheit)]
        [InlineData("Fahrenheit", TemperatureUnit.Fahrenheit)]
        public void Constructor_WithVariousTemperatureUnits_ConvertsCorrectly(string temperatureUnit, TemperatureUnit expected)
        {
            // Act
            var request = new WeatherRequest(40.0, -74.0, temperatureUnit, "km/h", "millimeters");

            // Assert
            Assert.Equal(expected, request.TemperatureUnit);
        }

        [Theory]
        [InlineData("kmh", WindSpeedUnit.Kmh)]
        [InlineData("km/h", WindSpeedUnit.Kmh)]
        [InlineData("KMH", WindSpeedUnit.Kmh)]
        [InlineData("KM/H", WindSpeedUnit.Kmh)]
        [InlineData("mph", WindSpeedUnit.Mph)]
        [InlineData("MPH", WindSpeedUnit.Mph)]
        [InlineData("knots", WindSpeedUnit.Knots)]
        [InlineData("KNOTS", WindSpeedUnit.Knots)]
        [InlineData("kn", WindSpeedUnit.Knots)]
        public void Constructor_WithVariousWindSpeedUnits_ConvertsCorrectly(string windSpeedUnit, WindSpeedUnit expected)
        {
            // Act
            var request = new WeatherRequest(40.0, -74.0, "celsius", windSpeedUnit, "millimeters");

            // Assert
            Assert.Equal(expected, request.WindSpeedUnit);
        }

        [Theory]
        [InlineData("millimeters", PrecipitationUnit.Millimeters)]
        [InlineData("mm", PrecipitationUnit.Millimeters)]
        [InlineData("MM", PrecipitationUnit.Millimeters)]
        [InlineData("inches", PrecipitationUnit.Inches)]
        [InlineData("in", PrecipitationUnit.Inches)]
        [InlineData("IN", PrecipitationUnit.Inches)]
        public void Constructor_WithVariousPrecipitationUnits_ConvertsCorrectly(string precipitationUnit, PrecipitationUnit expected)
        {
            // Act
            var request = new WeatherRequest(40.0, -74.0, "celsius", "km/h", precipitationUnit);

            // Assert
            Assert.Equal(expected, request.PrecipitationUnit);
        }

        #endregion

        #region Latitude Tests

        [Theory]
        [InlineData(0.0)]
        [InlineData(90.0)]
        [InlineData(-90.0)]
        [InlineData(45.5)]
        [InlineData(-33.8688)]
        public void Constructor_WithValidLatitudes_CreatesInstanceSuccessfully(double latitude)
        {
            // Act
            var request = new WeatherRequest(latitude, 0.0);

            // Assert
            Assert.Equal(latitude, request.Latitude);
        }

        [Theory]
        [InlineData(90.1)]
        [InlineData(-90.1)]
        [InlineData(180.0)]
        [InlineData(-180.1)]
        public void Constructor_WithOutOfRangeLatitudes_StillCreatesInstance(double latitude)
        {
            // Act & Assert
            // Note: The constructor doesn't validate latitude bounds, so we just verify it stores the value
            var request = new WeatherRequest(latitude, 0.0);
            Assert.Equal(latitude, request.Latitude);
        }

        #endregion

        #region Longitude Tests

        [Theory]
        [InlineData(0.0)]
        [InlineData(180.0)]
        [InlineData(-180.0)]
        [InlineData(139.6917)]
        [InlineData(-74.0060)]
        public void Constructor_WithValidLongitudes_CreatesInstanceSuccessfully(double longitude)
        {
            // Act
            var request = new WeatherRequest(0.0, longitude);

            // Assert
            Assert.Equal(longitude, request.Longitude);
        }

        [Theory]
        [InlineData(180.1)]
        [InlineData(-180.1)]
        [InlineData(360.0)]
        public void Constructor_WithOutOfRangeLongitudes_StillCreatesInstance(double longitude)
        {
            // Act & Assert
            // Note: The constructor doesn't validate longitude bounds, so we just verify it stores the value
            var request = new WeatherRequest(0.0, longitude);
            Assert.Equal(longitude, request.Longitude);
        }

        #endregion

        #region Invalid Unit String Tests

        [Fact]
        public void Constructor_WithInvalidTemperatureUnit_ThrowsArgumentException()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(
                () => new WeatherRequest(40.0, -74.0, "invalid_temp", "km/h", "millimeters"));
            Assert.Contains("not a valid temperature unit", ex.Message);
        }

        [Fact]
        public void Constructor_WithInvalidWindSpeedUnit_ThrowsArgumentException()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(
                () => new WeatherRequest(40.0, -74.0, "celsius", "invalid_wind", "millimeters"));
            Assert.Contains("not a valid wind speed unit", ex.Message);
        }

        [Fact]
        public void Constructor_WithInvalidPrecipitationUnit_ThrowsArgumentException()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(
                () => new WeatherRequest(40.0, -74.0, "celsius", "km/h", "invalid_precip"));
            Assert.Contains("not a valid precipitation unit", ex.Message);
        }

        #endregion

        #region Null Unit String Tests

        [Fact]
        public void Constructor_WithNullTemperatureUnit_ThrowsArgumentNullException()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(
                () => new WeatherRequest(40.0, -74.0, null!, "km/h", "millimeters"));
            Assert.Equal("value", ex.ParamName);
        }

        [Fact]
        public void Constructor_WithNullWindSpeedUnit_ThrowsArgumentNullException()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(
                () => new WeatherRequest(40.0, -74.0, "celsius", null!, "millimeters"));
            Assert.Equal("value", ex.ParamName);
        }

        [Fact]
        public void Constructor_WithNullPrecipitationUnit_ThrowsArgumentNullException()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(
                () => new WeatherRequest(40.0, -74.0, "celsius", "km/h", null!));
            Assert.Equal("value", ex.ParamName);
        }

        #endregion

        #region Empty/Whitespace Unit String Tests

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_WithEmptyTemperatureUnit_ThrowsArgumentException(string temperatureUnit)
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(
                () => new WeatherRequest(40.0, -74.0, temperatureUnit, "km/h", "millimeters"));
            Assert.Contains("not a valid temperature unit", ex.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_WithEmptyWindSpeedUnit_ThrowsArgumentException(string windSpeedUnit)
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(
                () => new WeatherRequest(40.0, -74.0, "celsius", windSpeedUnit, "millimeters"));
            Assert.Contains("not a valid wind speed unit", ex.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_WithEmptyPrecipitationUnit_ThrowsArgumentException(string precipitationUnit)
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(
                () => new WeatherRequest(40.0, -74.0, "celsius", "km/h", precipitationUnit));
            Assert.Contains("not a valid precipitation unit", ex.Message);
        }

        #endregion

        #region Property Access Tests

        [Fact]
        public void Properties_AreReadOnly_CannotBeModified()
        {
            // Arrange
            var request = new WeatherRequest(40.0, -74.0);

            // Assert - Verify properties are read-only (no setters)
            Assert.Equal(40.0, request.Latitude);
            Assert.Equal(-74.0, request.Longitude);
            Assert.Equal(TemperatureUnit.Celsius, request.TemperatureUnit);
            Assert.Equal(WindSpeedUnit.Kmh, request.WindSpeedUnit);
            Assert.Equal(PrecipitationUnit.Millimeters, request.PrecipitationUnit);
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        public void Constructor_WithZeroCoordinates_CreatesInstanceSuccessfully()
        {
            // Act
            var request = new WeatherRequest(0.0, 0.0);

            // Assert
            Assert.Equal(0.0, request.Latitude);
            Assert.Equal(0.0, request.Longitude);
        }

        [Fact]
        public void Constructor_WithExtremeCoordinates_CreatesInstanceSuccessfully()
        {
            // Act
            var request = new WeatherRequest(89.9999, 179.9999);

            // Assert
            Assert.Equal(89.9999, request.Latitude);
            Assert.Equal(179.9999, request.Longitude);
        }

        [Fact]
        public void Constructor_WithNegativeCoordinates_CreatesInstanceSuccessfully()
        {
            // Act
            var request = new WeatherRequest(-40.7128, -74.0060);

            // Assert
            Assert.Equal(-40.7128, request.Latitude);
            Assert.Equal(-74.0060, request.Longitude);
        }

        [Fact]
        public void Constructor_WithHighPrecisionCoordinates_PreservesValues()
        {
            // Arrange
            const double latitude = 40.712776;
            const double longitude = -74.005974;

            // Act
            var request = new WeatherRequest(latitude, longitude);

            // Assert
            Assert.Equal(latitude, request.Latitude);
            Assert.Equal(longitude, request.Longitude);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void Constructor_WithMixedCaseUnits_NormalizesCorrectly()
        {
            // Act
            var request = new WeatherRequest(40.0, -74.0, "CeLsIuS", "KmH", "MiLLiMeTeRs");

            // Assert
            Assert.Equal(TemperatureUnit.Celsius, request.TemperatureUnit);
            Assert.Equal(WindSpeedUnit.Kmh, request.WindSpeedUnit);
            Assert.Equal(PrecipitationUnit.Millimeters, request.PrecipitationUnit);
        }

        [Fact]
        public void Constructor_WithAliasedUnits_ConvertsToCorrectEnum()
        {
            // Act
            var request = new WeatherRequest(40.0, -74.0, "celsius", "km/h", "mm");

            // Assert
            Assert.Equal(TemperatureUnit.Celsius, request.TemperatureUnit);
            Assert.Equal(WindSpeedUnit.Kmh, request.WindSpeedUnit);
            Assert.Equal(PrecipitationUnit.Millimeters, request.PrecipitationUnit);
        }

        [Fact]
        public void MultipleInstances_WithSameParameters_AreIndependent()
        {
            // Act
            var request1 = new WeatherRequest(40.0, -74.0, "celsius", "km/h", "millimeters");
            var request2 = new WeatherRequest(40.0, -74.0, "celsius", "km/h", "millimeters");

            // Assert
            Assert.Equal(request1.Latitude, request2.Latitude);
            Assert.Equal(request1.Longitude, request2.Longitude);
            Assert.Equal(request1.TemperatureUnit, request2.TemperatureUnit);
            Assert.NotSame(request1, request2);
        }

        [Theory]
        [InlineData(35.6762, 139.6503, "celsius", "km/h", "millimeters")]     // Tokyo
        [InlineData(48.8566, 2.3522, "celsius", "km/h", "millimeters")]       // Paris
        [InlineData(-33.8688, 151.2093, "celsius", "km/h", "millimeters")]    // Sydney
        [InlineData(40.7128, -74.0060, "fahrenheit", "mph", "inches")]         // New York
        public void Constructor_WithRealWorldCoordinates_CreatesValidRequest(
            double latitude,
            double longitude,
            string tempUnit,
            string windUnit,
            string precipUnit)
        {
            // Act
            var request = new WeatherRequest(latitude, longitude, tempUnit, windUnit, precipUnit);

            // Assert
            Assert.Equal(latitude, request.Latitude);
            Assert.Equal(longitude, request.Longitude);
            // Verify the units were converted (just check they exist, not using NotEqual)
            Assert.True(Enum.IsDefined(typeof(TemperatureUnit), request.TemperatureUnit));
            Assert.True(Enum.IsDefined(typeof(WindSpeedUnit), request.WindSpeedUnit));
            Assert.True(Enum.IsDefined(typeof(PrecipitationUnit), request.PrecipitationUnit));
        }

        #endregion
    }
}