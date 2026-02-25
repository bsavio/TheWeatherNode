using System.Text.Json.Serialization;

namespace TheWeatherNode.WeatherService.OpenMeteo.DTOs
{
    /// <summary>
    /// Represents current weather conditions from the Open-Meteo API.
    /// </summary>
    /// <remarks>
    /// Contains real-time weather data including temperature, wind, precipitation,
    /// and atmospheric measurements at the time of API request.
    /// </remarks>
    public class OpenMeteoCurrent
    {
        /// <summary>
        /// Gets or sets the ISO 8601 timestamp of the current weather observation.
        /// </summary>
        /// <example>2024-02-25T14:30:00Z</example>
        [JsonPropertyName("time")]
        public string Time { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the current air temperature in degrees Celsius.
        /// </summary>
        [JsonPropertyName("temperature_2m")]
        public double Temperature { get; set; }

        /// <summary>
        /// Gets or sets the apparent temperature (wind chill) in degrees Celsius.
        /// </summary>
        [JsonPropertyName("apparent_temperature")]
        public double FeelsLike { get; set; }

        /// <summary>
        /// Gets or sets the dew point temperature in degrees Celsius.
        /// </summary>
        [JsonPropertyName("dewpoint_2m")]
        public double DewPoint { get; set; }

        /// <summary>
        /// Gets or sets the relative humidity as a percentage (0-100).
        /// </summary>
        [JsonPropertyName("relative_humidity_2m")]
        public double Humidity { get; set; }

        /// <summary>
        /// Gets or sets the wind speed at 10 meters height in km/h.
        /// </summary>
        [JsonPropertyName("wind_speed_10m")]
        public double WindSpeed { get; set; }

        /// <summary>
        /// Gets or sets the wind direction at 10 meters height in degrees (0-359).
        /// </summary>
        /// <remarks>0° = North, 90° = East, 180° = South, 270° = West</remarks>
        [JsonPropertyName("wind_direction_10m")]
        public double WindDirection { get; set; }

        /// <summary>
        /// Gets or sets the wind gust speed at 10 meters height in km/h.
        /// </summary>
        [JsonPropertyName("wind_gusts_10m")]
        public double WindGusts { get; set; }

        /// <summary>
        /// Gets or sets the current precipitation amount in millimeters.
        /// </summary>
        [JsonPropertyName("precipitation")]
        public double Precipitation { get; set; }

        /// <summary>
        /// Gets or sets the probability of precipitation as a percentage (0-100).
        /// </summary>
        [JsonPropertyName("precipitation_probability")]
        public double PrecipitationProbability { get; set; }

        /// <summary>
        /// Gets or sets the surface air pressure in hectopascals (hPa).
        /// </summary>
        [JsonPropertyName("surface_pressure")]
        public double Pressure { get; set; }

        /// <summary>
        /// Gets or sets the visibility distance in meters.
        /// </summary>
        [JsonPropertyName("visibility")]
        public double Visibility { get; set; }

        /// <summary>
        /// Gets or sets the UV index value.
        /// </summary>
        /// <remarks>0-2: Low, 3-5: Moderate, 6-7: High, 8-10: Very High, 11+: Extreme</remarks>
        [JsonPropertyName("uv_index")]
        public double UvIndex { get; set; }

        /// <summary>
        /// Gets or sets the cloud cover as a percentage (0-100).
        /// </summary>
        [JsonPropertyName("cloud_cover")]
        public double CloudCover { get; set; }

        /// <summary>
        /// Gets or sets the WMO Weather Code representing current weather conditions.
        /// </summary>
        /// <remarks>See WMO 4677 standard for weather code definitions.</remarks>
        [JsonPropertyName("weather_code")]
        public int WeatherCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is currently daytime.
        /// </summary>
        /// <remarks>0 = Night, 1 = Day</remarks>
        [JsonPropertyName("is_day")]
        public int IsDay { get; set; }
    }
}
