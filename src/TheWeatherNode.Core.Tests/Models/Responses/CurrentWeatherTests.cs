using TheWeatherNode.Core.Models.Responses;
using Xunit;

namespace TheWeatherNode.Core.Tests.Models.Responses
{
    /// <summary>
    /// Unit tests for the <see cref="CurrentWeather"/> class.
    /// </summary>
    public class CurrentWeatherTests
    {
        #region Constructor and Instantiation Tests

        [Fact]
        public void Constructor_CreatesInstanceWithDefaultValues()
        {
            // Act
            var weather = new CurrentWeather();

            // Assert
            Assert.NotNull(weather);
            Assert.Equal(0.0, weather.Temperature);
            Assert.Equal(0.0, weather.FeelsLike);
            Assert.Equal(0.0, weather.DewPoint);
            Assert.Equal(0.0, weather.Humidity);
            Assert.Equal(0.0, weather.WindSpeed);
            Assert.Equal(0.0, weather.WindDirection);
            Assert.Equal(0.0, weather.WindGusts);
            Assert.Equal(0.0, weather.Precipitation);
            Assert.Equal(0.0, weather.PrecipitationProbability);
            Assert.Equal(0.0, weather.Pressure);
            Assert.Equal(0.0, weather.Visibility);
            Assert.Equal(0.0, weather.UvIndex);
            Assert.Equal(0.0, weather.CloudCover);
            Assert.Equal(0, weather.WeatherCode);
            Assert.False(weather.IsDay);
            Assert.Equal(default(DateTime), weather.Time);
        }

        #endregion

        #region Temperature Tests

        [Theory]
        [InlineData(15.2)]
        [InlineData(0.0)]
        [InlineData(-10.5)]
        [InlineData(35.8)]
        [InlineData(-40.0)]
        public void Temperature_CanBeSetAndRetrieved(double temperature)
        {
            // Arrange
            var weather = new CurrentWeather();

            // Act
            weather.Temperature = temperature;

            // Assert
            Assert.Equal(temperature, weather.Temperature);
        }

        [Theory]
        [InlineData(32.0)]   // 0°C in Fahrenheit
        [InlineData(68.0)]   // 20°C in Fahrenheit
        [InlineData(86.0)]   // 30°C in Fahrenheit
        [InlineData(-4.0)]   // -20°C in Fahrenheit
        public void Temperature_WithImperialUnits_StoresCorrectly(double fahrenheit)
        {
            // Arrange & Act
            var weather = new CurrentWeather { Temperature = fahrenheit };

            // Assert
            Assert.Equal(fahrenheit, weather.Temperature);
        }

        #endregion

        #region FeelsLike Tests

        [Theory]
        [InlineData(14.1)]
        [InlineData(10.5)]
        [InlineData(-15.0)]
        [InlineData(28.3)]
        public void FeelsLike_CanBeSetAndRetrieved(double feelsLike)
        {
            // Arrange
            var weather = new CurrentWeather();

            // Act
            weather.FeelsLike = feelsLike;

            // Assert
            Assert.Equal(feelsLike, weather.FeelsLike);
        }

        [Fact]
        public void FeelsLike_CanBeDifferentFromTemperature()
        {
            // Arrange & Act
            var weather = new CurrentWeather 
            { 
                Temperature = 10.0,
                FeelsLike = 5.0  // Wind chill effect
            };

            // Assert
            Assert.NotEqual(weather.Temperature, weather.FeelsLike);
            Assert.True(weather.FeelsLike < weather.Temperature);
        }

        #endregion

        #region DewPoint Tests

        [Theory]
        [InlineData(8.5)]
        [InlineData(5.0)]
        [InlineData(20.0)]
        [InlineData(-5.0)]
        public void DewPoint_CanBeSetAndRetrieved(double dewPoint)
        {
            // Arrange
            var weather = new CurrentWeather();

            // Act
            weather.DewPoint = dewPoint;

            // Assert
            Assert.Equal(dewPoint, weather.DewPoint);
        }

