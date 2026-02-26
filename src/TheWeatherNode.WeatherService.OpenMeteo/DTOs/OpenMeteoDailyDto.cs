using System.Text.Json.Serialization;

namespace TheWeatherNode.WeatherService.OpenMeteo.DTOs
{
    /// <summary>
    /// Represents daily weather forecast data from the Open-Meteo API.
    /// </summary>
    /// <remarks>
    /// Contains arrays of aggregated weather measurements for each day,
    /// providing daily summaries of temperature extremes, precipitation, wind conditions,
    /// and other meteorological parameters.
    /// Each property contains data points aligned with corresponding time stamps.
    /// 
    /// Temperature, wind speed, and precipitation values are received in metric units
    /// (Celsius, km/h, mm) from the API and can be converted to imperial units
    /// (Fahrenheit, mph, inches) as needed by the consuming application.
    /// </remarks>
    public class OpenMeteoDailyDto
    {
        /// <summary>
        /// Gets or sets the list of date strings in YYYY-MM-DD format for each daily data point.
        /// </summary>
        /// <remarks>
        /// Each element represents the date for the corresponding index in other properties.
        /// </remarks>
        [JsonPropertyName("time")]
        public List<string> Time { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily maximum temperature forecasts.
        /// </summary>
        /// <remarks>
        /// Values are in degrees Celsius.
        /// To convert to Fahrenheit: (°C × 9/5) + 32 = °F
        /// </remarks>
        [JsonPropertyName("temperature_2m_max")]
        public List<double> TemperatureMax { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily minimum temperature forecasts.
        /// </summary>
        /// <remarks>
        /// Values are in degrees Celsius.
        /// To convert to Fahrenheit: (°C × 9/5) + 32 = °F
        /// </remarks>
        [JsonPropertyName("temperature_2m_min")]
        public List<double> TemperatureMin { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily maximum apparent temperature (feels-like) forecasts.
        /// </summary>
        /// <remarks>
        /// Values are in degrees Celsius.
        /// Accounts for wind chill and humidity effects on how temperature feels to humans.
        /// To convert to Fahrenheit: (°C × 9/5) + 32 = °F
        /// </remarks>
        [JsonPropertyName("apparent_temperature_max")]
        public List<double> FeelsLikeMax { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily minimum apparent temperature (feels-like) forecasts.
        /// </summary>
        /// <remarks>
        /// Values are in degrees Celsius.
        /// Accounts for wind chill and humidity effects on how temperature feels to humans.
        /// To convert to Fahrenheit: (°C × 9/5) + 32 = °F
        /// </remarks>
        [JsonPropertyName("apparent_temperature_min")]
        public List<double> FeelsLikeMin { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily maximum relative humidity forecasts.
        /// </summary>
        /// <remarks>
        /// Values are percentages (0-100), representing the ratio of actual water vapor
        /// to maximum water vapor the air can hold at that temperature.
        /// </remarks>
        [JsonPropertyName("relative_humidity_2m_max")]
        public List<double> HumidityMax { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily minimum relative humidity forecasts.
        /// </summary>
        /// <remarks>
        /// Values are percentages (0-100), representing the ratio of actual water vapor
        /// to maximum water vapor the air can hold at that temperature.
        /// </remarks>
        [JsonPropertyName("relative_humidity_2m_min")]
        public List<double> HumidityMin { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily mean atmospheric pressure at mean sea level.
        /// </summary>
        /// <remarks>
        /// Values are in hectopascals (hPa).
        /// To convert to inches of mercury: hPa × 0.02953 = inHg
        /// To convert to millibars: 1 hPa = 1 mb
        /// </remarks>
        [JsonPropertyName("pressure_msl_mean")]
        public List<double> PressureMean { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily total precipitation amount forecasts.
        /// </summary>
        /// <remarks>
        /// Values are in millimeters.
        /// To convert to inches: mm × 0.0393701 = inches
        /// Includes rain, snow, and other forms of precipitation combined.
        /// </remarks>
        [JsonPropertyName("precipitation_sum")]
        public List<double> PrecipitationSum { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily maximum precipitation probability forecasts.
        /// </summary>
        /// <remarks>
        /// Values are percentages (0-100), indicating the probability of precipitation occurring during the day.
        /// </remarks>
        [JsonPropertyName("precipitation_probability_max")]
        public List<double> PrecipitationProbabilityMax { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily maximum wind speed forecasts at 10 meters height.
        /// </summary>
        /// <remarks>
        /// Values are in kilometers per hour (km/h).
        /// To convert to miles per hour: km/h × 0.621371 = mph
        /// To convert to knots: km/h × 0.539957 = knots
        /// </remarks>
        [JsonPropertyName("wind_speed_10m_max")]
        public List<double> WindSpeedMax { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily maximum wind gust speed forecasts at 10 meters height.
        /// </summary>
        /// <remarks>
        /// Values are in kilometers per hour (km/h).
        /// Wind gusts are short-duration peak wind speeds.
        /// To convert to miles per hour: km/h × 0.621371 = mph
        /// To convert to knots: km/h × 0.539957 = knots
        /// </remarks>
        [JsonPropertyName("wind_gusts_10m_max")]
        public List<double> WindGustsMax { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily dominant wind direction forecasts.
        /// </summary>
        /// <remarks>
        /// Values are in degrees (0-359), representing the most frequent wind direction during the day.
        /// 0° = North, 45° = Northeast, 90° = East, 135° = Southeast,
        /// 180° = South, 225° = Southwest, 270° = West, 315° = Northwest
        /// </remarks>
        [JsonPropertyName("wind_direction_10m_dominant")]
        public List<double> WindDirectionDominant { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily maximum UV index forecasts.
        /// </summary>
        /// <remarks>
        /// UV Index scale:
        /// 0-2: Low exposure
        /// 3-5: Moderate exposure
        /// 6-7: High exposure
        /// 8-10: Very high exposure
        /// 11+: Extreme exposure
        /// </remarks>
        [JsonPropertyName("uv_index_max")]
        public List<double> UvIndexMax { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily WMO Weather Codes representing forecasted weather conditions.
        /// </summary>
        /// <remarks>
        /// Values follow the WMO 4677 standard for weather code definitions.
        /// Represents the most severe weather condition occurring during the day.
        /// See WMO Weather Code documentation for specific code meanings.
        /// </remarks>
        [JsonPropertyName("weather_code")]
        public List<int> WeatherCode { get; set; } = [];

        /// <summary>
        /// Gets or sets the ISO 8601 timestamps for sunrise at the requested location for each day.
        /// </summary>
        /// <remarks>
        /// Timestamp is in UTC (Zulu time). Time should be converted to local timezone
        /// using the timezone information from the parent forecast response.
        /// </remarks>
        /// <example>2024-02-25T06:45:00Z</example>
        [JsonPropertyName("sunrise")]
        public List<string> Sunrise { get; set; } = [];

        /// <summary>
        /// Gets or sets the ISO 8601 timestamps for sunset at the requested location for each day.
        /// </summary>
        /// <remarks>
        /// Timestamp is in UTC (Zulu time). Time should be converted to local timezone
        /// using the timezone information from the parent forecast response.
        /// </remarks>
        /// <example>2024-02-25T18:30:00Z</example>
        [JsonPropertyName("sunset")]
        public List<string> Sunset { get; set; } = [];
    }
}
