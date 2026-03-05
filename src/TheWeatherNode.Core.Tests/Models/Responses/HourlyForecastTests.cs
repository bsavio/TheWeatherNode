using TheWeatherNode.Core.Models.Responses;
using Xunit;

namespace TheWeatherNode.Core.Tests.Models.Responses
{
    /// <summary>
    /// Unit tests for the <see cref="HourlyForecast"/> class.
    /// </summary>
    public class HourlyForecastTests
    {
        #region Constructor and Instantiation Tests

        [Fact]
        public void Constructor_CreatesInstanceWithDefaultValues()
        {
            // Act
            var forecast = new HourlyForecast();

            // Assert
            Assert.NotNull(forecast);
            Assert.Equal(default(DateTime), forecast.Time);
            Assert.Equal(0.0, forecast.Temperature);
            Assert.Equal(0.0, forecast.FeelsLike);
            Assert.Equal(0.0, forecast.DewPoint);
            Assert.Equal(0.0, forecast.Humidity);
            Assert.Equal(0.0, forecast.WindSpeed);
            Assert.Equal(0.0, forecast.WindDirection);
            Assert.Equal(0.0, forecast.WindGusts);
            Assert.Equal(0.0, forecast.Precipitation);
            Assert.Equal(0.0, forecast.PrecipitationProbability);
            Assert.Equal(0.0, forecast.Pressure);
            Assert.Equal(0.0, forecast.CloudCover);
            Assert.Equal(0.0, forecast.Visibility);
            Assert.Equal(0, forecast.WeatherCode);
            Assert.False(forecast.IsDay);
        }

        #endregion

        #region Time Tests

        [Fact]
        public void Time_WithUtcTimestamp_CanBeSetAndRetrieved()
        {
            // Arrange
            var utcTime = new DateTime(2024, 2, 25, 14, 0, 0, DateTimeKind.Utc);
            var forecast = new HourlyForecast();

            // Act
            forecast.Time = utcTime;

            // Assert
            Assert.Equal(utcTime, forecast.Time);
            Assert.Equal(DateTimeKind.Utc, forecast.Time.Kind);
        }

        [Theory]
        [InlineData(0)]     // Midnight
        [InlineData(6)]     // 6 AM
        [InlineData(12)]    // Noon
        [InlineData(18)]    // 6 PM
        [InlineData(23)]    // 11 PM
        public void Time_WithDifferentHours_StoresCorrectly(int hour)
        {
            // Arrange
            var time = new DateTime(2024, 2, 25, hour, 0, 0, DateTimeKind.Utc);

            // Act
            var forecast = new HourlyForecast { Time = time };

            // Assert
            Assert.Equal(hour, forecast.Time.Hour);
        }

        #endregion

        #region Temperature Tests

        [Theory]
        [InlineData(15.2)]
        [InlineData(-5.0)]
        [InlineData(30.0)]
        public void Temperature_CanBeSetAndRetrieved(double temperature)
        {
            // Arrange
            var forecast = new HourlyForecast();

            // Act
            forecast.Temperature = temperature;

            // Assert
            Assert.Equal(temperature, forecast.Temperature);
        }

        #endregion

        #region FeelsLike Tests

        [Fact]
        public void FeelsLike_CanBeDifferentFromTemperature()
        {
            // Arrange & Act
            var forecast = new HourlyForecast
            {
                Temperature = 10.0,
                FeelsLike = 5.0
            };

            // Assert
            Assert.NotEqual(forecast.Temperature, forecast.FeelsLike);
        }

        #endregion

        #region DewPoint Tests

        [Theory]
        [InlineData(8.5)]
        [InlineData(20.0)]
        public void DewPoint_CanBeSetAndRetrieved(double dewPoint)
        {
            // Arrange
            var forecast = new HourlyForecast();

            // Act
            forecast.DewPoint = dewPoint;

            // Assert
            Assert.Equal(dewPoint, forecast.DewPoint);
        }

        #endregion

        #region Humidity Tests

        [Theory]
        [InlineData(0.0)]
        [InlineData(50.0)]
        [InlineData(100.0)]
        public void Humidity_CanBeSetAndRetrieved(double humidity)
        {
            // Arrange
            var forecast = new HourlyForecast();

            // Act
            forecast.Humidity = humidity;

            // Assert
            Assert.Equal(humidity, forecast.Humidity);
        }

        #endregion

        #region Wind Tests

        [Theory]
        [InlineData(12.3, 220.0, 18.5)]
        [InlineData(0.0, 0.0, 0.0)]
        [InlineData(50.0, 180.0, 65.0)]
        public void Wind_SpeedDirectionAndGusts_CanBeSetAndRetrieved(double speed, double direction, double gusts)
        {
            // Arrange
            var forecast = new HourlyForecast();

            // Act
            forecast.WindSpeed = speed;
            forecast.WindDirection = direction;
            forecast.WindGusts = gusts;

            // Assert
            Assert.Equal(speed, forecast.WindSpeed);
            Assert.Equal(direction, forecast.WindDirection);
            Assert.Equal(gusts, forecast.WindGusts);
        }