        [Fact]
        public void DewPoint_IsTypicallyLowerThanTemperature()
        {
            // Arrange & Act
            var weather = new CurrentWeather 
            { 
                Temperature = 20.0,
                DewPoint = 10.0
            };

            // Assert
            Assert.True(weather.DewPoint < weather.Temperature);
        }

        #endregion

        #region Humidity Tests

        [Theory]
        [InlineData(0.0)]      // Completely dry
        [InlineData(50.0)]     // Moderate
        [InlineData(100.0)]    // Saturated
        [InlineData(65.5)]     // Typical comfortable
        public void Humidity_WithValidRange_CanBeSetAndRetrieved(double humidity)
        {
            // Arrange
            var weather = new CurrentWeather();

            // Act
            weather.Humidity = humidity;

            // Assert
            Assert.Equal(humidity, weather.Humidity);
        }

        [Theory]
        [InlineData(-10.0)]    // Below valid range
        [InlineData(150.0)]    // Above valid range
        public void Humidity_OutsideValidRange_StillStoresValue(double humidity)
        {
            // Arrange & Act
            var weather = new CurrentWeather { Humidity = humidity };

            // Assert - No validation in model, just stores the value
            Assert.Equal(humidity, weather.Humidity);
        }

        #endregion

        #region Wind Speed Tests

        [Theory]
        [InlineData(0.0)]      // Calm
        [InlineData(12.3)]     // Light breeze
        [InlineData(50.0)]     // Strong wind
        [InlineData(100.0)]    // Hurricane force
        public void WindSpeed_CanBeSetAndRetrieved(double windSpeed)
        {
            // Arrange
            var weather = new CurrentWeather();

            // Act
            weather.WindSpeed = windSpeed;

            // Assert
            Assert.Equal(windSpeed, weather.WindSpeed);
        }

        #endregion

        #region Wind Direction Tests

        [Theory]
        [InlineData(0.0)]      // North
        [InlineData(90.0)]     // East
        [InlineData(180.0)]    // South
        [InlineData(270.0)]    // West
        [InlineData(45.5)]     // Northeast
        [InlineData(359.9)]    // Just before North
        public void WindDirection_WithValidRange_CanBeSetAndRetrieved(double windDirection)
        {
            // Arrange
            var weather = new CurrentWeather();

            // Act
            weather.WindDirection = windDirection;

            // Assert
            Assert.Equal(windDirection, weather.WindDirection);
        }

        [Theory]
        [InlineData(-45.0)]    // Below valid range
        [InlineData(360.0)]    // At boundary
        [InlineData(720.0)]    // Multiple rotations
        public void WindDirection_OutsideValidRange_StillStoresValue(double windDirection)
        {
            // Arrange & Act
            var weather = new CurrentWeather { WindDirection = windDirection };

            // Assert - No validation, just stores
            Assert.Equal(windDirection, weather.WindDirection);
        }

        #endregion

        #region Wind Gusts Tests

        [Theory]
        [InlineData(18.5)]
        [InlineData(25.0)]
        [InlineData(35.0)]
        public void WindGusts_CanBeSetAndRetrieved(double windGusts)
        {
            // Arrange
            var weather = new CurrentWeather();

            // Act
            weather.WindGusts = windGusts;

            // Assert
            Assert.Equal(windGusts, weather.WindGusts);
        }

        [Fact]
        public void WindGusts_IsTypicallyHigherThanWindSpeed()
        {
            // Arrange & Act
            var weather = new CurrentWeather 
            { 
                WindSpeed = 12.0,
                WindGusts = 18.5
            };

            // Assert
            Assert.True(weather.WindGusts > weather.WindSpeed);
        }

        #endregion

        #region Precipitation Tests

        [Theory]
        [InlineData(0.0)]      // No rain
        [InlineData(2.5)]      // Light rain
        [InlineData(10.0)]     // Moderate rain
        [InlineData(50.0)]     // Heavy rain
        public void Precipitation_CanBeSetAndRetrieved(double precipitation)
        {
            // Arrange
            var weather = new CurrentWeather();

            // Act
            weather.Precipitation = precipitation;

            // Assert
            Assert.Equal(precipitation, weather.Precipitation);
        }

