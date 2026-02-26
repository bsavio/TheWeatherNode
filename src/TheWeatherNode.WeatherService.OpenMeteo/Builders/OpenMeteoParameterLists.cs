namespace TheWeatherNode.WeatherService.OpenMeteo.Builders
{
    public static class OpenMeteoParameterLists
    {
        public static readonly List<string> Current =
            [
                "temperature_2m",
                "apparent_temperature",
                "dewpoint_2m",
                "relative_humidity_2m",
                "wind_speed_10m",
                "wind_direction_10m",
                "wind_gusts_10m",
                "precipitation",
                "precipitation_probability",
                "surface_pressure",
                "visibility",
                "uv_index",
                "cloud_cover",
                "weather_code",
                "is_day"

            ];

        public static readonly List<string> Hourly =
            [
                "temperature_2m",
                "apparent_temperature",
                "dewpoint_2m",
                "relative_humidity_2m",
                "precipitation_probability",
                "precipitation",
                "weather_code",
                "wind_speed_10m",
                "wind_direction_10m",
                "wind_gusts_10m",
                "surface_pressure",
                "cloud_cover",
                "visibility",
                "cape",
                "lifted_index",
                "is_day"
            ];
        public static readonly List<string> Daily = 
            [
                "temperature_2m_max",
                "temperature_2m_min",
                "apparent_temperature_max",
                "apparent_temperature_min",
                "relative_humidity_2m_max",
                "relative_humidity_2m_min",
                "pressure_msl_mean",
                "precipitation_sum",
                "precipitation_probability_max",
                "wind_speed_10m_max",
                "wind_gusts_10m_max",
                "wind_direction_10m_dominant",
                "uv_index_max",
                "weather_code",
                "sunrise",
                "sunset",
            ];
    }
}
