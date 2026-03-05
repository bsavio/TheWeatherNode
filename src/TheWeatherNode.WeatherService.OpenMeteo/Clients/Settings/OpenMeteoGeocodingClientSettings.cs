namespace TheWeatherNode.WeatherService.OpenMeteo.Clients.Settings
{
    /// <summary>
    /// Configuration _settings specific to the Open-Meteo Geocoding API client.
    /// </summary>
    /// <remarks>
    /// This class extends <see cref="OpenMeteoClientSettingsBase"/> to provide geocoding-specific
    /// configuration parameters. It encapsulates all runtime _settings required to initialize and
    /// configure the HTTP client for geocoding operations.
    /// 
    /// These _settings are typically loaded from application configuration (appsettings.json or
    /// environment variables) during dependency injection setup and passed to the geocoding client.
    /// 
    /// Example configuration in appsettings.json:
    /// <code>
    /// {
    ///   "OpenMeteoGeocodingClientSettings": {
    ///     "BaseUrl": "https://geocoding-api.open-meteo.com/v1/",
    ///     "Timeout": 15.0,
    ///     "SearchEndPoint": "search"
    ///   }
    /// }
    /// </code>
    /// 
    /// Inherits from <see cref="OpenMeteoClientSettingsBase"/>:
    /// - <see cref="OpenMeteoClientSettingsBase.BaseUrl"/>: Base URL for the geocoding API
    /// - <see cref="OpenMeteoClientSettingsBase.Timeout"/>: HTTP request timeout in seconds
    /// </remarks>
    public class OpenMeteoGeocodingClientSettings : OpenMeteoClientSettingsBase
    {
        /// <summary>
        /// Gets or sets the API endpoint path for geocoding search operations.
        /// </summary>
        /// <remarks>
        /// This endpoint path is appended to the <see cref="OpenMeteoClientSettingsBase.BaseUrl"/>
        /// to form the complete URL for geocoding search requests.
        /// 
        /// The endpoint supports both forward geocoding (searching by location name) and reverse
        /// geocoding (searching by coordinates). The actual geocoding type is determined by the
        /// query parameters sent with the request.
        /// 
        /// The default value "search" is the standard endpoint used by the Open-Meteo Geocoding API.
        /// This setting allows for flexibility if the API structure changes in future versions or
        /// if alternative endpoint paths need to be supported.
        /// 
        /// Complete URL example:
        /// BaseUrl: "https://geocoding-api.open-meteo.com/v1/"
        /// SearchEndPoint: "search"
        /// Final URL: "https://geocoding-api.open-meteo.com/v1/search"
        /// </remarks>
        /// <example>search</example>
        public string SearchEndPoint { get; set; } = string.Empty;
    }
}
