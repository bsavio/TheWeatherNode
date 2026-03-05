using TheWeatherNode.Core.Extensions;
using TheWeatherNode.Core.Models;

namespace TheWeatherNode.Core.Models.Requests
{
    /// <summary>
    /// Represents a request for weather data at a specified geographic location with unit preferences.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="WeatherRequest"/> class encapsulates all parameters necessary to retrieve weather forecast data
    /// from a weather service provider. It includes geographic coordinates (latitude and longitude) and unit preferences
    /// for temperature, wind speed, and precipitation.
    /// </para>
    /// <para>
    /// <strong>Unit Conversion:</strong>
    /// String-based unit parameters provided to the constructor are automatically converted to their corresponding
    /// enum types (<see cref="TemperatureUnit"/>, <see cref="WindSpeedUnit"/>, <see cref="PrecipitationUnit"/>) during
    /// instantiation. This provides type safety and validates units at the point of request creation, preventing
    /// invalid requests from being created.
    /// </para>
    /// <para>
    /// <strong>Supported Units:</strong>
    /// <list type="table">
    /// <listheader>
    /// <term>Unit Type</term>
    /// <description>Supported Values</description>
    /// </listheader>
    /// <item>
    /// <term>Temperature</term>
    /// <description>"celsius", "fahrenheit"</description>
    /// </item>
    /// <item>
    /// <term>Wind Speed</term>
    /// <description>"kmh", "km/h", "mph", "knots"</description>
    /// </item>
    /// <item>
    /// <term>Precipitation</term>
    /// <description>"millimeters", "mm", "inches", "in"</description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// <strong>Coordinate Validation:</strong>
    /// While the constructor does not validate coordinate ranges, all coordinates must conform to standard
    /// geographic standards:
    /// <list type="bullet">
    /// <item><description>Latitude: -90° to 90°</description></item>
    /// <item><description>Longitude: -180° to 180°</description></item>
    /// </list>
    /// Weather service implementations are responsible for coordinate validation before making API calls.
    /// </para>
    /// <para>
    /// <strong>Immutability Note:</strong>
    /// Properties are settable to allow for flexibility in different usage scenarios. However, for typical usage,
    /// it is recommended to set all values during construction and treat the object as immutable thereafter.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// <strong>Using string-based unit parameters (automatic conversion):</strong>
    /// </para>
    /// <code>
    /// // Create a request for New York City with Fahrenheit and mph
    /// var request = new WeatherRequest(
    ///     latitude: 40.7128,
    ///     longitude: -74.0060,
    ///     temperatureUnit: "fahrenheit",
    ///     windSpeedUnit: "mph",
    ///     precipitationUnit: "inches");
    /// </code>
    /// <para>
    /// <strong>Using enum-based unit parameters (type-safe):</strong>
    /// </para>
    /// <code>
    /// // Create a request using strongly-typed unit enums
    /// var request = new WeatherRequest(
    ///     latitude: 40.7128,
    ///     longitude: -74.0060,
    ///     temperatureUnit: TemperatureUnit.Fahrenheit,
    ///     windSpeedUnit: WindSpeedUnit.Mph,
    ///     precipitationUnit: PrecipitationUnit.Inches);
    /// </code>
    /// <para>
    /// <strong>Using default parameters:</strong>
    /// </para>
    /// <code>
    /// // Create a request with metric defaults (Celsius, km/h, millimeters)
    /// var request = new WeatherRequest(
    ///     latitude: 48.8566,
    ///     longitude: 2.3522); // Paris, France
    /// </code>
    /// </example>
    /// <exception cref="ArgumentNullException">
    /// Thrown by the string-based constructor when any unit string parameter is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown by the string-based constructor when an invalid unit string is provided that cannot be converted
    /// to its corresponding enum type. See <see cref="Extensions.UnitTypeExtensions"/> for valid unit strings.
    /// </exception>
    /// <seealso cref="Extensions.UnitTypeExtensions"/>
    /// <seealso cref="TemperatureUnit"/>
    /// <seealso cref="WindSpeedUnit"/>
    /// <seealso cref="PrecipitationUnit"/>
    public class WeatherRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherRequest"/> class with default parameter values.
        /// </summary>
        /// <remarks>
        /// This parameterless constructor provides default initialization when object properties need to be set
        /// after instantiation. Properties must be set manually before using the request with a weather service.
        /// </remarks>
        public WeatherRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherRequest"/> class with string-based unit parameters.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This constructor accepts unit preferences as strings and automatically converts them to their corresponding
        /// enum types using extension methods from <see cref="Extensions.UnitTypeExtensions"/>. Unit strings are
        /// case-insensitive and support common aliases (e.g., "km/h" and "kmh" both map to <see cref="WindSpeedUnit.Kmh"/>).
        /// </para>
        /// <para>
        /// Invalid unit strings will cause an <see cref="ArgumentException"/> to be thrown immediately during construction,
        /// preventing the creation of requests with unsupported units.
        /// </para>
        /// </remarks>
        /// <param name="latitude">
        /// The latitude coordinate in decimal degrees. 
        /// Valid range: -90.0 to 90.0
        /// <list type="bullet">
        /// <item><description>Positive values: Northern Hemisphere (north of equator)</description></item>
        /// <item><description>Negative values: Southern Hemisphere (south of equator)</description></item>
        /// <item><description>0: On the equator</description></item>
        /// <item><description>Example: 40.7128 = New York City</description></item>
        /// </list>
        /// </param>
        /// <param name="longitude">
        /// The longitude coordinate in decimal degrees.
        /// Valid range: -180.0 to 180.0
        /// <list type="bullet">
        /// <item><description>Positive values: East of prime meridian (Greenwich/London)</description></item>
        /// <item><description>Negative values: West of prime meridian</description></item>
        /// <item><description>0: On the prime meridian</description></item>
        /// <item><description>Example: -74.0060 = New York City</description></item>
        /// </list>
        /// </param>
        /// <param name="temperatureUnit">
        /// The desired temperature unit for the API response. Case-insensitive.
        /// <list type="bullet">
        /// <item><description>"celsius" or "c" → <see cref="TemperatureUnit.Celsius"/></description></item>
        /// <item><description>"fahrenheit" or "f" → <see cref="TemperatureUnit.Fahrenheit"/></description></item>
        /// </list>
        /// Default: "celsius" (metric standard)
        /// </param>
        /// <param name="windSpeedUnit">
        /// The desired wind speed unit for the API response. Case-insensitive with alias support.
        /// <list type="bullet">
        /// <item><description>"kmh" or "km/h" → <see cref="WindSpeedUnit.Kmh"/> (kilometers per hour)</description></item>
        /// <item><description>"mph" → <see cref="WindSpeedUnit.Mph"/> (miles per hour)</description></item>
        /// <item><description>"knots" → <see cref="WindSpeedUnit.Knots"/> (nautical miles per hour)</description></item>
        /// </list>
        /// Default: "km/h" (metric standard)
        /// </param>
        /// <param name="precipitationUnit">
        /// The desired precipitation unit for the API response. Case-insensitive with alias support.
        /// <list type="bullet">
        /// <item><description>"millimeters" or "mm" → <see cref="PrecipitationUnit.Millimeters"/></description></item>
        /// <item><description>"inches" or "in" → <see cref="PrecipitationUnit.Inches"/></description></item>
        /// </list>
        /// Default: "millimeters" (metric standard)
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="temperatureUnit"/>, <paramref name="windSpeedUnit"/>, or 
        /// <paramref name="precipitationUnit"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when an invalid unit string is provided. The exception message indicates which unit is invalid
        /// and the supported values. Call the extension methods in <see cref="Extensions.UnitTypeExtensions"/> 
        /// to see valid unit string formats.
        /// </exception>
        /// <example>
        /// <code>
        /// // Create request for New York City with US units
        /// var request = new WeatherRequest(
        ///     latitude: 40.7128,
        ///     longitude: -74.0060,
        ///     temperatureUnit: "fahrenheit",
        ///     windSpeedUnit: "mph",
        ///     precipitationUnit: "inches");
        /// 
        /// // Results in:
        /// // Latitude: 40.7128
        /// // Longitude: -74.0060
        /// // TemperatureUnit: TemperatureUnit.Fahrenheit
        /// // WindSpeedUnit: WindSpeedUnit.Mph
        /// // PrecipitationUnit: PrecipitationUnit.Inches
        /// </code>
        /// </example>
        public WeatherRequest(
            double latitude,
            double longitude,
            string temperatureUnit = "celsius",
            string windSpeedUnit = "km/h",
            string precipitationUnit = "millimeters")
        {
            Latitude = latitude;
            Longitude = longitude;
            TemperatureUnit = temperatureUnit.ToTemperatureUnit();
            WindSpeedUnit = windSpeedUnit.ToWindSpeedUnit();
            PrecipitationUnit = precipitationUnit.ToPrecipitationUnit();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherRequest"/> class with enum-based unit parameters.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This constructor accepts unit preferences as strongly-typed enum values, providing compile-time type safety
        /// and eliminating the need for string parsing and validation. This is the recommended constructor when unit
        /// values are already known at compile time or come from other enums in the application.
        /// </para>
        /// <para>
        /// Using enums directly avoids the overhead and potential errors of string conversion, making this constructor
        /// ideal for internal service-to-service communication and programmatic request construction where unit types
        /// are determined by application logic rather than user input.
        /// </para>
        /// </remarks>
        /// <param name="latitude">
        /// The latitude coordinate in decimal degrees.
        /// Valid range: -90.0 to 90.0
        /// <list type="bullet">
        /// <item><description>Positive values: Northern Hemisphere (north of equator)</description></item>
        /// <item><description>Negative values: Southern Hemisphere (south of equator)</description></item>
        /// <item><description>0: On the equator</description></item>
        /// </list>
        /// </param>
        /// <param name="longitude">
        /// The longitude coordinate in decimal degrees.
        /// Valid range: -180.0 to 180.0
        /// <list type="bullet">
        /// <item><description>Positive values: East of prime meridian</description></item>
        /// <item><description>Negative values: West of prime meridian</description></item>
        /// <item><description>0: On the prime meridian</description></item>
        /// </list>
        /// </param>
        /// <param name="temperatureUnit">
        /// The desired temperature unit enum value.
        /// <list type="bullet">
        /// <item><description><see cref="TemperatureUnit.Celsius"/>: Degrees Celsius (metric standard)</description></item>
        /// <item><description><see cref="TemperatureUnit.Fahrenheit"/>: Degrees Fahrenheit (US standard)</description></item>
        /// </list>
        /// Default: <see cref="TemperatureUnit.Celsius"/>
        /// </param>
        /// <param name="windSpeedUnit">
        /// The desired wind speed unit enum value.
        /// <list type="bullet">
        /// <item><description><see cref="WindSpeedUnit.Kmh"/>: Kilometers per hour (metric standard)</description></item>
        /// <item><description><see cref="WindSpeedUnit.Mph"/>: Miles per hour (US standard)</description></item>
        /// <item><description><see cref="WindSpeedUnit.Knots"/>: Knots - nautical miles per hour (marine/aviation standard)</description></item>
        /// </list>
        /// Default: <see cref="WindSpeedUnit.Kmh"/>
        /// </param>
        /// <param name="precipitationUnit">
        /// The desired precipitation unit enum value.
        /// <list type="bullet">
        /// <item><description><see cref="PrecipitationUnit.Millimeters"/>: Millimeters (metric standard)</description></item>
        /// <item><description><see cref="PrecipitationUnit.Inches"/>: Inches (imperial/US standard)</description></item>
        /// </list>
        /// Default: <see cref="PrecipitationUnit.Millimeters"/>
        /// </param>
        /// <example>
        /// <code>
        /// // Create a type-safe request using enum values
        /// var request = new WeatherRequest(
        ///     latitude: 40.7128,
        ///     longitude: -74.0060,
        ///     temperatureUnit: TemperatureUnit.Fahrenheit,
        ///     windSpeedUnit: WindSpeedUnit.Mph,
        ///     precipitationUnit: PrecipitationUnit.Inches);
        /// 
        /// // Or using a method that returns unit enums
        /// var userPreferences = GetUserUnitPreferences(); // Returns enum values
        /// var request = new WeatherRequest(
        ///     latitude: userPreferences.Latitude,
        ///     longitude: userPreferences.Longitude,
        ///     temperatureUnit: userPreferences.TemperatureUnit,
        ///     windSpeedUnit: userPreferences.WindSpeedUnit,
        ///     precipitationUnit: userPreferences.PrecipitationUnit);
        /// </code>
        /// </example>
        /// <seealso cref="TemperatureUnit"/>
        /// <seealso cref="WindSpeedUnit"/>
        /// <seealso cref="PrecipitationUnit"/>
        public WeatherRequest(
            double latitude,
            double longitude,
            TemperatureUnit temperatureUnit,
            WindSpeedUnit windSpeedUnit,
            PrecipitationUnit precipitationUnit)
        {
            Latitude = latitude;
            Longitude = longitude;
            TemperatureUnit = temperatureUnit;
            WindSpeedUnit = windSpeedUnit;
            PrecipitationUnit = precipitationUnit;
        }

        /// <summary>
        /// Gets or sets the latitude coordinate in decimal degrees for the requested location.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Latitude specifies the north-south position on Earth's surface.
        /// </para>
        /// <para>
        /// <strong>Valid Range:</strong> -90° to 90°
        /// <list type="bullet">
        /// <item><description><strong>90°:</strong> North Pole</description></item>
        /// <item><description><strong>0°:</strong> Equator</description></item>
        /// <item><description><strong>-90°:</strong> South Pole</description></item>
        /// </list>
        /// </para>
        /// <para>
        /// <strong>Examples:</strong>
        /// <list type="bullet">
        /// <item><description>40.7128: New York City</description></item>
        /// <item><description>48.8566: Paris, France</description></item>
        /// <item><description>-33.8688: Sydney, Australia</description></item>
        /// <item><description>35.6762: Tokyo, Japan</description></item>
        /// </list>
        /// </para>
        /// <para>
        /// Note: The constructor does not validate the coordinate range. Weather service implementations should
        /// validate coordinates before making API calls. Invalid coordinates will result in service errors.
        /// </para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var request = new WeatherRequest();
        /// request.Latitude = 40.7128; // New York City latitude
        /// </code>
        /// </example>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude coordinate in decimal degrees for the requested location.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Longitude specifies the east-west position on Earth's surface, measured from the Prime Meridian 
        /// (which passes through Greenwich, London).
        /// </para>
        /// <para>
        /// <strong>Valid Range:</strong> -180° to 180°
        /// <list type="bullet">
        /// <item><description><strong>0°:</strong> Prime Meridian (Greenwich/London)</description></item>
        /// <item><description><strong>180° or -180°:</strong> International Date Line (Pacific Ocean)</description></item>
        /// <item><description><strong>Positive values:</strong> East of Prime Meridian</description></item>
        /// <item><description><strong>Negative values:</strong> West of Prime Meridian</description></item>
        /// </list>
        /// </para>
        /// <para>
        /// <strong>Examples:</strong>
        /// <list type="bullet">
        /// <item><description>-74.0060: New York City</description></item>
        /// <item><description>2.3522: Paris, France</description></item>
        /// <item><description>151.2093: Sydney, Australia</description></item>
        /// <item><description>139.6503: Tokyo, Japan</description></item>
        /// </list>
        /// </para>
        /// <para>
        /// Note: The constructor does not validate the coordinate range. Weather service implementations should
        /// validate coordinates before making API calls. Invalid coordinates will result in service errors.
        /// </para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var request = new WeatherRequest();
        /// request.Longitude = -74.0060; // New York City longitude
        /// </code>
        /// </example>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the desired temperature unit for the weather API response.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Specifies whether temperature values in the API response should be expressed in Celsius or Fahrenheit.
        /// This value is determined by converting the temperature unit string provided in the constructor, or can
        /// be set directly using the enum.
        /// </para>
        /// <para>
        /// <strong>Supported Units:</strong>
        /// <list type="bullet">
        /// <item><description><see cref="TemperatureUnit.Celsius"/>: Degrees Celsius (metric standard)</description></item>
        /// <item><description><see cref="TemperatureUnit.Fahrenheit"/>: Degrees Fahrenheit (US standard)</description></item>
        /// </list>
        /// </para>
        /// <para>
        /// <strong>Conversion Formula:</strong> °F = (°C × 9/5) + 32
        /// </para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var request = new WeatherRequest(40.7128, -74.0060);
        /// var unit = request.TemperatureUnit; // TemperatureUnit.Celsius (default)
        /// 
        /// request.TemperatureUnit = TemperatureUnit.Fahrenheit; // Change to Fahrenheit
        /// </code>
        /// </example>
        /// <seealso cref="TemperatureUnit"/>
        public TemperatureUnit TemperatureUnit { get; set; }

        /// <summary>
        /// Gets or sets the desired wind speed unit for the weather API response.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Specifies the unit of measurement for wind speed values in the API response. The value is determined by
        /// converting the wind speed unit string provided in the constructor, or can be set directly using the enum.
        /// </para>
        /// <para>
        /// <strong>Supported Units:</strong>
        /// <list type="bullet">
        /// <item><description><see cref="WindSpeedUnit.Kmh"/>: Kilometers per hour (metric standard)</description></item>
        /// <item><description><see cref="WindSpeedUnit.Mph"/>: Miles per hour (US standard)</description></item>
        /// <item><description><see cref="WindSpeedUnit.Knots"/>: Knots - nautical miles per hour (marine/aviation standard)</description></item>
        /// </list>
        /// </para>
        /// <para>
        /// <strong>Conversion Reference:</strong>
        /// <list type="bullet">
        /// <item><description>1 km/h = 0.621371 mph</description></item>
        /// <item><description>1 km/h = 0.539957 knots</description></item>
        /// <item><description>1 mph = 1.60934 km/h</description></item>
        /// <item><description>1 knot = 1.852 km/h</description></item>
        /// </list>
        /// </para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var request = new WeatherRequest(40.7128, -74.0060, windSpeedUnit: "kmh");
        /// var unit = request.WindSpeedUnit; // WindSpeedUnit.Kmh (set from string)
        /// 
        /// request.WindSpeedUnit = WindSpeedUnit.Knots; // Change to nautical measurements
        /// </code>
        /// </example>
        /// <seealso cref="WindSpeedUnit"/>
        public WindSpeedUnit WindSpeedUnit { get; set; }

        /// <summary>
        /// Gets or sets the desired precipitation unit for the weather API response.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Specifies the unit of measurement for precipitation amounts (rain, snow, etc.) in the API response.
        /// The value is determined by converting the precipitation unit string provided in the constructor, or can
        /// be set directly using the enum.
        /// </para>
        /// <para>
        /// <strong>Supported Units:</strong>
        /// <list type="bullet">
        /// <item><description><see cref="PrecipitationUnit.Millimeters"/>: Millimeters (metric standard, commonly used in meteorology)</description></item>
        /// <item><description><see cref="PrecipitationUnit.Inches"/>: Inches (imperial/US standard)</description></item>
        /// </list>
        /// </para>
        /// <para>
        /// <strong>Conversion Reference:</strong>
        /// <list type="bullet">
        /// <item><description>1 inch = 25.4 millimeters</description></item>
        /// <item><description>1 millimeter = 0.0393701 inches</description></item>
        /// </list>
        /// </para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var request = new WeatherRequest(40.7128, -74.0060, precipitationUnit: "mm");
        /// var unit = request.PrecipitationUnit; // PrecipitationUnit.Millimeters
        /// 
        /// request.PrecipitationUnit = PrecipitationUnit.Inches; // Change to inches
        /// </code>
        /// </example>
        /// <seealso cref="PrecipitationUnit"/>
        public PrecipitationUnit PrecipitationUnit { get; set; }
    }
}
