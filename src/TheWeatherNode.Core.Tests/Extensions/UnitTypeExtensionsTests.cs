using TheWeatherNode.Core.Extensions;
using TheWeatherNode.Core.Models;
using Xunit;

namespace TheWeatherNode.Core.Tests.Extensions
{
    /// <summary>
    /// Unit tests for the <see cref="UnitTypeExtensions"/> class.
    /// </summary>
    public class UnitTypeExtensionsTests
    {
        #region ToTemperatureUnit Tests

        [Theory]
        [InlineData("celsius", TemperatureUnit.Celsius)]
        [InlineData("Celsius", TemperatureUnit.Celsius)]
        [InlineData("CELSIUS", TemperatureUnit.Celsius)]
        [InlineData("fahrenheit", TemperatureUnit.Fahrenheit)]
        [InlineData("Fahrenheit", TemperatureUnit.Fahrenheit)]
        [InlineData("FAHRENHEIT", TemperatureUnit.Fahrenheit)]
        public void ToTemperatureUnit_WithValidValue_ReturnsCorrectEnum(string input, TemperatureUnit expected)
        {
            // Act
            var result = input.ToTemperatureUnit();

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void ToTemperatureUnit_WithEmptyOrWhitespace_ThrowsArgumentException(string input)
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => input.ToTemperatureUnit());
            Assert.Contains("not a valid temperature unit", ex.Message);
        }

