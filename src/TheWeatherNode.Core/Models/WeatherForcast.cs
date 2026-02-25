namespace TheWeatherNode.Core.Models
{
    public class WeatherForecast
    {
        public Location Location { get; set; } = new();
        public CurrentWeather Current { get; set; } = new();
        public IEnumerable<HourlyForecast> Hourly { get; set; } = [];
        public IEnumerable<DailyForecast> Daily { get; set; } = [];
        public string Timezone { get; set; } = string.Empty;
        public string TimezoneAbbreviation { get; set; } = string.Empty;
    }
}
