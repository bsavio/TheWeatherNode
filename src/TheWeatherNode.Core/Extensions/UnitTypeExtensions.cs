using TheWeatherNode.Core.Models;

namespace TheWeatherNode.Core.Extensions
{
    /// <summary>
    /// Provides extension methods for unit type conversions.
    /// </summary>
    public static class UnitTypeExtensions
    {
        /// <summary>
        /// Converts a string to a <see cref="TemperatureUnit"/> with case-insensitive matching.
        /// </summary>
        /// <param name="value">The string value to convert (e.g., "celsius", "Fahrenheit", "CELSIUS").</param>
        /// <returns>The corresponding <see cref="TemperatureUnit"/> value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the string value does not match any valid <see cref="TemperatureUnit"/>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="value"/> is null.
        /// </exception>
        /// <remarks>
        /// This method performs case-insensitive matching. Valid inputs include:
        /// - "celsius", "Celsius", "CELSIUS"
        /// - "fahrenheit", "Fahrenheit", "FAHRENHEIT"
        /// </remarks>
        public static TemperatureUnit ToTemperatureUnit(this string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Temperature unit string cannot be null.");

            if (Enum.TryParse<TemperatureUnit>(value, ignoreCase: true, out var result))
                return result;

            throw new ArgumentException(
                $"'{value}' is not a valid temperature unit. Valid values are: {string.Join(", ", Enum.GetNames(typeof(TemperatureUnit)))}",
                nameof(value));
        }

        /// <summary>
        /// Converts a <see cref="TemperatureUnit"/> to its string representation.
        /// </summary>
        /// <param name="unit">The temperature unit to convert.</param>
        /// <returns>The string representation of the temperature unit (e.g., "Celsius", "Fahrenheit").</returns>
        /// <remarks>
        /// This method returns the enum name as-is without modification.
        /// To get a different string representation, use custom mappings or convert to lowercase/uppercase explicitly.
        /// </remarks>
        public static string ToTemperatureUnitString(this TemperatureUnit unit)
        {
            return unit.ToString();
        }

        /// <summary>
        /// Converts a string to a <see cref="WindSpeedUnit"/> with case-insensitive matching and alias support.
        /// </summary>
        /// <param name="value">The string value to convert (e.g., "kph", "km/h", "mph", "knots").</param>
        /// <returns>The corresponding <see cref="WindSpeedUnit"/> value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the string value does not match any valid <see cref="WindSpeedUnit"/> or its aliases.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="value"/> is null.
        /// </exception>
        /// <remarks>
        /// This method performs case-insensitive matching and supports common aliases:
        /// 
        /// For Kph (kilometers per hour):
        /// - "kph", "KPH", "Kph", "km/h", "kmh", "km\h"
        /// 
        /// For Mph (miles per hour):
        /// - "mph", "MPH", "Mph"
        /// 
        /// For Knots (nautical miles per hour):
        /// - "knots", "KNOTS", "Knots"
        /// </remarks>
        public static WindSpeedUnit ToWindSpeedUnit(this string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Wind speed unit string cannot be null.");

            // Normalize the input by removing spaces and converting to lowercase
            var normalizedValue = value.Trim().ToLowerInvariant().Replace(" ", "");

            // Check for Kph aliases
            if (normalizedValue is "kph" or "km/h" or "kmh" or "km\\h")
                return WindSpeedUnit.Kph;

            // Check for Mph aliases
            if (normalizedValue is "mph")
                return WindSpeedUnit.Mph;

            // Check for Knots aliases
            if (normalizedValue is "knots")
                return WindSpeedUnit.Knots;

            // Fallback to enum name matching for any other input
            if (Enum.TryParse<WindSpeedUnit>(value, ignoreCase: true, out var result))
                return result;

            throw new ArgumentException(
                $"'{value}' is not a valid wind speed unit. Valid values are: kph, km/h, kmh, mph, knots",
                nameof(value));
        }

