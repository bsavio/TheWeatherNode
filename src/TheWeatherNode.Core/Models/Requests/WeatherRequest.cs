using TheWeatherNode.Core.Extensions;
using TheWeatherNode.Core.Models;

namespace TheWeatherNode.Core.Models.Requests
{
    /// <summary>
    /// Represents a request for current weather data at a specified location.
    /// </summary>
    /// <remarks>
    /// This request object encapsulates all parameters needed to retrieve current weather conditions,
    /// including geographic coordinates and desired unit preferences. String unit parameters are
    /// automatically converted to their corresponding enum types during construction, providing
    /// type safety and validation at the point of instantiation.
    /// 
    /// If invalid unit strings are provided, an <see cref="ArgumentException"/> will be thrown
    /// during construction, preventing invalid requests from being created.
    /// </remarks>
    public class WeatherRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherRequest"/> class.
        /// </summary>
        /// <param name="latitude">
        /// The latitude coordinate in degrees. Valid range: -90 to 90.
        /// Positive values represent locations north of the equator.
        /// </param>
        /// <param name="longitude">
        /// The longitude coordinate in degrees. Valid range: -180 to 180.
        /// Positive values represent locations east of the prime meridian.
        /// </param>
        /// <param name="days">
        /// The number of days of forecast data to retrieve. Default: 7
        /// Note: This parameter is included for consistency with other request types,
        /// though current weather requests typically only return real-time data.
        /// </param>
        /// <param name="temperatureUnit">
        /// The desired temperature unit for the response (e.g., "celsius", "fahrenheit").
        /// Case-insensitive. Default: "celsius"
        /// </param>
        /// <param name="windSpeedUnit">
        /// The desired wind speed unit for the response (e.g., "kph", "km/h", "mph", "knots").
        /// Case-insensitive with alias support. Default: "km/h"
        /// </param>
        /// <param name="precipitationUnit">
        /// The desired precipitation unit for the response (e.g., "millimeters", "mm", "inches", "in").
        /// Case-insensitive with alias support. Default: "millimeters"
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when any of the unit string parameters are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when an invalid unit string is provided that cannot be converted to the corresponding enum type.
        /// </exception>
        public WeatherRequest(
            double latitude,
            double longitude,
            string temperatureUnit = "celsius",
            string windSpeedUnit = "km/h",
            string precipitationUnit = "millimeters")
        {
            Latitude = latitude;
            Longitude = longitude;
            TemperatureUnit = temperatureUnit.ToTemperatureUnit();
            WindSpeedUnit = windSpeedUnit.ToWindSpeedUnit();
            PrecipitationUnit = precipitationUnit.ToPrecipitationUnit();
        }

        /// <summary>
        /// Gets the latitude coordinate in degrees for the requested location.
        /// </summary>
        /// <remarks>
        /// Valid range: -90 to 90
        /// Positive values: North of the equator (Northern Hemisphere)
        /// Negative values: South of the equator (Southern Hemisphere)
        /// 0: On the equator
        /// </remarks>
        public double Latitude { get; }

        /// <summary>
        /// Gets the longitude coordinate in degrees for the requested location.
        /// </summary>
        /// <remarks>
        /// Valid range: -180 to 180
        /// Positive values: East of the prime meridian
        /// Negative values: West of the prime meridian
        /// 0: On the prime meridian (Greenwich/London)
        /// </remarks>
        public double Longitude { get; }


        /// <summary>
        /// Gets the desired temperature unit for the response.
        /// </summary>
        /// <remarks>
        /// Determined by converting the temperature unit string provided in the constructor.
        /// The unit string is converted case-insensitively using the extension method
        /// <see cref="TheWeatherNode.Core.Extensions.UnitTypeExtensions.ToTemperatureUnit(string)"/>.
        /// </remarks>
        public TemperatureUnit TemperatureUnit { get; }

        /// <summary>
        /// Gets the desired wind speed unit for the response.
        /// </summary>
        /// <remarks>
        /// Determined by converting the wind speed unit string provided in the constructor.
        /// The unit string is converted case-insensitively with alias support using the extension method
        /// <see cref="TheWeatherNode.Core.Extensions.UnitTypeExtensions.ToWindSpeedUnit(string)"/>.
        /// 
        /// Supported values: "kph", "km/h", "kmh", "mph", "knots"
        /// </remarks>
        public WindSpeedUnit WindSpeedUnit { get; }

        /// <summary>
        /// Gets the desired precipitation unit for the response.
        /// </summary>
        /// <remarks>
        /// Determined by converting the precipitation unit string provided in the constructor.
        /// The unit string is converted case-insensitively with alias support using the extension method
        /// <see cref="TheWeatherNode.Core.Extensions.UnitTypeExtensions.ToPrecipitationUnit(string)"/>.
        /// 
        /// Supported values: "millimeters", "mm", "inches", "in"
        /// </remarks>
        public PrecipitationUnit PrecipitationUnit { get; }
    }
}
