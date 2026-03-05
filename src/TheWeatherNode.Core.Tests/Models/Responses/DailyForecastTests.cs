using TheWeatherNode.Core.Models.Responses;
using Xunit;

namespace TheWeatherNode.Core.Tests.Models.Responses
{
    /// <summary>
    /// Unit tests for the <see cref="DailyForecast"/> class.
    /// </summary>
    public class DailyForecastTests
    {
        #region Constructor and Instantiation Tests

        [Fact]
        public void Constructor_CreatesInstanceWithDefaultValues()
        {
            // Act
            var forecast = new DailyForecast();

            // Assert
            Assert.NotNull(forecast);
            Assert.Equal(default(DateTime), forecast.Date);
            Assert.Equal(0.0, forecast.TemperatureMax);
            Assert.Equal(0.0, forecast.TemperatureMin);
            Assert.Equal(0.0, forecast.FeelsLikeMax);
            Assert.Equal(0.0, forecast.FeelsLikeMin);
            Assert.Equal(0.0, forecast.HumidityMax);
            Assert.Equal(0.0, forecast.HumidityMin);
            Assert.Equal(0.0, forecast.PressureMean);
            Assert.Equal(0.0, forecast.PrecipitationSum);
            Assert.Equal(0.0, forecast.PrecipitationProbabilityMax);
            Assert.Equal(0.0, forecast.WindSpeedMax);
            Assert.Equal(0.0, forecast.WindGustsMax);
            Assert.Equal(0.0, forecast.WindDirectionDominant);
            Assert.Equal(0.0, forecast.UvIndexMax);
            Assert.Equal(0, forecast.WeatherCode);
            Assert.Equal(default(DateTime), forecast.Sunrise);
            Assert.Equal(default(DateTime), forecast.Sunset);
        }

        #endregion

        #region Date Tests

        [Fact]
        public void Date_CanBeSetAndRetrieved()
        {
            // Arrange
            var date = new DateTime(2024, 2, 25);
            var forecast = new DailyForecast();

            // Act
            forecast.Date = date;

            // Assert
            Assert.Equal(date, forecast.Date);
        }

        [Fact]
        public void Date_WithDifferentDates_StoresCorrectly()
        {
            // Arrange
            var date1 = new DateTime(2024, 1, 1);
            var date2 = new DateTime(2024, 12, 31);

            // Act
            var forecast1 = new DailyForecast { Date = date1 };
            var forecast2 = new DailyForecast { Date = date2 };

            // Assert
            Assert.Equal(date1, forecast1.Date);
            Assert.Equal(date2, forecast2.Date);
            Assert.NotEqual(forecast1.Date, forecast2.Date);
        }

        #endregion

        #region Temperature Tests

        [Theory]
        [InlineData(18.5, 10.2)]
        [InlineData(35.0, 20.0)]
        [InlineData(-5.0, -15.0)]
        public void Temperature_MaxAndMin_CanBeSetAndRetrieved(double max, double min)
        {
            // Arrange
            var forecast = new DailyForecast();

            // Act
            forecast.TemperatureMax = max;
            forecast.TemperatureMin = min;

            // Assert
            Assert.Equal(max, forecast.TemperatureMax);
            Assert.Equal(min, forecast.TemperatureMin);
        }

        [Fact]
        public void TemperatureMax_IsTypicallyGreaterThanMin()
        {
            // Arrange & Act
            var forecast = new DailyForecast
            {
                TemperatureMax = 25.0,
                TemperatureMin = 15.0
            };

            // Assert
            Assert.True(forecast.TemperatureMax > forecast.TemperatureMin);
        }

        #endregion

        #region FeelsLike Temperature Tests

        [Theory]
        [InlineData(17.1, 9.0)]
        [InlineData(30.0, 18.0)]
        public void FeelsLike_MaxAndMin_CanBeSetAndRetrieved(double max, double min)
        {
            // Arrange
            var forecast = new DailyForecast();

            // Act
            forecast.FeelsLikeMax = max;
            forecast.FeelsLikeMin = min;

            // Assert
            Assert.Equal(max, forecast.FeelsLikeMax);
            Assert.Equal(min, forecast.FeelsLikeMin);
        }

        #endregion

        #region Humidity Tests

        [Theory]
        [InlineData(75.0, 55.0)]
        [InlineData(100.0, 0.0)]
        public void Humidity_MaxAndMin_CanBeSetAndRetrieved(double max, double min)
        {
            // Arrange
            var forecast = new DailyForecast();

            // Act
            forecast.HumidityMax = max;
            forecast.HumidityMin = min;

            // Assert
            Assert.Equal(max, forecast.HumidityMax);
            Assert.Equal(min, forecast.HumidityMin);
        }

        #endregion

        #region Pressure Tests

        [Theory]
        [InlineData(1013.5)]
        [InlineData(1000.0)]
        [InlineData(1030.0)]
        public void PressureMean_CanBeSetAndRetrieved(double pressure)
        {
            // Arrange
            var forecast = new DailyForecast();

            // Act
            forecast.PressureMean = pressure;

            // Assert
            Assert.Equal(pressure, forecast.PressureMean);
        }

        #endregion

        #region Precipitation Tests

        [Theory]
        [InlineData(2.5, 65.0)]
        [InlineData(0.0, 0.0)]
        [InlineData(50.0, 100.0)]
        public void Precipitation_SumAndProbability_CanBeSetAndRetrieved(double sum, double probability)
        {
            // Arrange
            var forecast = new DailyForecast();

            // Act
            forecast.PrecipitationSum = sum;
            forecast.PrecipitationProbabilityMax = probability;

            // Assert
            Assert.Equal(sum, forecast.PrecipitationSum);
            Assert.Equal(probability, forecast.PrecipitationProbabilityMax);
        }