        #endregion

        #region Precipitation Probability Tests

        [Theory]
        [InlineData(0.0)]      // No chance
        [InlineData(25.0)]     // Low chance
        [InlineData(50.0)]     // Moderate chance
        [InlineData(100.0)]    // Certain
        public void PrecipitationProbability_WithValidRange_CanBeSetAndRetrieved(double probability)
        {
            // Arrange
            var weather = new CurrentWeather();

            // Act
            weather.PrecipitationProbability = probability;

            // Assert
            Assert.Equal(probability, weather.PrecipitationProbability);
        }

        #endregion

        #region Pressure Tests

        [Theory]
        [InlineData(1013.25)]  // Standard atmospheric pressure
        [InlineData(1000.0)]   // Low pressure system
        [InlineData(1030.0)]   // High pressure system
        public void Pressure_CanBeSetAndRetrieved(double pressure)
        {
            // Arrange
            var weather = new CurrentWeather();

            // Act
            weather.Pressure = pressure;

            // Assert
            Assert.Equal(pressure, weather.Pressure);
        }

        #endregion

        #region Visibility Tests

        [Theory]
        [InlineData(10000.0)]  // Perfect visibility
        [InlineData(5000.0)]   // Moderate visibility
        [InlineData(100.0)]    // Very limited visibility (fog)
        [InlineData(0.0)]      // No visibility
        public void Visibility_CanBeSetAndRetrieved(double visibility)
        {
            // Arrange
            var weather = new CurrentWeather();

            // Act
            weather.Visibility = visibility;

            // Assert
            Assert.Equal(visibility, weather.Visibility);
        }

        #endregion

        #region UV Index Tests

        [Theory]
        [InlineData(0.0)]      // No UV exposure
        [InlineData(3.2)]      // Moderate exposure
        [InlineData(8.5)]      // Very high exposure
        [InlineData(11.0)]     // Extreme exposure
        public void UvIndex_CanBeSetAndRetrieved(double uvIndex)
        {
            // Arrange
            var weather = new CurrentWeather();

            // Act
            weather.UvIndex = uvIndex;

            // Assert
            Assert.Equal(uvIndex, weather.UvIndex);
        }

        #endregion

        #region Cloud Cover Tests

        [Theory]
        [InlineData(0.0)]      // Clear sky
        [InlineData(25.0)]     // Mostly clear
        [InlineData(50.0)]     // Partly cloudy
        [InlineData(100.0)]    // Completely overcast
        public void CloudCover_WithValidRange_CanBeSetAndRetrieved(double cloudCover)
        {
            // Arrange
            var weather = new CurrentWeather();

            // Act
            weather.CloudCover = cloudCover;

            // Assert
            Assert.Equal(cloudCover, weather.CloudCover);
        }

        #endregion

        #region Weather Code Tests

        [Theory]
        [InlineData(0)]        // Clear sky
        [InlineData(3)]        // Overcast
        [InlineData(45)]       // Foggy
        [InlineData(60)]       // Rain
        [InlineData(80)]       // Rain showers
        [InlineData(95)]       // Thunderstorm
        public void WeatherCode_CanBeSetAndRetrieved(int weatherCode)
        {
            // Arrange
            var weather = new CurrentWeather();

            // Act
            weather.WeatherCode = weatherCode;

            // Assert
            Assert.Equal(weatherCode, weather.WeatherCode);
        }

        #endregion

        #region IsDay Tests

        [Theory]
        [InlineData(true)]     // Daytime
        [InlineData(false)]    // Nighttime
        public void IsDay_CanBeSetAndRetrieved(bool isDay)
        {
            // Arrange
            var weather = new CurrentWeather();

            // Act
            weather.IsDay = isDay;

            // Assert
            Assert.Equal(isDay, weather.IsDay);
        }

        #endregion

        #region Time Tests

        [Fact]
        public void Time_WithUtcTimestamp_CanBeSetAndRetrieved()
        {
            // Arrange
            var utcTime = new DateTime(2024, 2, 25, 14, 30, 0, DateTimeKind.Utc);
            var weather = new CurrentWeather();

            // Act
            weather.Time = utcTime;

            // Assert
            Assert.Equal(utcTime, weather.Time);
            Assert.Equal(DateTimeKind.Utc, weather.Time.Kind);
        }

