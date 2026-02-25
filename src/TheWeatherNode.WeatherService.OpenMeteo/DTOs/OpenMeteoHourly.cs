using System.Text.Json.Serialization;

namespace TheWeatherNode.WeatherService.OpenMeteo.DTOs
{
    /// <summary>
    /// Represents hourly weather forecast data from the Open-Meteo API.
    /// </summary>
    /// <remarks>
    /// Contains arrays of weather measurements sampled at hourly intervals,
    /// allowing for detailed time-series analysis of forecasted weather conditions.
    /// Each property contains data points aligned with corresponding time stamps.
    /// </remarks>
    public class OpenMeteoHourly
    {
        /// <summary>
        /// Gets or sets the list of ISO 8601 timestamps for each hourly data point.
        /// </summary>
        [JsonPropertyName("time")]
        public List<string> Time { get; set; } = [];

        /// <summary>
        /// Gets or sets the hourly air temperature forecasts in degrees Celsius.
        /// </summary>
        [JsonPropertyName("temperature_2m")]
        public List<double> Temperature { get; set; } = [];

        /// <summary>
        /// Gets or sets the hourly apparent temperature (wind chill) forecasts in degrees Celsius.
        /// </summary>
        [JsonPropertyName("apparent_temperature")]
        public List<double> FeelsLike { get; set; } = [];

        /// <summary>
        /// Gets or sets the hourly dew point temperature forecasts in degrees Celsius.
        /// </summary>
        [JsonPropertyName("dewpoint_2m")]
        public List<double> DewPoint { get; set; } = [];

        /// <summary>
        /// Gets or sets the hourly relative humidity forecasts as percentages (0-100).
        /// </summary>
        [JsonPropertyName("relative_humidity_2m")]
        public List<double> Humidity { get; set; } = [];

        /// <summary>
        /// Gets or sets the hourly precipitation probability forecasts as percentages (0-100).
        /// </summary>
        [JsonPropertyName("precipitation_probability")]
        public List<double> PrecipitationProbability { get; set; } = [];

        /// <summary>
        /// Gets or sets the hourly precipitation amount forecasts in millimeters.
        /// </summary>
        [JsonPropertyName("precipitation")]
        public List<double> Precipitation { get; set; } = [];

        /// <summary>
        /// Gets or sets the hourly WMO Weather Codes representing forecasted weather conditions.
        /// </summary>
        /// <remarks>See WMO 4677 standard for weather code definitions.</remarks>
        [JsonPropertyName("weather_code")]
        public List<int> WeatherCode { get; set; } = [];

        /// <summary>
        /// Gets or sets the hourly wind speed forecasts at 10 meters height in km/h.
        /// </summary>
        [JsonPropertyName("wind_speed_10m")]
        public List<double> WindSpeed { get; set; } = [];

        /// <summary>
        /// Gets or sets the hourly wind direction forecasts at 10 meters height in degrees (0-359).
        /// </summary>
        /// <remarks>0° = North, 90° = East, 180° = South, 270° = West</remarks>
        [JsonPropertyName("wind_direction_10m")]
        public List<double> WindDirection { get; set; } = [];

        /// <summary>
        /// Gets or sets the hourly wind gust speed forecasts at 10 meters height in km/h.
        /// </summary>
        [JsonPropertyName("wind_gusts_10m")]
        public List<double> WindGusts { get; set; } = [];

        /// <summary>
        /// Gets or sets the hourly surface air pressure forecasts in hectopascals (hPa).
        /// </summary>
        [JsonPropertyName("surface_pressure")]
        public List<double> Pressure { get; set; } = [];

        /// <summary>
        /// Gets or sets the hourly cloud cover forecasts as percentages (0-100).
        /// </summary>
        [JsonPropertyName("cloud_cover")]
        public List<double> CloudCover { get; set; } = [];

        /// <summary>
        /// Gets or sets the hourly visibility distance forecasts in meters.
        /// </summary>
        [JsonPropertyName("visibility")]
        public List<double> Visibility { get; set; } = [];

        /// <summary>
        /// Gets or sets the hourly Convective Available Potential Energy (CAPE) values in J/kg.
        /// </summary>
        /// <remarks>Indicates atmospheric instability and potential for severe weather.</remarks>
        [JsonPropertyName("cape")]
        public List<double> Cape { get; set; } = [];

        /// <summary>
        /// Gets or sets the hourly Lifted Index values in Kelvin.
        /// </summary>
        /// <remarks>Negative values indicate atmospheric instability and thunderstorm potential.</remarks>
        [JsonPropertyName("lifted_index")]
        public List<double> LiftedIndex { get; set; } = [];

        /// <summary>
        /// Gets or sets the hourly daytime indicator values.
        /// </summary>
        /// <remarks>0 = Night, 1 = Day</remarks>
        [JsonPropertyName("is_day")]
        public List<int> IsDay { get; set; } = [];
    }
}