        [Fact]
        public void ToTemperatureUnit_WithNull_ThrowsArgumentNullException()
        {
            // Arrange
            string? nullInput = null;

            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => nullInput!.ToTemperatureUnit());
            Assert.Equal("value", ex.ParamName);
        }

        [Theory]
        [InlineData("kelvin")]
        [InlineData("rankine")]
        [InlineData("invalid")]
        [InlineData("cels")]
        public void ToTemperatureUnit_WithInvalidValue_ThrowsArgumentException(string input)
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => input.ToTemperatureUnit());
            Assert.Contains("not a valid temperature unit", ex.Message);
        }

        #endregion

        #region ToTemperatureUnitString Tests

        [Theory]
        [InlineData(TemperatureUnit.Celsius, "Celsius")]
        [InlineData(TemperatureUnit.Fahrenheit, "Fahrenheit")]
        public void ToTemperatureUnitString_WithValidEnum_ReturnsCorrectString(TemperatureUnit input, string expected)
        {
            // Act
            var result = input.ToTemperatureUnitString();

            // Assert
            Assert.Equal(expected, result);
        }

        #endregion

        #region ToWindSpeedUnit Tests

        [Theory]
        [InlineData("kmh", WindSpeedUnit.Kmh)]
        [InlineData("KMH", WindSpeedUnit.Kmh)]
        [InlineData("Kmh", WindSpeedUnit.Kmh)]
        [InlineData("km/h", WindSpeedUnit.Kmh)]
        [InlineData("KM/H", WindSpeedUnit.Kmh)]
        [InlineData("km\\h", WindSpeedUnit.Kmh)]
        [InlineData("mph", WindSpeedUnit.Mph)]
        [InlineData("MPH", WindSpeedUnit.Mph)]
        [InlineData("Mph", WindSpeedUnit.Mph)]
        [InlineData("knots", WindSpeedUnit.Knots)]
        [InlineData("KNOTS", WindSpeedUnit.Knots)]
        [InlineData("Knots", WindSpeedUnit.Knots)]
        [InlineData("kn", WindSpeedUnit.Knots)]
        [InlineData("KN", WindSpeedUnit.Knots)]
        public void ToWindSpeedUnit_WithValidValue_ReturnsCorrectEnum(string input, WindSpeedUnit expected)
        {
            // Act
            var result = input.ToWindSpeedUnit();

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(" kmh ")]
        [InlineData(" km/h ")]
        [InlineData(" mph ")]
        [InlineData(" knots ")]
        [InlineData(" kn ")]
        public void ToWindSpeedUnit_WithValidValueAndWhitespace_ReturnsCorrectEnum(string input)
        {
            // Act
            var result = input.ToWindSpeedUnit();

            // Assert
            var normalized = input.Trim().ToLowerInvariant();
            var expected = normalized switch
            {
                "kmh" or "km/h" => WindSpeedUnit.Kmh,
                "mph" => WindSpeedUnit.Mph,
                "knots" or "kn" => WindSpeedUnit.Knots,
                _ => throw new InvalidOperationException($"Unexpected normalized value: {normalized}")
            };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToWindSpeedUnit_WithNull_ThrowsArgumentNullException()
        {
            // Arrange
            string? nullInput = null;

            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => nullInput!.ToWindSpeedUnit());
            Assert.Equal("value", ex.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void ToWindSpeedUnit_WithEmptyOrWhitespace_ThrowsArgumentException(string input)
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => input.ToWindSpeedUnit());
            Assert.Contains("not a valid wind speed unit", ex.Message);
        }

        [Theory]
        [InlineData("knots/hour")]
        [InlineData("kilometers")]
        [InlineData("kph/s")]
        [InlineData("invalid")]
        [InlineData("kph")]
        public void ToWindSpeedUnit_WithInvalidValue_ThrowsArgumentException(string input)
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => input.ToWindSpeedUnit());
            Assert.Contains("not a valid wind speed unit", ex.Message);
        }

        #endregion

        #region ToWindSpeedUnitString Tests

        [Theory]
        [InlineData(WindSpeedUnit.Kmh, "Kmh")]
        [InlineData(WindSpeedUnit.Mph, "Mph")]
        [InlineData(WindSpeedUnit.Knots, "Knots")]
        public void ToWindSpeedUnitString_WithValidEnum_ReturnsCorrectString(WindSpeedUnit input, string expected)
        {
            // Act
            var result = input.ToWindSpeedUnitString();

            // Assert
            Assert.Equal(expected, result);
        }

        #endregion

        #region ToWindSpeedUnitAbbreviation Tests

        [Theory]
        [InlineData(WindSpeedUnit.Kmh, "km/h")]
        [InlineData(WindSpeedUnit.Mph, "mph")]
        [InlineData(WindSpeedUnit.Knots, "knots")]
        public void ToWindSpeedUnitAbbreviation_WithValidEnum_ReturnsCorrectAbbreviation(WindSpeedUnit input, string expected)
        {
            // Act
            var result = input.ToWindSpeedUnitAbbreviation();

            // Assert
            Assert.Equal(expected, result);
        }

        #endregion

        #region ToPrecipitationUnit Tests

        [Theory]
        [InlineData("millimeters", PrecipitationUnit.Millimeters)]
        [InlineData("Millimeters", PrecipitationUnit.Millimeters)]
        [InlineData("MILLIMETERS", PrecipitationUnit.Millimeters)]
        [InlineData("mm", PrecipitationUnit.Millimeters)]
        [InlineData("MM", PrecipitationUnit.Millimeters)]
        [InlineData("inches", PrecipitationUnit.Inches)]
        [InlineData("Inches", PrecipitationUnit.Inches)]
        [InlineData("INCHES", PrecipitationUnit.Inches)]
        [InlineData("in", PrecipitationUnit.Inches)]
        [InlineData("IN", PrecipitationUnit.Inches)]
        public void ToPrecipitationUnit_WithValidValue_ReturnsCorrectEnum(string input, PrecipitationUnit expected)
        {
            // Act
            var result = input.ToPrecipitationUnit();

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(" millimeters ")]
        [InlineData(" mm ")]
        [InlineData(" inches ")]
        [InlineData(" in ")]
        public void ToPrecipitationUnit_WithValidValueAndWhitespace_ReturnsCorrectEnum(string input)
        {
            // Act
            var result = input.ToPrecipitationUnit();

            // Assert
            var trimmed = input.Trim().ToLowerInvariant();
            var expected = trimmed switch
            {
                "millimeters" or "mm" => PrecipitationUnit.Millimeters,
                "inches" or "in" => PrecipitationUnit.Inches,
                _ => throw new InvalidOperationException()
            };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToPrecipitationUnit_WithNull_ThrowsArgumentNullException()
        {
            // Arrange
            string? nullInput = null;

            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => nullInput!.ToPrecipitationUnit());
            Assert.Equal("value", ex.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void ToPrecipitationUnit_WithEmptyOrWhitespace_ThrowsArgumentException(string input)
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => input.ToPrecipitationUnit());
            Assert.Contains("not a valid precipitation unit", ex.Message);
        }

        [Theory]
        [InlineData("centimeters")]
        [InlineData("cm")]
        [InlineData("feet")]
        [InlineData("invalid")]
        public void ToPrecipitationUnit_WithInvalidValue_ThrowsArgumentException(string input)
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => input.ToPrecipitationUnit());
            Assert.Contains("not a valid precipitation unit", ex.Message);
        }

        #endregion

        #region ToPrecipitationUnitString Tests

        [Theory]
        [InlineData(PrecipitationUnit.Millimeters, "Millimeters")]
        [InlineData(PrecipitationUnit.Inches, "Inches")]
        public void ToPrecipitationUnitString_WithValidEnum_ReturnsCorrectString(PrecipitationUnit input, string expected)
        {
            // Act
            var result = input.ToPrecipitationUnitString();

            // Assert
            Assert.Equal(expected, result);
        }

        #endregion

        #region ToPrecipitationUnitAbbreviation Tests

        [Theory]
        [InlineData(PrecipitationUnit.Millimeters, "mm")]
        [InlineData(PrecipitationUnit.Inches, "in")]
        public void ToPrecipitationUnitAbbreviation_WithValidEnum_ReturnsCorrectAbbreviation(PrecipitationUnit input, string expected)
        {
            // Act
            var result = input.ToPrecipitationUnitAbbreviation();

            // Assert
            Assert.Equal(expected, result);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void RoundTrip_TemperatureUnit_ConversionIsConsistent()
        {
            // Arrange
            const string celsius = "celsius";

            // Act
            var unit = celsius.ToTemperatureUnit();
            var result = unit.ToTemperatureUnitString();

            // Assert
            Assert.Equal("Celsius", result);
        }

        [Fact]
        public void RoundTrip_WindSpeedUnit_ConversionIsConsistent()
        {
            // Arrange
            const string kmh = "km/h";

            // Act
            var unit = kmh.ToWindSpeedUnit();
            var abbreviation = unit.ToWindSpeedUnitAbbreviation();

            // Assert
            Assert.Equal("km/h", abbreviation);
        }

        [Fact]
        public void RoundTrip_PrecipitationUnit_ConversionIsConsistent()
        {
            // Arrange
            const string mm = "mm";

            // Act
            var unit = mm.ToPrecipitationUnit();
            var abbreviation = unit.ToPrecipitationUnitAbbreviation();

            // Assert
            Assert.Equal("mm", abbreviation);
        }

        [Fact]
        public void MultipleConversions_AllUnitsConvertCorrectly()
        {
            // Arrange & Act
            var tempUnit = "celsius".ToTemperatureUnit();
            var windUnit = "mph".ToWindSpeedUnit();
            var precipUnit = "inches".ToPrecipitationUnit();

            // Assert
            Assert.Equal(TemperatureUnit.Celsius, tempUnit);
            Assert.Equal(WindSpeedUnit.Mph, windUnit);
            Assert.Equal(PrecipitationUnit.Inches, precipUnit);
        }

        #endregion
    }
}