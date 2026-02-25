namespace TheWeatherNode.Core.Models
{
    public class DailyForecast
    {
        public DateTime Date { get; set; }
        public double TemperatureMax { get; set; }
        public double TemperatureMin { get; set; }
        public double PrecipitationSum { get; set; }
        public double PrecipitationProbabilityMax { get; set; }
        public double WindSpeedMax { get; set; }
        public double WindGustsMax { get; set; }
        public double WindDirectionDominant { get; set; }
        public double UvIndexMax { get; set; }
        public int WeatherCode { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
    }
}
