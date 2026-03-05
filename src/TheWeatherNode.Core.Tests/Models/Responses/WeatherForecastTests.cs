using TheWeatherNode.Core.Models.Responses;
using Xunit;

namespace TheWeatherNode.Core.Tests.Models.Responses
{
    /// <summary>
    /// Unit tests for the <see cref="WeatherForecast"/> class.
    /// </summary>
    public class WeatherForecastTests
    {
        #region Constructor and Instantiation Tests

        [Fact]
        public void Constructor_CreatesInstanceWithDefaultValues()
        {
            // Act
            var forecast = new WeatherForecast();

            // Assert
            Assert.NotNull(forecast);
            Assert.NotNull(forecast.Location);
            Assert.NotNull(forecast.Current);
            Assert.NotNull(forecast.Hourly);
            Assert.NotNull(forecast.Daily);
            Assert.Empty(forecast.Hourly);
            Assert.Empty(forecast.Daily);
            Assert.Equal(string.Empty, forecast.Timezone);
            Assert.Equal(string.Empty, forecast.TimezoneAbbreviation);
        }

        #endregion

        #region Location Tests

        [Fact]
        public void Location_CanBeSetAndRetrieved()
        {
            // Arrange
            var location = new Location 
            { 
                Name = "New York",
                Latitude = 40.7128,
                Longitude = -74.0060
            };
            var forecast = new WeatherForecast();

            // Act
            forecast.Location = location;

            // Assert
            Assert.Equal(location, forecast.Location);
            Assert.Equal("New York", forecast.Location.Name);
        }

        #endregion

        #region Current Weather Tests

        [Fact]
        public void Current_CanBeSetAndRetrieved()
        {
            // Arrange
            var current = new CurrentWeather 
            { 
                Temperature = 15.2,
                IsDay = true
            };
            var forecast = new WeatherForecast();

            // Act
            forecast.Current = current;

            // Assert
            Assert.Equal(current, forecast.Current);
            Assert.Equal(15.2, forecast.Current.Temperature);
            Assert.True(forecast.Current.IsDay);
        }

        #endregion

        #region Hourly Forecast Tests

        [Fact]
        public void Hourly_DefaultsToEmptyCollection()
        {
            // Arrange & Act
            var forecast = new WeatherForecast();

            // Assert
            Assert.NotNull(forecast.Hourly);
            Assert.Empty(forecast.Hourly);
        }

        [Fact]
        public void Hourly_CanBeSetWithSingleForecast()
        {
            // Arrange
            var hourly = new[]
            {
                new HourlyForecast 
                { 
                    Time = new DateTime(2024, 2, 25, 14, 0, 0, DateTimeKind.Utc),
                    Temperature = 15.0
                }
            };
            var forecast = new WeatherForecast();

            // Act
            forecast.Hourly = hourly;

            // Assert
            Assert.Single(forecast.Hourly);
            Assert.Equal(15.0, forecast.Hourly.First().Temperature);
        }

        [Fact]
        public void Hourly_CanBeSetWithMultipleForecasts()
        {
            // Arrange
            var hourly = new[]
            {
                new HourlyForecast { Time = new DateTime(2024, 2, 25, 14, 0, 0, DateTimeKind.Utc), Temperature = 15.0 },
                new HourlyForecast { Time = new DateTime(2024, 2, 25, 15, 0, 0, DateTimeKind.Utc), Temperature = 16.0 },
                new HourlyForecast { Time = new DateTime(2024, 2, 25, 16, 0, 0, DateTimeKind.Utc), Temperature = 17.0 }
            };
            var forecast = new WeatherForecast();

            // Act
            forecast.Hourly = hourly;

            // Assert
            Assert.Equal(3, forecast.Hourly.Count());
        }

        #endregion

        #region Daily Forecast Tests

        [Fact]
        public void Daily_DefaultsToEmptyCollection()
        {
            // Arrange & Act
            var forecast = new WeatherForecast();

            // Assert
            Assert.NotNull(forecast.Daily);
            Assert.Empty(forecast.Daily);
        }

        [Fact]
        public void Daily_CanBeSetWithSingleForecast()
        {
            // Arrange
            var daily = new[]
            {
                new DailyForecast 
                { 
                    Date = new DateTime(2024, 2, 25),
                    TemperatureMax = 20.0,
                    TemperatureMin = 10.0
                }
            };
            var forecast = new WeatherForecast();

            // Act
            forecast.Daily = daily;

            // Assert
            Assert.Single(forecast.Daily);
            Assert.Equal(20.0, forecast.Daily.First().TemperatureMax);
        }

