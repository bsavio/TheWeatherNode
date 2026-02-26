namespace TheWeatherNode.Core.Models
{
    /// <summary>
    /// Represents a daily weather forecast for a specific location and date.
    /// </summary>
    /// <remarks>
    /// This model serves as the domain model for daily forecast data, typically mapped
    /// from the <see cref="TheWeatherNode.WeatherService.OpenMeteo.DTOs.OpenMeteoDailyDto"/> DTO.
    /// 
    /// All temperature, wind speed, and precipitation values are stored in metric units:
    /// - Temperature: Celsius
    /// - Wind Speed: kilometers per hour (km/h)
    /// - Pressure: hectopascals (hPa)
    /// - Precipitation: millimeters (mm)
    /// 
    /// These values can be converted to imperial units by consuming services as needed:
    /// - Temperature: (°C × 9/5) + 32 = °F
    /// - Wind Speed: km/h × 0.621371 = mph
    /// - Pressure: hPa × 0.02953 = inHg
    /// - Precipitation: mm × 0.0393701 = inches
    /// </remarks>
    public class DailyForecast
    {
        /// <summary>
        /// Gets or sets the date of the forecast.
        /// </summary>
        /// <remarks>
        /// Represents the date (without time component) for which this forecast applies.
        /// All forecast values in this model are aggregates for this entire date.
        /// </remarks>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the maximum temperature for the day in degrees Celsius.
        /// </summary>
        /// <remarks>
        /// The highest air temperature expected to occur during the day.
        /// To convert to Fahrenheit: (°C × 9/5) + 32 = °F
        /// </remarks>
        public double TemperatureMax { get; set; }

        /// <summary>
        /// Gets or sets the minimum temperature for the day in degrees Celsius.
        /// </summary>
        /// <remarks>
        /// The lowest air temperature expected to occur during the day.
        /// To convert to Fahrenheit: (°C × 9/5) + 32 = °F
        /// </remarks>
        public double TemperatureMin { get; set; }

        /// <summary>
        /// Gets or sets the maximum apparent temperature (feels-like) for the day in degrees Celsius.
        /// </summary>
        /// <remarks>
        /// The highest temperature that accounts for wind chill and humidity effects.
        /// Represents how hot it will feel to humans at the warmest point of the day.
        /// To convert to Fahrenheit: (°C × 9/5) + 32 = °F
        /// </remarks>
        public double FeelsLikeMax { get; set; }

        /// <summary>
        /// Gets or sets the minimum apparent temperature (feels-like) for the day in degrees Celsius.
        /// </summary>
        /// <remarks>
        /// The lowest temperature that accounts for wind chill and humidity effects.
        /// Represents how cold it will feel to humans at the coldest point of the day.
        /// To convert to Fahrenheit: (°C × 9/5) + 32 = °F
        /// </remarks>
        public double FeelsLikeMin { get; set; }

        /// <summary>
        /// Gets or sets the maximum relative humidity for the day as a percentage.
        /// </summary>
        /// <remarks>
        /// The highest ratio of actual water vapor to maximum water vapor the air can hold.
        /// Range: 0-100 (percent)
        /// </remarks>
        public double HumidityMax { get; set; }

        /// <summary>
        /// Gets or sets the minimum relative humidity for the day as a percentage.
        /// </summary>
        /// <remarks>
        /// The lowest ratio of actual water vapor to maximum water vapor the air can hold.
        /// Range: 0-100 (percent)
        /// </remarks>
        public double HumidityMin { get; set; }

        /// <summary>
        /// Gets or sets the mean atmospheric pressure at mean sea level in hectopascals.
        /// </summary>
        /// <remarks>
        /// The average air pressure measured at sea level for the day.
        /// Unit: hectopascals (hPa)
        /// To convert to inches of mercury: hPa × 0.02953 = inHg
        /// To convert to millibars: 1 hPa = 1 mb
        /// </remarks>
        public double PressureMean { get; set; }

        /// <summary>
        /// Gets or sets the total precipitation amount for the day in millimeters.
        /// </summary>
        /// <remarks>
        /// The cumulative rainfall, snowfall, and other forms of precipitation expected during the day.
        /// Unit: millimeters (mm)
        /// To convert to inches: mm × 0.0393701 = inches
        /// </remarks>
        public double PrecipitationSum { get; set; }

        /// <summary>
        /// Gets or sets the maximum precipitation probability for the day as a percentage.
        /// </summary>
        /// <remarks>
        /// The highest probability of precipitation occurring at any point during the day.
        /// Range: 0-100 (percent)
        /// </remarks>
        public double PrecipitationProbabilityMax { get; set; }

        /// <summary>
        /// Gets or sets the maximum wind speed for the day at 10 meters height in kilometers per hour.
        /// </summary>
        /// <remarks>
        /// The highest sustained wind speed expected to occur during the day.
        /// Measured at standard height of 10 meters above ground.
        /// Unit: kilometers per hour (km/h)
        /// To convert to miles per hour: km/h × 0.621371 = mph
        /// To convert to knots: km/h × 0.539957 = knots
        /// </remarks>
        public double WindSpeedMax { get; set; }

        /// <summary>
        /// Gets or sets the maximum wind gust speed for the day at 10 meters height in kilometers per hour.
        /// </summary>
        /// <remarks>
        /// The highest short-duration peak wind speed expected to occur during the day.
        /// Measured at standard height of 10 meters above ground.
        /// Unit: kilometers per hour (km/h)
        /// To convert to miles per hour: km/h × 0.621371 = mph
        /// To convert to knots: km/h × 0.539957 = knots
        /// </remarks>
        public double WindGustsMax { get; set; }

        /// <summary>
        /// Gets or sets the dominant wind direction for the day in degrees.
        /// </summary>
        /// <remarks>
        /// The most frequent wind direction observed or forecasted during the day.
        /// Range: 0-359 degrees
        /// 0° = North, 45° = Northeast, 90° = East, 135° = Southeast,
        /// 180° = South, 225° = Southwest, 270° = West, 315° = Northwest
        /// </remarks>
        public double WindDirectionDominant { get; set; }

        /// <summary>
        /// Gets or sets the maximum UV index for the day.
        /// </summary>
        /// <remarks>
        /// The highest ultraviolet radiation index expected to occur during the day.
        /// 
        /// UV Index Scale:
        /// 0-2: Low exposure - minimal sun protection required
        /// 3-5: Moderate exposure - sunscreen and protective clothing recommended
        /// 6-7: High exposure - extra precautions necessary
        /// 8-10: Very high exposure - limit outdoor activity
        /// 11+: Extreme exposure - avoid sun exposure
        /// </remarks>
        public double UvIndexMax { get; set; }

        /// <summary>
        /// Gets or sets the WMO Weather Code representing the primary weather condition for the day.
        /// </summary>
        /// <remarks>
        /// Follows the World Meteorological Organization (WMO) 4677 standard.
        /// Represents the most severe or significant weather condition occurring during the day.
        /// 
        /// Common codes:
        /// 0: Clear sky
        /// 1-3: Mainly clear/mostly cloudy
        /// 45, 48: Foggy
        /// 51-67: Drizzle/rain
        /// 71-85: Snow
        /// 80-82: Rain showers
        /// 85-86: Snow showers
        /// 95-99: Thunderstorm
        /// 
        /// See WMO 4677 documentation for complete code definitions.
        /// </remarks>
        public int WeatherCode { get; set; }

        /// <summary>
        /// Gets or sets the time of sunrise for the day in UTC.
        /// </summary>
        /// <remarks>
        /// The exact moment when the sun rises above the horizon.
        /// Time is provided in UTC (Coordinated Universal Time).
        /// Should be converted to local timezone for display to end users.
        /// </remarks>
        public DateTime Sunrise { get; set; }

        /// <summary>
        /// Gets or sets the time of sunset for the day in UTC.
        /// </summary>
        /// <remarks>
        /// The exact moment when the sun descends below the horizon.
        /// Time is provided in UTC (Coordinated Universal Time).
        /// Should be converted to local timezone for display to end users.
        /// </remarks>
        public DateTime Sunset { get; set; }
    }
}