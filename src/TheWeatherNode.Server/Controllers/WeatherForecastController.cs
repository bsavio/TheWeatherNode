using Microsoft.AspNetCore.Mvc;
using TheWeatherNode.Core.Interfaces;
using TheWeatherNode.Core.Models.Requests;
using TheWeatherNode.Core.Models.Responses;

namespace TheWeatherNode.Server.Controllers
{
    /// <summary>
    /// Provides REST API endpoints for retrieving weather forecast data.
    /// </summary>
    /// <remarks>
    /// This controller exposes three weather forecast endpoints that communicate with the
    /// <see cref="IWeatherService"/> to retrieve current weather conditions and forecast data.
    /// 
    /// All endpoints currently use hardcoded coordinates for a fixed location (40.3247°N, 74.3369°W).
    /// Future enhancements should make these coordinates configurable via query parameters or route parameters.
    /// 
    /// The controller implements comprehensive error handling and logging for all weather service operations.
    /// </remarks>
    [ApiController]
    [Route("weather")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
        /// </summary>
        /// <param name="weatherService">The weather service for retrieving forecast data.</param>
        /// <param name="logger">The logger for recording controller operations and errors.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="weatherService"/> or <paramref name="logger"/> is null.
        /// </exception>
        public WeatherForecastController(IWeatherService weatherService, ILogger<WeatherForecastController> logger)
        {
            _weatherService = weatherService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves the current weather conditions for the configured location.
        /// </summary>
        /// <returns>
        /// An <see cref="IActionResult"/> containing:
        /// - 200 OK with a <see cref="CurrentWeather"/> object on success
        /// - 500 Internal Server Error with an error message if an exception occurs
        /// </returns>
        /// <remarks>
        /// This endpoint queries the weather service for real-time weather conditions
        /// including temperature, humidity, wind, precipitation, visibility, UV index, and more.
        /// 
        /// Currently uses hardcoded coordinates (40.3247°N, 74.3369°W).
        /// Future improvements should make location configurable via query parameters.
        /// </remarks>
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentWeather(double latitude = 40.3025, double longitude = 74.3038, string temperatureUnit = "celsius", string windSpeedUnit = "kmp", string precipituationUnit = "millimeters")
        {
            try
            {
                var weatherRequest = new WeatherRequest(latitude, longitude, temperatureUnit, windSpeedUnit, precipituationUnit);
                var currentWeather = await _weatherService.GetCurrentWeatherAsync(weatherRequest);
                return Ok(currentWeather);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving current weather data.");
                return StatusCode(500, "An error occurred while retrieving weather data. Please try again later.");
            }
        }

        /// <summary>
        /// Retrieves hourly weather forecasts for the configured location.
        /// </summary>
        /// <returns>
        /// An <see cref="IActionResult"/> containing:
        /// - 200 OK with an enumerable collection of <see cref="HourlyForecast"/> objects on success
        /// - 500 Internal Server Error with an error message if an exception occurs
        /// </returns>
        /// <remarks>
        /// This endpoint queries the weather service for detailed hour-by-hour weather predictions.
        /// Returns a default of 7 days of hourly forecasts, which is approximately 168 data points.
        /// 
        /// Currently uses hardcoded coordinates (40.3247°N, 74.3369°W).
        /// Future improvements should make location and number of days configurable via query parameters.
        /// </remarks>
        [HttpGet("hourly")]
        public async Task<IActionResult> GetHourlyForecast(double latitude = 40.3025, double longitude = 74.3038, string temperatureUnit = "celsius", string windSpeedUnit = "kmp", string precipituationUnit = "millimeters")
        {
            try
            {
                var weatherRequest = new WeatherRequest(latitude, longitude, temperatureUnit, windSpeedUnit, precipituationUnit);
                var hourlyForecast = await _weatherService.GetHourlyForecastAsync(weatherRequest);
                return Ok(hourlyForecast);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving hourly forecast data.");
                return StatusCode(500, "An error occurred while retrieving weather data. Please try again later.");
            }
        }

        /// <summary>
        /// Retrieves daily weather forecasts for the configured location.
        /// </summary>
        /// <returns>
        /// An <see cref="IActionResult"/> containing:
        /// - 200 OK with an enumerable collection of <see cref="DailyForecast"/> objects on success
        /// - 500 Internal Server Error with an error message if an exception occurs
        /// </returns>
        /// <remarks>
        /// This endpoint queries the weather service for daily weather summaries with
        /// maximum/minimum temperatures, total precipitation, wind conditions, and other aggregated metrics.
        /// Returns a default of 7 days of forecast data.
        /// 
        /// Currently uses hardcoded coordinates (40.3247°N, 74.3369°W).
        /// Future improvements should make location and number of days configurable via query parameters.
        /// </remarks>
        [HttpGet("daily")]
        public async Task<IActionResult> GetDailyForecast(double latitude = 40.3025, double longitude = 74.3038, string temperatureUnit = "celsius", string windSpeedUnit = "kmp", string precipituationUnit = "millimeters")
        {
            try
            {
                var weatherRequest = new WeatherRequest(latitude, longitude, temperatureUnit, windSpeedUnit, precipituationUnit);
                var dailyForecast = await _weatherService.GetDailyForecastAsync(weatherRequest);
                return Ok(dailyForecast);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving daily forecast data.");
                return StatusCode(500, "An error occurred while retrieving weather data. Please try again later.");
            }
        }
    }
}