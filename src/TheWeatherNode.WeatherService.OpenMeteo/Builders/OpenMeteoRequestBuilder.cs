using TheWeatherNode.Core.Models;
using TheWeatherNode.Core.Models.Requests;

namespace TheWeatherNode.WeatherService.OpenMeteo.Builders
{
    public static class OpenMeteoRequestBuilder
    {
        public static IDictionary<TemperatureUnit, string> TemperatureMappings = new Dictionary<TemperatureUnit, string>
        {
            { TemperatureUnit.Celsius, "celsius" },
            { TemperatureUnit.Fahrenheit, "fahrenheit" }
        };

        private static readonly IDictionary<WindSpeedUnit, string> WindSpeedMappings = new Dictionary<WindSpeedUnit, string>
        {
            { WindSpeedUnit.Kph, "km/h" },
            { WindSpeedUnit.Mph, "mph" },
            { WindSpeedUnit.Knots, "knots" }
        };

        private static readonly IDictionary<PrecipitationUnit, string> PrecipitationMappings = new Dictionary<PrecipitationUnit, string>
        {
            { PrecipitationUnit.Millimeters, "mm" },
            { PrecipitationUnit.Inches, "inch" }
        };

        public static Dictionary<string, object> BuildForecastParameters(
            WeatherRequest weatherRequest,
            bool includeCurrent = false,
            bool includeHourly = false,
            bool includeDaily = false)
        {
            var parameters = new Dictionary<string, object>
            {
                { "latitude", weatherRequest.Latitude },
                { "longitude", weatherRequest.Longitude },
                { "temperature_unit", TemperatureMappings[weatherRequest.TemperatureUnit] },
                { "wind_speed_unit", WindSpeedMappings[weatherRequest.WindSpeedUnit] },
                { "precipitation_unit", PrecipitationMappings[weatherRequest.PrecipitationUnit] }
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