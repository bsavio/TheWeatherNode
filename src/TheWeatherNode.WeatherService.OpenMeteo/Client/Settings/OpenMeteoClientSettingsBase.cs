using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeatherNode.WeatherService.OpenMeteo.Client.Settings
{
    /// <summary>
    /// Base class for Open-Meteo API client configuration _settings.
    /// </summary>
    /// <remarks>
    /// This abstract base class provides common configuration properties shared across
    /// different Open-Meteo API clients (weather forecasting, geocoding, etc.).
    /// It establishes a consistent contract for API client initialization and HTTP communication setup.
    /// 
    /// Derived classes should extend this base class to add API-specific endpoint configurations
    /// and custom _settings as needed.
    /// 
    /// Example derived classes:
    /// - <see cref="OpenMeteoWeatherClientSettings"/>: Configuration for weather forecast API
    /// - <see cref="OpenMeteoGeocodingClientSettings"/>: Configuration for geocoding API
    /// </remarks>
    public abstract class OpenMeteoClientSettingsBase
    {
        /// <summary>
        /// Gets or sets the base URL for the Open-Meteo API.
        /// </summary>
        /// <remarks>
        /// The base URL should point to the root endpoint of the Open-Meteo API service.
        /// Different Open-Meteo services may use different base URLs:
        /// - Weather API: https://api.open-meteo.com/v1/
        /// - Geocoding API: https://geocoding-api.open-meteo.com/v1/
        /// 
        /// This value is used as the foundation for all API requests made by derived client implementations.
        /// Individual endpoint paths are appended to this base URL to form complete request URIs.
        /// </remarks>
        /// <example>https://api.open-meteo.com/v1/</example>
        public string BaseUrl { get; set; } = "";

        /// <summary>
        /// Gets or sets the HTTP request timeout duration in seconds.
        /// </summary>
        /// <remarks>
        /// Specifies the maximum amount of time (in seconds) the HTTP client will wait for
        /// a response from the Open-Meteo API before timing out and throwing an exception.
        /// 
        /// This setting applies to all HTTP requests made through derived client implementations.
        /// 
        /// Recommended values:
        /// - 10-15 seconds: For typical weather forecast and geocoding requests
        /// - 20-30 seconds: For requests with large amounts of data or slow network connections
        /// - 5 seconds or less: For critical operations requiring fast failure detection
        /// 
        /// A value of 0 or negative indicates infinite timeout (not recommended for production environments).
        /// </remarks>
        /// <example>30.0</example>
        public double Timeout { get; set; }
    }
}