        #endregion

        #region Wind Tests

        [Theory]
        [InlineData(25.0, 35.0, 220.0)]
        [InlineData(15.0, 22.0, 90.0)]
        public void Wind_SpeedGustsAndDirection_CanBeSetAndRetrieved(double speed, double gusts, double direction)
        {
            // Arrange
            var forecast = new DailyForecast();

            // Act
            forecast.WindSpeedMax = speed;
            forecast.WindGustsMax = gusts;
            forecast.WindDirectionDominant = direction;

            // Assert
            Assert.Equal(speed, forecast.WindSpeedMax);
            Assert.Equal(gusts, forecast.WindGustsMax);
            Assert.Equal(direction, forecast.WindDirectionDominant);
        }

        [Fact]
        public void WindGustsMax_IsTypicallyGreaterThanWindSpeedMax()
        {
            // Arrange & Act
            var forecast = new DailyForecast
            {
                WindSpeedMax = 20.0,
                WindGustsMax = 30.0
            };

            // Assert
            Assert.True(forecast.WindGustsMax > forecast.WindSpeedMax);
        }

        #endregion

        #region UV Index Tests

        [Theory]
        [InlineData(4.2)]
        [InlineData(0.0)]
        [InlineData(12.0)]
        public void UvIndexMax_CanBeSetAndRetrieved(double uvIndex)
        {
            // Arrange
            var forecast = new DailyForecast();

            // Act
            forecast.UvIndexMax = uvIndex;

            // Assert
            Assert.Equal(uvIndex, forecast.UvIndexMax);
        }

        #endregion

        #region Weather Code Tests

        [Theory]
        [InlineData(0)]     // Clear
        [InlineData(3)]     // Overcast
        [InlineData(60)]    // Rain
        [InlineData(95)]    // Thunderstorm
        public void WeatherCode_CanBeSetAndRetrieved(int code)
        {
            // Arrange
            var forecast = new DailyForecast();

            // Act
            forecast.WeatherCode = code;

            // Assert
            Assert.Equal(code, forecast.WeatherCode);
        }

        #endregion

        #region Sunrise/Sunset Tests

        [Fact]
        public void Sunrise_And_Sunset_CanBeSetAndRetrieved()
        {
            // Arrange
            var sunrise = new DateTime(2024, 2, 25, 7, 15, 0, DateTimeKind.Utc);
            var sunset = new DateTime(2024, 2, 25, 18, 45, 0, DateTimeKind.Utc);
            var forecast = new DailyForecast();

            // Act
            forecast.Sunrise = sunrise;
            forecast.Sunset = sunset;

            // Assert
            Assert.Equal(sunrise, forecast.Sunrise);
            Assert.Equal(sunset, forecast.Sunset);
        }

        [Fact]
        public void Sunset_IsAfterSunrise()
        {
            // Arrange & Act
            var forecast = new DailyForecast
            {
                Sunrise = new DateTime(2024, 2, 25, 7, 15, 0, DateTimeKind.Utc),
                Sunset = new DateTime(2024, 2, 25, 18, 45, 0, DateTimeKind.Utc)
            };

            // Assert
            Assert.True(forecast.Sunset > forecast.Sunrise);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void DailyForecast_WithRealisticValues_CreatesValidInstance()
        {
            // Arrange & Act
            var forecast = new DailyForecast
            {
                Date = new DateTime(2024, 2, 25),
                TemperatureMax = 18.5,
                TemperatureMin = 10.2,
                FeelsLikeMax = 17.1,
                FeelsLikeMin = 9.0,
                HumidityMax = 75.0,
                HumidityMin = 55.0,
                PressureMean = 1013.5,
                PrecipitationSum = 2.5,
                PrecipitationProbabilityMax = 65.0,
                WindSpeedMax = 25.0,
                WindGustsMax = 35.0,
                WindDirectionDominant = 220.0,
                UvIndexMax = 4.2,
                WeatherCode = 3,
                Sunrise = new DateTime(2024, 2, 25, 7, 15, 0, DateTimeKind.Utc),
                Sunset = new DateTime(2024, 2, 25, 18, 45, 0, DateTimeKind.Utc)
            };

            // Assert
            Assert.Equal(new DateTime(2024, 2, 25), forecast.Date);
            Assert.Equal(18.5, forecast.TemperatureMax);
            Assert.Equal(10.2, forecast.TemperatureMin);
            Assert.True(forecast.TemperatureMax > forecast.TemperatureMin);
            Assert.True(forecast.Sunset > forecast.Sunrise);
        }

        [Fact]
        public void DailyForecast_MultipleInstances_AreIndependent()
        {
            // Arrange & Act
            var forecast1 = new DailyForecast 
            { 
                Date = new DateTime(2024, 2, 25),
                TemperatureMax = 20.0 
            };
            var forecast2 = new DailyForecast 
            { 
                Date = new DateTime(2024, 2, 26),
                TemperatureMax = 15.0 
            };

            // Assert
            Assert.NotEqual(forecast1.Date, forecast2.Date);
            Assert.NotEqual(forecast1.TemperatureMax, forecast2.TemperatureMax);
            Assert.NotSame(forecast1, forecast2);
        }

        #endregion
    }
}