namespace TheWeatherNode.WeatherService.OpenMeteo.Clients.Settings
{
    /// <summary>
    /// Configuration _settings specific to the Open-Meteo weather API client.
    /// </summary>
    /// <remarks>
    /// This class extends <see cref="OpenMeteoClientSettingsBase"/> to provide weather-specific
    /// configuration parameters. It encapsulates all runtime _settings required to initialize and
    /// configure the HTTP client for weather forecast operations.
    /// 
    /// These _settings are typically loaded from application configuration (appsettings.json or
    /// environment variables) during dependency injection setup and passed to the weather client.
    /// 
    /// Example configuration in appsettings.json:
    /// <code>
    /// {
    ///   "OpenMeteoWeatherClientSettings": {
    ///     "BaseUrl": "https://api.open-meteo.com/v1/",
    ///     "Timeout": 30.0,
    ///     "ForcastEndPoint": "forecast"
    ///   }
    /// }
    /// </code>
    /// 
    /// Inherits from <see cref="OpenMeteoClientSettingsBase"/>:
    /// - <see cref="OpenMeteoClientSettingsBase.BaseUrl"/>: Base URL for the weather API
    /// - <see cref="OpenMeteoClientSettingsBase.Timeout"/>: HTTP request timeout in seconds
    /// </remarks>
    public class OpenMeteoWeatherClientSettings : OpenMeteoClientSettingsBase
    {
        /// <summary>
        /// Gets or sets the API endpoint path for weather forecast operations.
        /// </summary>
        /// <remarks>
        /// This endpoint path is appended to the <see cref="OpenMeteoClientSettingsBase.BaseUrl"/>
        /// to form the complete URL for weather forecast requests.
        /// 
        /// The endpoint supports retrieving multiple types of weather data through query parameters:
        /// - Current weather conditions
        /// - Hourly weather forecasts
        /// - Daily weather forecasts
        /// 
        /// The actual data returned is determined by the query parameters (current, hourly, daily)
        /// sent with the request, not by different endpoint paths.
        /// 
        /// The default value "forecast" is the standard endpoint used by the Open-Meteo Weather API.
        /// This setting allows for flexibility if the API structure changes in future versions or
        /// if alternative endpoint paths need to be supported.
        /// 
        /// Complete URL example:
        /// BaseUrl: "https://api.open-meteo.com/v1/"
        /// ForcastEndPoint: "forecast"
        /// Final URL: "https://api.open-meteo.com/v1/forecast"
        /// </remarks>
        /// <example>forecast</example>
        public string ForcastEndPoint { get; set; } = string.Empty;
    }
}