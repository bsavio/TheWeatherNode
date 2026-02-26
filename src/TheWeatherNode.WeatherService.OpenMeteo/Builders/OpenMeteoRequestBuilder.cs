namespace TheWeatherNode.WeatherService.OpenMeteo.Builders
{
    public static class OpenMeteoRequestBuilder
    {
        public static Dictionary<string, object> BuildForecastParameters(
            double latitude,
            double longitude,
            bool includeCurrent = false,
            bool includeHourly = false,
            bool includeDaily = false,
            string temperatureUnit = "fahrenheit",
            string windSpeedUnit = "mph",
            string precipitationUnit = "inch")
        {
            var parameters = new Dictionary<string, object>
            {
                { "latitude", latitude },
                { "longitude", longitude },
                { "temperature_unit", temperatureUnit },
                { "wind_speed_unit", windSpeedUnit },
                { "precipitation_unit", precipitationUnit }
            };

            if (includeCurrent)
                parameters.Add("current", OpenMeteoParameterLists.Current);

            if (includeHourly)
                parameters.Add("hourly", OpenMeteoParameterLists.Hourly);

            if (includeDaily)
                parameters.Add("daily", OpenMeteoParameterLists.Daily);

            return parameters;
        }
    }
}