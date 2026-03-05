using TheWeatherNode.Core.Models;
using TheWeatherNode.Core.Models.Requests;
using TheWeatherNode.WeatherService.OpenMeteo.Builders;

namespace TheWeatherNode.WeatherService.OpenMeteo.Tests.Builders
{
    public class OpenMeteoRequestBuilderTests
    {
        private readonly WeatherRequest _validWeatherRequest = new()
        {
            Latitude = 40.7128,
            Longitude = -74.0060,
            TemperatureUnit = TemperatureUnit.Fahrenheit,
            WindSpeedUnit = WindSpeedUnit.Mph,
            PrecipitationUnit = PrecipitationUnit.Inches
        };

        [Fact]
        public void BuildForecastParameters_WithValidRequest_ShouldIncludeCoordinates()
        {
            // Act
            var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(_validWeatherRequest);

            // Assert
            Assert.Contains("latitude", parameters.Keys);
            Assert.Contains("longitude", parameters.Keys);
            Assert.Equal(_validWeatherRequest.Latitude, parameters["latitude"]);
            Assert.Equal(_validWeatherRequest.Longitude, parameters["longitude"]);
        }

        [Fact]
        public void BuildForecastParameters_WithValidRequest_ShouldIncludeUnitConversions()
        {
            // Act
            var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(_validWeatherRequest);

            // Assert
            Assert.Contains("temperature_unit", parameters.Keys);
            Assert.Contains("wind_speed_unit", parameters.Keys);
            Assert.Contains("precipitation_unit", parameters.Keys);
            Assert.Equal("fahrenheit", parameters["temperature_unit"]);
            Assert.Equal("mph", parameters["wind_speed_unit"]);
            Assert.Equal("inch", parameters["precipitation_unit"]);
        }

        [Fact]
        public void BuildForecastParameters_WithCelsiusUnit_ShouldMapCorrectly()
        {
            // Arrange
            var request = new WeatherRequest
            {
                Latitude = 40.7128,
                Longitude = -74.0060,
                TemperatureUnit = TemperatureUnit.Celsius,
                WindSpeedUnit = WindSpeedUnit.Kmh,
                PrecipitationUnit = PrecipitationUnit.Millimeters
            };

            // Act
            var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(request);

            // Assert
            Assert.Equal("celsius", parameters["temperature_unit"]);
            Assert.Equal("kmh", parameters["wind_speed_unit"]);
            Assert.Equal("mm", parameters["precipitation_unit"]);
        }

        [Fact]
        public void BuildForecastParameters_WithKnotsWindUnit_ShouldMapToKn()
        {
            // Arrange
            var request = new WeatherRequest
            {
                Latitude = 40.7128,
                Longitude = -74.0060,
                TemperatureUnit = TemperatureUnit.Celsius,
                WindSpeedUnit = WindSpeedUnit.Knots,
                PrecipitationUnit = PrecipitationUnit.Millimeters
            };

            // Act
            var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(request);

            // Assert
            Assert.Equal("kn", parameters["wind_speed_unit"]);
        }

        [Fact]
        public void BuildForecastParameters_IncludingCurrent_ShouldAddCurrentParameters()
        {
            // Act
            var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(
                _validWeatherRequest,
                includeCurrent: true);

            // Assert
            Assert.Contains("current", parameters.Keys);
            var currentList = parameters["current"] as List<string>;
            Assert.NotNull(currentList);
            Assert.NotEmpty(currentList);
        }

        [Fact]
        public void BuildForecastParameters_IncludingHourly_ShouldAddHourlyParameters()
        {
            // Act
            var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(
                _validWeatherRequest,
                includeHourly: true);

            // Assert
            Assert.Contains("hourly", parameters.Keys);
            var hourlyList = parameters["hourly"] as List<string>;
            Assert.NotNull(hourlyList);
            Assert.NotEmpty(hourlyList);
        }

        [Fact]
        public void BuildForecastParameters_IncludingDaily_ShouldAddDailyParameters()
        {
            // Act
            var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(
                _validWeatherRequest,
                includeDaily: true);

            // Assert
            Assert.Contains("daily", parameters.Keys);
            var dailyList = parameters["daily"] as List<string>;
            Assert.NotNull(dailyList);
            Assert.NotEmpty(dailyList);
        }

        [Fact]
        public void BuildForecastParameters_IncludingAll_ShouldAddAllDataTypes()
        {
            // Act
            var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(
                _validWeatherRequest,
                includeCurrent: true,
                includeHourly: true,
                includeDaily: true);

            // Assert
            Assert.Contains("current", parameters.Keys);
            Assert.Contains("hourly", parameters.Keys);
            Assert.Contains("daily", parameters.Keys);
        }

        [Fact]
        public void BuildForecastParameters_ExcludingAllDataTypes_ShouldOnlyIncludeCoordinatesAndUnits()
        {
            // Act
            var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(
                _validWeatherRequest,
                includeCurrent: false,
                includeHourly: false,
                includeDaily: false);

            // Assert
            Assert.Equal(5, parameters.Count); // latitude, longitude, temperature_unit, wind_speed_unit, precipitation_unit
            Assert.DoesNotContain("current", parameters.Keys);
            Assert.DoesNotContain("hourly", parameters.Keys);
            Assert.DoesNotContain("daily", parameters.Keys);
        }

        [Fact]
        public void TemperatureMappings_ShouldContainAllUnits()
        {
            // Act & Assert
            Assert.Contains(TemperatureUnit.Celsius, OpenMeteoRequestBuilder.TemperatureMappings.Keys);
            Assert.Contains(TemperatureUnit.Fahrenheit, OpenMeteoRequestBuilder.TemperatureMappings.Keys);
        }

        [Fact]
        public void BuildForecastParameters_WithNegativeCoordinates_ShouldAcceptValidValues()
        {
            // Arrange
            var request = new WeatherRequest
            {
                Latitude = -33.8688,
                Longitude = 151.2093,
                TemperatureUnit = TemperatureUnit.Celsius,
                WindSpeedUnit = WindSpeedUnit.Kmh,
                PrecipitationUnit = PrecipitationUnit.Millimeters
            };

            // Act
            var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(request);

            // Assert
            Assert.Equal(-33.8688, parameters["latitude"]);
            Assert.Equal(151.2093, parameters["longitude"]);
        }
    }
}