using System.Text.Json.Serialization;

namespace TheWeatherNode.WeatherService.OpenMeteo.DTOs
{
    /// <summary>
    /// Represents a geolocation response from the Open-Meteo API.
    /// </summary>
    public class OpenMeteoGeocodingDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for this location.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the location (city/town).
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the latitude coordinate in degrees.
        /// </summary>
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude coordinate in degrees.
        /// </summary>
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the elevation in meters above sea level.
        /// </summary>
        [JsonPropertyName("elevation")]
        public double Elevation { get; set; }

        /// <summary>
        /// Gets or sets the feature code (e.g., PPLA2 for administrative division).
        /// </summary>
        [JsonPropertyName("feature_code")]
        public string? FeatureCode { get; set; }

        /// <summary>
        /// Gets or sets the ISO 3166-1 alpha-2 country code.
        /// </summary>
        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the administrative division 1 identifier (state/province).
        /// </summary>
        [JsonPropertyName("admin1_id")]
        public int Admin1Id { get; set; }

        /// <summary>
        /// Gets or sets the administrative division 2 identifier (county/district).
        /// </summary>
        [JsonPropertyName("admin2_id")]
        public int Admin2Id { get; set; }

        /// <summary>
        /// Gets or sets the administrative division 3 identifier (city/municipality).
        /// </summary>
        [JsonPropertyName("admin3_id")]
        public int Admin3Id { get; set; }

        /// <summary>
        /// Gets or sets the IANA timezone identifier for this location.
        /// </summary>
        [JsonPropertyName("timezone")]
        public string? Timezone { get; set; }

        /// <summary>
        /// Gets or sets the estimated population of this location.
        /// </summary>
        [JsonPropertyName("population")]
        public int Population { get; set; }

        /// <summary>
        /// Gets or sets the list of postal codes associated with this location.
        /// </summary>
        [JsonPropertyName("postcodes")]
        public List<string>? Postcodes { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the country.
        /// </summary>
        [JsonPropertyName("country_id")]
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the full country name.
        /// </summary>
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        /// <summary>
        /// Gets or sets the name of administrative division 1 (state/province).
        /// </summary>
        [JsonPropertyName("admin1")]
        public string? Admin1 { get; set; }

        /// <summary>
        /// Gets or sets the name of administrative division 2 (county/district).
        /// </summary>
        [JsonPropertyName("admin2")]
        public string? Admin2 { get; set; }

        /// <summary>
        /// Gets or sets the name of administrative division 3 (city/municipality).
        /// </summary>
        [JsonPropertyName("admin3")]
        public string? Admin3 { get; set; }
    }
}