        [Fact]
        public void Daily_CanBeSetWithMultipleForecasts()
        {
            // Arrange
            var daily = new[]
            {
                new DailyForecast { Date = new DateTime(2024, 2, 25), TemperatureMax = 20.0, TemperatureMin = 10.0 },
                new DailyForecast { Date = new DateTime(2024, 2, 26), TemperatureMax = 22.0, TemperatureMin = 12.0 },
                new DailyForecast { Date = new DateTime(2024, 2, 27), TemperatureMax = 18.0, TemperatureMin = 8.0 }
            };
            var forecast = new WeatherForecast();

            // Act
            forecast.Daily = daily;

            // Assert
            Assert.Equal(3, forecast.Daily.Count());
        }

        #endregion

        #region Timezone Tests

        [Theory]
        [InlineData("America/New_York")]
        [InlineData("Europe/London")]
        [InlineData("Asia/Tokyo")]
        public void Timezone_CanBeSetAndRetrieved(string timezone)
        {
            // Arrange
            var forecast = new WeatherForecast();

            // Act
            forecast.Timezone = timezone;

            // Assert
            Assert.Equal(timezone, forecast.Timezone);
        }

        #endregion

        #region Timezone Abbreviation Tests

        [Theory]
        [InlineData("EST")]
        [InlineData("GMT")]
        [InlineData("JST")]
        public void TimezoneAbbreviation_CanBeSetAndRetrieved(string abbr)
        {
            // Arrange
            var forecast = new WeatherForecast();

            // Act
            forecast.TimezoneAbbreviation = abbr;

            // Assert
            Assert.Equal(abbr, forecast.TimezoneAbbreviation);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void WeatherForecast_WithCompleteData_CreatesValidInstance()
        {
            // Arrange & Act
            var forecast = new WeatherForecast
            {
                Location = new Location
                {
                    Name = "New York",
                    Latitude = 40.7128,
                    Longitude = -74.0060,
                    Country = "United States",
                    Timezone = "America/New_York"
                },
                Current = new CurrentWeather
                {
                    Temperature = 15.2,
                    IsDay = true,
                    Time = new DateTime(2024, 2, 25, 14, 30, 0, DateTimeKind.Utc)
                },
                Hourly = new[]
                {
                    new HourlyForecast { Time = new DateTime(2024, 2, 25, 14, 0, 0, DateTimeKind.Utc), Temperature = 15.0 },
                    new HourlyForecast { Time = new DateTime(2024, 2, 25, 15, 0, 0, DateTimeKind.Utc), Temperature = 16.0 }
                },
                Daily = new[]
                {
                    new DailyForecast { Date = new DateTime(2024, 2, 25), TemperatureMax = 20.0, TemperatureMin = 10.0 },
                    new DailyForecast { Date = new DateTime(2024, 2, 26), TemperatureMax = 22.0, TemperatureMin = 12.0 }
                },
                Timezone = "America/New_York",
                TimezoneAbbreviation = "EST"
            };

            // Assert
            Assert.Equal("New York", forecast.Location.Name);
            Assert.Equal(15.2, forecast.Current.Temperature);
            Assert.Equal(2, forecast.Hourly.Count());
            Assert.Equal(2, forecast.Daily.Count());
            Assert.Equal("America/New_York", forecast.Timezone);
            Assert.Equal("EST", forecast.TimezoneAbbreviation);
        }

        [Fact]
        public void WeatherForecast_WithRealWorldScenario_Tokyo()
        {
            // Arrange & Act
            var forecast = new WeatherForecast
            {
                Location = new Location
                {
                    Name = "Tokyo",
                    Latitude = 35.6762,
                    Longitude = 139.6503,
                    Country = "Japan",
                    Timezone = "Asia/Tokyo"
                },
                Hourly = Enumerable.Range(0, 24)
                    .Select(i => new HourlyForecast
                    {
                        Time = new DateTime(2024, 2, 25, i, 0, 0, DateTimeKind.Utc),
                        Temperature = 10.0 + i * 0.5
                    })
                    .ToList(),
                Daily = Enumerable.Range(0, 7)
                    .Select(i => new DailyForecast
                    {
                        Date = new DateTime(2024, 2, 25).AddDays(i),
                        TemperatureMax = 25.0 - i,
                        TemperatureMin = 15.0 - i
                    })
                    .ToList(),
                Timezone = "Asia/Tokyo",
                TimezoneAbbreviation = "JST"
            };

            // Assert
            Assert.Equal("Tokyo", forecast.Location.Name);
            Assert.Equal(24, forecast.Hourly.Count());
            Assert.Equal(7, forecast.Daily.Count());
        }

        [Fact]
        public void WeatherForecast_MultipleInstances_AreIndependent()
        {
            // Arrange & Act
            var forecast1 = new WeatherForecast
            {
                Location = new Location { Name = "New York" },
                Timezone = "America/New_York"
            };
            var forecast2 = new WeatherForecast
            {
                Location = new Location { Name = "Paris" },
                Timezone = "Europe/Paris"
            };

            // Assert
            Assert.NotEqual(forecast1.Location.Name, forecast2.Location.Name);
            Assert.NotEqual(forecast1.Timezone, forecast2.Timezone);
            Assert.NotSame(forecast1, forecast2);
        }

        #endregion
    }
}