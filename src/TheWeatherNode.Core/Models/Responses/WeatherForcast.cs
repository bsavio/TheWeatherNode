namespace TheWeatherNode.Core.Models.Responses
{
    /// <summary>
    /// Represents a comprehensive weather forecast response containing current conditions and forecasts.
    /// </summary>
    /// <remarks>
    /// This response model serves as the primary weather data container, aggregating current weather,
    /// hourly forecasts, daily forecasts, and location information into a single cohesive response object.
    /// It is typically returned by weather service endpoints to provide clients with complete weather information.
    /// 
    /// The forecast data may be in metric or imperial units depending on the unit preferences
    /// specified in the corresponding request object.
    /// 
    /// All timestamp values are in UTC (Coordinated Universal Time) and should be converted
    /// to the local timezone (indicated by <see cref="Timezone"/>) for display to end users.
    /// </remarks>
    public class WeatherForecast
    {
        /// <summary>
        /// Gets or sets the geographic location information for this forecast.
        /// </summary>
        /// <remarks>
        /// Contains coordinates (latitude/longitude) and other location details
        /// for which this forecast data applies.
        /// Defaults to an empty <see cref="Location"/> instance if not set.
        /// </remarks>
        public Location Location { get; set; } = new();

        /// <summary>
        /// Gets or sets the current weather conditions.
        /// </summary>
        /// <remarks>
        /// Contains real-time weather measurements including temperature, humidity,
        /// wind, precipitation, and other current atmospheric conditions.
        /// Defaults to an empty <see cref="CurrentWeather"/> instance if not set.
        /// </remarks>
        public CurrentWeather Current { get; set; } = new();

        /// <summary>
        /// Gets or sets the collection of hourly weather forecasts.
        /// </summary>
        /// <remarks>
        /// An enumerable collection of <see cref="HourlyForecast"/> objects, typically
        /// containing 7-16 days of hourly forecasts depending on the request parameters.
        /// Each element represents weather predictions for a specific hour.
        /// Defaults to an empty collection if not set.
        /// </remarks>
        public IEnumerable<HourlyForecast> Hourly { get; set; } = [];

        /// <summary>
        /// Gets or sets the collection of daily weather forecasts.
        /// </summary>
        /// <remarks>
        /// An enumerable collection of <see cref="DailyForecast"/> objects containing
        /// daily aggregated weather data such as high/low temperatures, total precipitation,
        /// and other daily metrics. Typically contains 7-16 days of forecasts depending on
        /// the request parameters.
        /// Defaults to an empty collection if not set.
        /// </remarks>
        public IEnumerable<DailyForecast> Daily { get; set; } = [];

        /// <summary>
        /// Gets or sets the IANA time zone identifier for the location.
        /// </summary>
        /// <remarks>
        /// Standard time zone identifier used to convert UTC timestamps to local time.
        /// Examples: "America/New_York", "Europe/London", "Asia/Tokyo"
        /// Use this value with time zone libraries to properly convert UTC timestamps
        /// from this forecast to the local time for the location.
        /// Defaults to an empty string if not set.
        /// </remarks>
        /// <example>
        /// "America/New_York" - Eastern Time
        /// "Europe/London" - Greenwich Mean Time / British Summer Time
        /// "Asia/Tokyo" - Japan Standard Time
        /// </example>
        public string Timezone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the abbreviated time zone name.
        /// </summary>
        /// <remarks>
        /// Short abbreviation of the time zone, useful for displaying to end users.
        /// Note that abbreviations can be ambiguous (e.g., "EST" could mean Eastern Standard Time
        /// or several other time zones), so use <see cref="Timezone"/> for accurate conversions.
        /// Defaults to an empty string if not set.
        /// </remarks>
        /// <example>
        /// "EST" - Eastern Standard Time
        /// "EDT" - Eastern Daylight Time
        /// "GMT" - Greenwich Mean Time
        /// "BST" - British Summer Time
        /// "JST" - Japan Standard Time
        /// </example>
        public string TimezoneAbbreviation { get; set; } = string.Empty;
    }
}
