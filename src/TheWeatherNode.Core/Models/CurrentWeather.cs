namespace TheWeatherNode.Core.Models
{
    // Models/CurrentWeather.cs
    public class CurrentWeather
    {
        public double Temperature { get; set; }
        public double FeelsLike { get; set; }
        public double DewPoint { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public double WindDirection { get; set; }
        public double WindGusts { get; set; }
        public double Precipitation { get; set; }
        public double PrecipitationProbability { get; set; }
        public double Pressure { get; set; }
        public double Visibility { get; set; }
        public double UvIndex { get; set; }
        public double CloudCover { get; set; }
        public int WeatherCode { get; set; }           // WMO weather code
        public bool IsDay { get; set; }
        public DateTime Time { get; set; }
    }
}
