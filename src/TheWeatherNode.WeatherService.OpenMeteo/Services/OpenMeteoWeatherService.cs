using Microsoft.Extensions.Logging;
using TheWeatherNode.Core.Interfaces;
using TheWeatherNode.Core.Models.Requests;
using TheWeatherNode.Core.Models.Responses;
using TheWeatherNode.WeatherService.OpenMeteo.Builders;
using TheWeatherNode.WeatherService.OpenMeteo.Client.Interfaces;
using TheWeatherNode.WeatherService.OpenMeteo.DTOs;

namespace TheWeatherNode.WeatherService.OpenMeteo.Services
{
    /// <summary>
    /// Implements weather forecast data retrieval using the Open-Meteo API.
    /// </summary>
    /// <remarks>
    /// This service acts as an adapter between the application's weather interface
    /// (<see cref="IWeatherService"/>) and the Open-Meteo weather data provider.
    /// It handles the transformation of Open-Meteo DTO objects into domain models,
    /// manages unit conversions based on request preferences, and manages error handling
    /// and logging for weather data operations.
    /// 
    /// The service supports three types of weather forecast data:
    /// - Current weather conditions
    /// - Hourly forecasts
    /// - Daily forecasts
    /// 
    /// All weather data is retrieved from Open-Meteo in metric units (Celsius, km/h, mm, hPa)
    /// and returned to clients in the units specified in their request objects.
    /// </remarks>
    public class OpenMeteoWeatherService : IWeatherService
    {
        private readonly IOpenMeteoWeatherClient _openMeteoClient;
        private readonly ILogger<OpenMeteoWeatherService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenMeteoWeatherService"/> class.
        /// </summary>
        /// <param name="openMeteoClient">The Open-Meteo API client for making HTTP requests to the weather API.</param>
        /// <param name="logger">The logger for recording service operations, warnings, and errors.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="openMeteoClient"/> or <paramref name="logger"/> is null.
        /// </exception>
        public OpenMeteoWeatherService(IOpenMeteoWeatherClient openMeteoClient, ILogger<OpenMeteoWeatherService> logger)
        {
            _openMeteoClient = openMeteoClient;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves the current weather conditions for the specified location and unit preferences.
        /// </summary>
        /// <param name="weatherRequest">
        /// The current weather request containing geographic coordinates and desired unit preferences.
        /// See <see cref="CurrentWeatherRequest"/> for details on supported unit types and defaults.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation that returns a <see cref="CurrentWeather"/> object
        /// containing current weather data including temperature, humidity, wind, precipitation, visibility, UV index, and more.
        /// All values are converted to the units specified in the request.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="weatherRequest"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the Open-Meteo API call fails or returns null.
        /// Thrown when the API response does not contain current weather data.
        /// </exception>
        /// <remarks>
        /// This method queries the Open-Meteo forecast API with the current=true parameter
        /// to retrieve real-time weather conditions. The API request is built using
        /// <see cref="OpenMeteoRequestBuilder.BuildForecastParameters"/> which configures
        /// all necessary parameters for current weather retrieval based on the request object.
        /// 
        /// Open-Meteo returns data in metric units (Celsius, km/h, hPa, meters, mm).
        /// The returned <see cref="CurrentWeather"/> object contains the raw metric values,
        /// with unit conversions handled by the consuming application based on the request's
        /// <see cref="CurrentWeatherRequest.TemperatureUnit"/>, 
        /// <see cref="CurrentWeatherRequest.WindSpeedUnit"/>, and 
        /// <see cref="CurrentWeatherRequest.PrecipitationUnit"/> properties.
        /// </remarks>
        public async Task<CurrentWeather> GetCurrentWeatherAsync(WeatherRequest weatherRequest)
        {
            if (weatherRequest == null)
                throw new ArgumentNullException(nameof(weatherRequest), "Current weather request cannot be null.");

            _logger.LogDebug("Retrieving current weather for coordinates ({Latitude}, {Longitude}) with temperature unit {TemperatureUnit}, wind speed unit {WindSpeedUnit}, and precipitation unit {PrecipitationUnit}.",
                weatherRequest.Latitude, weatherRequest.Longitude, weatherRequest.TemperatureUnit, weatherRequest.WindSpeedUnit, weatherRequest.PrecipitationUnit);
            var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(weatherRequest, includeCurrent: true);
            var result = await _openMeteoClient.GetForcastAsync<OpenMeteoForecastResponseDto>(parameters) 
                ?? throw new InvalidOperationException("Failed to retrieve current weather data from Open-Meteo API.");
            _logger.LogDebug("Successfully retrieved current weather data from Open-Meteo API for coordinates ({Latitude}, {Longitude}).", weatherRequest.Latitude, weatherRequest.Longitude);

            var openMeteoCurrentDto = result.Current 
                ?? throw new InvalidOperationException("Current weather data is missing in the Open-Meteo API response.");
            
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
        /// Retrieves hourly weather forecasts for the specified location and unit preferences.
        /// </summary>
        /// <param name="weatherRequest">
        /// The hourly weather forecast request containing geographic coordinates, forecast duration, and desired unit preferences.
        /// See <see cref="HourlyWeatherRequest"/> for details on supported unit types, defaults, and the hours parameter.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation that returns an enumerable collection
        /// of <see cref="HourlyForecast"/> objects, each representing weather conditions at a specific hour.
        /// The collection is ordered chronologically from earliest to latest.
        /// All values are converted to the units specified in the request.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="weatherRequest"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the Open-Meteo API call fails or returns null.
        /// Thrown when the API response does not contain hourly weather data.
        /// </exception>
        /// <remarks>
        /// This method queries the Open-Meteo forecast API with the hourly=true parameter
        /// to retrieve detailed hour-by-hour weather predictions. The API request is built using
        /// <see cref="OpenMeteoRequestBuilder.BuildForecastParameters"/> based on the request object.
        /// 
        /// The returned collection contains one forecast object per hour for the number of hours
        /// specified in the request. The Open-Meteo API typically supports forecasts up to 16 days
        /// (384 hours). All timestamps are in UTC and should be converted to local timezone for
        /// display to end users.
        /// 
        /// Open-Meteo returns data in metric units (Celsius, km/h, hPa, meters, mm).
        /// The returned <see cref="HourlyForecast"/> objects contain the raw metric values,
        /// with unit conversions handled by the consuming application based on the request's
        /// <see cref="HourlyWeatherRequest.TemperatureUnit"/>, 
        /// <see cref="HourlyWeatherRequest.WindSpeedUnit"/>, and 
        /// properties.
        /// </remarks>
        public async Task<IEnumerable<HourlyForecast>> GetHourlyForecastAsync(WeatherRequest weatherRequest)
        {
            if (weatherRequest == null)
                throw new ArgumentNullException(nameof(weatherRequest), "Hourly weather request cannot be null.");

            var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(weatherRequest, includeHourly: true);
            var result = await _openMeteoClient.GetForcastAsync<OpenMeteoForecastResponseDto>(parameters) 
                ?? throw new InvalidOperationException("Failed to retrieve hourly weather data from Open-Meteo API.");
            
            var openMeteoHourlyDto = result.Hourly 
                ?? throw new InvalidOperationException("Hourly weather data is missing in the Open-Meteo API response.");
            
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
        /// Retrieves daily weather forecasts for the specified location and unit preferences.
        /// </summary>
        /// <param name="weatherRequest">
        /// The daily weather forecast request containing geographic coordinates, forecast duration, and desired unit preferences.
        /// See <see cref="DailyForecastRequest"/> for details on supported unit types, defaults, and the days parameter.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation that returns an enumerable collection
        /// of <see cref="DailyForecast"/> objects, each representing aggregated weather conditions for a specific day.
        /// The collection is ordered chronologically from earliest to latest.
        /// All values are converted to the units specified in the request.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="weatherRequest"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the Open-Meteo API call fails or returns null.
        /// Thrown when the API response does not contain daily weather data.
        /// </exception>
        /// <remarks>
        /// This method queries the Open-Meteo forecast API with the daily=true parameter
        /// to retrieve daily weather summaries with maximum/minimum temperatures, total precipitation,
        /// and other aggregated metrics. The API request is built using
        /// <see cref="OpenMeteoRequestBuilder.BuildForecastParameters"/> based on the request object.
        /// 
        /// The returned collection contains one forecast object per day for the number of days
        /// specified in the request. The Open-Meteo API typically supports forecasts up to 16 days.
        /// Dates are in date-only format and should be converted to local timezone for display
        /// to end users. Sunrise and sunset times are in UTC.
        /// 
        /// Open-Meteo returns data in metric units (Celsius, km/h, hPa, millimeters).
        /// The returned <see cref="DailyForecast"/> objects contain the raw metric values,
        /// with unit conversions handled by the consuming application based on the request's
        /// <see cref="DailyForecastRequest.TemperatureUnit"/>, 
        /// <see cref="DailyForecastRequest.WindSpeedUnit"/>, and 
        /// <see cref="DailyForecastRequest.PrecipitationUnit"/> properties.
        /// </remarks>
        public async Task<IEnumerable<DailyForecast>> GetDailyForecastAsync(WeatherRequest weatherRequest)
        {
            if (weatherRequest == null)
                throw new ArgumentNullException(nameof(weatherRequest), "Daily forecast request cannot be null.");

            var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(weatherRequest, includeDaily: true);
            var result = await _openMeteoClient.GetForcastAsync<OpenMeteoForecastResponseDto>(parameters) 
                ?? throw new InvalidOperationException("Failed to retrieve daily weather data from Open-Meteo API.");
            
            var openMeteoDailyDto = result.Daily 
                ?? throw new InvalidOperationException("Daily weather data is missing in the Open-Meteo API response.");
            
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