        #endregion

        #region Precipitation Tests

        [Theory]
        [InlineData(0.0, 0.0)]
        [InlineData(2.5, 50.0)]
        [InlineData(10.0, 100.0)]
        public void Precipitation_AmountAndProbability_CanBeSetAndRetrieved(double amount, double probability)
        {
            // Arrange
            var forecast = new HourlyForecast();

            // Act
            forecast.Precipitation = amount;
            forecast.PrecipitationProbability = probability;

            // Assert
            Assert.Equal(amount, forecast.Precipitation);
            Assert.Equal(probability, forecast.PrecipitationProbability);
        }

        #endregion

        #region Pressure Tests

        [Theory]
        [InlineData(1013.25)]
        [InlineData(1000.0)]
        public void Pressure_CanBeSetAndRetrieved(double pressure)
        {
            // Arrange
            var forecast = new HourlyForecast();

            // Act
            forecast.Pressure = pressure;

            // Assert
            Assert.Equal(pressure, forecast.Pressure);
        }

        #endregion

        #region Cloud Cover Tests

        [Theory]
        [InlineData(0.0)]
        [InlineData(50.0)]
        [InlineData(100.0)]
        public void CloudCover_CanBeSetAndRetrieved(double cloudCover)
        {
            // Arrange
            var forecast = new HourlyForecast();

            // Act
            forecast.CloudCover = cloudCover;

            // Assert
            Assert.Equal(cloudCover, forecast.CloudCover);
        }

        #endregion

        #region Visibility Tests

        [Theory]
        [InlineData(10000.0)]
        [InlineData(5000.0)]
        [InlineData(100.0)]
        public void Visibility_CanBeSetAndRetrieved(double visibility)
        {
            // Arrange
            var forecast = new HourlyForecast();

            // Act
            forecast.Visibility = visibility;

            // Assert
            Assert.Equal(visibility, forecast.Visibility);
        }

        #endregion

        #region Weather Code Tests

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        [InlineData(60)]
        [InlineData(95)]
        public void WeatherCode_CanBeSetAndRetrieved(int code)
        {
            // Arrange
            var forecast = new HourlyForecast();

            // Act
            forecast.WeatherCode = code;

            // Assert
            Assert.Equal(code, forecast.WeatherCode);
        }

        #endregion

        #region IsDay Tests

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsDay_CanBeSetAndRetrieved(bool isDay)
        {
            // Arrange
            var forecast = new HourlyForecast();

            // Act
            forecast.IsDay = isDay;

            // Assert
            Assert.Equal(isDay, forecast.IsDay);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void HourlyForecast_WithRealisticValues_CreatesValidInstance()
        {
            // Arrange & Act
            var forecast = new HourlyForecast
            {
                Time = new DateTime(2024, 2, 25, 14, 0, 0, DateTimeKind.Utc),
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
                CloudCover = 40.0,
                Visibility = 10000.0,
                WeatherCode = 1,
                IsDay = true
            };

            // Assert
            Assert.Equal(new DateTime(2024, 2, 25, 14, 0, 0, DateTimeKind.Utc), forecast.Time);
            Assert.Equal(15.2, forecast.Temperature);
            Assert.True(forecast.IsDay);
        }

        [Fact]
        public void HourlyForecast_WithConsecutiveHours_StoresCorrectly()
        {
            // Arrange & Act
            var forecast1 = new HourlyForecast 
            { 
                Time = new DateTime(2024, 2, 25, 14, 0, 0, DateTimeKind.Utc),
                Temperature = 15.0
            };
            var forecast2 = new HourlyForecast 
            { 
                Time = new DateTime(2024, 2, 25, 15, 0, 0, DateTimeKind.Utc),
                Temperature = 16.0
            };

            // Assert
            Assert.True(forecast2.Time > forecast1.Time);
            Assert.True(forecast2.Temperature > forecast1.Temperature);
        }

        [Fact]
        public void HourlyForecast_MultipleInstances_AreIndependent()
        {
            // Arrange & Act
            var forecast1 = new HourlyForecast 
            { 
                Time = new DateTime(2024, 2, 25, 14, 0, 0, DateTimeKind.Utc),
                Temperature = 15.0 
            };
            var forecast2 = new HourlyForecast 
            { 
                Time = new DateTime(2024, 2, 25, 15, 0, 0, DateTimeKind.Utc),
                Temperature = 16.0 
            };

            // Assert
            Assert.NotEqual(forecast1.Time, forecast2.Time);
            Assert.NotEqual(forecast1.Temperature, forecast2.Temperature);
            Assert.NotSame(forecast1, forecast2);
        }

        #endregion
    }
}