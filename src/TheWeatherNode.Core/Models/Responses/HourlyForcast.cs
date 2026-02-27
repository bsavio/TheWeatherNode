namespace TheWeatherNode.Core.Models.Responses
{
    /// <summary>
    /// Represents hourly weather forecast data for a specific point in time.
    /// </summary>
    /// <remarks>
    /// This response model contains weather measurements and predictions for a single hour,
    /// typically part of a collection spanning multiple hours or days. All values are stored
    /// in the units specified by the request (metric or imperial).
    /// 
    /// Common metric units:
    /// - Temperature: degrees Celsius
    /// - Wind Speed: kilometers per hour (km/h)
    /// - Pressure: hectopascals (hPa)
    /// - Visibility: meters
    /// - Precipitation: millimeters
    /// 
    /// Common imperial units:
    /// - Temperature: degrees Fahrenheit
    /// - Wind Speed: miles per hour (mph)
    /// - Pressure: inches of mercury (inHg)
    /// - Visibility: feet
    /// - Precipitation: inches
    /// </remarks>
    public class HourlyForecast
    {
        /// <summary>
        /// Gets or sets the ISO 8601 timestamp for this hourly forecast.
        /// </summary>
        /// <remarks>
        /// Timestamp is in UTC (Coordinated Universal Time) and should be converted
        /// to local timezone for display to end users.
        /// </remarks>
        /// <example>2024-02-25T14:00:00Z</example>
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the air temperature for this hour.
        /// </summary>
        /// <remarks>
        /// Unit depends on the request unit preference (Celsius or Fahrenheit).
        /// </remarks>
        public double Temperature { get; set; }

        /// <summary>
        /// Gets or sets the apparent temperature (wind chill/heat index) for this hour.
        /// </summary>
        /// <remarks>
        /// Accounts for the combined effects of temperature, wind, and humidity.
        /// Represents how the temperature feels to humans.
        /// Unit depends on the request unit preference (Celsius or Fahrenheit).
        /// </remarks>
        public double FeelsLike { get; set; }

        /// <summary>
        /// Gets or sets the dew point temperature for this hour.
        /// </summary>
        /// <remarks>
        /// The temperature to which air must be cooled to reach 100% relative humidity.
        /// A higher dew point indicates more moisture in the air.
        /// Unit depends on the request unit preference (Celsius or Fahrenheit).
        /// </remarks>
        public double DewPoint { get; set; }

        /// <summary>
        /// Gets or sets the relative humidity for this hour as a percentage.
        /// </summary>
        /// <remarks>
        /// Range: 0-100 (percent)
        /// 0% = completely dry air, 100% = air saturated with moisture
        /// </remarks>
        public double Humidity { get; set; }

        /// <summary>
        /// Gets or sets the wind speed at 10 meters height for this hour.
        /// </summary>
        /// <remarks>
        /// Unit depends on the request unit preference (km/h, mph, or knots).
        /// Measured at standard height of 10 meters above ground.
        /// </remarks>
        public double WindSpeed { get; set; }

        /// <summary>
        /// Gets or sets the wind direction for this hour in degrees.
        /// </summary>
        /// <remarks>
        /// Range: 0-359 degrees
        /// 0° = North, 90° = East, 180° = South, 270° = West
        /// </remarks>
        public double WindDirection { get; set; }

        /// <summary>
        /// Gets or sets the wind gust speed at 10 meters height for this hour.
        /// </summary>
        /// <remarks>
        /// Short-duration peak wind speed during the hour.
        /// Unit depends on the request unit preference (km/h, mph, or knots).
        /// Measured at standard height of 10 meters above ground.
        /// </remarks>
        public double WindGusts { get; set; }

        /// <summary>
        /// Gets or sets the precipitation amount for this hour.
        /// </summary>
        /// <remarks>
        /// Includes rain, snow, and other forms of precipitation combined.
        /// Unit depends on the request unit preference (millimeters or inches).
        /// </remarks>
        public double Precipitation { get; set; }

        /// <summary>
        /// Gets or sets the probability of precipitation for this hour as a percentage.
        /// </summary>
        /// <remarks>
        /// Range: 0-100 (percent)
        /// 0% = no precipitation expected, 100% = precipitation certain
        /// </remarks>
        public double PrecipitationProbability { get; set; }

        /// <summary>
        /// Gets or sets the atmospheric pressure at sea level for this hour.
        /// </summary>
        /// <remarks>
        /// Unit depends on the request unit preference (hectopascals or inches of mercury).
        /// Used to indicate weather systems and atmospheric stability.
        /// </remarks>
        public double Pressure { get; set; }

        /// <summary>
        /// Gets or sets the cloud cover for this hour as a percentage.
        /// </summary>
        /// <remarks>
        /// Range: 0-100 (percent)
        /// 0% = clear sky, 100% = completely overcast
        /// </remarks>
        public double CloudCover { get; set; }

        /// <summary>
        /// Gets or sets the visibility distance for this hour.
        /// </summary>
        /// <remarks>
        /// Unit depends on the request unit preference (meters or feet).
        /// Represents the maximum distance at which objects can be clearly seen.
        /// </remarks>
        public double Visibility { get; set; }

        /// <summary>
        /// Gets or sets the WMO Weather Code for this hour.
        /// </summary>
        /// <remarks>
        /// Follows the World Meteorological Organization (WMO) 4677 standard.
        /// Describes the weather condition occurring during this hour.
        /// 
        /// Common codes:
        /// 0: Clear sky
        /// 1-3: Mainly clear/mostly cloudy
        /// 45, 48: Foggy
        /// 51-67: Drizzle/rain
        /// 71-85: Snow
        /// 80-82: Rain showers
        /// 85-86: Snow showers
        /// 95-99: Thunderstorm
        /// 
        /// See WMO 4677 documentation for complete code definitions.
        /// </remarks>
        public int WeatherCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is daytime during this hour.
        /// </summary>
        /// <remarks>
        /// true = day (sun is above horizon)
        /// false = night (sun is below horizon)
        /// </remarks>
        public bool IsDay { get; set; }
    }
}
