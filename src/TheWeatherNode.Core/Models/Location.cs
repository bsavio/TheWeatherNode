namespace TheWeatherNode.Core.Models
{
    public class Location
    {
        public string Name { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;  // admin1 in Open-Meteo
        public int Population { get; set; }
        public string Timezone { get; set; } = string.Empty;
    }
}