        /// <summary>
        /// Converts a <see cref="WindSpeedUnit"/> to its string representation.
        /// </summary>
        /// <param name="unit">The wind speed unit to convert.</param>
        /// <returns>The string representation of the wind speed unit (e.g., "Kph", "Mph", "Knots").</returns>
        /// <remarks>
        /// This method returns the enum name as-is without modification.
        /// To get a different string representation (e.g., "km/h" instead of "Kph"),
        /// consider implementing a separate method with custom mappings.
        /// </remarks>
        public static string ToWindSpeedUnitString(this WindSpeedUnit unit)
        {
            return unit.ToString();
        }

        /// <summary>
        /// Converts a <see cref="WindSpeedUnit"/> to its common abbreviation string.
        /// </summary>
        /// <param name="unit">The wind speed unit to convert.</param>
        /// <returns>The abbreviated string representation (e.g., "km/h", "mph", "knots").</returns>
        /// <remarks>
        /// This method returns common abbreviations used in weather data and API responses.
        /// </remarks>
        public static string ToWindSpeedUnitAbbreviation(this WindSpeedUnit unit)
        {
            return unit switch
            {
                WindSpeedUnit.Kph => "km/h",
                WindSpeedUnit.Mph => "mph",
                WindSpeedUnit.Knots => "knots",
                _ => unit.ToString()
            };
        }

        /// <summary>
        /// Converts a string to a <see cref="PrecipitationUnit"/> with case-insensitive matching and alias support.
        /// </summary>
        /// <param name="value">The string value to convert (e.g., "millimeters", "mm", "inches", "in").</param>
        /// <returns>The corresponding <see cref="PrecipitationUnit"/> value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the string value does not match any valid <see cref="PrecipitationUnit"/> or its aliases.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="value"/> is null.
        /// </exception>
        /// <remarks>
        /// This method performs case-insensitive matching and supports common aliases:
        /// 
        /// For Millimeters:
        /// - "millimeters", "Millimeters", "MILLIMETERS", "mm", "MM"
        /// 
        /// For Inches:
        /// - "inches", "Inches", "INCHES", "in", "IN"
        /// </remarks>
        public static PrecipitationUnit ToPrecipitationUnit(this string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Precipitation unit string cannot be null.");

            // Normalize the input by converting to lowercase
            var normalizedValue = value.Trim().ToLowerInvariant();

            // Check for Millimeters aliases
            if (normalizedValue is "millimeters" or "mm")
                return PrecipitationUnit.Millimeters;

            // Check for Inches aliases
            if (normalizedValue is "inches" or "in")
                return PrecipitationUnit.Inches;

            // Fallback to enum name matching for any other input
            if (Enum.TryParse<PrecipitationUnit>(value, ignoreCase: true, out var result))
                return result;

            throw new ArgumentException(
                $"'{value}' is not a valid precipitation unit. Valid values are: millimeters, mm, inches, in",
                nameof(value));
        }

        /// <summary>
        /// Converts a <see cref="PrecipitationUnit"/> to its string representation.
        /// </summary>
        /// <param name="unit">The precipitation unit to convert.</param>
        /// <returns>The string representation of the precipitation unit (e.g., "Millimeters", "Inches").</returns>
        /// <remarks>
        /// This method returns the enum name as-is without modification.
        /// To get abbreviations (e.g., "mm" instead of "Millimeters"),
        /// consider implementing a separate method with custom mappings.
        /// </remarks>
        public static string ToPrecipitationUnitString(this PrecipitationUnit unit)
        {
            return unit.ToString();
        }

        /// <summary>
        /// Converts a <see cref="PrecipitationUnit"/> to its common abbreviation string.
        /// </summary>
        /// <param name="unit">The precipitation unit to convert.</param>
        /// <returns>The abbreviated string representation (e.g., "mm", "in").</returns>
        /// <remarks>
        /// This method returns common abbreviations used in weather data and API responses.
        /// </remarks>
        public static string ToPrecipitationUnitAbbreviation(this PrecipitationUnit unit)
        {
            return unit switch
            {
                PrecipitationUnit.Millimeters => "mm",
                PrecipitationUnit.Inches => "in",
                _ => unit.ToString()
            };
        }
    }
}
