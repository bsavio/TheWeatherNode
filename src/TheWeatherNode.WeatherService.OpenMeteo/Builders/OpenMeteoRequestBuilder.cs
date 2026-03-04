using TheWeatherNode.Core.Models;
using TheWeatherNode.Core.Models.Requests;

namespace TheWeatherNode.WeatherService.OpenMeteo.Builders
{
    /// <summary>
    /// Builds and configures request parameters for the Open-Meteo weather API.
    /// </summary>
    /// <remarks>
    /// This static utility class constructs properly formatted query parameters for Open-Meteo API requests.
    /// It handles unit conversions and parameter mappings, transforming domain enums into API-compatible string values.
    /// 
    /// The builder maintains unit mappings as static dictionaries to ensure consistency across all API requests
    /// and provides a centralized location for managing unit format standards expected by Open-Meteo.
    /// </remarks>
    public static class OpenMeteoRequestBuilder
    {
        /// <summary>
        /// Gets or sets the mapping of temperature unit enums to their Open-Meteo API string representations.
        /// </summary>
        /// <remarks>
        /// Maps <see cref="TemperatureUnit"/> enum values to the string format expected by the Open-Meteo API.
        /// The Open-Meteo API accepts lowercase temperature unit strings.
        /// 
        /// Mapping:
        /// - <see cref="TemperatureUnit.Celsius"/> → "celsius"
        /// - <see cref="TemperatureUnit.Fahrenheit"/> → "fahrenheit"
        /// 
        /// This mapping is used in all weather requests to specify the desired temperature unit
        /// for API responses.
        /// </remarks>
        public static IDictionary<TemperatureUnit, string> TemperatureMappings = new Dictionary<TemperatureUnit, string>
        {
            { TemperatureUnit.Celsius, "celsius" },
            { TemperatureUnit.Fahrenheit, "fahrenheit" }
        };

        /// <summary>
        /// Gets the mapping of wind speed unit enums to their Open-Meteo API string representations.
        /// </summary>
        /// <remarks>
        /// Maps <see cref="WindSpeedUnit"/> enum values to the string format expected by the Open-Meteo API.
        /// The Open-Meteo API uses abbreviated wind speed unit identifiers.
        /// 
        /// Mapping:
        /// - <see cref="WindSpeedUnit.Kmh"/> → "kmh" (kilometers per hour)
        /// - <see cref="WindSpeedUnit.Mph"/> → "mph" (miles per hour)
        /// - <see cref="WindSpeedUnit.Knots"/> → "kn" (knots, nautical miles per hour)
        /// 
        /// This mapping is used in all weather requests to specify the desired wind speed unit
        /// for API responses.
        /// </remarks>
        private static readonly IDictionary<WindSpeedUnit, string> WindSpeedMappings = new Dictionary<WindSpeedUnit, string>
        {
            { WindSpeedUnit.Kmh, "kmh" },
            { WindSpeedUnit.Mph, "mph" },
            { WindSpeedUnit.Knots, "kn" }
        };

        /// <summary>
        /// Gets the mapping of precipitation unit enums to their Open-Meteo API string representations.
        /// </summary>
        /// <remarks>
        /// Maps <see cref="PrecipitationUnit"/> enum values to the string format expected by the Open-Meteo API.
        /// The Open-Meteo API uses abbreviated precipitation unit identifiers.
        /// 
        /// Mapping:
        /// - <see cref="PrecipitationUnit.Millimeters"/> → "mm" (millimeters)
        /// - <see cref="PrecipitationUnit.Inches"/> → "inch" (inches)
        /// 
        /// This mapping is used in all weather requests to specify the desired precipitation unit
        /// for API responses.
        /// </remarks>
        private static readonly IDictionary<PrecipitationUnit, string> PrecipitationMappings = new Dictionary<PrecipitationUnit, string>
        {
            { PrecipitationUnit.Millimeters, "mm" },
            { PrecipitationUnit.Inches, "inch" }
        };

        /// <summary>
        /// Builds a dictionary of query parameters for Open-Meteo weather forecast API requests.
        /// </summary>
        /// <remarks>
        /// This method constructs a parameter dictionary suitable for the Open-Meteo forecast endpoint.
        /// It converts domain models (<see cref="WeatherRequest"/>) into API-compatible parameters,
        /// including unit conversions and conditional parameter inclusion.
        /// 
        /// The resulting dictionary contains:
        /// - Geographic coordinates (latitude, longitude)
        /// - Unit preferences (temperature, wind speed, precipitation)
        /// - Optional forecast data sections (current, hourly, daily)
        /// 
        /// The dictionary is then passed to an HTTP client which converts it into a query string.
        /// </remarks>
        /// <param name="weatherRequest">
        /// The weather request containing geographic coordinates and unit preferences.
        /// Required and cannot be null.
        /// </param>
        /// <param name="includeCurrent">
        /// If true, adds current weather data parameters to the request.
        /// Default: false
        /// </param>
        /// <param name="includeHourly">
        /// If true, adds hourly forecast data parameters to the request.
        /// Default: false
        /// </param>
        /// <param name="includeDaily">
        /// If true, adds daily forecast data parameters to the request.
        /// Default: false
        /// </param>
        /// <returns>
        /// A dictionary of query parameters with string keys and object values.
        /// The dictionary always contains geographic and unit parameters.
        /// It conditionally includes current, hourly, and/or daily parameters based on the flags.
        /// </returns>
        /// <example>
        /// <code>
        /// var weatherRequest = new WeatherRequest(40.7128, -74.0060, "celsius", "kmh", "mm");
        /// var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(
        ///     weatherRequest,
        ///     includeCurrent: true,
        ///     includeHourly: true,
        ///     includeDaily: false);
        /// 
        /// // Result:
        /// // {
        /// //   "latitude": 40.7128,
        /// //   "longitude": -74.0060,
        /// //   "temperature_unit": "celsius",
        /// //   "wind_speed_unit": "kmh",
        /// //   "precipitation_unit": "mm",
        /// //   "current": [list of current weather variables],
        /// //   "hourly": [list of hourly weather variables]
        /// // }
        /// </code>
        /// </example>
        public static Dictionary<string, object> BuildForecastParameters(
            WeatherRequest weatherRequest,
            bool includeCurrent = false,
            bool includeHourly = false,
            bool includeDaily = false)
        {
            var parameters = new Dictionary<string, object>
            {
                { "latitude", weatherRequest.Latitude },
                { "longitude", weatherRequest.Longitude },
                { "temperature_unit", TemperatureMappings[weatherRequest.TemperatureUnit] },
                { "wind_speed_unit", WindSpeedMappings[weatherRequest.WindSpeedUnit] },
                { "precipitation_unit", PrecipitationMappings[weatherRequest.PrecipitationUnit] }
            };

            if (includeCurrent)
                parameters.Add("current", OpenMeteoParameterLists.Current);

            if (includeHourly)
                parameters.Add("hourly", OpenMeteoParameterLists.Hourly);

            if (includeDaily)
                parameters.Add("daily", OpenMeteoParameterLists.Daily);

            return parameters;
        }
    }
}