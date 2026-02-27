using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeatherNode.Core.Models
{
    /// <summary>
    /// Specifies the temperature unit for weather data.
    /// </summary>
    public enum TemperatureUnit
    {
        /// <summary>
        /// Celsius temperature scale.
        /// </summary>
        Celsius,

        /// <summary>
        /// Fahrenheit temperature scale.
        /// </summary>
        Fahrenheit
    }

    /// <summary>
    /// Specifies the wind speed unit for weather data.
    /// </summary>
    public enum WindSpeedUnit
    {
        /// <summary>
        /// Kilometers per hour (km/h).
        /// </summary>
        Kph,

        /// <summary>
        /// Miles per hour (mph).
        /// </summary>
        Mph,

        /// <summary>
        /// Nautical miles per hour (knots).
        /// </summary>
        Knots
    }

    /// <summary>
    /// Specifies the precipitation unit for weather data.
    /// </summary>
    public enum PrecipitationUnit
    {
        /// <summary>
        /// Millimeters (mm).
        /// </summary>
        Millimeters,

        /// <summary>
        /// Inches (in).
        /// </summary>
        Inches
    }
}