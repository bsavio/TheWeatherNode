using TheWeatherNode.Core.Models;

namespace TheWeatherNode.Core.Interfaces
{
    /// <summary>
    /// Defines the contract for weather forecast data services.
    /// </summary>
    /// <remarks>
    /// This interface abstracts the weather service implementation, allowing different weather
    /// data providers (Open-Meteo, Weather API, etc.) to be plugged in without changing client code.
    /// 
    /// Weather data returned by implementations of this interface may be in metric or imperial units
    /// depending on the configuration of the weather service. Consuming services should be aware of
    /// the unit system in use and perform conversions as needed.
    /// 
    /// Common metric units:
    /// - Temperature: degrees Celsius
    /// - Wind Speed: kilometers per hour (km/h)
    /// - Precipitation: millimeters (mm)
    /// - Pressure: hectopascals (hPa)
    /// - Visibility: meters
    /// 
    /// Common imperial units:
    /// - Temperature: degrees Fahrenheit
    /// - Wind Speed: miles per hour (mph)
    /// - Precipitation: inches
    /// - Pressure: inches of mercury (inHg)
    /// - Visibility: feet
    /// </remarks>
    public interface IWeatherService
    {
        /// <summary>
        /// Retrieves the current weather conditions for the specified geographic coordinates.
        /// </summary>
        /// <param name="latitude">The latitude coordinate in degrees (-90 to 90). Positive values are north of the equator.</param>
        /// <param name="longitude">The longitude coordinate in degrees (-180 to 180). Positive values are east of the prime meridian.</param>
        /// <returns>
        /// A task representing the asynchronous operation that returns a <see cref="CurrentWeather"/> object
        /// containing current weather data including temperature, humidity, wind, precipitation, visibility, UV index, and more.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the weather service is unable to retrieve data for the specified coordinates.
        /// </exception>
        /// <remarks>
        /// This method retrieves real-time weather conditions at the specified location.
        /// The returned data includes the current timestamp, temperature, "feels like" temperature,
        /// dew point, humidity, wind speed/direction/gusts, precipitation, atmospheric pressure,
        /// visibility, UV index, cloud cover, weather code, and daylight indicator.
        /// 
        /// The unit system (metric or imperial) depends on the service implementation configuration.
        /// Refer to the specific implementation documentation for unit details.
        /// </remarks>
        Task<CurrentWeather> GetCurrentWeatherAsync(double latitude, double longitude);

        /// <summary>
        /// Retrieves hourly weather forecasts for the specified geographic coordinates.
        /// </summary>
        /// <param name="latitude">The latitude coordinate in degrees (-90 to 90). Positive values are north of the equator.</param>
        /// <param name="longitude">The longitude coordinate in degrees (-180 to 180). Positive values are east of the prime meridian.</param>
        /// <param name="days">
        /// The number of days of forecast data to retrieve. Default is 7 days.
        /// Implementation-dependent; typical weather APIs support between 7-16 days of forecasts.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation that returns an enumerable collection
        /// of <see cref="HourlyForecast"/> objects, each representing weather conditions at a specific hour.
        /// The collection is ordered chronologically from earliest to latest.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the weather service is unable to retrieve hourly forecast data for the specified coordinates.
        /// </exception>
        /// <remarks>
        /// This method retrieves detailed hour-by-hour weather predictions for the specified location.
        /// The number of forecast hours returned depends on the requested number of days and will typically
        /// be (days * 24) hourly forecasts.
        /// 
        /// Each hourly forecast includes temperature, apparent temperature ("feels like"), dew point,
        /// humidity, precipitation probability and amount, atmospheric pressure, cloud cover, visibility,
        /// wind speed/direction/gusts, weather code, and daylight indicator.
        /// 
        /// All timestamps are in UTC and should be converted to local timezone for display to end users.
        /// The unit system (metric or imperial) depends on the service implementation configuration.
        /// Refer to the specific implementation documentation for unit details.
        /// </remarks>
        Task<IEnumerable<HourlyForecast>> GetHourlyForecastAsync(double latitude, double longitude, int days = 7);

        /// <summary>
        /// Retrieves daily weather forecasts for the specified geographic coordinates.
        /// </summary>
        /// <param name="latitude">The latitude coordinate in degrees (-90 to 90). Positive values are north of the equator.</param>
        /// <param name="longitude">The longitude coordinate in degrees (-180 to 180). Positive values are east of the prime meridian.</param>
        /// <param name="days">
        /// The number of days of forecast data to retrieve. Default is 7 days.
        /// Implementation-dependent; typical weather APIs support between 7-16 days of forecasts.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation that returns an enumerable collection
        /// of <see cref="DailyForecast"/> objects, each representing aggregated weather conditions for a specific day.
        /// The collection is ordered chronologically from earliest to latest.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the weather service is unable to retrieve daily forecast data for the specified coordinates.
        /// </exception>
        /// <remarks>
        /// This method retrieves daily weather summaries for the specified location,
        /// containing maximum/minimum temperatures and other aggregated metrics for each day.
        /// This data is useful for multi-day forecasts and weather summaries.
        /// 
        /// Each daily forecast includes date, maximum/minimum temperatures, maximum/minimum apparent temperatures,
        /// maximum/minimum humidity, mean atmospheric pressure, total precipitation, maximum precipitation probability,
        /// maximum wind speed/gusts, dominant wind direction, maximum UV index, weather code, sunrise time, and sunset time.
        /// 
        /// Dates are provided as date-only values (no time component). Sunrise and sunset times are in UTC
        /// and should be converted to local timezone for display to end users.
        /// The unit system (metric or imperial) depends on the service implementation configuration.
        /// Refer to the specific implementation documentation for unit details.
        /// </remarks>
        Task<IEnumerable<DailyForecast>> GetDailyForecastAsync(double latitude, double longitude, int days = 7);
    }
}