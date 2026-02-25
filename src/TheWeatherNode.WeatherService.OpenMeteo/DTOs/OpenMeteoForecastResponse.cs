using System.Text.Json.Serialization;

namespace TheWeatherNode.WeatherService.OpenMeteo.DTOs
{
    /// <summary>
    /// Represents the root response object from the Open-Meteo API forecast endpoint.
    /// </summary>
    /// <remarks>
    /// This DTO maps the JSON response from Open-Meteo's weather forecast API, containing
    /// geographic information and weather data aggregated at current, hourly, and daily intervals.
    /// </remarks>
    public class OpenMeteoForecastResponse
    {
        /// <summary>
        /// Gets or sets the latitude coordinate of the requested location.
        /// </summary>
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude coordinate of the requested location.
        /// </summary>
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the IANA time zone identifier for the location.
        /// </summary>
        /// <example>Europe/London, America/New_York</example>
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the abbreviated time zone name.
        /// </summary>
        /// <example>GMT, EST, PST</example>
        [JsonPropertyName("timezone_abbreviation")]
        public string TimezoneAbbreviation { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the current weather conditions.
        /// </summary>
        [JsonPropertyName("current")]
        public OpenMeteoCurrent? Current { get; set; }

        /// <summary>
        /// Gets or sets the hourly weather forecast data.
        /// </summary>
        [JsonPropertyName("hourly")]
        public OpenMeteoHourly? Hourly { get; set; }

        /// <summary>
        /// Gets or sets the daily weather forecast data.
        /// </summary>
        [JsonPropertyName("daily")]
        public OpenMeteoDaily? Daily { get; set; }
    }
}