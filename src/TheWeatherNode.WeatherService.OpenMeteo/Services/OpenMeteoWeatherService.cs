using Microsoft.Extensions.Logging;
using TheWeatherNode.Core.Interfaces;
using TheWeatherNode.Core.Models;
using TheWeatherNode.WeatherService.OpenMeteo.Builders;
using TheWeatherNode.WeatherService.OpenMeteo.Client;
using TheWeatherNode.WeatherService.OpenMeteo.DTOs;

namespace TheWeatherNode.WeatherService.OpenMeteo.Services
{
    /// <summary>
    /// Implements weather forecast data retrieval using the Open-Meteo API.
    /// </summary>
    /// <remarks>
    /// This service acts as an adapter between the application's weather interface
    /// (<see cref="IWeatherService"/>) and the Open-Meteo weather data provider.
    /// It handles the transformation of Open-Meteo DTO objects into domain models
    /// and manages error handling and logging for weather data operations.
    /// 
    /// The service supports three types of weather forecast data:
    /// - Current weather conditions
    /// - Hourly forecasts
    /// - Daily forecasts
    /// 
    /// All weather data is retrieved in metric units (Celsius, km/h, mm, hPa)
    /// and can be converted to imperial units by consuming services as needed.
    /// </remarks>
    public class OpenMeteoWeatherService : IWeatherService
    {
        private readonly IOpenMeteoClient _openMeteoClient;
        private readonly ILogger<OpenMeteoWeatherService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenMeteoWeatherService"/> class.
        /// </summary>
        /// <param name="openMeteoClient">The Open-Meteo API client for making HTTP requests to the weather API.</param>
        /// <param name="logger">The logger for recording service operations, warnings, and errors.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="openMeteoClient"/> or <paramref name="logger"/> is null.
        /// </exception>
        public OpenMeteoWeatherService(IOpenMeteoClient openMeteoClient, ILogger<OpenMeteoWeatherService> logger)
        {
            _openMeteoClient = openMeteoClient;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves the current weather conditions for the specified geographic coordinates.
        /// </summary>
        /// <param name="latitude">The latitude coordinate in degrees (-90 to 90). Positive values are north of the equator.</param>
        /// <param name="longitude">The longitude coordinate in degrees (-180 to 180). Positive values are east of the prime meridian.</param>
        /// <returns>
        /// A task representing the asynchronous operation that returns a <see cref="CurrentWeather"/> object
        /// containing current weather data including temperature, humidity, wind, precipitation, and more.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the Open-Meteo API call fails or returns null.
        /// Thrown when the API response does not contain current weather data.
        /// </exception>
        /// <remarks>
        /// This method queries the Open-Meteo forecast API with the current=true parameter
        /// to retrieve real-time weather conditions. The API request is built using
        /// <see cref="OpenMeteoRequestBuilder.BuildForecastParameters"/> which configures
        /// all necessary parameters for current weather retrieval.
        /// 
        /// Temperature values are returned in Celsius. Wind speeds are in km/h.
        /// Pressure is in hectopascals (hPa). Visibility is in meters.
        /// Humidity and cloud cover are percentages (0-100).
        /// </remarks>
        public async Task<CurrentWeather> GetCurrentWeatherAsync(double latitude, double longitude)
        {
            var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(latitude, longitude, includeCurrent: true);
            var result = await _openMeteoClient.GetAsync<OpenMeteoForecastResponseDto>("forecast", parameters) ?? throw new InvalidOperationException("Failed to retrieve current weather data from Open-Meteo API.");
            var openMeteoCurrentDto = result.Current ?? throw new InvalidOperationException("Current weather data is missing in the Open-Meteo API response.");
            CurrentWeather currentWeather = new()
            {
                Temperature = openMeteoCurrentDto.Temperature,
                FeelsLike = openMeteoCurrentDto.FeelsLike,
                DewPoint = openMeteoCurrentDto.DewPoint,
                Humidity = openMeteoCurrentDto.Humidity,
                WindSpeed = openMeteoCurrentDto.WindSpeed,
                WindDirection = openMeteoCurrentDto.WindDirection,
                WindGusts = openMeteoCurrentDto.WindGusts,
                Precipitation = openMeteoCurrentDto.Precipitation,
                Pressure = openMeteoCurrentDto.Pressure,
                Visibility = openMeteoCurrentDto.Visibility,
                UvIndex = openMeteoCurrentDto.UvIndex,
                CloudCover = openMeteoCurrentDto.CloudCover,
                WeatherCode = openMeteoCurrentDto.WeatherCode,
                IsDay = Convert.ToBoolean(openMeteoCurrentDto.IsDay),
                Time = DateTime.TryParse(openMeteoCurrentDto.Time, out var time) ? time : DateTime.MinValue
            };
            return currentWeather;
        }

        /// <summary>
        /// Retrieves hourly weather forecasts for the specified geographic coordinates.
        /// </summary>
        /// <param name="latitude">The latitude coordinate in degrees (-90 to 90). Positive values are north of the equator.</param>
        /// <param name="longitude">The longitude coordinate in degrees (-180 to 180). Positive values are east of the prime meridian.</param>
        /// <param name="days">
        /// The number of days of forecast data to retrieve. Default is 7 days.
        /// The Open-Meteo API typically supports forecasts up to 16 days.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation that returns an enumerable collection
        /// of <see cref="HourlyForecast"/> objects, each representing weather conditions at a specific hour.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the Open-Meteo API call fails or returns null.
        /// Thrown when the API response does not contain hourly weather data.
        /// </exception>
        /// <remarks>
        /// This method queries the Open-Meteo forecast API with the hourly=true parameter
        /// to retrieve detailed hour-by-hour weather predictions. The API request is built
        /// using <see cref="OpenMeteoRequestBuilder.BuildForecastParameters"/>.
        /// 
        /// The returned collection contains one forecast object per hour for the specified
        /// number of days. All timestamps are in UTC and should be converted to local
        /// timezone for display to end users.
        /// 
        /// Temperature values are in Celsius. Wind speeds are in km/h.
        /// Pressure is in hectopascals (hPa). Visibility is in meters.
        /// Humidity and cloud cover are percentages (0-100).
        /// Precipitation probability ranges from 0-100 (percent).
        /// </remarks>
        public async Task<IEnumerable<HourlyForecast>> GetHourlyForecastAsync(double latitude, double longitude, int days = 7)
        {
            var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(latitude, longitude, includeHourly: true);
            var result = await _openMeteoClient.GetAsync<OpenMeteoForecastResponseDto>("forecast", parameters) ?? throw new InvalidOperationException("Failed to retrieve current weather data from Open-Meteo API.");
            var openMeteoHourlyDto = result.Hourly ?? throw new InvalidOperationException("Current weather data is missing in the Open-Meteo API response.");
            var hourlyForecasts = new List<HourlyForecast>();
            for (int i = 0; i < openMeteoHourlyDto.Time.Count; i++)
            {
                HourlyForecast hourlyForecast = new()
                {
                    Time = DateTime.TryParse(openMeteoHourlyDto.Time[i], out var time) ? time : DateTime.MinValue,
                    Temperature = openMeteoHourlyDto.Temperature[i],
                    FeelsLike = openMeteoHourlyDto.FeelsLike[i],
                    DewPoint = openMeteoHourlyDto.DewPoint[i],
                    Humidity = openMeteoHourlyDto.Humidity[i],
                    WindSpeed = openMeteoHourlyDto.WindSpeed[i],
                    WindDirection = openMeteoHourlyDto.WindDirection[i],
                    WindGusts = openMeteoHourlyDto.WindGusts[i],
                    Precipitation = openMeteoHourlyDto.Precipitation[i],
                    PrecipitationProbability = openMeteoHourlyDto.PrecipitationProbability[i],
                    Pressure = openMeteoHourlyDto.Pressure[i],
                    CloudCover = openMeteoHourlyDto.CloudCover[i],
                    Visibility = openMeteoHourlyDto.Visibility[i],
                    WeatherCode = openMeteoHourlyDto.WeatherCode[i],
                    IsDay = Convert.ToBoolean(openMeteoHourlyDto.IsDay[i])
                };
                hourlyForecasts.Add(hourlyForecast);
            }
            return hourlyForecasts;
        }

        /// <summary>
        /// Retrieves daily weather forecasts for the specified geographic coordinates.
        /// </summary>
        /// <param name="latitude">The latitude coordinate in degrees (-90 to 90). Positive values are north of the equator.</param>
        /// <param name="longitude">The longitude coordinate in degrees (-180 to 180). Positive values are east of the prime meridian.</param>
        /// <param name="days">
        /// The number of days of forecast data to retrieve. Default is 7 days.
        /// The Open-Meteo API typically supports forecasts up to 16 days.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation that returns an enumerable collection
        /// of <see cref="DailyForecast"/> objects, each representing aggregated weather conditions for a specific day.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the Open-Meteo API call fails or returns null.
        /// Thrown when the API response does not contain daily weather data.
        /// </exception>
        /// <remarks>
        /// This method queries the Open-Meteo forecast API with the daily=true parameter
        /// to retrieve daily weather summaries with maximum/minimum temperatures, total precipitation,
        /// and other aggregated metrics. The API request is built using
        /// <see cref="OpenMeteoRequestBuilder.BuildForecastParameters"/>.
        /// 
        /// The returned collection contains one forecast object per day for the specified number of days.
        /// Dates are in YYYY-MM-DD format (UTC) and should be converted to local timezone
        /// for display to end users.
        /// 
        /// Temperature values are in Celsius. Wind speeds are in km/h.
        /// Pressure is in hectopascals (hPa). Precipitation is in millimeters.
        /// Humidity percentages range from 0-100. Wind direction is in degrees (0-359).
        /// Sunrise and sunset times are in ISO 8601 format (UTC).
        /// </remarks>
        public async Task<IEnumerable<DailyForecast>> GetDailyForecastAsync(double latitude, double longitude, int days = 7)
        {
            var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(latitude, longitude, includeDaily: true);
            var result = await _openMeteoClient.GetAsync<OpenMeteoForecastResponseDto>("forecast", parameters) ?? throw new InvalidOperationException("Failed to retrieve current weather data from Open-Meteo API.");
            var openMeteoDailyDto = result.Daily ?? throw new InvalidOperationException("Current weather data is missing in the Open-Meteo API response.");
            var dailyForecasts = new List<DailyForecast>();
            for (int i = 0; i < openMeteoDailyDto.Time.Count; i++)
            {
                DailyForecast dailyForecast = new()
                {
                    Date = DateTime.TryParse(openMeteoDailyDto.Time[i], out var date) ? date : DateTime.MinValue,
                    TemperatureMax = openMeteoDailyDto.TemperatureMax[i],
                    TemperatureMin = openMeteoDailyDto.TemperatureMin[i],
                    FeelsLikeMax = openMeteoDailyDto.FeelsLikeMax[i],
                    FeelsLikeMin = openMeteoDailyDto.FeelsLikeMin[i],
                    HumidityMax = openMeteoDailyDto.HumidityMax[i],
                    HumidityMin = openMeteoDailyDto.HumidityMin[i],
                    PressureMean = openMeteoDailyDto.PressureMean[i],
                    PrecipitationSum = openMeteoDailyDto.PrecipitationSum[i],
                    PrecipitationProbabilityMax = openMeteoDailyDto.PrecipitationProbabilityMax[i],
                    WindSpeedMax = openMeteoDailyDto.WindSpeedMax[i],
                    WindGustsMax = openMeteoDailyDto.WindGustsMax[i],
                    WindDirectionDominant = openMeteoDailyDto.WindDirectionDominant[i],
                    UvIndexMax = openMeteoDailyDto.UvIndexMax[i],
                    WeatherCode = openMeteoDailyDto.WeatherCode[i],
                    Sunrise = DateTime.TryParse(openMeteoDailyDto.Sunrise[i], out var sunrise) ? sunrise : DateTime.MinValue,
                    Sunset = DateTime.TryParse(openMeteoDailyDto.Sunset[i], out var sunset) ? sunset : DateTime.MinValue
                };
                dailyForecasts.Add(dailyForecast);
            }
            return dailyForecasts;
        }
    }
}