        [Fact]
        public void Time_DefaultValue_IsMinValue()
        {
            // Arrange & Act
            var weather = new CurrentWeather();

            // Assert
            Assert.Equal(default(DateTime), weather.Time);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void CurrentWeather_WithRealisticValues_CreatesValidInstance()
        {
            // Arrange & Act
            var weather = new CurrentWeather
            {
                Temperature = 15.2,
                FeelsLike = 14.1,
                DewPoint = 8.5,
                Humidity = 65.0,
                WindSpeed = 12.3,
                WindDirection = 220.0,
                WindGusts = 18.5,
                Precipitation = 0.0,
                PrecipitationProbability = 10.0,
                Pressure = 1013.25,
                Visibility = 10000.0,
                UvIndex = 3.2,
                CloudCover = 40.0,
                WeatherCode = 1,
                IsDay = true,
                Time = new DateTime(2024, 2, 25, 14, 30, 0, DateTimeKind.Utc)
            };

            // Assert
            Assert.Equal(15.2, weather.Temperature);
            Assert.Equal(14.1, weather.FeelsLike);
            Assert.Equal(8.5, weather.DewPoint);
            Assert.Equal(65.0, weather.Humidity);
            Assert.Equal(12.3, weather.WindSpeed);
            Assert.Equal(220.0, weather.WindDirection);
            Assert.Equal(18.5, weather.WindGusts);
            Assert.Equal(0.0, weather.Precipitation);
            Assert.Equal(10.0, weather.PrecipitationProbability);
            Assert.Equal(1013.25, weather.Pressure);
            Assert.Equal(10000.0, weather.Visibility);
            Assert.Equal(3.2, weather.UvIndex);
            Assert.Equal(40.0, weather.CloudCover);
            Assert.Equal(1, weather.WeatherCode);
            Assert.True(weather.IsDay);
            Assert.Equal(new DateTime(2024, 2, 25, 14, 30, 0, DateTimeKind.Utc), weather.Time);
        }

        [Fact]
        public void CurrentWeather_WithExtremeColdValues_StoresCorrectly()
        {
            // Arrange & Act
            var weather = new CurrentWeather
            {
                Temperature = -40.0,
                FeelsLike = -50.0,
                DewPoint = -45.0,
                Humidity = 75.0,
                WindSpeed = 45.0,
                WindGusts = 60.0,
                WeatherCode = 73,  // Heavy snow
                IsDay = false
            };

            // Assert
            Assert.Equal(-40.0, weather.Temperature);
            Assert.Equal(-50.0, weather.FeelsLike);
            Assert.Equal(-45.0, weather.DewPoint);
            Assert.True(weather.WindSpeed > 40.0);
        }

        [Fact]
        public void CurrentWeather_WithExtremeHotValues_StoresCorrectly()
        {
            // Arrange & Act
            var weather = new CurrentWeather
            {
                Temperature = 50.0,
                FeelsLike = 55.0,
                DewPoint = 25.0,
                Humidity = 20.0,
                UvIndex = 12.0,
                WeatherCode = 0,  // Clear sky
                IsDay = true
            };

            // Assert
            Assert.Equal(50.0, weather.Temperature);
            Assert.Equal(55.0, weather.FeelsLike);
            Assert.True(weather.FeelsLike > weather.Temperature);
            Assert.Equal(12.0, weather.UvIndex);
        }

        [Fact]
        public void CurrentWeather_MultipleInstances_AreIndependent()
        {
            // Arrange & Act
            var weather1 = new CurrentWeather { Temperature = 20.0, Humidity = 60.0 };
            var weather2 = new CurrentWeather { Temperature = 15.0, Humidity = 70.0 };

            // Assert
            Assert.NotEqual(weather1.Temperature, weather2.Temperature);
            Assert.NotEqual(weather1.Humidity, weather2.Humidity);
            Assert.NotSame(weather1, weather2);
        }

        #endregion
    }
}