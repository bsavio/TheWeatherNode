namespace TheWeatherNode.Core.Models.Responses
{
    public class SevereWeatherData
    {
        public DateTime Time { get; set; }
        public double Cape { get; set; }               // Convective Available Potential Energy
        public double LiftedIndex { get; set; }        // negative = unstable atmosphere
        public double ConvectivePrecipitation { get; set; }
        public double FreezingLevelHeight { get; set; }
        public double DewPoint { get; set; }
        public double DewPointSpread { get; set; }     // temp - dewpoint, lower = more moisture
        public double SurfacePressure { get; set; }
        public double TotalColumnWater { get; set; }   // precipitable water
    }
}
