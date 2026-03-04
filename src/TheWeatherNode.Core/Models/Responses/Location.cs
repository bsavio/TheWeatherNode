namespace TheWeatherNode.Core.Models.Responses
{
    /// <summary>
    /// Represents geographic location information retrieved from geocoding operations.
    /// </summary>
    /// <remarks>
    /// This model encapsulates essential geographic and administrative data for a specific location,
    /// including coordinates, political boundaries, and timezone information. It serves as the
    /// response model for geocoding queries and provides the geographic context needed for
    /// weather requests.
    /// 
    /// Locations can represent cities, towns, administrative divisions, or any named geographic point.
    /// The population field provides a relative sense of the location's significance.
    /// </remarks>
    public class Location
    {
        /// <summary>
        /// Gets or sets the name of the location (city, town, or administrative division).
        /// </summary>
        /// <remarks>
        /// The primary display name for the location. This is the most user-friendly identifier
        /// and is typically the city or town name.
        /// 
        /// Examples: "New York", "Paris", "Tokyo", "London"
        /// </remarks>
        /// <example>York</example>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the latitude coordinate of the location in degrees.
        /// </summary>
        /// <remarks>
        /// The geographic latitude measured in decimal degrees, ranging from -90 (South Pole)
        /// to +90 (North Pole). This coordinate is essential for weather API queries.
        /// 
        /// Positive values indicate locations north of the equator (Northern Hemisphere).
        /// Negative values indicate locations south of the equator (Southern Hemisphere).
        /// A value of 0 represents the equator.
        /// </remarks>
        /// <example>40.86807</example>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude coordinate of the location in degrees.
        /// </summary>
        /// <remarks>
        /// The geographic longitude measured in decimal degrees, ranging from -180 to +180.
        /// This coordinate is essential for weather API queries.
        /// 
        /// Positive values indicate locations east of the Prime Meridian.
        /// Negative values indicate locations west of the Prime Meridian.
        /// A value of 0 represents the Prime Meridian (Greenwich/London).
        /// </remarks>
        /// <example>-97.592</example>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the full country name where this location is situated.
        /// </summary>
        /// <remarks>
        /// The complete English name of the country containing this location.
        /// Used for disambiguation when multiple locations share the same city name
        /// across different countries (e.g., "York" in both England and Nebraska, USA).
        /// </remarks>
        /// <example>United States</example>
        public string Country { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ISO 3166-1 alpha-2 country code.
        /// </summary>
        /// <remarks>
        /// The two-letter ISO standard country code for the country containing this location.
        /// This provides a standardized, language-independent identifier for the country.
        /// 
        /// Examples:
        /// - "US" for United States
        /// - "GB" for United Kingdom
        /// - "FR" for France
        /// - "JP" for Japan
        /// - "CA" for Canada
        /// </remarks>
        /// <example>US</example>
        public string CountryCode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the state, province, or administrative division.
        /// </summary>
        /// <remarks>
        /// The first-level administrative division within the country. This typically
        /// represents a state (in the US), province (in Canada), or region (in other countries).
        /// 
        /// Useful for further disambiguation of location names that may be duplicated
        /// within a country (e.g., "Springfield" exists in many US states).
        /// </remarks>
        /// <example>Nebraska</example>
        public string State { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the collection of postal codes associated with this location.
        /// </summary>
        /// <remarks>
        /// A collection of postal code strings that correspond to this geographic location.
        /// Postal codes vary in format by country:
        /// 
        /// Format examples:
        /// - United States: ZIP codes (5 digits, e.g., "68467", or ZIP+4 format "12345-6789")
        /// - Canada: Postal codes (format "A1A 1A1", e.g., "K1A 0B1")
        /// - United Kingdom: Postcodes (format "SW1A 1AA", e.g., "EC1A 1BB")
        /// - Germany: Postal codes (5 digits, e.g., "10115")
        /// - Japan: Postal codes (format "XXX-XXXX", e.g., "100-0001")
        /// 
        /// A location may have multiple postal codes if it spans multiple postal code boundaries
        /// or includes multiple administrative subdivisions. If no postal codes are associated
        /// with the location, this collection will be empty.
        /// </remarks>
        /// <example>68467</example>
        public IEnumerable<string> PostalCodes { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Gets or sets the estimated population of the location.
        /// </summary>
        /// <remarks>
        /// A non-negative integer representing the approximate population size of the location.
        /// This value provides context about the location's significance and scale.
        /// 
        /// Population data may not be available for all locations; in such cases, the value
        /// may be 0 or represent the last known census data.
        /// 
        /// Useful for ranking search results by relevance or size when multiple locations
        /// match a search query.
        /// </remarks>
        /// <example>7864</example>
        public int Population { get; set; }

        /// <summary>
        /// Gets or sets the IANA timezone identifier for this location.
        /// </summary>
        /// <remarks>
        /// The timezone designation in IANA format (also known as the "Olson database" format).
        /// This identifies the timezone rules that apply to this location, accounting for
        /// daylight saving time and historical timezone changes.
        /// 
        /// The timezone is essential for converting UTC timestamps to local time for display
        /// in weather forecasts and other time-sensitive weather data.
        /// 
        /// Examples:
        /// - "America/New_York" (Eastern Time)
        /// - "America/Chicago" (Central Time)
        /// - "Europe/London" (Greenwich Mean Time / British Summer Time)
        /// - "Asia/Tokyo" (Japan Standard Time)
        /// - "Australia/Sydney" (Australian Eastern Time)
        /// </remarks>
        /// <example>America/Chicago</example>
        public string Timezone { get; set; } = string.Empty;
    }
}
