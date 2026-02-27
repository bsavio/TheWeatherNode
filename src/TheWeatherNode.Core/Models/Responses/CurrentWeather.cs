namespace TheWeatherNode.Core.Models.Responses
{
    /// <summary>
    /// Represents the current weather conditions at a specific location and time.
    /// </summary>
    /// <remarks>
    /// This response model contains real-time weather measurements and observations,
    /// typically representing the current moment or the most recent weather observation.
    /// All values are stored in the units specified by the request (metric or imperial).
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
    public class CurrentWeather
    {
        /// <summary>
        /// Gets or sets the current air temperature.
        /// </summary>
        /// <remarks>
        /// Unit depends on the request unit preference (Celsius or Fahrenheit).
        /// </remarks>
        public double Temperature { get; set; }

        /// <summary>
        /// Gets or sets the apparent temperature (wind chill/heat index).
        /// </summary>
        /// <remarks>
        /// Accounts for the combined effects of temperature, wind speed, and humidity.
        /// Represents how the temperature actually feels to humans.
        /// Unit depends on the request unit preference (Celsius or Fahrenheit).
        /// </remarks>
        public double FeelsLike { get; set; }

        /// <summary>
        /// Gets or sets the dew point temperature.
        /// </summary>
        /// <remarks>
        /// The temperature to which air must be cooled to reach 100% relative humidity,
        /// assuming constant atmospheric pressure and water vapor content.
        /// A higher dew point indicates more moisture in the air.
        /// Unit depends on the request unit preference (Celsius or Fahrenheit).
        /// </remarks>
        public double DewPoint { get; set; }

        /// <summary>
        /// Gets or sets the relative humidity as a percentage.
        /// </summary>
        /// <remarks>
        /// Range: 0-100 (percent)
        /// 0% = completely dry air
        /// 100% = air saturated with moisture
        /// </remarks>
        public double Humidity { get; set; }

        /// <summary>
        /// Gets or sets the wind speed at 10 meters height.
        /// </summary>
        /// <remarks>
        /// Unit depends on the request unit preference (km/h, mph, or knots).
        /// Measured at standard height of 10 meters above ground.
        /// </remarks>
        public double WindSpeed { get; set; }

        /// <summary>
        /// Gets or sets the wind direction in degrees.
        /// </summary>
        /// <remarks>
        /// Range: 0-359 degrees
        /// 0° = North
        /// 90° = East
        /// 180° = South
        /// 270° = West
        /// </remarks>
        public double WindDirection { get; set; }

        /// <summary>
        /// Gets or sets the wind gust speed at 10 meters height.
        /// </summary>
        /// <remarks>
        /// The maximum short-duration peak wind speed at the current moment.
        /// Unit depends on the request unit preference (km/h, mph, or knots).
        /// Measured at standard height of 10 meters above ground.
        /// Wind gusts are typically higher than sustained wind speeds.
        /// </remarks>
        public double WindGusts { get; set; }

        /// <summary>
        /// Gets or sets the current precipitation amount.
        /// </summary>
        /// <remarks>
        /// Represents the amount of rain, snow, or other precipitation currently falling.
        /// Unit depends on the request unit preference (millimeters or inches).
        /// </remarks>
        public double Precipitation { get; set; }

        /// <summary>
        /// Gets or sets the probability of precipitation as a percentage.
        /// </summary>
        /// <remarks>
        /// Range: 0-100 (percent)
        /// 0% = no precipitation expected
        /// 100% = precipitation certain
        /// Indicates the likelihood of precipitation occurring at the current time.
        /// </remarks>
        public double PrecipitationProbability { get; set; }

        /// <summary>
        /// Gets or sets the atmospheric pressure at sea level.
        /// </summary>
        /// <remarks>
        /// Unit depends on the request unit preference (hectopascals or inches of mercury).
        /// Used to indicate weather systems and atmospheric stability.
        /// High pressure generally indicates fair weather, while low pressure indicates poor weather.
        /// </remarks>
        public double Pressure { get; set; }

        /// <summary>
        /// Gets or sets the visibility distance.
        /// </summary>
        /// <remarks>
        /// Unit depends on the request unit preference (meters or feet).
        /// Represents the maximum distance at which objects can be clearly seen.
        /// Reduced visibility may indicate fog, precipitation, or air pollution.
        /// </remarks>
        public double Visibility { get; set; }

        /// <summary>
        /// Gets or sets the ultraviolet (UV) index value.
        /// </summary>
        /// <remarks>
        /// A measure of the strength of ultraviolet radiation from the sun.
        /// 
        /// UV Index Scale:
        /// 0-2: Low exposure - minimal sun protection required
        /// 3-5: Moderate exposure - sunscreen and protective clothing recommended
        /// 6-7: High exposure - extra precautions necessary
        /// 8-10: Very high exposure - limit outdoor activity, seek shade
        /// 11+: Extreme exposure - avoid sun exposure
        /// </remarks>
        public double UvIndex { get; set; }

        /// <summary>
        /// Gets or sets the cloud cover as a percentage.
        /// </summary>
        /// <remarks>
        /// Range: 0-100 (percent)
        /// 0% = clear sky
        /// 50% = partly cloudy
        /// 100% = completely overcast (no visible sky)
        /// </remarks>
        public double CloudCover { get; set; }

        /// <summary>
        /// Gets or sets the WMO Weather Code representing the current weather condition.
        /// </summary>
        /// <remarks>
        /// Follows the World Meteorological Organization (WMO) 4677 standard.
        /// Describes the primary weather condition occurring at the current time.
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
        /// Gets or sets a value indicating whether it is currently daytime.
        /// </summary>
        /// <remarks>
        /// true = day (sun is above the horizon)
        /// false = night (sun is below the horizon)
        /// Useful for adjusting UI elements or applying day/night specific logic.
        /// </remarks>
        public bool IsDay { get; set; }

        /// <summary>
        /// Gets or sets the ISO 8601 timestamp for this weather observation.
        /// </summary>
        /// <remarks>
        /// Timestamp is in UTC (Coordinated Universal Time).
        /// Should be converted to the local timezone using the timezone information
        /// from the parent <see cref="WeatherForecast"/> response for display to end users.
        /// </remarks>
        /// <example>2024-02-25T14:30:00Z</example>
        public DateTime Time { get; set; }
    }
}
