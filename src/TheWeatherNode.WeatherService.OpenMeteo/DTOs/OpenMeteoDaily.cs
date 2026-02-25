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
    /// </remarks>
    public class OpenMeteoDaily
    {
        /// <summary>
        /// Gets or sets the list of date strings (YYYY-MM-DD format) for each daily data point.
        /// </summary>
        [JsonPropertyName("time")]
        public List<string> Time { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily maximum temperature forecasts in degrees Celsius.
        /// </summary>
        [JsonPropertyName("temperature_2m_max")]
        public List<double> TemperatureMax { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily minimum temperature forecasts in degrees Celsius.
        /// </summary>
        [JsonPropertyName("temperature_2m_min")]
        public List<double> TemperatureMin { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily total precipitation amount forecasts in millimeters.
        /// </summary>
        [JsonPropertyName("precipitation_sum")]
        public List<double> PrecipitationSum { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily maximum precipitation probability forecasts as percentages (0-100).
        /// </summary>
        [JsonPropertyName("precipitation_probability_max")]
        public List<double> PrecipitationProbabilityMax { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily maximum wind speed forecasts at 10 meters height in km/h.
        /// </summary>
        [JsonPropertyName("wind_speed_10m_max")]
        public List<double> WindSpeedMax { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily maximum wind gust speed forecasts at 10 meters height in km/h.
        /// </summary>
        [JsonPropertyName("wind_gusts_10m_max")]
        public List<double> WindGustsMax { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily dominant wind direction forecasts in degrees (0-359).
        /// </summary>
        /// <remarks>0° = North, 90° = East, 180° = South, 270° = West. Dominant direction represents the most frequent wind direction during the day.</remarks>
        [JsonPropertyName("wind_direction_10m_dominant")]
        public List<double> WindDirectionDominant { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily maximum UV index forecasts.
        /// </summary>
        /// <remarks>0-2: Low, 3-5: Moderate, 6-7: High, 8-10: Very High, 11+: Extreme</remarks>
        [JsonPropertyName("uv_index_max")]
        public List<double> UvIndexMax { get; set; } = [];

        /// <summary>
        /// Gets or sets the daily WMO Weather Codes representing forecasted weather conditions.
        /// </summary>
        /// <remarks>See WMO 4677 standard for weather code definitions. Represents the most severe condition during the day.</remarks>
        [JsonPropertyName("weather_code")]
        public List<int> WeatherCode { get; set; } = [];

        /// <summary>
        /// Gets or sets the ISO 8601 timestamps for sunrise at each location for each day.
        /// </summary>
        /// <example>2024-02-25T06:45:00Z</example>
        [JsonPropertyName("sunrise")]
        public List<string> Sunrise { get; set; } = [];

        /// <summary>
        /// Gets or sets the ISO 8601 timestamps for sunset at each location for each day.
        /// </summary>
        /// <example>2024-02-25T18:30:00Z</example>
        [JsonPropertyName("sunset")]
        public List<string> Sunset { get; set; } = [];
    }
}
