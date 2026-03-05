## Classes

Utility

# Namespace TheWeatherNode.Core


Namespace:TheWeatherNode.Core

Assembly:TheWeatherNode.Core.dll

**Inheritance**

object Utility

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Methods

## Parameters

base64EncodedData string

## Returns

string

## Parameters

plainText string

# Class Utility

```
public class Utility
```
##### 

## Base64Decode(string)

```
public static string Base64Decode(string base64EncodedData)
```
## Base64Encode(string)

```
public static string Base64Encode(string plainText)
```

#### Returns

string

Encoding insensitive Bytes to string conversion.

#### Parameters

bytes byte[]

```
The bytes.
```
#### Returns

string

Gets the environment variable.

#### Parameters

value string

```
The value.
```
#### Returns

string

### BytesToString(byte[])

```
public static string BytesToString(byte[] bytes)
```
### GetEnvironmentVariable(string)

```
public static string? GetEnvironmentVariable(string value)
```
### GetEpochTime(DateTime?)


#### Parameters

dateTime DateTime?

#### Returns

int

Parses the string to enum.

#### Parameters

value string

```
The value.
```
#### Returns

##### T

#### Type Parameters

##### T

Encoding insensitive String to bytes conversion.

#### Parameters

```
public static int GetEpochTime(DateTime? dateTime = null)
```
### ParseEnum<T>(string)

```
public static T ParseEnum<T>(string value)
```
### StringToBytes(string)

```
public static byte[] StringToBytes(string str)
```

str string

```
The string.
```
#### Returns

byte[]

Strings to stream.

#### Parameters

str string

```
The string.
```
#### Returns

Stream

### StringToStream(string)

```
public static Stream StringToStream(string str)
```

## Classes

AppSettingsProvider

## Interfaces

IAppSettingsProvider

# Namespace TheWeatherNode.Core.Config


Namespace:TheWeatherNode.Core.Config

Assembly:TheWeatherNode.Core.dll

**Inheritance**

object AppSettingsProvider

**Implements**
IAppSettingsProvider

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Constructors

Initializes a new instance of the AppSettingsProvider class.

## Parameters

appSettingsStream Stream

## Methods

# Class AppSettingsProvider

```
public class AppSettingsProvider : IAppSettingsProvider
```
##### 

## AppSettingsProvider()

```
public AppSettingsProvider()
```
## AppSettingsProvider(Stream)

```
public AppSettingsProvider(Stream appSettingsStream)
```

Gets the application setting.

#### Returns

##### T

#### Type Parameters

##### T

Gets the application setting.

#### Parameters

appSetting string

```
The application setting.
```
#### Returns

##### T

#### Type Parameters

##### T

Gets the configuration section.

### GetAppSetting<T>()

```
public T GetAppSetting<T>()
```
### GetAppSetting<T>(string)

```
public T GetAppSetting<T>(string appSetting)
```
### GetConfigSection(string)


#### Parameters

appSetting string

```
The application setting.
```
#### Returns

IConfigurationSection

Gets the environment.

#### Returns

string

```
public IConfigurationSection GetConfigSection(string appSetting)
```
### GetEnvironment()

```
public string GetEnvironment()
```

Namespace:TheWeatherNode.Core.Config

Assembly:TheWeatherNode.Core.dll

## Methods

## Returns

##### T

## Type Parameters

##### T

## Parameters

appSetting string

## Returns

##### T

## Type Parameters

# Interface IAppSettingsProvider

```
public interface IAppSettingsProvider
```
## GetAppSetting<T>()

```
T GetAppSetting<T>()
```
## GetAppSetting<T>(string)

```
T GetAppSetting<T>(string appSetting)
```

##### T

#### Parameters

appSetting string

#### Returns

IConfigurationSection

#### Returns

string

### GetConfigSection(string)

```
IConfigurationSection GetConfigSection(string appSetting)
```
### GetEnvironment()

```
string GetEnvironment()
```

## Classes

UnitTypeExtensions
Provides extension methods for unit type conversions.

# Namespace TheWeatherNode.Core.Extensions


Namespace:TheWeatherNode.Core.Extensions

Assembly:TheWeatherNode.Core.dll

Provides extension methods for unit type conversions.

**Inheritance**

object UnitTypeExtensions

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Methods

Converts a string to a PrecipitationUnit with case-insensitive matching and alias support.

## Parameters

value string

```
The string value to convert (e.g., "millimeters", "mm", "inches", "in").
```
## Returns

PrecipitationUnit

```
The corresponding PrecipitationUnit value.
```
## Remarks

This method performs case-insensitive matching and supports common aliases:

# Class UnitTypeExtensions

```
public static class UnitTypeExtensions
```
##### 

## ToPrecipitationUnit(string)

```
public static PrecipitationUnit ToPrecipitationUnit(this string value)
```

For Millimeters:

```
"millimeters", "Millimeters", "MILLIMETERS", "mm", "MM"
```
For Inches:

```
"inches", "Inches", "INCHES", "in", "IN"
```
#### Exceptions

ArgumentException

```
Thrown when the string value does not match any valid PrecipitationUnit or its aliases.
```
ArgumentNullException

```
Thrown when value is null.
```
Converts a PrecipitationUnit to its common abbreviation string.

#### Parameters

unit PrecipitationUnit

```
The precipitation unit to convert.
```
#### Returns

string

```
The abbreviated string representation (e.g., "mm", "in").
```
#### Remarks

This method returns common abbreviations used in weather data and API responses.

### ToPrecipitationUnitAbbreviation(PrecipitationUnit)

```
public static string ToPrecipitationUnitAbbreviation(this PrecipitationUnit unit)
```
### ToPrecipitationUnitString(PrecipitationUnit)


Converts a PrecipitationUnit to its string representation.

#### Parameters

unit PrecipitationUnit

```
The precipitation unit to convert.
```
#### Returns

string

```
The string representation of the precipitation unit (e.g., "Millimeters", "Inches").
```
#### Remarks

This method returns the enum name as-is without modification. To get abbreviations (e.g., "mm" instead
of "Millimeters"), consider implementing a separate method with custom mappings.

Converts a string to a TemperatureUnit with case-insensitive matching.

#### Parameters

value string

```
The string value to convert (e.g., "celsius", "Fahrenheit", "CELSIUS").
```
#### Returns

TemperatureUnit

```
The corresponding TemperatureUnit value.
```
#### Remarks

```
public static string ToPrecipitationUnitString(this PrecipitationUnit unit)
```
### ToTemperatureUnit(string)

```
public static TemperatureUnit ToTemperatureUnit(this string value)
```

This method performs case-insensitive matching. Valid inputs include:

```
"celsius", "Celsius", "CELSIUS", "c", "C"
"fahrenheit", "Fahrenheit", "FAHRENHEIT", "f", "F"
```
#### Exceptions

ArgumentException

```
Thrown when the string value does not match any valid TemperatureUnit.
```
ArgumentNullException

```
Thrown when value is null.
```
Converts a TemperatureUnit to its string representation.

#### Parameters

unit TemperatureUnit

```
The temperature unit to convert.
```
#### Returns

string

```
The string representation of the temperature unit (e.g., "Celsius", "Fahrenheit").
```
#### Remarks

This method returns the enum name as-is without modification. To get a different string representation,
use custom mappings or convert to lowercase/uppercase explicitly.

Converts a string to a WindSpeedUnit with case-insensitive matching and alias support.

### ToTemperatureUnitString(TemperatureUnit)

```
public static string ToTemperatureUnitString(this TemperatureUnit unit)
```
### ToWindSpeedUnit(string)


#### Parameters

value string

```
The string value to convert (e.g., "kmh", "km/h", "mph", "knots").
```
#### Returns

WindSpeedUnit

```
The corresponding WindSpeedUnit value.
```
#### Remarks

This method performs case-insensitive matching and supports common aliases:

For Kmh (kilometers per hour):

```
"kmh", "KPH", "Kmh", "km/h", "kmh", "km\h"
```
For Mph (miles per hour):

```
"mph", "MPH", "Mph"
```
For Knots (nautical miles per hour):

```
"knots", "KNOTS", "Knots"
```
#### Exceptions

ArgumentException

```
Thrown when the string value does not match any valid WindSpeedUnit or its aliases.
```
ArgumentNullException

```
Thrown when value is null.
```
Converts a WindSpeedUnit to its common abbreviation string.

```
public static WindSpeedUnit ToWindSpeedUnit(this string value)
```
### ToWindSpeedUnitAbbreviation(WindSpeedUnit)


#### Parameters

unit WindSpeedUnit

```
The wind speed unit to convert.
```
#### Returns

string

```
The abbreviated string representation (e.g., "km/h", "mph", "knots").
```
#### Remarks

This method returns common abbreviations used in weather data and API responses.

Converts a WindSpeedUnit to its string representation.

#### Parameters

unit WindSpeedUnit

```
The wind speed unit to convert.
```
#### Returns

string

```
The string representation of the wind speed unit (e.g., "Kmh", "Mph", "Knots").
```
#### Remarks

This method returns the enum name as-is without modification. To get a different string representation
(e.g., "km/h" instead of "Kmh"), consider implementing a separate method with custom mappings.

```
public static string ToWindSpeedUnitAbbreviation(this WindSpeedUnit unit)
```
### ToWindSpeedUnitString(WindSpeedUnit)

```
public static string ToWindSpeedUnitString(this WindSpeedUnit unit)
```

## Interfaces

IGeocodingService
Defines the contract for geocoding service operations.

IWeatherService
Defines the contract for weather forecast data services.

# Namespace TheWeatherNode.Core.Interfaces


Namespace:TheWeatherNode.Core.Interfaces

Assembly:TheWeatherNode.Core.dll

Defines the contract for geocoding service operations.

## Remarks

This interface abstracts geocoding functionality, enabling location name to coordinate conversions and
vice versa. Implementations may use various geocoding providers (e.g., Open-Meteo, Google Maps, etc.).

Geocoding operations support:

```
Forward geocoding: Converting location names to geographic coordinates
Reverse geocoding: Converting coordinates to location names
Location search with optional country filtering for refined results
```
## Methods

Retrieves a specific location by city name, with optional country filtering asynchronously.

## Parameters

city string

```
The city name to search for (e.g., "York", "London", "Paris"). Cannot be null or empty.
```
country string

```
Optional country name or country code to filter results geographically. When provided, only locations
within the specified country are considered. If null or not specified, searches across all countries.
Examples: "United States", "US", "France", "FR"
```
# Interface IGeocodingService

```
public interface IGeocodingService
```
## GetLocationAsync(string, string?)

```
Task<Location?> GetLocationAsync(string city, string? country = null)
```

#### Returns

Task<Location>

```
A task that represents the asynchronous operation. The task result contains a Location object if a
matching location is found; otherwise, null.
```
#### Remarks

Performs a targeted location lookup by city name, optionally narrowed by country. When a country is
provided, the search results are filtered to locations within that country, reducing ambiguity for cities
that share names across regions.

Returns the first matching location if multiple results are found, typically the one with the largest
population or highest relevance score.

#### Exceptions

ArgumentNullException

```
Thrown when city is null.
```
ArgumentException

```
Thrown when city is empty or whitespace.
```
HttpRequestException

```
Thrown when the geocoding API request fails.
```
Searches for locations matching the specified query string asynchronously.

#### Parameters

query string

```
The search query string (e.g., "New York", "Paris, France", "40.7128, -74.0060"). Cannot be null or
empty.
```
### SearchLocationsAsync(string)

```
Task<IEnumerable<Location>> SearchLocationsAsync(string query)
```

#### Returns

Task<IEnumerable<Location>>

```
A task that represents the asynchronous operation. The task result contains an enumerable collection
of Location objects matching the query. Returns an empty collection if no matches are found.
```
#### Remarks

Performs a forward geocoding search to find locations matching the provided query. The query can be a
city name, address, or any location identifier supported by the underlying geocoding provider.

Multiple results may be returned if the query matches several locations. Results are typically ordered by
relevance or population size.

#### Exceptions

ArgumentNullException

```
Thrown when query is null.
```
ArgumentException

```
Thrown when query is empty or whitespace.
```
HttpRequestException

```
Thrown when the geocoding API request fails.
```

Namespace:TheWeatherNode.Core.Interfaces

Assembly:TheWeatherNode.Core.dll

Defines the contract for weather forecast data services.

## Remarks

This interface abstracts the weather service implementation, allowing different weather data providers
(Open-Meteo, Weather API, etc.) to be plugged in without changing client code.

Weather data returned by implementations of this interface uses units specified in the request object
(metric or imperial). All request objects handle unit conversion from strings to strongly-typed enums.

Common metric units:

```
Temperature: degrees Celsius
Wind Speed: kilometers per hour (km/h)
Precipitation: millimeters (mm)
Pressure: hectopascals (hPa)
Visibility: meters
```
Common imperial units:

```
Temperature: degrees Fahrenheit
Wind Speed: miles per hour (mph)
Precipitation: inches
Pressure: inches of mercury (inHg)
Visibility: feet
```
## Methods

Retrieves the current weather conditions for the specified geographic coordinates.

# Interface IWeatherService

```
public interface IWeatherService
```
## GetCurrentWeatherAsync(WeatherRequest)


#### Parameters

weatherRequest WeatherRequest

#### Returns

Task<CurrentWeather>

```
A task representing the asynchronous operation that returns a CurrentWeather object containing
current weather data including temperature, humidity, wind, precipitation, visibility, UV index, and
more.
```
#### Remarks

This method retrieves real-time weather conditions at the specified location. The returned data includes
the current timestamp, temperature, "feels like" temperature, dew point, humidity, wind
speed/direction/gusts, precipitation, atmospheric pressure, visibility, UV index, cloud cover, weather
code, and daylight indicator.

The unit system (metric or imperial) depends on the service implementation configuration. Refer to the
specific implementation documentation for unit details.

#### Exceptions

InvalidOperationException

```
Thrown when the weather service is unable to retrieve data for the specified coordinates.
```
Retrieves daily weather forecasts for the specified geographic coordinates.

#### Parameters

weatherRequest WeatherRequest

```
Task<CurrentWeather> GetCurrentWeatherAsync(WeatherRequest weatherRequest)
```
### GetDailyForecastAsync(WeatherRequest)

```
Task<IEnumerable<DailyForecast>> GetDailyForecastAsync(WeatherRequest weatherRequest)
```

#### Returns

Task<IEnumerable<DailyForecast>>

```
A task representing the asynchronous operation that returns an enumerable collection of Daily
Forecast objects, each representing aggregated weather conditions for a specific day. The collection is
ordered chronologically from earliest to latest.
```
#### Remarks

This method retrieves daily weather summaries for the specified location, containing
maximum/minimum temperatures and other aggregated metrics for each day. This data is useful for
multi-day forecasts and weather summaries.

Each daily forecast includes date, maximum/minimum temperatures, maximum/minimum apparent
temperatures, maximum/minimum humidity, mean atmospheric pressure, total precipitation, maximum
precipitation probability, maximum wind speed/gusts, dominant wind direction, maximum UV index,
weather code, sunrise time, and sunset time.

Dates are provided as date-only values (no time component). Sunrise and sunset times are in UTC and
should be converted to local timezone for display to end users. The unit system (metric or imperial)
depends on the service implementation configuration. Refer to the specific implementation
documentation for unit details.

#### Exceptions

InvalidOperationException

```
Thrown when the weather service is unable to retrieve daily forecast data for the specified coordinates.
```
Retrieves hourly weather forecasts for the specified geographic coordinates.

#### Parameters

weatherRequest WeatherRequest

#### Returns

### GetHourlyForecastAsync(WeatherRequest)

```
Task<IEnumerable<HourlyForecast>> GetHourlyForecastAsync(WeatherRequest weatherRequest)
```

Task<IEnumerable<HourlyForecast>>

```
A task representing the asynchronous operation that returns an enumerable collection of Hourly
Forecast objects, each representing weather conditions at a specific hour. The collection is ordered
chronologically from earliest to latest.
```
#### Remarks

This method retrieves detailed hour-by-hour weather predictions for the specified location. The number
of forecast hours returned depends on the requested number of days and will typically be (days * 24)
hourly forecasts.

Each hourly forecast includes temperature, apparent temperature ("feels like"), dew point, humidity,
precipitation probability and amount, atmospheric pressure, cloud cover, visibility, wind
speed/direction/gusts, weather code, and daylight indicator.

All timestamps are in UTC and should be converted to local timezone for display to end users. The unit
system (metric or imperial) depends on the service implementation configuration. Refer to the specific
implementation documentation for unit details.

#### Exceptions

InvalidOperationException

```
Thrown when the weather service is unable to retrieve hourly forecast data for the specified
coordinates.
```

## Enums

PrecipitationUnit
Specifies the precipitation unit for weather data.

TemperatureUnit
Specifies the temperature unit for weather data.

WindSpeedUnit
Specifies the wind speed unit for weather data.

# Namespace TheWeatherNode.Core.Models


Namespace:TheWeatherNode.Core.Models

Assembly:TheWeatherNode.Core.dll

Specifies the precipitation unit for weather data.

**Extension Methods**
UnitTypeExtensions.ToPrecipitationUnitAbbreviation(PrecipitationUnit) ,
UnitTypeExtensions.ToPrecipitationUnitString(PrecipitationUnit)

## Fields

Inches = 1

```
Inches (in).
```
Millimeters = 0

```
Millimeters (mm).
```
# Enum PrecipitationUnit

```
public enum PrecipitationUnit
```

Namespace:TheWeatherNode.Core.Models

Assembly:TheWeatherNode.Core.dll

Specifies the temperature unit for weather data.

**Extension Methods**
UnitTypeExtensions.ToTemperatureUnitString(TemperatureUnit)

## Fields

Celsius = 0

```
Celsius temperature scale.
```
Fahrenheit = 1

```
Fahrenheit temperature scale.
```
# Enum TemperatureUnit

```
public enum TemperatureUnit
```

Namespace:TheWeatherNode.Core.Models

Assembly:TheWeatherNode.Core.dll

Specifies the wind speed unit for weather data.

**Extension Methods**
UnitTypeExtensions.ToWindSpeedUnitAbbreviation(WindSpeedUnit) ,
UnitTypeExtensions.ToWindSpeedUnitString(WindSpeedUnit)

## Fields

Kmh = 0

```
Kilometers per hour (km/h).
```
Knots = 2

```
Nautical miles per hour (knots).
```
Mph = 1

```
Miles per hour (mph).
```
# Enum WindSpeedUnit

```
public enum WindSpeedUnit
```

## Classes

WeatherRequest
Represents a request for weather data at a specified geographic location with unit preferences.

# Namespace TheWeatherNode.Core.Models.

# Requests


Namespace:TheWeatherNode.Core.Models.Requests

Assembly:TheWeatherNode.Core.dll

Represents a request for weather data at a specified geographic location with unit preferences.

**Inheritance**

object WeatherRequest

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Examples

**Using string-based unit parameters (automatic conversion):**

**Using enum-based unit parameters (type-safe):**

**Using default parameters:**

# Class WeatherRequest

```
public class WeatherRequest
```
##### 

```
// Create a request for New York City with Fahrenheit and mph
var request = new WeatherRequest(
latitude: 40.7128,
longitude: -74.0060,
temperatureUnit: "fahrenheit",
windSpeedUnit: "mph",
precipitationUnit: "inches");
```
```
// Create a request using strongly-typed unit enums
var request = new WeatherRequest(
latitude: 40.7128,
longitude: -74.0060,
temperatureUnit: TemperatureUnit.Fahrenheit,
windSpeedUnit: WindSpeedUnit.Mph,
precipitationUnit: PrecipitationUnit.Inches);
```

## Remarks

The WeatherRequest class encapsulates all parameters necessary to retrieve weather forecast data from a
weather service provider. It includes geographic coordinates (latitude and longitude) and unit
preferences for temperature, wind speed, and precipitation.

**Unit Conversion:** String-based unit parameters provided to the constructor are automatically converted
to their corresponding enum types (TemperatureUnit, WindSpeedUnit, PrecipitationUnit) during
instantiation. This provides type safety and validates units at the point of request creation, preventing
invalid requests from being created.

**Supported Units:**

```
Unit Type Supported Values
```
```
Temperature "celsius", "fahrenheit"
```
```
Wind Speed "kmh", "km/h", "mph", "knots"
```
```
Precipitation "millimeters", "mm", "inches", "in"
```
**Coordinate Validation:** While the constructor does not validate coordinate ranges, all coordinates must
conform to standard geographic standards:

```
Latitude: -90° to 90°
Longitude: -180° to 180°
```
Weather service implementations are responsible for coordinate validation before making API calls.

**Immutability Note:** Properties are settable to allow for flexibility in different usage scenarios. However,
for typical usage, it is recommended to set all values during construction and treat the object as
immutable thereafter.

## Constructors

```
// Create a request with metric defaults (Celsius, km/h, millimeters)
var request = new WeatherRequest(
latitude: 48.8566,
longitude: 2.3522); // Paris, France
```
### WeatherRequest()


Initializes a new instance of the WeatherRequest class with default parameter values.

#### Remarks

This parameterless constructor provides default initialization when object properties need to be set after
instantiation. Properties must be set manually before using the request with a weather service.

#### Exceptions

ArgumentNullException

```
Thrown by the string-based constructor when any unit string parameter is null.
```
ArgumentException

```
Thrown by the string-based constructor when an invalid unit string is provided that cannot be
converted to its corresponding enum type. See UnitTypeExtensions for valid unit strings.
```
Initializes a new instance of the WeatherRequest class with string-based unit parameters.

#### Parameters

latitude double

```
The latitude coordinate in decimal degrees. Valid range: -90.0 to 90.0
```
```
Positive values: Northern Hemisphere (north of equator)
Negative values: Southern Hemisphere (south of equator)
0: On the equator
Example: 40.7128 = New York City
```
longitude double

```
The longitude coordinate in decimal degrees. Valid range: -180.0 to 180.0
```
```
public WeatherRequest()
```
### WeatherRequest(double, double, string, string, string)

```
public WeatherRequest(double latitude, double longitude, string temperatureUnit = "celsius",
string windSpeedUnit = "km/h", string precipitationUnit = "millimeters")
```

```
Positive values: East of prime meridian (Greenwich/London)
Negative values: West of prime meridian
0: On the prime meridian
Example: -74.0060 = New York City
```
temperatureUnit string

```
The desired temperature unit for the API response. Case-insensitive.
```
```
"celsius" or "c" → Celsius
"fahrenheit" or "f" → Fahrenheit
```
```
Default: "celsius" (metric standard)
```
windSpeedUnit string

```
The desired wind speed unit for the API response. Case-insensitive with alias support.
```
```
"kmh" or "km/h" → Kmh (kilometers per hour)
"mph" → Mph (miles per hour)
"knots" → Knots (nautical miles per hour)
```
```
Default: "km/h" (metric standard)
```
precipitationUnit string

```
The desired precipitation unit for the API response. Case-insensitive with alias support.
```
```
"millimeters" or "mm" → Millimeters
"inches" or "in" → Inches
```
```
Default: "millimeters" (metric standard)
```
#### Examples

```
// Create request for New York City with US units
var request = new WeatherRequest(
latitude: 40.7128,
longitude: -74.0060,
temperatureUnit: "fahrenheit",
windSpeedUnit: "mph",
precipitationUnit: "inches");
```
```
// Results in:
// Latitude: 40.7128
```

#### Remarks

This constructor accepts unit preferences as strings and automatically converts them to their
corresponding enum types using extension methods from UnitTypeExtensions. Unit strings are case-
insensitive and support common aliases (e.g., "km/h" and "kmh" both map to Kmh).

Invalid unit strings will cause an ArgumentException to be thrown immediately during construction,
preventing the creation of requests with unsupported units.

#### Exceptions

ArgumentNullException

```
Thrown when temperatureUnit, windSpeedUnit, or precipitationUnit is null.
```
ArgumentException

```
Thrown when an invalid unit string is provided. The exception message indicates which unit is invalid
and the supported values. Call the extension methods in UnitTypeExtensions to see valid unit string
formats.
```
Initializes a new instance of the WeatherRequest class with enum-based unit parameters.

#### Parameters

latitude double

```
The latitude coordinate in decimal degrees. Valid range: -90.0 to 90.0
```
```
Positive values: Northern Hemisphere (north of equator)
```
```
// Longitude: -74.0060
// TemperatureUnit: TemperatureUnit.Fahrenheit
// WindSpeedUnit: WindSpeedUnit.Mph
// PrecipitationUnit: PrecipitationUnit.Inches
```
### WeatherRequest(double, double, TemperatureUnit,

### WindSpeedUnit, PrecipitationUnit)

```
public WeatherRequest(double latitude, double longitude, TemperatureUnit temperatureUnit,
WindSpeedUnit windSpeedUnit, PrecipitationUnit precipitationUnit)
```

```
Negative values: Southern Hemisphere (south of equator)
0: On the equator
```
longitude double

```
The longitude coordinate in decimal degrees. Valid range: -180.0 to 180.0
```
```
Positive values: East of prime meridian
Negative values: West of prime meridian
0: On the prime meridian
```
temperatureUnit TemperatureUnit

```
The desired temperature unit enum value.
```
```
Celsius: Degrees Celsius (metric standard)
Fahrenheit: Degrees Fahrenheit (US standard)
```
```
Default: Celsius
```
windSpeedUnit WindSpeedUnit

```
The desired wind speed unit enum value.
```
```
Kmh: Kilometers per hour (metric standard)
Mph: Miles per hour (US standard)
Knots: Knots - nautical miles per hour (marine/aviation standard)
```
```
Default: Kmh
```
precipitationUnit PrecipitationUnit

```
The desired precipitation unit enum value.
```
```
Millimeters: Millimeters (metric standard)
Inches: Inches (imperial/US standard)
```
```
Default: Millimeters
```
#### Examples

```
// Create a type-safe request using enum values
var request = new WeatherRequest(
latitude: 40.7128,
longitude: -74.0060,
temperatureUnit: TemperatureUnit.Fahrenheit,
```

#### Remarks

This constructor accepts unit preferences as strongly-typed enum values, providing compile-time type
safety and eliminating the need for string parsing and validation. This is the recommended constructor
when unit values are already known at compile time or come from other enums in the application.

Using enums directly avoids the overhead and potential errors of string conversion, making this
constructor ideal for internal service-to-service communication and programmatic request construction
where unit types are determined by application logic rather than user input.

#### Exceptions

ArgumentNullException

```
Thrown by the string-based constructor when any unit string parameter is null.
```
ArgumentException

```
Thrown by the string-based constructor when an invalid unit string is provided that cannot be
converted to its corresponding enum type. See UnitTypeExtensions for valid unit strings.
```
**See Also**
TemperatureUnit, WindSpeedUnit, PrecipitationUnit

## Properties

Gets or sets the latitude coordinate in decimal degrees for the requested location.

```
windSpeedUnit: WindSpeedUnit.Mph,
precipitationUnit: PrecipitationUnit.Inches);
```
```
// Or using a method that returns unit enums
var userPreferences = GetUserUnitPreferences(); // Returns enum values
var request = new WeatherRequest(
latitude: userPreferences.Latitude,
longitude: userPreferences.Longitude,
temperatureUnit: userPreferences.TemperatureUnit,
windSpeedUnit: userPreferences.WindSpeedUnit,
precipitationUnit: userPreferences.PrecipitationUnit);
```
### Latitude


#### Property Value

double

#### Examples

#### Remarks

Latitude specifies the north-south position on Earth's surface.

**Valid Range:** -90° to 90°

```
90°: North Pole
0°: Equator
-90°: South Pole
```
**Examples:**

```
40.7128: New York City
48.8566: Paris, France
-33.8688: Sydney, Australia
35.6762: Tokyo, Japan
```
Note: The constructor does not validate the coordinate range. Weather service implementations should
validate coordinates before making API calls. Invalid coordinates will result in service errors.

#### Exceptions

ArgumentNullException

```
Thrown by the string-based constructor when any unit string parameter is null.
```
ArgumentException

```
Thrown by the string-based constructor when an invalid unit string is provided that cannot be
converted to its corresponding enum type. See UnitTypeExtensions for valid unit strings.
```
```
public double Latitude { get; set; }
```
```
var request = new WeatherRequest();
request.Latitude = 40.7128; // New York City latitude
```

Gets or sets the longitude coordinate in decimal degrees for the requested location.

#### Property Value

double

#### Examples

#### Remarks

Longitude specifies the east-west position on Earth's surface, measured from the Prime Meridian (which
passes through Greenwich, London).

**Valid Range:** -180° to 180°

```
0°: Prime Meridian (Greenwich/London)
180° or -180°: International Date Line (Pacific Ocean)
Positive values: East of Prime Meridian
Negative values: West of Prime Meridian
```
**Examples:**

```
-74.0060: New York City
2.3522: Paris, France
151.2093: Sydney, Australia
139.6503: Tokyo, Japan
```
Note: The constructor does not validate the coordinate range. Weather service implementations should
validate coordinates before making API calls. Invalid coordinates will result in service errors.

#### Exceptions

ArgumentNullException

```
Thrown by the string-based constructor when any unit string parameter is null.
```
### Longitude

```
public double Longitude { get; set; }
```
```
var request = new WeatherRequest();
request.Longitude = -74.0060; // New York City longitude
```

ArgumentException

```
Thrown by the string-based constructor when an invalid unit string is provided that cannot be
converted to its corresponding enum type. See UnitTypeExtensions for valid unit strings.
```
Gets or sets the desired precipitation unit for the weather API response.

#### Property Value

PrecipitationUnit

#### Examples

#### Remarks

Specifies the unit of measurement for precipitation amounts (rain, snow, etc.) in the API response. The
value is determined by converting the precipitation unit string provided in the constructor, or can be set
directly using the enum.

**Supported Units:**

```
Millimeters: Millimeters (metric standard, commonly used in meteorology)
Inches: Inches (imperial/US standard)
```
**Conversion Reference:**

```
1 inch = 25.4 millimeters
1 millimeter = 0.0393701 inches
```
#### Exceptions

ArgumentNullException

### PrecipitationUnit

```
public PrecipitationUnit PrecipitationUnit { get; set; }
```
```
var request = new WeatherRequest(40.7128, -74.0060, precipitationUnit: "mm");
var unit = request.PrecipitationUnit; // PrecipitationUnit.Millimeters
```
```
request.PrecipitationUnit = PrecipitationUnit.Inches; // Change to inches
```

```
Thrown by the string-based constructor when any unit string parameter is null.
```
ArgumentException

```
Thrown by the string-based constructor when an invalid unit string is provided that cannot be
converted to its corresponding enum type. See UnitTypeExtensions for valid unit strings.
```
**See Also**
PrecipitationUnit

Gets or sets the desired temperature unit for the weather API response.

#### Property Value

TemperatureUnit

#### Examples

#### Remarks

Specifies whether temperature values in the API response should be expressed in Celsius or Fahrenheit.
This value is determined by converting the temperature unit string provided in the constructor, or can be
set directly using the enum.

**Supported Units:**

```
Celsius: Degrees Celsius (metric standard)
Fahrenheit: Degrees Fahrenheit (US standard)
```
**Conversion Formula:** °F = (°C × 9/5) + 32

#### Exceptions

### TemperatureUnit

```
public TemperatureUnit TemperatureUnit { get; set; }
```
```
var request = new WeatherRequest(40.7128, -74.0060);
var unit = request.TemperatureUnit; // TemperatureUnit.Celsius (default)
```
```
request.TemperatureUnit = TemperatureUnit.Fahrenheit; // Change to Fahrenheit
```

ArgumentNullException

```
Thrown by the string-based constructor when any unit string parameter is null.
```
ArgumentException

```
Thrown by the string-based constructor when an invalid unit string is provided that cannot be
converted to its corresponding enum type. See UnitTypeExtensions for valid unit strings.
```
**See Also**
TemperatureUnit

Gets or sets the desired wind speed unit for the weather API response.

#### Property Value

WindSpeedUnit

#### Examples

#### Remarks

Specifies the unit of measurement for wind speed values in the API response. The value is determined by
converting the wind speed unit string provided in the constructor, or can be set directly using the enum.

**Supported Units:**

```
Kmh: Kilometers per hour (metric standard)
Mph: Miles per hour (US standard)
Knots: Knots - nautical miles per hour (marine/aviation standard)
```
**Conversion Reference:**

### WindSpeedUnit

```
public WindSpeedUnit WindSpeedUnit { get; set; }
```
```
var request = new WeatherRequest(40.7128, -74.0060, windSpeedUnit: "kmh");
var unit = request.WindSpeedUnit; // WindSpeedUnit.Kmh (set from string)
```
```
request.WindSpeedUnit = WindSpeedUnit.Knots; // Change to nautical measurements
```

```
1 km/h = 0.621371 mph
1 km/h = 0.539957 knots
1 mph = 1.60934 km/h
1 knot = 1.852 km/h
```
#### Exceptions

ArgumentNullException

```
Thrown by the string-based constructor when any unit string parameter is null.
```
ArgumentException

```
Thrown by the string-based constructor when an invalid unit string is provided that cannot be
converted to its corresponding enum type. See UnitTypeExtensions for valid unit strings.
```
**See Also**
WindSpeedUnit

## See Also

UnitTypeExtensions
TemperatureUnit
WindSpeedUnit
PrecipitationUnit


## Classes

CurrentWeather
Represents the current weather conditions at a specific location and time.

DailyForecast
Represents a daily weather forecast for a specific location and date.

HourlyForecast
Represents hourly weather forecast data for a specific point in time.

Location
Represents geographic location information retrieved from geocoding operations.

SevereWeatherData

WeatherForecast
Represents a comprehensive weather forecast response containing current conditions and forecasts.

# Namespace TheWeatherNode.Core.Models.

# Responses


Namespace:TheWeatherNode.Core.Models.Responses

Assembly:TheWeatherNode.Core.dll

Represents the current weather conditions at a specific location and time.

**Inheritance**

object CurrentWeather

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Remarks

This response model contains real-time weather measurements and observations, typically representing
the current moment or the most recent weather observation. All values are stored in the units specified
by the request (metric or imperial).

Common metric units:

```
Temperature: degrees Celsius
Wind Speed: kilometers per hour (km/h)
Pressure: hectopascals (hPa)
Visibility: meters
Precipitation: millimeters
```
Common imperial units:

```
Temperature: degrees Fahrenheit
Wind Speed: miles per hour (mph)
Pressure: inches of mercury (inHg)
Visibility: feet
Precipitation: inches
```
## Properties

# Class CurrentWeather

```
public class CurrentWeather
```
##### 


Gets or sets the cloud cover as a percentage.

#### Property Value

double

#### Remarks

Range: 0-100 (percent) 0% = clear sky 50% = partly cloudy 100% = completely overcast (no visible sky)

Gets or sets the dew point temperature.

#### Property Value

double

#### Remarks

The temperature to which air must be cooled to reach 100% relative humidity, assuming constant
atmospheric pressure and water vapor content. A higher dew point indicates more moisture in the air.
Unit depends on the request unit preference (Celsius or Fahrenheit).

Gets or sets the apparent temperature (wind chill/heat index).

#### Property Value

### CloudCover

```
public double CloudCover { get; set; }
```
### DewPoint

```
public double DewPoint { get; set; }
```
### FeelsLike

```
public double FeelsLike { get; set; }
```

double

#### Remarks

Accounts for the combined effects of temperature, wind speed, and humidity. Represents how the
temperature actually feels to humans. Unit depends on the request unit preference (Celsius or
Fahrenheit).

Gets or sets the relative humidity as a percentage.

#### Property Value

double

#### Remarks

Range: 0-100 (percent) 0% = completely dry air 100% = air saturated with moisture

Gets or sets a value indicating whether it is currently daytime.

#### Property Value

bool

#### Remarks

true = day (sun is above the horizon) false = night (sun is below the horizon) Useful for adjusting UI
elements or applying day/night specific logic.

### Humidity

```
public double Humidity { get; set; }
```
### IsDay

```
public bool IsDay { get; set; }
```
### Precipitation


Gets or sets the current precipitation amount.

#### Property Value

double

#### Remarks

Represents the amount of rain, snow, or other precipitation currently falling. Unit depends on the
request unit preference (millimeters or inches).

Gets or sets the probability of precipitation as a percentage.

#### Property Value

double

#### Remarks

Range: 0-100 (percent) 0% = no precipitation expected 100% = precipitation certain Indicates the
likelihood of precipitation occurring at the current time.

Gets or sets the atmospheric pressure at sea level.

#### Property Value

double

```
public double Precipitation { get; set; }
```
### PrecipitationProbability

```
public double PrecipitationProbability { get; set; }
```
### Pressure

```
public double Pressure { get; set; }
```

#### Remarks

Unit depends on the request unit preference (hectopascals or inches of mercury). Used to indicate
weather systems and atmospheric stability. High pressure generally indicates fair weather, while low
pressure indicates poor weather.

Gets or sets the current air temperature.

#### Property Value

double

#### Remarks

Unit depends on the request unit preference (Celsius or Fahrenheit).

Gets or sets the ISO 8601 timestamp for this weather observation.

#### Property Value

DateTime

#### Examples

##### 2024-02-25T14:30:00Z

#### Remarks

Timestamp is in UTC (Coordinated Universal Time). Should be converted to the local timezone using the
timezone information from the parent WeatherForecast response for display to end users.

### Temperature

```
public double Temperature { get; set; }
```
### Time

```
public DateTime Time { get; set; }
```

Gets or sets the ultraviolet (UV) index value.

#### Property Value

double

#### Remarks

A measure of the strength of ultraviolet radiation from the sun.

UV Index Scale: 0-2: Low exposure - minimal sun protection required 3-5: Moderate exposure -
sunscreen and protective clothing recommended 6-7: High exposure - extra precautions necessary 8-10:
Very high exposure - limit outdoor activity, seek shade 11+: Extreme exposure - avoid sun exposure

Gets or sets the visibility distance.

#### Property Value

double

#### Remarks

Unit depends on the request unit preference (meters or feet). Represents the maximum distance at which
objects can be clearly seen. Reduced visibility may indicate fog, precipitation, or air pollution.

Gets or sets the WMO Weather Code representing the current weather condition.

### UvIndex

```
public double UvIndex { get; set; }
```
### Visibility

```
public double Visibility { get; set; }
```
### WeatherCode

```
public int WeatherCode { get; set; }
```

#### Property Value

int

#### Remarks

Follows the World Meteorological Organization (WMO) 4677 standard. Describes the primary weather
condition occurring at the current time.

Common codes: 0: Clear sky 1-3: Mainly clear/mostly cloudy 45, 48: Foggy 51-67: Drizzle/rain 71-85:
Snow 80-82: Rain showers 85-86: Snow showers 95-99: Thunderstorm

See WMO 4677 documentation for complete code definitions.

Gets or sets the wind direction in degrees.

#### Property Value

double

#### Remarks

Range: 0-359 degrees 0° = North 90° = East 180° = South 270° = West

Gets or sets the wind gust speed at 10 meters height.

#### Property Value

double

#### Remarks

### WindDirection

```
public double WindDirection { get; set; }
```
### WindGusts

```
public double WindGusts { get; set; }
```

The maximum short-duration peak wind speed at the current moment. Unit depends on the request unit
preference (km/h, mph, or knots). Measured at standard height of 10 meters above ground. Wind gusts
are typically higher than sustained wind speeds.

Gets or sets the wind speed at 10 meters height.

#### Property Value

double

#### Remarks

Unit depends on the request unit preference (km/h, mph, or knots). Measured at standard height of 10
meters above ground.

### WindSpeed

```
public double WindSpeed { get; set; }
```

Namespace:TheWeatherNode.Core.Models.Responses

Assembly:TheWeatherNode.Core.dll

Represents a daily weather forecast for a specific location and date.

**Inheritance**

object DailyForecast

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Remarks

This model serves as the domain model for daily forecast data, typically mapped from the
TheWeatherNode.WeatherService.OpenMeteo.DTOs.OpenMeteoDailyDto DTO.

All temperature, wind speed, and precipitation values are stored in metric units:

```
Temperature: Celsius
Wind Speed: kilometers per hour (km/h)
Pressure: hectopascals (hPa)
Precipitation: millimeters (mm)
```
These values can be converted to imperial units by consuming services as needed:

```
Temperature: (°C × 9/5) + 32 = °F
Wind Speed: km/h × 0.621371 = mph
Pressure: hPa × 0.02953 = inHg
Precipitation: mm × 0.0393701 = inches
```
## Properties

Gets or sets the date of the forecast.

# Class DailyForecast

```
public class DailyForecast
```
##### 

## Date


#### Property Value

DateTime

#### Remarks

Represents the date (without time component) for which this forecast applies. All forecast values in this
model are aggregates for this entire date.

Gets or sets the maximum apparent temperature (feels-like) for the day in degrees Celsius.

#### Property Value

double

#### Remarks

The highest temperature that accounts for wind chill and humidity effects. Represents how hot it will feel
to humans at the warmest point of the day. To convert to Fahrenheit: (°C × 9/5) + 32 = °F

Gets or sets the minimum apparent temperature (feels-like) for the day in degrees Celsius.

#### Property Value

double

#### Remarks

```
public DateTime Date { get; set; }
```
### FeelsLikeMax

```
public double FeelsLikeMax { get; set; }
```
### FeelsLikeMin

```
public double FeelsLikeMin { get; set; }
```

The lowest temperature that accounts for wind chill and humidity effects. Represents how cold it will feel
to humans at the coldest point of the day. To convert to Fahrenheit: (°C × 9/5) + 32 = °F

Gets or sets the maximum relative humidity for the day as a percentage.

#### Property Value

double

#### Remarks

The highest ratio of actual water vapor to maximum water vapor the air can hold. Range: 0-100 (percent)

Gets or sets the minimum relative humidity for the day as a percentage.

#### Property Value

double

#### Remarks

The lowest ratio of actual water vapor to maximum water vapor the air can hold. Range: 0-100 (percent)

Gets or sets the maximum precipitation probability for the day as a percentage.

### HumidityMax

```
public double HumidityMax { get; set; }
```
### HumidityMin

```
public double HumidityMin { get; set; }
```
### PrecipitationProbabilityMax

```
public double PrecipitationProbabilityMax { get; set; }
```

#### Property Value

double

#### Remarks

The highest probability of precipitation occurring at any point during the day. Range: 0-100 (percent)

Gets or sets the total precipitation amount for the day in millimeters.

#### Property Value

double

#### Remarks

The cumulative rainfall, snowfall, and other forms of precipitation expected during the day. Unit:
millimeters (mm) To convert to inches: mm × 0.0393701 = inches

Gets or sets the mean atmospheric pressure at mean sea level in hectopascals.

#### Property Value

double

#### Remarks

The average air pressure measured at sea level for the day. Unit: hectopascals (hPa) To convert to inches
of mercury: hPa × 0.02953 = inHg To convert to millibars: 1 hPa = 1 mb

### PrecipitationSum

```
public double PrecipitationSum { get; set; }
```
### PressureMean

```
public double PressureMean { get; set; }
```

Gets or sets the time of sunrise for the day in UTC.

#### Property Value

DateTime

#### Remarks

The exact moment when the sun rises above the horizon. Time is provided in UTC (Coordinated Universal
Time). Should be converted to local timezone for display to end users.

Gets or sets the time of sunset for the day in UTC.

#### Property Value

DateTime

#### Remarks

The exact moment when the sun descends below the horizon. Time is provided in UTC (Coordinated
Universal Time). Should be converted to local timezone for display to end users.

Gets or sets the maximum temperature for the day in degrees Celsius.

#### Property Value

### Sunrise

```
public DateTime Sunrise { get; set; }
```
### Sunset

```
public DateTime Sunset { get; set; }
```
### TemperatureMax

```
public double TemperatureMax { get; set; }
```

double

#### Remarks

The highest air temperature expected to occur during the day. To convert to Fahrenheit: (°C × 9/5) + 32
= °F

Gets or sets the minimum temperature for the day in degrees Celsius.

#### Property Value

double

#### Remarks

The lowest air temperature expected to occur during the day. To convert to Fahrenheit: (°C × 9/5) + 32 =
°F

Gets or sets the maximum UV index for the day.

#### Property Value

double

#### Remarks

The highest ultraviolet radiation index expected to occur during the day.

UV Index Scale: 0-2: Low exposure - minimal sun protection required 3-5: Moderate exposure -
sunscreen and protective clothing recommended 6-7: High exposure - extra precautions necessary 8-10:
Very high exposure - limit outdoor activity 11+: Extreme exposure - avoid sun exposure

### TemperatureMin

```
public double TemperatureMin { get; set; }
```
### UvIndexMax

```
public double UvIndexMax { get; set; }
```

Gets or sets the WMO Weather Code representing the primary weather condition for the day.

#### Property Value

int

#### Remarks

Follows the World Meteorological Organization (WMO) 4677 standard. Represents the most severe or
significant weather condition occurring during the day.

Common codes: 0: Clear sky 1-3: Mainly clear/mostly cloudy 45, 48: Foggy 51-67: Drizzle/rain 71-85:
Snow 80-82: Rain showers 85-86: Snow showers 95-99: Thunderstorm

See WMO 4677 documentation for complete code definitions.

Gets or sets the dominant wind direction for the day in degrees.

#### Property Value

double

#### Remarks

The most frequent wind direction observed or forecasted during the day. Range: 0-359 degrees 0° =
North, 45° = Northeast, 90° = East, 135° = Southeast, 180° = South, 225° = Southwest, 270° = West, 315°
= Northwest

Gets or sets the maximum wind gust speed for the day at 10 meters height in kilometers per hour.

### WeatherCode

```
public int WeatherCode { get; set; }
```
### WindDirectionDominant

```
public double WindDirectionDominant { get; set; }
```
### WindGustsMax


#### Property Value

double

#### Remarks

The highest short-duration peak wind speed expected to occur during the day. Measured at standard
height of 10 meters above ground. Unit: kilometers per hour (km/h) To convert to miles per hour: km/h ×
0.621371 = mph To convert to knots: km/h × 0.539957 = knots

Gets or sets the maximum wind speed for the day at 10 meters height in kilometers per hour.

#### Property Value

double

#### Remarks

The highest sustained wind speed expected to occur during the day. Measured at standard height of 10
meters above ground. Unit: kilometers per hour (km/h) To convert to miles per hour: km/h × 0.621371 =
mph To convert to knots: km/h × 0.539957 = knots

```
public double WindGustsMax { get; set; }
```
### WindSpeedMax

```
public double WindSpeedMax { get; set; }
```

Namespace:TheWeatherNode.Core.Models.Responses

Assembly:TheWeatherNode.Core.dll

Represents hourly weather forecast data for a specific point in time.

**Inheritance**

object HourlyForecast

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Remarks

This response model contains weather measurements and predictions for a single hour, typically part of
a collection spanning multiple hours or days. All values are stored in the units specified by the request
(metric or imperial).

Common metric units:

```
Temperature: degrees Celsius
Wind Speed: kilometers per hour (km/h)
Pressure: hectopascals (hPa)
Visibility: meters
Precipitation: millimeters
```
Common imperial units:

```
Temperature: degrees Fahrenheit
Wind Speed: miles per hour (mph)
Pressure: inches of mercury (inHg)
Visibility: feet
Precipitation: inches
```
## Properties

# Class HourlyForecast

```
public class HourlyForecast
```
##### 


Gets or sets the cloud cover for this hour as a percentage.

#### Property Value

double

#### Remarks

Range: 0-100 (percent) 0% = clear sky, 100% = completely overcast

Gets or sets the dew point temperature for this hour.

#### Property Value

double

#### Remarks

The temperature to which air must be cooled to reach 100% relative humidity. A higher dew point
indicates more moisture in the air. Unit depends on the request unit preference (Celsius or Fahrenheit).

Gets or sets the apparent temperature (wind chill/heat index) for this hour.

#### Property Value

double

### CloudCover

```
public double CloudCover { get; set; }
```
### DewPoint

```
public double DewPoint { get; set; }
```
### FeelsLike

```
public double FeelsLike { get; set; }
```

#### Remarks

Accounts for the combined effects of temperature, wind, and humidity. Represents how the temperature
feels to humans. Unit depends on the request unit preference (Celsius or Fahrenheit).

Gets or sets the relative humidity for this hour as a percentage.

#### Property Value

double

#### Remarks

Range: 0-100 (percent) 0% = completely dry air, 100% = air saturated with moisture

Gets or sets a value indicating whether it is daytime during this hour.

#### Property Value

bool

#### Remarks

true = day (sun is above horizon) false = night (sun is below horizon)

Gets or sets the precipitation amount for this hour.

### Humidity

```
public double Humidity { get; set; }
```
### IsDay

```
public bool IsDay { get; set; }
```
### Precipitation


#### Property Value

double

#### Remarks

Includes rain, snow, and other forms of precipitation combined. Unit depends on the request unit
preference (millimeters or inches).

Gets or sets the probability of precipitation for this hour as a percentage.

#### Property Value

double

#### Remarks

Range: 0-100 (percent) 0% = no precipitation expected, 100% = precipitation certain

Gets or sets the atmospheric pressure at sea level for this hour.

#### Property Value

double

#### Remarks

```
public double Precipitation { get; set; }
```
### PrecipitationProbability

```
public double PrecipitationProbability { get; set; }
```
### Pressure

```
public double Pressure { get; set; }
```

Unit depends on the request unit preference (hectopascals or inches of mercury). Used to indicate
weather systems and atmospheric stability.

Gets or sets the air temperature for this hour.

#### Property Value

double

#### Remarks

Unit depends on the request unit preference (Celsius or Fahrenheit).

Gets or sets the ISO 8601 timestamp for this hourly forecast.

#### Property Value

DateTime

#### Examples

##### 2024-02-25T14:00:00Z

#### Remarks

Timestamp is in UTC (Coordinated Universal Time) and should be converted to local timezone for display
to end users.

### Temperature

```
public double Temperature { get; set; }
```
### Time

```
public DateTime Time { get; set; }
```
### Visibility


Gets or sets the visibility distance for this hour.

#### Property Value

double

#### Remarks

Unit depends on the request unit preference (meters or feet). Represents the maximum distance at which
objects can be clearly seen.

Gets or sets the WMO Weather Code for this hour.

#### Property Value

int

#### Remarks

Follows the World Meteorological Organization (WMO) 4677 standard. Describes the weather condition
occurring during this hour.

Common codes: 0: Clear sky 1-3: Mainly clear/mostly cloudy 45, 48: Foggy 51-67: Drizzle/rain 71-85:
Snow 80-82: Rain showers 85-86: Snow showers 95-99: Thunderstorm

See WMO 4677 documentation for complete code definitions.

Gets or sets the wind direction for this hour in degrees.

```
public double Visibility { get; set; }
```
### WeatherCode

```
public int WeatherCode { get; set; }
```
### WindDirection

```
public double WindDirection { get; set; }
```

#### Property Value

double

#### Remarks

Range: 0-359 degrees 0° = North, 90° = East, 180° = South, 270° = West

Gets or sets the wind gust speed at 10 meters height for this hour.

#### Property Value

double

#### Remarks

Short-duration peak wind speed during the hour. Unit depends on the request unit preference (km/h,
mph, or knots). Measured at standard height of 10 meters above ground.

Gets or sets the wind speed at 10 meters height for this hour.

#### Property Value

double

#### Remarks

Unit depends on the request unit preference (km/h, mph, or knots). Measured at standard height of 10
meters above ground.

### WindGusts

```
public double WindGusts { get; set; }
```
### WindSpeed

```
public double WindSpeed { get; set; }
```

Namespace:TheWeatherNode.Core.Models.Responses

Assembly:TheWeatherNode.Core.dll

Represents geographic location information retrieved from geocoding operations.

**Inheritance**

object Location

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Remarks

This model encapsulates essential geographic and administrative data for a specific location, including
coordinates, political boundaries, and timezone information. It serves as the response model for
geocoding queries and provides the geographic context needed for weather requests.

Locations can represent cities, towns, administrative divisions, or any named geographic point. The
population field provides a relative sense of the location's significance.

## Properties

Gets or sets the full country name where this location is situated.

## Property Value

string

## Examples

# Class Location

```
public class Location
```
##### 

## Country

```
public string Country { get; set; }
```

United States

#### Remarks

The complete English name of the country containing this location. Used for disambiguation when
multiple locations share the same city name across different countries (e.g., "York" in both England and
Nebraska, USA).

Gets or sets the ISO 3166-1 alpha-2 country code.

#### Property Value

string

#### Examples

##### US

#### Remarks

The two-letter ISO standard country code for the country containing this location. This provides a
standardized, language-independent identifier for the country.

Examples:

```
"US" for United States
"GB" for United Kingdom
"FR" for France
"JP" for Japan
"CA" for Canada
```
Gets or sets the latitude coordinate of the location in degrees.

### CountryCode

```
public string CountryCode { get; set; }
```
### Latitude

```
public double Latitude { get; set; }
```

#### Property Value

double

#### Examples

##### 40.86807

#### Remarks

The geographic latitude measured in decimal degrees, ranging from -90 (South Pole) to +90 (North
Pole). This coordinate is essential for weather API queries.

Positive values indicate locations north of the equator (Northern Hemisphere). Negative values indicate
locations south of the equator (Southern Hemisphere). A value of 0 represents the equator.

Gets or sets the longitude coordinate of the location in degrees.

#### Property Value

double

#### Examples

##### -97.592

#### Remarks

The geographic longitude measured in decimal degrees, ranging from -180 to +180. This coordinate is
essential for weather API queries.

Positive values indicate locations east of the Prime Meridian. Negative values indicate locations west of
the Prime Meridian. A value of 0 represents the Prime Meridian (Greenwich/London).

Gets or sets the name of the location (city, town, or administrative division).

### Longitude

```
public double Longitude { get; set; }
```
### Name


#### Property Value

string

#### Examples

York

#### Remarks

The primary display name for the location. This is the most user-friendly identifier and is typically the city
or town name.

Examples: "New York", "Paris", "Tokyo", "London"

Gets or sets the estimated population of the location.

#### Property Value

int

#### Examples

##### 7864

#### Remarks

A non-negative integer representing the approximate population size of the location. This value provides
context about the location's significance and scale.

Population data may not be available for all locations; in such cases, the value may be 0 or represent the
last known census data.

Useful for ranking search results by relevance or size when multiple locations match a search query.

```
public string Name { get; set; }
```
### Population

```
public int Population { get; set; }
```

Gets or sets the collection of postal codes associated with this location.

#### Property Value

IEnumerable<string>

#### Examples

##### 68467

#### Remarks

A collection of postal code strings that correspond to this geographic location. Postal codes vary in
format by country:

Format examples:

```
United States: ZIP codes (5 digits, e.g., "68467", or ZIP+4 format "12345-6789")
Canada: Postal codes (format "A1A 1A1", e.g., "K1A 0B1")
United Kingdom: Postcodes (format "SW1A 1AA", e.g., "EC1A 1BB")
Germany: Postal codes (5 digits, e.g., "10115")
Japan: Postal codes (format "XXX-XXXX", e.g., "100-0001")
```
A location may have multiple postal codes if it spans multiple postal code boundaries or includes
multiple administrative subdivisions. If no postal codes are associated with the location, this collection
will be empty.

Gets or sets the name of the state, province, or administrative division.

#### Property Value

string

### PostalCodes

```
public IEnumerable<string> PostalCodes { get; set; }
```
### State

```
public string State { get; set; }
```

#### Examples

Nebraska

#### Remarks

The first-level administrative division within the country. This typically represents a state (in the US),
province (in Canada), or region (in other countries).

Useful for further disambiguation of location names that may be duplicated within a country (e.g.,
"Springfield" exists in many US states).

Gets or sets the IANA timezone identifier for this location.

#### Property Value

string

#### Examples

America/Chicago

#### Remarks

The timezone designation in IANA format (also known as the "Olson database" format). This identifies
the timezone rules that apply to this location, accounting for daylight saving time and historical
timezone changes.

The timezone is essential for converting UTC timestamps to local time for display in weather forecasts
and other time-sensitive weather data.

Examples:

```
"America/New_York" (Eastern Time)
"America/Chicago" (Central Time)
"Europe/London" (Greenwich Mean Time / British Summer Time)
"Asia/Tokyo" (Japan Standard Time)
"Australia/Sydney" (Australian Eastern Time)
```
### Timezone

```
public string Timezone { get; set; }
```


Namespace:TheWeatherNode.Core.Models.Responses

Assembly:TheWeatherNode.Core.dll

**Inheritance**

object SevereWeatherData

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Properties

## Property Value

double

## Property Value

double

# Class SevereWeatherData

```
public class SevereWeatherData
```
##### 

## Cape

```
public double Cape { get; set; }
```
## ConvectivePrecipitation

```
public double ConvectivePrecipitation { get; set; }
```
## DewPoint


#### Property Value

double

#### Property Value

double

#### Property Value

double

#### Property Value

double

```
public double DewPoint { get; set; }
```
### DewPointSpread

```
public double DewPointSpread { get; set; }
```
### FreezingLevelHeight

```
public double FreezingLevelHeight { get; set; }
```
### LiftedIndex

```
public double LiftedIndex { get; set; }
```
### SurfacePressure


#### Property Value

double

#### Property Value

DateTime

#### Property Value

double

```
public double SurfacePressure { get; set; }
```
### Time

```
public DateTime Time { get; set; }
```
### TotalColumnWater

```
public double TotalColumnWater { get; set; }
```

Namespace:TheWeatherNode.Core.Models.Responses

Assembly:TheWeatherNode.Core.dll

Represents a comprehensive weather forecast response containing current conditions and forecasts.

**Inheritance**

object WeatherForecast

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Remarks

This response model serves as the primary weather data container, aggregating current weather, hourly
forecasts, daily forecasts, and location information into a single cohesive response object. It is typically
returned by weather service endpoints to provide clients with complete weather information.

The forecast data may be in metric or imperial units depending on the unit preferences specified in the
corresponding request object.

All timestamp values are in UTC (Coordinated Universal Time) and should be converted to the local
timezone (indicated by Timezone) for display to end users.

## Properties

Gets or sets the current weather conditions.

## Property Value

CurrentWeather

# Class WeatherForecast

```
public class WeatherForecast
```
##### 

## Current

```
public CurrentWeather Current { get; set; }
```

#### Remarks

Contains real-time weather measurements including temperature, humidity, wind, precipitation, and
other current atmospheric conditions. Defaults to an empty CurrentWeather instance if not set.

Gets or sets the collection of daily weather forecasts.

#### Property Value

IEnumerable<DailyForecast>

#### Remarks

An enumerable collection of DailyForecast objects containing daily aggregated weather data such as
high/low temperatures, total precipitation, and other daily metrics. Typically contains 7-16 days of
forecasts depending on the request parameters. Defaults to an empty collection if not set.

Gets or sets the collection of hourly weather forecasts.

#### Property Value

IEnumerable<HourlyForecast>

#### Remarks

An enumerable collection of HourlyForecast objects, typically containing 7-16 days of hourly forecasts
depending on the request parameters. Each element represents weather predictions for a specific hour.
Defaults to an empty collection if not set.

### Daily

```
public IEnumerable<DailyForecast> Daily { get; set; }
```
### Hourly

```
public IEnumerable<HourlyForecast> Hourly { get; set; }
```

Gets or sets the geographic location information for this forecast.

#### Property Value

Location

#### Remarks

Contains coordinates (latitude/longitude) and other location details for which this forecast data applies.
Defaults to an empty Location instance if not set.

Gets or sets the IANA time zone identifier for the location.

#### Property Value

string

#### Examples

"America/New_York" - Eastern Time "Europe/London" - Greenwich Mean Time / British Summer Time
"Asia/Tokyo" - Japan Standard Time

#### Remarks

Standard time zone identifier used to convert UTC timestamps to local time. Examples:
"America/New_York", "Europe/London", "Asia/Tokyo" Use this value with time zone libraries to properly
convert UTC timestamps from this forecast to the local time for the location. Defaults to an empty string
if not set.

### Location

```
public Location Location { get; set; }
```
### Timezone

```
public string Timezone { get; set; }
```
### TimezoneAbbreviation


Gets or sets the abbreviated time zone name.

#### Property Value

string

#### Examples

"EST" - Eastern Standard Time "EDT" - Eastern Daylight Time "GMT" - Greenwich Mean Time "BST" -
British Summer Time "JST" - Japan Standard Time

#### Remarks

Short abbreviation of the time zone, useful for displaying to end users. Note that abbreviations can be
ambiguous (e.g., "EST" could mean Eastern Standard Time or several other time zones), so use Timezone
for accurate conversions. Defaults to an empty string if not set.

```
public string TimezoneAbbreviation { get; set; }
```

## Classes

UtilityTests
Unit tests for the Utility class.

# Namespace TheWeatherNode.Core.Tests


Namespace:TheWeatherNode.Core.Tests

Assembly:TheWeatherNode.Core.Tests.dll

Unit tests for the Utility class.

**Inheritance**

object UtilityTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Methods

# Class UtilityTests

```
public class UtilityTests
```
##### 

## Base64Decode_WithEmptyString_ReturnsEmptyString()

```
[Fact]
public void Base64Decode_WithEmptyString_ReturnsEmptyString()
```
## Base64Decode_WithInvalidBase64_ThrowsFormatException()

```
[Fact]
public void Base64Decode_WithInvalidBase64_ThrowsFormatException()
```
## Base64Decode_WithUnicodeBase64_ReturnsUnicodeString()

```
[Fact]
public void Base64Decode_WithUnicodeBase64_ReturnsUnicodeString()
```

#### Parameters

original string

### Base64Decode_WithValidBase64String_ReturnsOriginalString()

```
[Fact]
public void Base64Decode_WithValidBase64String_ReturnsOriginalString()
```
### Base64Encode_Decode_RoundTrip_ReturnsOriginal(string)

```
[Theory]
[InlineData(new object[] { "Simple" })]
[InlineData(new object[] { "With Spaces" })]
[InlineData(new object[] { "With\nNewlines" })]
[InlineData(new object[] { "Special!@#$%^&*()" })]
[InlineData(new object[] { "Unicode: 日本語" })]
[InlineData(new object[] { "" })]
public void Base64Encode_Decode_RoundTrip_ReturnsOriginal(string original)
```
### Base64Encode_WithEmptyString_ReturnsEmptyString()

```
[Fact]
public void Base64Encode_WithEmptyString_ReturnsEmptyString()
```
### Base64Encode_WithSpecialCharacters_ReturnsValidBase64()

```
[Fact]
public void Base64Encode_WithSpecialCharacters_ReturnsValidBase64()
```
### Base64Encode_WithUnicodeString_ReturnsValidBase64()

```
[Fact]
public void Base64Encode_WithUnicodeString_ReturnsValidBase64()
```

#### Parameters

input string

### Base64Encode_WithValidString_ReturnsBase64String(string)

```
[Theory]
[InlineData(new object[] { "Hello" })]
[InlineData(new object[] { "Hello World" })]
[InlineData(new object[] { "Test123!@#" })]
public void Base64Encode_WithValidString_ReturnsBase64String(string input)
```
### Base64Encode_WithVeryLongString_ReturnsValidBase64()

```
[Fact]
public void Base64Encode_WithVeryLongString_ReturnsValidBase64()
```
### BytesToString_WithEmptyByteArray_ReturnsEmptyString()

```
[Fact]
public void BytesToString_WithEmptyByteArray_ReturnsEmptyString()
```
### BytesToString_WithSpecialCharacterBytes_ReturnsCorrectString()

```
[Fact]
public void BytesToString_WithSpecialCharacterBytes_ReturnsCorrectString()
```
### BytesToString_WithUnicodeBytes_ReturnsCorrectString()

```
[Fact]
public void BytesToString_WithUnicodeBytes_ReturnsCorrectString()
```

### BytesToString_WithValidBytes_ReturnsCorrectString()

```
[Fact]
public void BytesToString_WithValidBytes_ReturnsCorrectString()
```
### ComplexConversion_MultipleOperations_MaintainsIntegrity()

```
[Fact]
public void ComplexConversion_MultipleOperations_MaintainsIntegrity()
```
### GetEnvironmentVariable_WithEmptyString_ReturnsNullWhenVari

### ableNotSet()

```
[Fact]
public void GetEnvironmentVariable_WithEmptyString_ReturnsNullWhenVariableNotSet()
```
### GetEnvironmentVariable_WithExistingVariable_ReturnsValue()

```
[Fact]
public void GetEnvironmentVariable_WithExistingVariable_ReturnsValue()
```
### GetEnvironmentVariable_WithNonexistentVariable_ReturnsNull()

```
[Fact]
public void GetEnvironmentVariable_WithNonexistentVariable_ReturnsNull()
```
### GetEpochTime_WithDateAfterEpoch_ReturnsPositiveValue()

```
[Fact]
public void GetEpochTime_WithDateAfterEpoch_ReturnsPositiveValue()
```

### GetEpochTime_WithEpochDate_ReturnsZero()

```
[Fact]
public void GetEpochTime_WithEpochDate_ReturnsZero()
```
### GetEpochTime_WithKnownDate_ReturnsCorrectEpochTime()

```
[Fact]
public void GetEpochTime_WithKnownDate_ReturnsCorrectEpochTime()
```
### GetEpochTime_WithLocalTime_ConvertsToUtcCorrectly()

```
[Fact]
public void GetEpochTime_WithLocalTime_ConvertsToUtcCorrectly()
```
### GetEpochTime_WithNullParameter_ReturnsCurrentEpochTime()

```
[Fact]
public void GetEpochTime_WithNullParameter_ReturnsCurrentEpochTime()
```
### GetEpochTime_WithoutParameter_ReturnsPositiveInteger()

```
[Fact]
public void GetEpochTime_WithoutParameter_ReturnsPositiveInteger()
```
### ParseEnum_WithInvalidEnumValue_ThrowsArgumentException()

```
[Fact]
public void ParseEnum_WithInvalidEnumValue_ThrowsArgumentException()
```

### ParseEnum_WithLowerCaseEnumValue_ReturnsCorrectEnum()

```
[Fact]
public void ParseEnum_WithLowerCaseEnumValue_ReturnsCorrectEnum()
```
### ParseEnum_WithMixedCaseEnumValue_ReturnsCorrectEnum()

```
[Fact]
public void ParseEnum_WithMixedCaseEnumValue_ReturnsCorrectEnum()
```
### ParseEnum_WithUpperCaseEnumValue_ReturnsCorrectEnum()

```
[Fact]
public void ParseEnum_WithUpperCaseEnumValue_ReturnsCorrectEnum()
```
### ParseEnum_WithValidEnumValue_ReturnsCorrectEnum()

```
[Fact]
public void ParseEnum_WithValidEnumValue_ReturnsCorrectEnum()
```
### ParseEnum_WithVariousDayValues_ReturnsCorrectEnum(string,

### DayOfWeek)

```
[Theory]
[InlineData(new object[] { "Monday", DayOfWeek.Monday })]
[InlineData(new object[] { "Tuesday", DayOfWeek.Tuesday })]
[InlineData(new object[] { "Wednesday", DayOfWeek.Wednesday })]
[InlineData(new object[] { "Thursday", DayOfWeek.Thursday })]
[InlineData(new object[] { "Friday", DayOfWeek.Friday })]
[InlineData(new object[] { "Saturday", DayOfWeek.Saturday })]
[InlineData(new object[] { "Sunday", DayOfWeek.Sunday })]
public void ParseEnum_WithVariousDayValues_ReturnsCorrectEnum(string dayString,
DayOfWeek expected)
```

#### Parameters

dayString string

expected DayOfWeek

#### Parameters

original string

### StringToBytes_BytesToString_RoundTrip_ReturnsOriginal(string)

```
[Theory]
[InlineData(new object[] { "Simple" })]
[InlineData(new object[] { "With Spaces" })]
[InlineData(new object[] { "With\nNewlines" })]
[InlineData(new object[] { "Special!@#$%^&*()" })]
[InlineData(new object[] { "Unicode: 日本語" })]
public void StringToBytes_BytesToString_RoundTrip_ReturnsOriginal(string original)
```
### StringToBytes_WithEmptyString_ReturnsEmptyByteArray()

```
[Fact]
public void StringToBytes_WithEmptyString_ReturnsEmptyByteArray()
```
### StringToBytes_WithNewlines_ReturnsCorrectBytes()

```
[Fact]
public void StringToBytes_WithNewlines_ReturnsCorrectBytes()
```
### StringToBytes_WithSimpleString_ReturnsCorrectBytes()

```
[Fact]
public void StringToBytes_WithSimpleString_ReturnsCorrectBytes()
```

### StringToBytes_WithSpecialCharacters_ReturnsCorrectBytes()

```
[Fact]
public void StringToBytes_WithSpecialCharacters_ReturnsCorrectBytes()
```
### StringToBytes_WithUnicodeCharacters_ReturnsCorrectBytes()

```
[Fact]
public void StringToBytes_WithUnicodeCharacters_ReturnsCorrectBytes()
```
### StringToBytes_WithVeryLongString_ReturnsCorrectBytes()

```
[Fact]
public void StringToBytes_WithVeryLongString_ReturnsCorrectBytes()
```
### StringToBytes_WithWhitespace_ReturnsCorrectBytes()

```
[Fact]
public void StringToBytes_WithWhitespace_ReturnsCorrectBytes()
```
### StringToStream_PositionIsAtBeginning_AfterCreation()

```
[Fact]
public void StringToStream_PositionIsAtBeginning_AfterCreation()
```
### StringToStream_WithBytesFromStringToBytes_RoundTrip_Return

### sOriginal()

```
[Fact]
public void StringToStream_WithBytesFromStringToBytes_RoundTrip_ReturnsOriginal()
```

### StringToStream_WithEmptyString_ReturnsValidStream()

```
[Fact]
public void StringToStream_WithEmptyString_ReturnsValidStream()
```
### StringToStream_WithMultilineString_ReturnsValidStream()

```
[Fact]
public void StringToStream_WithMultilineString_ReturnsValidStream()
```
### StringToStream_WithSimpleString_ReturnsValidStream()

```
[Fact]
public void StringToStream_WithSimpleString_ReturnsValidStream()
```
### StringToStream_WithSimpleString_StreamContainsCorrectConte

### nt()

```
[Fact]
public void StringToStream_WithSimpleString_StreamContainsCorrectContent()
```

## Classes

AppSettingsProviderTests
Unit tests for the AppSettingsProvider class.

# Namespace TheWeatherNode.Core.Tests.Config


Namespace:TheWeatherNode.Core.Tests.Config

Assembly:TheWeatherNode.Core.Tests.dll

Unit tests for the AppSettingsProvider class.

**Inheritance**

object AppSettingsProviderTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Methods

# Class AppSettingsProviderTests

```
public class AppSettingsProviderTests
```
##### 

## GetAppSetting_AndGetConfigSection_ReturnConsistentData()

```
[Fact]
public void GetAppSetting_AndGetConfigSection_ReturnConsistentData()
```
## GetAppSetting_WithEmptySection_ThrowsInvalidOperationExce

## ption()

```
[Fact]
public void GetAppSetting_WithEmptySection_ThrowsInvalidOperationException()
```
## GetAppSetting_WithNonexistentSection_ThrowsInvalidOperatio

## nException()

```
[Fact]
```

```
public void GetAppSetting_WithNonexistentSection_ThrowsInvalidOperationException()
```
### GetAppSetting_WithNullSection_ThrowsInvalidOperationExcepti

### on()

```
[Fact]
public void GetAppSetting_WithNullSection_ThrowsInvalidOperationException()
```
### GetAppSetting_WithPartialData_ReturnsObjectWithDefaultValue

### s()

```
[Fact]
public void GetAppSetting_WithPartialData_ReturnsObjectWithDefaultValues()
```
### GetAppSetting_WithValidSectionName_ReturnsCorrectType()

```
[Fact]
public void GetAppSetting_WithValidSectionName_ReturnsCorrectType()
```
### GetAppSetting_WithoutParameter_ThrowsWhenSectionNotFoun

### d()

```
[Fact]
public void GetAppSetting_WithoutParameter_ThrowsWhenSectionNotFound()
```
### GetAppSetting_WithoutParameter_UsesTypeNameAsSection()

```
[Fact]
public void GetAppSetting_WithoutParameter_UsesTypeNameAsSection()
```

### GetConfigSection_WithNestedSection_ReturnsCorrectData()

```
[Fact]
public void GetConfigSection_WithNestedSection_ReturnsCorrectData()
```
### GetConfigSection_WithNonexistentSection_ReturnsEmptySectio

### n()

```
[Fact]
public void GetConfigSection_WithNonexistentSection_ReturnsEmptySection()
```
### GetConfigSection_WithValidSectionName_ReturnsConfiguration

### Section()

```
[Fact]
public void GetConfigSection_WithValidSectionName_ReturnsConfigurationSection()
```
### GetEnvironment_WhenEnvironmentVariableNotSet_ReturnsDefa

### ultValue()

```
[Fact]
public void GetEnvironment_WhenEnvironmentVariableNotSet_ReturnsDefaultValue()
```
### GetEnvironment_WhenEnvironmentVariableSet_ReturnsEnviron

### mentValue()

```
[Fact]
public void GetEnvironment_WhenEnvironmentVariableSet_ReturnsEnvironmentValue()
```

#### Parameters

envValue string

### GetEnvironment_WithVariousEnvironmentValues_ReturnsCorrect

### Value(string)

```
[Theory]
[InlineData(new object[] { "development" })]
[InlineData(new object[] { "staging" })]
[InlineData(new object[] { "production" })]
public void GetEnvironment_WithVariousEnvironmentValues_ReturnsCorrectValue(string envValue)
```
### MultipleGetAppSetting_WithSameSectionName_ReturnsSameD

### ata()

```
[Fact]
public void MultipleGetAppSetting_WithSameSectionName_ReturnsSameData()
```

## Classes

UnitTypeExtensionsTests
Unit tests for the UnitTypeExtensions class.

# Namespace TheWeatherNode.Core.Tests.

# Extensions


Namespace:TheWeatherNode.Core.Tests.Extensions

Assembly:TheWeatherNode.Core.Tests.dll

Unit tests for the UnitTypeExtensions class.

**Inheritance**

object UnitTypeExtensionsTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Methods

# Class UnitTypeExtensionsTests

```
public class UnitTypeExtensionsTests
```
##### 

## MultipleConversions_AllUnitsConvertCorrectly()

```
[Fact]
public void MultipleConversions_AllUnitsConvertCorrectly()
```
## RoundTrip_PrecipitationUnit_ConversionIsConsistent()

```
[Fact]
public void RoundTrip_PrecipitationUnit_ConversionIsConsistent()
```
## RoundTrip_TemperatureUnit_ConversionIsConsistent()

```
[Fact]
public void RoundTrip_TemperatureUnit_ConversionIsConsistent()
```

#### Parameters

input PrecipitationUnit

expected string

#### Parameters

input PrecipitationUnit

expected string

### RoundTrip_WindSpeedUnit_ConversionIsConsistent()

```
[Fact]
public void RoundTrip_WindSpeedUnit_ConversionIsConsistent()
```
### ToPrecipitationUnitAbbreviation_WithValidEnum_ReturnsCorrect

### Abbreviation(PrecipitationUnit, string)

```
[Theory]
[InlineData(new object[] { PrecipitationUnit.Millimeters, "mm" })]
[InlineData(new object[] { PrecipitationUnit.Inches, "in" })]
public void
ToPrecipitationUnitAbbreviation_WithValidEnum_ReturnsCorrectAbbreviation(PrecipitationUnit
input, string expected)
```
### ToPrecipitationUnitString_WithValidEnum_ReturnsCorrectString(

### PrecipitationUnit, string)

```
[Theory]
[InlineData(new object[] { PrecipitationUnit.Millimeters, "Millimeters" })]
[InlineData(new object[] { PrecipitationUnit.Inches, "Inches" })]
public void ToPrecipitationUnitString_WithValidEnum_ReturnsCorrectString(PrecipitationUnit
input, string expected)
```

#### Parameters

input string

#### Parameters

input string

### ToPrecipitationUnit_WithEmptyOrWhitespace_ThrowsArgument

### Exception(string)

```
[Theory]
[InlineData(new object[] { "" })]
[InlineData(new object[] { " " })]
public void ToPrecipitationUnit_WithEmptyOrWhitespace_ThrowsArgumentException(string input)
```
### ToPrecipitationUnit_WithInvalidValue_ThrowsArgumentExceptio

### n(string)

```
[Theory]
[InlineData(new object[] { "centimeters" })]
[InlineData(new object[] { "cm" })]
[InlineData(new object[] { "feet" })]
[InlineData(new object[] { "invalid" })]
public void ToPrecipitationUnit_WithInvalidValue_ThrowsArgumentException(string input)
```
### ToPrecipitationUnit_WithNull_ThrowsArgumentNullException()

```
[Fact]
public void ToPrecipitationUnit_WithNull_ThrowsArgumentNullException()
```
### ToPrecipitationUnit_WithValidValueAndWhitespace_ReturnsCorr

### ectEnum(string)


#### Parameters

input string

#### Parameters

input string

expected PrecipitationUnit

```
[Theory]
[InlineData(new object[] { " millimeters " })]
[InlineData(new object[] { " mm " })]
[InlineData(new object[] { " inches " })]
[InlineData(new object[] { " in " })]
public void ToPrecipitationUnit_WithValidValueAndWhitespace_ReturnsCorrectEnum(string input)
```
### ToPrecipitationUnit_WithValidValue_ReturnsCorrectEnum(string,

### PrecipitationUnit)

```
[Theory]
[InlineData(new object[] { "millimeters", PrecipitationUnit.Millimeters })]
[InlineData(new object[] { "Millimeters", PrecipitationUnit.Millimeters })]
[InlineData(new object[] { "MILLIMETERS", PrecipitationUnit.Millimeters })]
[InlineData(new object[] { "mm", PrecipitationUnit.Millimeters })]
[InlineData(new object[] { "MM", PrecipitationUnit.Millimeters })]
[InlineData(new object[] { "inches", PrecipitationUnit.Inches })]
[InlineData(new object[] { "Inches", PrecipitationUnit.Inches })]
[InlineData(new object[] { "INCHES", PrecipitationUnit.Inches })]
[InlineData(new object[] { "in", PrecipitationUnit.Inches })]
[InlineData(new object[] { "IN", PrecipitationUnit.Inches })]
public void ToPrecipitationUnit_WithValidValue_ReturnsCorrectEnum(string input,
PrecipitationUnit expected)
```
### ToTemperatureUnitString_WithValidEnum_ReturnsCorrectString(

### TemperatureUnit, string)


#### Parameters

input TemperatureUnit

expected string

#### Parameters

input string

#### Parameters

input string

```
[Theory]
[InlineData(new object[] { TemperatureUnit.Celsius, "Celsius" })]
[InlineData(new object[] { TemperatureUnit.Fahrenheit, "Fahrenheit" })]
public void ToTemperatureUnitString_WithValidEnum_ReturnsCorrectString(TemperatureUnit
input, string expected)
```
### ToTemperatureUnit_WithEmptyOrWhitespace_ThrowsArgument

### Exception(string)

```
[Theory]
[InlineData(new object[] { "" })]
[InlineData(new object[] { " " })]
public void ToTemperatureUnit_WithEmptyOrWhitespace_ThrowsArgumentException(string input)
```
### ToTemperatureUnit_WithInvalidValue_ThrowsArgumentExceptio

### n(string)

```
[Theory]
[InlineData(new object[] { "kelvin" })]
[InlineData(new object[] { "rankine" })]
[InlineData(new object[] { "invalid" })]
[InlineData(new object[] { "cels" })]
public void ToTemperatureUnit_WithInvalidValue_ThrowsArgumentException(string input)
```

#### Parameters

input string

expected TemperatureUnit

### ToTemperatureUnit_WithNull_ThrowsArgumentNullException()

```
[Fact]
public void ToTemperatureUnit_WithNull_ThrowsArgumentNullException()
```
### ToTemperatureUnit_WithValidValue_ReturnsCorrectEnum(string,

### TemperatureUnit)

```
[Theory]
[InlineData(new object[] { "celsius", TemperatureUnit.Celsius })]
[InlineData(new object[] { "Celsius", TemperatureUnit.Celsius })]
[InlineData(new object[] { "CELSIUS", TemperatureUnit.Celsius })]
[InlineData(new object[] { "fahrenheit", TemperatureUnit.Fahrenheit })]
[InlineData(new object[] { "Fahrenheit", TemperatureUnit.Fahrenheit })]
[InlineData(new object[] { "FAHRENHEIT", TemperatureUnit.Fahrenheit })]
public void ToTemperatureUnit_WithValidValue_ReturnsCorrectEnum(string input,
TemperatureUnit expected)
```
### ToWindSpeedUnitAbbreviation_WithValidEnum_ReturnsCorrect

### Abbreviation(WindSpeedUnit, string)

```
[Theory]
[InlineData(new object[] { WindSpeedUnit.Kmh, "km/h" })]
[InlineData(new object[] { WindSpeedUnit.Mph, "mph" })]
[InlineData(new object[] { WindSpeedUnit.Knots, "knots" })]
public void
ToWindSpeedUnitAbbreviation_WithValidEnum_ReturnsCorrectAbbreviation(WindSpeedUnit input,
string expected)
```

#### Parameters

input WindSpeedUnit

expected string

#### Parameters

input WindSpeedUnit

expected string

#### Parameters

input string

### ToWindSpeedUnitString_WithValidEnum_ReturnsCorrectString(

### WindSpeedUnit, string)

```
[Theory]
[InlineData(new object[] { WindSpeedUnit.Kmh, "Kmh" })]
[InlineData(new object[] { WindSpeedUnit.Mph, "Mph" })]
[InlineData(new object[] { WindSpeedUnit.Knots, "Knots" })]
public void ToWindSpeedUnitString_WithValidEnum_ReturnsCorrectString(WindSpeedUnit input,
string expected)
```
### ToWindSpeedUnit_WithEmptyOrWhitespace_ThrowsArgumentE

### xception(string)

```
[Theory]
[InlineData(new object[] { "" })]
[InlineData(new object[] { " " })]
public void ToWindSpeedUnit_WithEmptyOrWhitespace_ThrowsArgumentException(string input)
```
### ToWindSpeedUnit_WithInvalidValue_ThrowsArgumentException(

### string)


#### Parameters

input string

#### Parameters

input string

```
[Theory]
[InlineData(new object[] { "knots/hour" })]
[InlineData(new object[] { "kilometers" })]
[InlineData(new object[] { "kph/s" })]
[InlineData(new object[] { "invalid" })]
[InlineData(new object[] { "kph" })]
public void ToWindSpeedUnit_WithInvalidValue_ThrowsArgumentException(string input)
```
### ToWindSpeedUnit_WithNull_ThrowsArgumentNullException()

```
[Fact]
public void ToWindSpeedUnit_WithNull_ThrowsArgumentNullException()
```
### ToWindSpeedUnit_WithValidValueAndWhitespace_ReturnsCorre

### ctEnum(string)

```
[Theory]
[InlineData(new object[] { " kmh " })]
[InlineData(new object[] { " km/h " })]
[InlineData(new object[] { " mph " })]
[InlineData(new object[] { " knots " })]
[InlineData(new object[] { " kn " })]
public void ToWindSpeedUnit_WithValidValueAndWhitespace_ReturnsCorrectEnum(string input)
```
### ToWindSpeedUnit_WithValidValue_ReturnsCorrectEnum(string,

### WindSpeedUnit)


#### Parameters

input string

expected WindSpeedUnit

```
[Theory]
[InlineData(new object[] { "kmh", WindSpeedUnit.Kmh })]
[InlineData(new object[] { "KMH", WindSpeedUnit.Kmh })]
[InlineData(new object[] { "Kmh", WindSpeedUnit.Kmh })]
[InlineData(new object[] { "km/h", WindSpeedUnit.Kmh })]
[InlineData(new object[] { "KM/H", WindSpeedUnit.Kmh })]
[InlineData(new object[] { "km\\h", WindSpeedUnit.Kmh })]
[InlineData(new object[] { "mph", WindSpeedUnit.Mph })]
[InlineData(new object[] { "MPH", WindSpeedUnit.Mph })]
[InlineData(new object[] { "Mph", WindSpeedUnit.Mph })]
[InlineData(new object[] { "knots", WindSpeedUnit.Knots })]
[InlineData(new object[] { "KNOTS", WindSpeedUnit.Knots })]
[InlineData(new object[] { "Knots", WindSpeedUnit.Knots })]
[InlineData(new object[] { "kn", WindSpeedUnit.Knots })]
[InlineData(new object[] { "KN", WindSpeedUnit.Knots })]
public void ToWindSpeedUnit_WithValidValue_ReturnsCorrectEnum(string input,
WindSpeedUnit expected)
```

## Classes

WeatherRequestTests
Unit tests for the WeatherRequest class.

# Namespace TheWeatherNode.Core.Tests.

# Models.Requests


Namespace:TheWeatherNode.Core.Tests.Models.Requests

Assembly:TheWeatherNode.Core.Tests.dll

Unit tests for the WeatherRequest class.

**Inheritance**

object WeatherRequestTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Methods

# Class WeatherRequestTests

```
public class WeatherRequestTests
```
##### 

## Constructor_Parameterless_CreatesInstanceWithDefaultValues()

```
[Fact]
public void Constructor_Parameterless_CreatesInstanceWithDefaultValues()
```
## Constructor_StringBased_AndEnumBased_ProduceSameResult()

```
[Fact]
public void Constructor_StringBased_AndEnumBased_ProduceSameResult()
```
## Constructor_WithAliasedUnits_ConvertsToCorrectEnum()

```
[Fact]
public void Constructor_WithAliasedUnits_ConvertsToCorrectEnum()
```

### Constructor_WithAllEnumParametersSpecified_CreatesInstanceS

### uccessfully()

```
[Fact]
public void Constructor_WithAllEnumParametersSpecified_CreatesInstanceSuccessfully()
```
### Constructor_WithAllImperialUnits_CreatesRequest()

```
[Fact]
public void Constructor_WithAllImperialUnits_CreatesRequest()
```
### Constructor_WithAllMetricDefaults_CreatesRequest()

```
[Fact]
public void Constructor_WithAllMetricDefaults_CreatesRequest()
```
### Constructor_WithAllStringParametersSpecified_CreatesInstanceS

### uccessfully()

```
[Fact]
public void Constructor_WithAllStringParametersSpecified_CreatesInstanceSuccessfully()
```
### Constructor_WithDecimalCoordinates_PreservesDecimalPlaces()

```
[Fact]
public void Constructor_WithDecimalCoordinates_PreservesDecimalPlaces()
```
### Constructor_WithEmptyPrecipitationUnit_ThrowsArgumentExce

### ption(string)


#### Parameters

precipitationUnit string

#### Parameters

temperatureUnit string

#### Parameters

```
[Theory]
[InlineData(new object[] { "" })]
[InlineData(new object[] { " " })]
[InlineData(new object[] { "\t" })]
public void Constructor_WithEmptyPrecipitationUnit_ThrowsArgumentException(string
precipitationUnit)
```
### Constructor_WithEmptyTemperatureUnit_ThrowsArgumentExce

### ption(string)

```
[Theory]
[InlineData(new object[] { "" })]
[InlineData(new object[] { " " })]
[InlineData(new object[] { "\t" })]
[InlineData(new object[] { "\n" })]
public void Constructor_WithEmptyTemperatureUnit_ThrowsArgumentException(string
temperatureUnit)
```
### Constructor_WithEmptyWindSpeedUnit_ThrowsArgumentExcept

### ion(string)

```
[Theory]
[InlineData(new object[] { "" })]
[InlineData(new object[] { " " })]
[InlineData(new object[] { "\t" })]
public void Constructor_WithEmptyWindSpeedUnit_ThrowsArgumentException(string windSpeedUnit)
```

windSpeedUnit string

#### Parameters

value double

### Constructor_WithExtremeCoordinates_CreatesInstanceSuccessfu

### lly()

```
[Fact]
public void Constructor_WithExtremeCoordinates_CreatesInstanceSuccessfully()
```
### Constructor_WithExtremeDoubleValues_CreatesInstance(double)

```
[Theory]
[InlineData(new object[] { -1.7976931348623157E+308 })]
[InlineData(new object[] { 1.7976931348623157E+308 })]
public void Constructor_WithExtremeDoubleValues_CreatesInstance(double value)
```
### Constructor_WithHighPrecisionCoordinates_PreservesValues()

```
[Fact]
public void Constructor_WithHighPrecisionCoordinates_PreservesValues()
```
### Constructor_WithInvalidPrecipitationUnit_ThrowsArgumentExce

### ption()

```
[Fact]
public void Constructor_WithInvalidPrecipitationUnit_ThrowsArgumentException()
```
### Constructor_WithInvalidTemperatureUnit_ThrowsArgumentExce

### ption()


```
[Fact]
public void Constructor_WithInvalidTemperatureUnit_ThrowsArgumentException()
```
### Constructor_WithInvalidWindSpeedUnit_ThrowsArgumentExcep

### tion()

```
[Fact]
public void Constructor_WithInvalidWindSpeedUnit_ThrowsArgumentException()
```
### Constructor_WithMaxLatitude_CreatesInstanceSuccessfully()

```
[Fact]
public void Constructor_WithMaxLatitude_CreatesInstanceSuccessfully()
```
### Constructor_WithMaxLongitude_CreatesInstanceSuccessfully()

```
[Fact]
public void Constructor_WithMaxLongitude_CreatesInstanceSuccessfully()
```
### Constructor_WithMinLatitude_CreatesInstanceSuccessfully()

```
[Fact]
public void Constructor_WithMinLatitude_CreatesInstanceSuccessfully()
```
### Constructor_WithMinLongitude_CreatesInstanceSuccessfully()

```
[Fact]
public void Constructor_WithMinLongitude_CreatesInstanceSuccessfully()
```

### Constructor_WithMixedCaseUnits_NormalizesCorrectly()

```
[Fact]
public void Constructor_WithMixedCaseUnits_NormalizesCorrectly()
```
### Constructor_WithMixedMetricAndImperial_CreatesRequest()

```
[Fact]
public void Constructor_WithMixedMetricAndImperial_CreatesRequest()
```
### Constructor_WithNegativeCoordinates_CreatesInstanceSuccessf

### ully()

```
[Fact]
public void Constructor_WithNegativeCoordinates_CreatesInstanceSuccessfully()
```
### Constructor_WithNegativeZeroCoordinate_CreatesInstance()

```
[Fact]
public void Constructor_WithNegativeZeroCoordinate_CreatesInstance()
```
### Constructor_WithNullPrecipitationUnit_ThrowsArgumentNullExc

### eption()

```
[Fact]
public void Constructor_WithNullPrecipitationUnit_ThrowsArgumentNullException()
```
### Constructor_WithNullTemperatureUnit_ThrowsArgumentNullExc

### eption()


#### Parameters

latitude double

```
[Fact]
public void Constructor_WithNullTemperatureUnit_ThrowsArgumentNullException()
```
### Constructor_WithNullWindSpeedUnit_ThrowsArgumentNullExce

### ption()

```
[Fact]
public void Constructor_WithNullWindSpeedUnit_ThrowsArgumentNullException()
```
### Constructor_WithOutOfRangeLatitudes_StillCreatesInstance(dou

### ble)

```
[Theory]
[InlineData(new object[] { 90.1 })]
[InlineData(new object[] { -90.1 })]
[InlineData(new object[] { 180 })]
[InlineData(new object[] { -180.1 })]
[InlineData(new object[] { 999 })]
public void Constructor_WithOutOfRangeLatitudes_StillCreatesInstance(double latitude)
```
### Constructor_WithOutOfRangeLongitudes_StillCreatesInstance(d

### ouble)

```
[Theory]
[InlineData(new object[] { 180.1 })]
[InlineData(new object[] { -180.1 })]
[InlineData(new object[] { 360 })]
[InlineData(new object[] { -360 })]
public void Constructor_WithOutOfRangeLongitudes_StillCreatesInstance(double longitude)
```

#### Parameters

longitude double

#### Parameters

latitude double

longitude double

tempUnit string

windUnit string

precipUnit string

### Constructor_WithRealWorldCoordinates_CreatesValidRequest(d

### ouble, double, string, string, string)

```
[Theory]
[InlineData(new object[] { 35.6762, 139.6503, "celsius", "km/h", "millimeters" })]
[InlineData(new object[] { 48.8566, 2.3522, "celsius", "km/h", "millimeters" })]
[InlineData(new object[] { -33.8688, 151.2093, "celsius", "km/h", "millimeters" })]
[InlineData(new object[] { 40.7128, -74.006, "fahrenheit", "mph", "inches" })]
[InlineData(new object[] { 51.5074, -0.1278, "celsius", "kmh", "mm" })]
[InlineData(new object[] { 1.3521, 103.8198, "celsius", "km/h", "millimeters" })]
public void Constructor_WithRealWorldCoordinates_CreatesValidRequest(double latitude, double
longitude, string tempUnit, string windUnit, string precipUnit)
```
### Constructor_WithUnsupportedTemperatureUnit_ThrowsArgume

### ntException(string)

```
[Theory]
[InlineData(new object[] { "kelvin" })]
[InlineData(new object[] { "rankine" })]
[InlineData(new object[] { "temp" })]
[InlineData(new object[] { "c" })]
public void Constructor_WithUnsupportedTemperatureUnit_ThrowsArgumentException(string
invalidUnit)
```

#### Parameters

invalidUnit string

#### Parameters

latitude double

### Constructor_WithValidCoordinatesAndDefaults_CreatesInstance

### Successfully()

```
[Fact]
public void Constructor_WithValidCoordinatesAndDefaults_CreatesInstanceSuccessfully()
```
### Constructor_WithValidLatitudes_CreatesInstanceSuccessfully(do

### uble)

```
[Theory]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { 90 })]
[InlineData(new object[] { -90 })]
[InlineData(new object[] { 45.5 })]
[InlineData(new object[] { -33.8688 })]
[InlineData(new object[] { 51.5074 })]
[InlineData(new object[] { 35.6762 })]
public void Constructor_WithValidLatitudes_CreatesInstanceSuccessfully(double latitude)
```
### Constructor_WithValidLongitudes_CreatesInstanceSuccessfully(d

### ouble)

```
[Theory]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { 180 })]
[InlineData(new object[] { -180 })]
[InlineData(new object[] { 139.6917 })]
[InlineData(new object[] { -74.006 })]
[InlineData(new object[] { 2.3522 })]
```

#### Parameters

longitude double

#### Parameters

precipitationUnit string

expected PrecipitationUnit

```
[InlineData(new object[] { 151.2093 })]
public void Constructor_WithValidLongitudes_CreatesInstanceSuccessfully(double longitude)
```
### Constructor_WithVariousPrecipitationUnits_ConvertsCorrectly(st

### ring, PrecipitationUnit)

```
[Theory]
[InlineData(new object[] { "millimeters", PrecipitationUnit.Millimeters })]
[InlineData(new object[] { "mm", PrecipitationUnit.Millimeters })]
[InlineData(new object[] { "MM", PrecipitationUnit.Millimeters })]
[InlineData(new object[] { "MILLIMETERS", PrecipitationUnit.Millimeters })]
[InlineData(new object[] { "inches", PrecipitationUnit.Inches })]
[InlineData(new object[] { "in", PrecipitationUnit.Inches })]
[InlineData(new object[] { "IN", PrecipitationUnit.Inches })]
[InlineData(new object[] { "INCHES", PrecipitationUnit.Inches })]
public void Constructor_WithVariousPrecipitationUnits_ConvertsCorrectly(string
precipitationUnit, PrecipitationUnit expected)
```
### Constructor_WithVariousTemperatureUnits_ConvertsCorrectly(st

### ring, TemperatureUnit)

```
[Theory]
[InlineData(new object[] { "celsius", TemperatureUnit.Celsius })]
[InlineData(new object[] { "Celsius", TemperatureUnit.Celsius })]
[InlineData(new object[] { "CELSIUS", TemperatureUnit.Celsius })]
[InlineData(new object[] { "fahrenheit", TemperatureUnit.Fahrenheit })]
[InlineData(new object[] { "Fahrenheit", TemperatureUnit.Fahrenheit })]
[InlineData(new object[] { "FAHRENHEIT", TemperatureUnit.Fahrenheit })]
[InlineData(new object[] { "c", TemperatureUnit.Celsius })]
```

#### Parameters

temperatureUnit string

expected TemperatureUnit

#### Parameters

windSpeedUnit string

expected WindSpeedUnit

```
[InlineData(new object[] { "f", TemperatureUnit.Fahrenheit })]
public void Constructor_WithVariousTemperatureUnits_ConvertsCorrectly(string
temperatureUnit, TemperatureUnit expected)
```
### Constructor_WithVariousWindSpeedUnits_ConvertsCorrectly(stri

### ng, WindSpeedUnit)

```
[Theory]
[InlineData(new object[] { "kmh", WindSpeedUnit.Kmh })]
[InlineData(new object[] { "km/h", WindSpeedUnit.Kmh })]
[InlineData(new object[] { "KMH", WindSpeedUnit.Kmh })]
[InlineData(new object[] { "KM/H", WindSpeedUnit.Kmh })]
[InlineData(new object[] { "mph", WindSpeedUnit.Mph })]
[InlineData(new object[] { "MPH", WindSpeedUnit.Mph })]
[InlineData(new object[] { "knots", WindSpeedUnit.Knots })]
[InlineData(new object[] { "KNOTS", WindSpeedUnit.Knots })]
[InlineData(new object[] { "kn", WindSpeedUnit.Knots })]
[InlineData(new object[] { "KN", WindSpeedUnit.Knots })]
public void Constructor_WithVariousWindSpeedUnits_ConvertsCorrectly(string windSpeedUnit,
WindSpeedUnit expected)
```
### Constructor_WithVerySmallCoordinates_PreservesValues()

```
[Fact]
public void Constructor_WithVerySmallCoordinates_PreservesValues()
```

### Constructor_WithZeroCoordinates_CreatesInstanceSuccessfully()

```
[Fact]
public void Constructor_WithZeroCoordinates_CreatesInstanceSuccessfully()
```
### Latitude_CanBeModifiedMultipleTimes()

```
[Fact]
public void Latitude_CanBeModifiedMultipleTimes()
```
### Longitude_CanBeModifiedMultipleTimes()

```
[Fact]
public void Longitude_CanBeModifiedMultipleTimes()
```
### MultipleInstances_CanBeModifiedIndependently()

```
[Fact]
public void MultipleInstances_CanBeModifiedIndependently()
```
### MultipleInstances_WithSameParameters_AreIndependent()

```
[Fact]
public void MultipleInstances_WithSameParameters_AreIndependent()
```
### Properties_CanBeModified()

```
[Fact]
public void Properties_CanBeModified()
```

### SameRequest_HasConsistentProperties()

```
[Fact]
public void SameRequest_HasConsistentProperties()
```
### TemperatureUnit_CanBeModifiedMultipleTimes()

```
[Fact]
public void TemperatureUnit_CanBeModifiedMultipleTimes()
```
### TwoRequests_WithIdenticalParameters_AreNotEqual()

```
[Fact]
public void TwoRequests_WithIdenticalParameters_AreNotEqual()
```

## Classes

CurrentWeatherTests
Unit tests for the CurrentWeather class.

DailyForecastTests
Unit tests for the DailyForecast class.

HourlyForecastTests
Unit tests for the HourlyForecast class.

LocationTests
Unit tests for the Location class.

WeatherForecastTests
Unit tests for the WeatherForecast class.

# Namespace TheWeatherNode.Core.Tests.

# Models.Responses


Namespace:TheWeatherNode.Core.Tests.Models.Responses

Assembly:TheWeatherNode.Core.Tests.dll

Unit tests for the CurrentWeather class.

**Inheritance**

object CurrentWeatherTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Methods

## Parameters

cloudCover double

# Class CurrentWeatherTests

```
public class CurrentWeatherTests
```
##### 

## CloudCover_WithValidRange_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { 25 })]
[InlineData(new object[] { 50 })]
[InlineData(new object[] { 100 })]
public void CloudCover_WithValidRange_CanBeSetAndRetrieved(double cloudCover)
```
## Constructor_CreatesInstanceWithDefaultValues()

```
[Fact]
public void Constructor_CreatesInstanceWithDefaultValues()
```

#### Parameters

dewPoint double

### CurrentWeather_MultipleInstances_AreIndependent()

```
[Fact]
public void CurrentWeather_MultipleInstances_AreIndependent()
```
### CurrentWeather_WithExtremeColdValues_StoresCorrectly()

```
[Fact]
public void CurrentWeather_WithExtremeColdValues_StoresCorrectly()
```
### CurrentWeather_WithExtremeHotValues_StoresCorrectly()

```
[Fact]
public void CurrentWeather_WithExtremeHotValues_StoresCorrectly()
```
### CurrentWeather_WithRealisticValues_CreatesValidInstance()

```
[Fact]
public void CurrentWeather_WithRealisticValues_CreatesValidInstance()
```
### DewPoint_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 8.5 })]
[InlineData(new object[] { 5 })]
[InlineData(new object[] { 20 })]
[InlineData(new object[] { -5 })]
public void DewPoint_CanBeSetAndRetrieved(double dewPoint)
```

#### Parameters

feelsLike double

#### Parameters

humidity double

### DewPoint_IsTypicallyLowerThanTemperature()

```
[Fact]
public void DewPoint_IsTypicallyLowerThanTemperature()
```
### FeelsLike_CanBeDifferentFromTemperature()

```
[Fact]
public void FeelsLike_CanBeDifferentFromTemperature()
```
### FeelsLike_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 14.1 })]
[InlineData(new object[] { 10.5 })]
[InlineData(new object[] { -15 })]
[InlineData(new object[] { 28.3 })]
public void FeelsLike_CanBeSetAndRetrieved(double feelsLike)
```
### Humidity_OutsideValidRange_StillStoresValue(double)

```
[Theory]
[InlineData(new object[] { -10 })]
[InlineData(new object[] { 150 })]
public void Humidity_OutsideValidRange_StillStoresValue(double humidity)
```

#### Parameters

humidity double

#### Parameters

isDay bool

#### Parameters

probability double

### Humidity_WithValidRange_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { 50 })]
[InlineData(new object[] { 100 })]
[InlineData(new object[] { 65.5 })]
public void Humidity_WithValidRange_CanBeSetAndRetrieved(double humidity)
```
### IsDay_CanBeSetAndRetrieved(bool)

```
[Theory]
[InlineData(new object[] { true })]
[InlineData(new object[] { false })]
public void IsDay_CanBeSetAndRetrieved(bool isDay)
```
### PrecipitationProbability_WithValidRange_CanBeSetAndRetrieved

### (double)

```
[Theory]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { 25 })]
[InlineData(new object[] { 50 })]
[InlineData(new object[] { 100 })]
public void PrecipitationProbability_WithValidRange_CanBeSetAndRetrieved(double probability)
```

#### Parameters

precipitation double

#### Parameters

pressure double

#### Parameters

temperature double

### Precipitation_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { 2.5 })]
[InlineData(new object[] { 10 })]
[InlineData(new object[] { 50 })]
public void Precipitation_CanBeSetAndRetrieved(double precipitation)
```
### Pressure_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 1013.25 })]
[InlineData(new object[] { 1000 })]
[InlineData(new object[] { 1030 })]
public void Pressure_CanBeSetAndRetrieved(double pressure)
```
### Temperature_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 15.2 })]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { -10.5 })]
[InlineData(new object[] { 35.8 })]
[InlineData(new object[] { -40 })]
public void Temperature_CanBeSetAndRetrieved(double temperature)
```

#### Parameters

fahrenheit double

#### Parameters

### Temperature_WithImperialUnits_StoresCorrectly(double)

```
[Theory]
[InlineData(new object[] { 32 })]
[InlineData(new object[] { 68 })]
[InlineData(new object[] { 86 })]
[InlineData(new object[] { -4 })]
public void Temperature_WithImperialUnits_StoresCorrectly(double fahrenheit)
```
### Time_DefaultValue_IsMinValue()

```
[Fact]
public void Time_DefaultValue_IsMinValue()
```
### Time_WithUtcTimestamp_CanBeSetAndRetrieved()

```
[Fact]
public void Time_WithUtcTimestamp_CanBeSetAndRetrieved()
```
### UvIndex_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { 3.2 })]
[InlineData(new object[] { 8.5 })]
[InlineData(new object[] { 11 })]
public void UvIndex_CanBeSetAndRetrieved(double uvIndex)
```

uvIndex double

#### Parameters

visibility double

#### Parameters

weatherCode int

### Visibility_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 10000 })]
[InlineData(new object[] { 5000 })]
[InlineData(new object[] { 100 })]
[InlineData(new object[] { 0 })]
public void Visibility_CanBeSetAndRetrieved(double visibility)
```
### WeatherCode_CanBeSetAndRetrieved(int)

```
[Theory]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { 3 })]
[InlineData(new object[] { 45 })]
[InlineData(new object[] { 60 })]
[InlineData(new object[] { 80 })]
[InlineData(new object[] { 95 })]
public void WeatherCode_CanBeSetAndRetrieved(int weatherCode)
```
### WindDirection_OutsideValidRange_StillStoresValue(double)

```
[Theory]
[InlineData(new object[] { -45 })]
[InlineData(new object[] { 360 })]
[InlineData(new object[] { 720 })]
public void WindDirection_OutsideValidRange_StillStoresValue(double windDirection)
```

#### Parameters

windDirection double

#### Parameters

windDirection double

#### Parameters

windGusts double

### WindDirection_WithValidRange_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { 90 })]
[InlineData(new object[] { 180 })]
[InlineData(new object[] { 270 })]
[InlineData(new object[] { 45.5 })]
[InlineData(new object[] { 359.9 })]
public void WindDirection_WithValidRange_CanBeSetAndRetrieved(double windDirection)
```
### WindGusts_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 18.5 })]
[InlineData(new object[] { 25 })]
[InlineData(new object[] { 35 })]
public void WindGusts_CanBeSetAndRetrieved(double windGusts)
```
### WindGusts_IsTypicallyHigherThanWindSpeed()

```
[Fact]
public void WindGusts_IsTypicallyHigherThanWindSpeed()
```

#### Parameters

windSpeed double

### WindSpeed_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { 12.3 })]
[InlineData(new object[] { 50 })]
[InlineData(new object[] { 100 })]
public void WindSpeed_CanBeSetAndRetrieved(double windSpeed)
```

Namespace:TheWeatherNode.Core.Tests.Models.Responses

Assembly:TheWeatherNode.Core.Tests.dll

Unit tests for the DailyForecast class.

**Inheritance**

object DailyForecastTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Methods

# Class DailyForecastTests

```
public class DailyForecastTests
```
##### 

## Constructor_CreatesInstanceWithDefaultValues()

```
[Fact]
public void Constructor_CreatesInstanceWithDefaultValues()
```
## DailyForecast_MultipleInstances_AreIndependent()

```
[Fact]
public void DailyForecast_MultipleInstances_AreIndependent()
```
## DailyForecast_WithRealisticValues_CreatesValidInstance()

```
[Fact]
public void DailyForecast_WithRealisticValues_CreatesValidInstance()
```

#### Parameters

max double

min double

#### Parameters

max double

min double

### Date_CanBeSetAndRetrieved()

```
[Fact]
public void Date_CanBeSetAndRetrieved()
```
### Date_WithDifferentDates_StoresCorrectly()

```
[Fact]
public void Date_WithDifferentDates_StoresCorrectly()
```
### FeelsLike_MaxAndMin_CanBeSetAndRetrieved(double, double)

```
[Theory]
[InlineData(new object[] { 17.1, 9 })]
[InlineData(new object[] { 30 , 18 })]
public void FeelsLike_MaxAndMin_CanBeSetAndRetrieved(double max, double min)
```
### Humidity_MaxAndMin_CanBeSetAndRetrieved(double, double)

```
[Theory]
[InlineData(new object[] { 75 , 55 })]
[InlineData(new object[] { 100 , 0 })]
public void Humidity_MaxAndMin_CanBeSetAndRetrieved(double max, double min)
```

#### Parameters

sum double

probability double

#### Parameters

pressure double

### Precipitation_SumAndProbability_CanBeSetAndRetrieved(doubl

### e, double)

```
[Theory]
[InlineData(new object[] { 2.5, 65 })]
[InlineData(new object[] { 0 , 0 })]
[InlineData(new object[] { 50 , 100 })]
public void Precipitation_SumAndProbability_CanBeSetAndRetrieved(double sum,
double probability)
```
### PressureMean_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 1013.5 })]
[InlineData(new object[] { 1000 })]
[InlineData(new object[] { 1030 })]
public void PressureMean_CanBeSetAndRetrieved(double pressure)
```
### Sunrise_And_Sunset_CanBeSetAndRetrieved()

```
[Fact]
public void Sunrise_And_Sunset_CanBeSetAndRetrieved()
```
### Sunset_IsAfterSunrise()


#### Parameters

max double

min double

#### Parameters

uvIndex double

```
[Fact]
public void Sunset_IsAfterSunrise()
```
### TemperatureMax_IsTypicallyGreaterThanMin()

```
[Fact]
public void TemperatureMax_IsTypicallyGreaterThanMin()
```
### Temperature_MaxAndMin_CanBeSetAndRetrieved(double,

### double)

```
[Theory]
[InlineData(new object[] { 18.5, 10.2 })]
[InlineData(new object[] { 35 , 20 })]
[InlineData(new object[] { -5, -15 })]
public void Temperature_MaxAndMin_CanBeSetAndRetrieved(double max, double min)
```
### UvIndexMax_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 4.2 })]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { 12 })]
public void UvIndexMax_CanBeSetAndRetrieved(double uvIndex)
```

#### Parameters

code int

#### Parameters

speed double

gusts double

direction double

### WeatherCode_CanBeSetAndRetrieved(int)

```
[Theory]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { 3 })]
[InlineData(new object[] { 60 })]
[InlineData(new object[] { 95 })]
public void WeatherCode_CanBeSetAndRetrieved(int code)
```
### WindGustsMax_IsTypicallyGreaterThanWindSpeedMax()

```
[Fact]
public void WindGustsMax_IsTypicallyGreaterThanWindSpeedMax()
```
### Wind_SpeedGustsAndDirection_CanBeSetAndRetrieved(double,

### double, double)

```
[Theory]
[InlineData(new object[] { 25 , 35 , 220 })]
[InlineData(new object[] { 15 , 22 , 90 })]
public void Wind_SpeedGustsAndDirection_CanBeSetAndRetrieved(double speed, double gusts,
double direction)
```

Namespace:TheWeatherNode.Core.Tests.Models.Responses

Assembly:TheWeatherNode.Core.Tests.dll

Unit tests for the HourlyForecast class.

**Inheritance**

object HourlyForecastTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Methods

## Parameters

cloudCover double

# Class HourlyForecastTests

```
public class HourlyForecastTests
```
##### 

## CloudCover_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { 50 })]
[InlineData(new object[] { 100 })]
public void CloudCover_CanBeSetAndRetrieved(double cloudCover)
```
## Constructor_CreatesInstanceWithDefaultValues()

```
[Fact]
public void Constructor_CreatesInstanceWithDefaultValues()
```

#### Parameters

dewPoint double

### DewPoint_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 8.5 })]
[InlineData(new object[] { 20 })]
public void DewPoint_CanBeSetAndRetrieved(double dewPoint)
```
### FeelsLike_CanBeDifferentFromTemperature()

```
[Fact]
public void FeelsLike_CanBeDifferentFromTemperature()
```
### HourlyForecast_MultipleInstances_AreIndependent()

```
[Fact]
public void HourlyForecast_MultipleInstances_AreIndependent()
```
### HourlyForecast_WithConsecutiveHours_StoresCorrectly()

```
[Fact]
public void HourlyForecast_WithConsecutiveHours_StoresCorrectly()
```
### HourlyForecast_WithRealisticValues_CreatesValidInstance()

```
[Fact]
public void HourlyForecast_WithRealisticValues_CreatesValidInstance()
```
### Humidity_CanBeSetAndRetrieved(double)


#### Parameters

humidity double

#### Parameters

isDay bool

#### Parameters

amount double

probability double

```
[Theory]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { 50 })]
[InlineData(new object[] { 100 })]
public void Humidity_CanBeSetAndRetrieved(double humidity)
```
### IsDay_CanBeSetAndRetrieved(bool)

```
[Theory]
[InlineData(new object[] { true })]
[InlineData(new object[] { false })]
public void IsDay_CanBeSetAndRetrieved(bool isDay)
```
### Precipitation_AmountAndProbability_CanBeSetAndRetrieved(do

### uble, double)

```
[Theory]
[InlineData(new object[] { 0 , 0 })]
[InlineData(new object[] { 2.5, 50 })]
[InlineData(new object[] { 10 , 100 })]
public void Precipitation_AmountAndProbability_CanBeSetAndRetrieved(double amount,
double probability)
```

#### Parameters

pressure double

#### Parameters

temperature double

#### Parameters

hour int

### Pressure_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 1013.25 })]
[InlineData(new object[] { 1000 })]
public void Pressure_CanBeSetAndRetrieved(double pressure)
```
### Temperature_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 15.2 })]
[InlineData(new object[] { -5 })]
[InlineData(new object[] { 30 })]
public void Temperature_CanBeSetAndRetrieved(double temperature)
```
### Time_WithDifferentHours_StoresCorrectly(int)

```
[Theory]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { 6 })]
[InlineData(new object[] { 12 })]
[InlineData(new object[] { 18 })]
[InlineData(new object[] { 23 })]
public void Time_WithDifferentHours_StoresCorrectly(int hour)
```

#### Parameters

visibility double

#### Parameters

code int

### Time_WithUtcTimestamp_CanBeSetAndRetrieved()

```
[Fact]
public void Time_WithUtcTimestamp_CanBeSetAndRetrieved()
```
### Visibility_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 10000 })]
[InlineData(new object[] { 5000 })]
[InlineData(new object[] { 100 })]
public void Visibility_CanBeSetAndRetrieved(double visibility)
```
### WeatherCode_CanBeSetAndRetrieved(int)

```
[Theory]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { 3 })]
[InlineData(new object[] { 60 })]
[InlineData(new object[] { 95 })]
public void WeatherCode_CanBeSetAndRetrieved(int code)
```
### Wind_SpeedDirectionAndGusts_CanBeSetAndRetrieved(double,

### double, double)

```
[Theory]
[InlineData(new object[] { 12.3, 220 , 18.5 })]
[InlineData(new object[] { 0 , 0 , 0 })]
```

#### Parameters

speed double

direction double

gusts double

```
[InlineData(new object[] { 50 , 180 , 65 })]
public void Wind_SpeedDirectionAndGusts_CanBeSetAndRetrieved(double speed, double direction,
double gusts)
```

Namespace:TheWeatherNode.Core.Tests.Models.Responses

Assembly:TheWeatherNode.Core.Tests.dll

Unit tests for the Location class.

**Inheritance**

object LocationTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Methods

## Parameters

code string

# Class LocationTests

```
public class LocationTests
```
##### 

## Constructor_CreatesInstanceWithDefaultValues()

```
[Fact]
public void Constructor_CreatesInstanceWithDefaultValues()
```
## CountryCode_CanBeSetAndRetrieved(string)

```
[Theory]
[InlineData(new object[] { "US" })]
[InlineData(new object[] { "FR" })]
[InlineData(new object[] { "JP" })]
[InlineData(new object[] { "GB" })]
public void CountryCode_CanBeSetAndRetrieved(string code)
```

#### Parameters

country string

#### Parameters

latitude double

### Country_CanBeSetAndRetrieved(string)

```
[Theory]
[InlineData(new object[] { "United States" })]
[InlineData(new object[] { "France" })]
[InlineData(new object[] { "Japan" })]
public void Country_CanBeSetAndRetrieved(string country)
```
### Latitude_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { 40.7128 })]
[InlineData(new object[] { -33.8688 })]
[InlineData(new object[] { 90 })]
[InlineData(new object[] { -90 })]
public void Latitude_CanBeSetAndRetrieved(double latitude)
```
### Location_MultipleInstances_AreIndependent()

```
[Fact]
public void Location_MultipleInstances_AreIndependent()
```
### Location_WithRealWorldCoordinates_Tokyo()

```
[Fact]
public void Location_WithRealWorldCoordinates_Tokyo()
```

#### Parameters

longitude double

#### Parameters

name string

### Location_WithRealisticValues_CreatesValidInstance()

```
[Fact]
public void Location_WithRealisticValues_CreatesValidInstance()
```
### Longitude_CanBeSetAndRetrieved(double)

```
[Theory]
[InlineData(new object[] { 0 })]
[InlineData(new object[] { -74.006 })]
[InlineData(new object[] { 139.6917 })]
[InlineData(new object[] { 180 })]
[InlineData(new object[] { -180 })]
public void Longitude_CanBeSetAndRetrieved(double longitude)
```
### Name_CanBeSetAndRetrieved(string)

```
[Theory]
[InlineData(new object[] { "New York" })]
[InlineData(new object[] { "Paris" })]
[InlineData(new object[] { "Tokyo" })]
[InlineData(new object[] { "London" })]
public void Name_CanBeSetAndRetrieved(string name)
```
### Population_CanBeSetAndRetrieved(int)

```
[Theory]
[InlineData(new object[] { 0 })]
```

#### Parameters

population int

#### Parameters

state string

```
[InlineData(new object[] { 7864 })]
[InlineData(new object[] { 8000000 })]
public void Population_CanBeSetAndRetrieved(int population)
```
### PostalCodes_CanBeSetWithMultipleCodes()

```
[Fact]
public void PostalCodes_CanBeSetWithMultipleCodes()
```
### PostalCodes_CanBeSetWithSingleCode()

```
[Fact]
public void PostalCodes_CanBeSetWithSingleCode()
```
### PostalCodes_DefaultsToEmptyCollection()

```
[Fact]
public void PostalCodes_DefaultsToEmptyCollection()
```
### State_CanBeSetAndRetrieved(string)

```
[Theory]
[InlineData(new object[] { "New York" })]
[InlineData(new object[] { "California" })]
[InlineData(new object[] { "Nebraska" })]
public void State_CanBeSetAndRetrieved(string state)
```

#### Parameters

timezone string

### Timezone_CanBeSetAndRetrieved(string)

```
[Theory]
[InlineData(new object[] { "America/New_York" })]
[InlineData(new object[] { "Europe/London" })]
[InlineData(new object[] { "Asia/Tokyo" })]
[InlineData(new object[] { "America/Chicago" })]
public void Timezone_CanBeSetAndRetrieved(string timezone)
```

Namespace:TheWeatherNode.Core.Tests.Models.Responses

Assembly:TheWeatherNode.Core.Tests.dll

Unit tests for the WeatherForecast class.

**Inheritance**

object WeatherForecastTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Methods

# Class WeatherForecastTests

```
public class WeatherForecastTests
```
##### 

## Constructor_CreatesInstanceWithDefaultValues()

```
[Fact]
public void Constructor_CreatesInstanceWithDefaultValues()
```
## Current_CanBeSetAndRetrieved()

```
[Fact]
public void Current_CanBeSetAndRetrieved()
```
## Daily_CanBeSetWithMultipleForecasts()

```
[Fact]
public void Daily_CanBeSetWithMultipleForecasts()
```

### Daily_CanBeSetWithSingleForecast()

```
[Fact]
public void Daily_CanBeSetWithSingleForecast()
```
### Daily_DefaultsToEmptyCollection()

```
[Fact]
public void Daily_DefaultsToEmptyCollection()
```
### Hourly_CanBeSetWithMultipleForecasts()

```
[Fact]
public void Hourly_CanBeSetWithMultipleForecasts()
```
### Hourly_CanBeSetWithSingleForecast()

```
[Fact]
public void Hourly_CanBeSetWithSingleForecast()
```
### Hourly_DefaultsToEmptyCollection()

```
[Fact]
public void Hourly_DefaultsToEmptyCollection()
```
### Location_CanBeSetAndRetrieved()

```
[Fact]
public void Location_CanBeSetAndRetrieved()
```

#### Parameters

abbr string

#### Parameters

timezone string

### TimezoneAbbreviation_CanBeSetAndRetrieved(string)

```
[Theory]
[InlineData(new object[] { "EST" })]
[InlineData(new object[] { "GMT" })]
[InlineData(new object[] { "JST" })]
public void TimezoneAbbreviation_CanBeSetAndRetrieved(string abbr)
```
### Timezone_CanBeSetAndRetrieved(string)

```
[Theory]
[InlineData(new object[] { "America/New_York" })]
[InlineData(new object[] { "Europe/London" })]
[InlineData(new object[] { "Asia/Tokyo" })]
public void Timezone_CanBeSetAndRetrieved(string timezone)
```
### WeatherForecast_MultipleInstances_AreIndependent()

```
[Fact]
public void WeatherForecast_MultipleInstances_AreIndependent()
```
### WeatherForecast_WithCompleteData_CreatesValidInstance()

```
[Fact]
public void WeatherForecast_WithCompleteData_CreatesValidInstance()
```

### WeatherForecast_WithRealWorldScenario_Tokyo()

```
[Fact]
public void WeatherForecast_WithRealWorldScenario_Tokyo()
```

## Classes

HttpQueryBuilderTests
Unit tests for the HttpQueryBuilder class.

# Namespace TheWeatherNode.Core.Tests.Web


Namespace:TheWeatherNode.Core.Tests.Web

Assembly:TheWeatherNode.Core.Tests.dll

Unit tests for the HttpQueryBuilder class.

**Inheritance**

object HttpQueryBuilderTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Methods

# Class HttpQueryBuilderTests

```
public class HttpQueryBuilderTests
```
##### 

## BuildQueryString_ComplexRealWorldScenario_ReturnsValidQuer

## yString()

```
[Fact]
public void BuildQueryString_ComplexRealWorldScenario_ReturnsValidQueryString()
```
## BuildQueryString_WithDictionaryParameters_MaintainsOrder()

```
[Fact]
public void BuildQueryString_WithDictionaryParameters_MaintainsOrder()
```
## BuildQueryString_WithEmptyDictionary_ReturnsEmptyString()

```
[Fact]
public void BuildQueryString_WithEmptyDictionary_ReturnsEmptyString()
```

### BuildQueryString_WithEmptyListParameter_ReturnsEmptyValue()

```
[Fact]
public void BuildQueryString_WithEmptyListParameter_ReturnsEmptyValue()
```
### BuildQueryString_WithEmptyStringValue_ReturnsEmptyValue()

```
[Fact]
public void BuildQueryString_WithEmptyStringValue_ReturnsEmptyValue()
```
### BuildQueryString_WithGeocodingApiParameters_ReturnsCorrect

### Format()

```
[Fact]
public void BuildQueryString_WithGeocodingApiParameters_ReturnsCorrectFormat()
```
### BuildQueryString_WithListItemsContainingSpecialCharacters_Ret

### urnsValueAsIs()

```
[Fact]
public void BuildQueryString_WithListItemsContainingSpecialCharacters_ReturnsValueAsIs()
```
### BuildQueryString_WithMixedScalarAndListParameters_ReturnsC

### orrectFormat()

```
[Fact]
public void BuildQueryString_WithMixedScalarAndListParameters_ReturnsCorrectFormat()
```
### BuildQueryString_WithMixedTypeParameters_ReturnsCorrectFor

### mat()


```
[Fact]
public void BuildQueryString_WithMixedTypeParameters_ReturnsCorrectFormat()
```
### BuildQueryString_WithMultipleListParameters_ReturnsCorrectFo

### rmat()

```
[Fact]
public void BuildQueryString_WithMultipleListParameters_ReturnsCorrectFormat()
```
### BuildQueryString_WithMultipleStringParameters_ReturnsCorrect

### Format()

```
[Fact]
public void BuildQueryString_WithMultipleStringParameters_ReturnsCorrectFormat()
```
### BuildQueryString_WithNegativeValue_ReturnsNegative()

```
[Fact]
public void BuildQueryString_WithNegativeValue_ReturnsNegative()
```
### BuildQueryString_WithSingleBooleanParameter_ReturnsCorrectF

### ormat()

```
[Fact]
public void BuildQueryString_WithSingleBooleanParameter_ReturnsCorrectFormat()
```
### BuildQueryString_WithSingleDoubleParameter_ReturnsCorrectF

### ormat()


```
[Fact]
public void BuildQueryString_WithSingleDoubleParameter_ReturnsCorrectFormat()
```
### BuildQueryString_WithSingleIntegerParameter_ReturnsCorrectF

### ormat()

```
[Fact]
public void BuildQueryString_WithSingleIntegerParameter_ReturnsCorrectFormat()
```
### BuildQueryString_WithSingleItemListParameter_ReturnsSingleVa

### lue()

```
[Fact]
public void BuildQueryString_WithSingleItemListParameter_ReturnsSingleValue()
```
### BuildQueryString_WithSingleListParameter_ReturnsCommaSepar

### atedValues()

```
[Fact]
public void BuildQueryString_WithSingleListParameter_ReturnsCommaSeparatedValues()
```
### BuildQueryString_WithSingleStringParameter_ReturnsCorrectFor

### mat()

```
[Fact]
public void BuildQueryString_WithSingleStringParameter_ReturnsCorrectFormat()
```
### BuildQueryString_WithSpecialCharacters_ReturnsValueAsIs(strin

### g)


#### Parameters

value string

```
[Theory]
[InlineData(new object[] { "value with spaces" })]
[InlineData(new object[] { "value/with/slashes" })]
[InlineData(new object[] { "value-with-dashes" })]
[InlineData(new object[] { "value_with_underscores" })]
public void BuildQueryString_WithSpecialCharacters_ReturnsValueAsIs(string value)
```
### BuildQueryString_WithVeryLargeDictionary_ReturnsAllParameter

### s()

```
[Fact]
public void BuildQueryString_WithVeryLargeDictionary_ReturnsAllParameters()
```
### BuildQueryString_WithWeatherApiParameters_ReturnsCorrectFo

### rmat()

```
[Fact]
public void BuildQueryString_WithWeatherApiParameters_ReturnsCorrectFormat()
```
### BuildQueryString_WithZeroValue_ReturnsZero()

```
[Fact]
public void BuildQueryString_WithZeroValue_ReturnsZero()
```

## Classes

HttpQueryBuilder

# Namespace TheWeatherNode.Core.Web


Namespace:TheWeatherNode.Core.Web

Assembly:TheWeatherNode.Core.dll

**Inheritance**

object HttpQueryBuilder

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Methods

## Parameters

parameters Dictionary<string, object>

## Returns

string

# Class HttpQueryBuilder

```
public static class HttpQueryBuilder
```
##### 

## BuildQueryString(Dictionary<string, object>)

```
public static string BuildQueryString(Dictionary<string, object> parameters)
```

## Classes

WeatherForecast

# Namespace TheWeatherNode.Server


Namespace:TheWeatherNode.Server

Assembly:TheWeatherNode.Server.dll

**Inheritance**

object WeatherForecast

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Properties

## Property Value

DateOnly

## Property Value

string

# Class WeatherForecast

```
public class WeatherForecast
```
##### 

## Date

```
public DateOnly Date { get; set; }
```
## Summary

```
public string? Summary { get; set; }
```
## TemperatureC


#### Property Value

int

#### Property Value

int

```
public int TemperatureC { get; set; }
```
### TemperatureF

```
public int TemperatureF { get; }
```

## Classes

LocationController

WeatherForecastController
Provides REST API endpoints for retrieving weather forecast data.

# Namespace TheWeatherNode.Server.

# Controllers


Namespace:TheWeatherNode.Server.Controllers

Assembly:TheWeatherNode.Server.dll

**Inheritance**
object ControllerBase LocationController

**Inherited Members**
ControllerBase.StatusCode(int) , ControllerBase.StatusCode(int, object) ,
ControllerBase.Content(string) , ControllerBase.Content(string, string) ,
ControllerBase.Content(string, string, Encoding) ,
ControllerBase.Content(string, MediaTypeHeaderValue) , ControllerBase.NoContent() ,
ControllerBase.Ok() , ControllerBase.Ok(object) , ControllerBase.Redirect(string) ,
ControllerBase.RedirectPermanent(string) , ControllerBase.RedirectPreserveMethod(string) ,
ControllerBase.RedirectPermanentPreserveMethod(string) , ControllerBase.LocalRedirect(string) ,
ControllerBase.LocalRedirectPermanent(string) , ControllerBase.LocalRedirectPreserveMethod(string) ,
ControllerBase.LocalRedirectPermanentPreserveMethod(string) , ControllerBase.RedirectToAction() ,
ControllerBase.RedirectToAction(string) , ControllerBase.RedirectToAction(string, object) ,
ControllerBase.RedirectToAction(string, string) ,
ControllerBase.RedirectToAction(string, string, object) ,
ControllerBase.RedirectToAction(string, string, string) ,
ControllerBase.RedirectToAction(string, string, object, string) ,
ControllerBase.RedirectToActionPreserveMethod(string, string, object, string) ,
ControllerBase.RedirectToActionPermanent(string) ,
ControllerBase.RedirectToActionPermanent(string, object) ,
ControllerBase.RedirectToActionPermanent(string, string) ,
ControllerBase.RedirectToActionPermanent(string, string, string) ,
ControllerBase.RedirectToActionPermanent(string, string, object) ,
ControllerBase.RedirectToActionPermanent(string, string, object, string) ,
ControllerBase.RedirectToActionPermanentPreserveMethod(string, string, object, string) ,
ControllerBase.RedirectToRoute(string) , ControllerBase.RedirectToRoute(object) ,
ControllerBase.RedirectToRoute(string, object) , ControllerBase.RedirectToRoute(string, string) ,
ControllerBase.RedirectToRoute(string, object, string) ,
ControllerBase.RedirectToRoutePreserveMethod(string, object, string) ,

# Class LocationController

```
[Route("location")]
[ApiController]
public class LocationController : ControllerBase
```
#####  


ControllerBase.RedirectToRoutePermanent(string) ,
ControllerBase.RedirectToRoutePermanent(object) ,
ControllerBase.RedirectToRoutePermanent(string, object) ,
ControllerBase.RedirectToRoutePermanent(string, string) ,
ControllerBase.RedirectToRoutePermanent(string, object, string) ,
ControllerBase.RedirectToRoutePermanentPreserveMethod(string, object, string) ,
ControllerBase.RedirectToPage(string) , ControllerBase.RedirectToPage(string, object) ,
ControllerBase.RedirectToPage(string, string) , ControllerBase.RedirectToPage(string, string, object) ,
ControllerBase.RedirectToPage(string, string, string) ,
ControllerBase.RedirectToPage(string, string, object, string) ,
ControllerBase.RedirectToPagePermanent(string) ,
ControllerBase.RedirectToPagePermanent(string, object) ,
ControllerBase.RedirectToPagePermanent(string, string) ,
ControllerBase.RedirectToPagePermanent(string, string, string) ,
ControllerBase.RedirectToPagePermanent(string, string, object, string) ,
ControllerBase.RedirectToPagePreserveMethod(string, string, object, string) ,
ControllerBase.RedirectToPagePermanentPreserveMethod(string, string, object, string) ,
ControllerBase.File(byte[], string) , ControllerBase.File(byte[], string, bool) ,
ControllerBase.File(byte[], string, string) , ControllerBase.File(byte[], string, string, bool) ,
ControllerBase.File(byte[], string, DateTimeOffset?, EntityTagHeaderValue) ,
ControllerBase.File(byte[], string, DateTimeOffset?, EntityTagHeaderValue, bool) ,
ControllerBase.File(byte[], string, string, DateTimeOffset?, EntityTagHeaderValue) ,
ControllerBase.File(byte[], string, string, DateTimeOffset?, EntityTagHeaderValue, bool) ,
ControllerBase.File(Stream, string) , ControllerBase.File(Stream, string, bool) ,
ControllerBase.File(Stream, string, string) , ControllerBase.File(Stream, string, string, bool) ,
ControllerBase.File(Stream, string, DateTimeOffset?, EntityTagHeaderValue) ,
ControllerBase.File(Stream, string, DateTimeOffset?, EntityTagHeaderValue, bool) ,
ControllerBase.File(Stream, string, string, DateTimeOffset?, EntityTagHeaderValue) ,
ControllerBase.File(Stream, string, string, DateTimeOffset?, EntityTagHeaderValue, bool) ,
ControllerBase.File(string, string) , ControllerBase.File(string, string, bool) ,
ControllerBase.File(string, string, string) , ControllerBase.File(string, string, string, bool) ,
ControllerBase.File(string, string, DateTimeOffset?, EntityTagHeaderValue) ,
ControllerBase.File(string, string, DateTimeOffset?, EntityTagHeaderValue, bool) ,
ControllerBase.File(string, string, string, DateTimeOffset?, EntityTagHeaderValue) ,
ControllerBase.File(string, string, string, DateTimeOffset?, EntityTagHeaderValue, bool) ,
ControllerBase.PhysicalFile(string, string) , ControllerBase.PhysicalFile(string, string, bool) ,
ControllerBase.PhysicalFile(string, string, string) ,
ControllerBase.PhysicalFile(string, string, string, bool) ,
ControllerBase.PhysicalFile(string, string, DateTimeOffset?, EntityTagHeaderValue) ,
ControllerBase.PhysicalFile(string, string, DateTimeOffset?, EntityTagHeaderValue, bool) ,


ControllerBase.PhysicalFile(string, string, string, DateTimeOffset?, EntityTagHeaderValue) ,
ControllerBase.PhysicalFile(string, string, string, DateTimeOffset?, EntityTagHeaderValue, bool) ,
ControllerBase.Unauthorized() , ControllerBase.Unauthorized(object) , ControllerBase.NotFound() ,
ControllerBase.NotFound(object) , ControllerBase.BadRequest() ,
ControllerBase.BadRequest(object) , ControllerBase.BadRequest(ModelStateDictionary) ,
ControllerBase.UnprocessableEntity() , ControllerBase.UnprocessableEntity(object) ,
ControllerBase.UnprocessableEntity(ModelStateDictionary) , ControllerBase.Conflict() ,
ControllerBase.Conflict(object) , ControllerBase.Conflict(ModelStateDictionary) ,
ControllerBase.Problem(string, string, int?, string, string) ,
ControllerBase.ValidationProblem(ValidationProblemDetails) ,
ControllerBase.ValidationProblem(ModelStateDictionary) , ControllerBase.ValidationProblem() ,
ControllerBase.ValidationProblem(string, string, int?, string, string, ModelStateDictionary) ,
ControllerBase.Created() , ControllerBase.Created(string, object) ,
ControllerBase.Created(Uri, object) , ControllerBase.CreatedAtAction(string, object) ,
ControllerBase.CreatedAtAction(string, object, object) ,
ControllerBase.CreatedAtAction(string, string, object, object) ,
ControllerBase.CreatedAtRoute(string, object) , ControllerBase.CreatedAtRoute(object, object) ,
ControllerBase.CreatedAtRoute(string, object, object) , ControllerBase.Accepted() ,
ControllerBase.Accepted(object) , ControllerBase.Accepted(Uri) , ControllerBase.Accepted(string) ,
ControllerBase.Accepted(string, object) , ControllerBase.Accepted(Uri, object) ,
ControllerBase.AcceptedAtAction(string) , ControllerBase.AcceptedAtAction(string, string) ,
ControllerBase.AcceptedAtAction(string, object) ,
ControllerBase.AcceptedAtAction(string, string, object) ,
ControllerBase.AcceptedAtAction(string, object, object) ,
ControllerBase.AcceptedAtAction(string, string, object, object) ,
ControllerBase.AcceptedAtRoute(object) , ControllerBase.AcceptedAtRoute(string) ,
ControllerBase.AcceptedAtRoute(string, object) , ControllerBase.AcceptedAtRoute(object, object) ,
ControllerBase.AcceptedAtRoute(string, object, object) , ControllerBase.Challenge() ,
ControllerBase.Challenge(params string[]) , ControllerBase.Challenge(AuthenticationProperties) ,
ControllerBase.Challenge(AuthenticationProperties, params string[]) , ControllerBase.Forbid() ,
ControllerBase.Forbid(params string[]) , ControllerBase.Forbid(AuthenticationProperties) ,
ControllerBase.Forbid(AuthenticationProperties, params string[]) ,
ControllerBase.SignIn(ClaimsPrincipal) , ControllerBase.SignIn(ClaimsPrincipal, string) ,
ControllerBase.SignIn(ClaimsPrincipal, AuthenticationProperties) ,
ControllerBase.SignIn(ClaimsPrincipal, AuthenticationProperties, string) , ControllerBase.SignOut() ,
ControllerBase.SignOut(AuthenticationProperties) , ControllerBase.SignOut(params string[]) ,
ControllerBase.SignOut(AuthenticationProperties, params string[]) ,
ControllerBase.TryUpdateModelAsync<TModel>(TModel) ,
ControllerBase.TryUpdateModelAsync<TModel>(TModel, string) ,
ControllerBase.TryUpdateModelAsync<TModel>(TModel, string, IValueProvider) ,


ControllerBase.TryUpdateModelAsync<TModel>(TModel, string, params Expression<Func<TModel,
object>>[]) ,
ControllerBase.TryUpdateModelAsync<TModel>(TModel, string, Func<ModelMetadata, bool>) ,
ControllerBase.TryUpdateModelAsync<TModel>(TModel, string, IValueProvider, params
Expression<Func<TModel, object>>[]) ,
ControllerBase.TryUpdateModelAsync<TModel>(TModel, string, IValueProvider, Func<ModelMetadata,
bool>) ,
ControllerBase.TryUpdateModelAsync(object, Type, string) ,
ControllerBase.TryUpdateModelAsync(object, Type, string, IValueProvider, Func<ModelMetadata, bool>)
 ,
ControllerBase.TryValidateModel(object) , ControllerBase.TryValidateModel(object, string) ,
ControllerBase.HttpContext , ControllerBase.Request , ControllerBase.Response ,
ControllerBase.RouteData , ControllerBase.ModelState , ControllerBase.ControllerContext ,
ControllerBase.MetadataProvider , ControllerBase.ModelBinderFactory , ControllerBase.Url ,
ControllerBase.ObjectValidator , ControllerBase.ProblemDetailsFactory , ControllerBase.User ,
ControllerBase.Empty , object.Equals(object) , object.Equals(object, object) ,
object.GetHashCode() , object.GetType() , object.MemberwiseClone() ,
object.ReferenceEquals(object, object) , object.ToString()

## Constructors

#### Parameters

geocodingService IGeocodingService

logger ILogger<LocationController>

## Methods

### LocationController(IGeocodingService,

### ILogger<LocationController>)

```
public LocationController(IGeocodingService geocodingService, ILogger<LocationController>
logger)
```
### SearchLocations(string)


#### Parameters

query string

#### Returns

Task<IActionResult>

```
[HttpGet("search")]
public Task<IActionResult> SearchLocations(string query)
```

Namespace:TheWeatherNode.Server.Controllers

Assembly:TheWeatherNode.Server.dll

Provides REST API endpoints for retrieving weather forecast data.

**Inheritance**
object ControllerBase WeatherForecastController

**Inherited Members**
ControllerBase.StatusCode(int) , ControllerBase.StatusCode(int, object) ,
ControllerBase.Content(string) , ControllerBase.Content(string, string) ,
ControllerBase.Content(string, string, Encoding) ,
ControllerBase.Content(string, MediaTypeHeaderValue) , ControllerBase.NoContent() ,
ControllerBase.Ok() , ControllerBase.Ok(object) , ControllerBase.Redirect(string) ,
ControllerBase.RedirectPermanent(string) , ControllerBase.RedirectPreserveMethod(string) ,
ControllerBase.RedirectPermanentPreserveMethod(string) , ControllerBase.LocalRedirect(string) ,
ControllerBase.LocalRedirectPermanent(string) , ControllerBase.LocalRedirectPreserveMethod(string) ,
ControllerBase.LocalRedirectPermanentPreserveMethod(string) , ControllerBase.RedirectToAction() ,
ControllerBase.RedirectToAction(string) , ControllerBase.RedirectToAction(string, object) ,
ControllerBase.RedirectToAction(string, string) ,
ControllerBase.RedirectToAction(string, string, object) ,
ControllerBase.RedirectToAction(string, string, string) ,
ControllerBase.RedirectToAction(string, string, object, string) ,
ControllerBase.RedirectToActionPreserveMethod(string, string, object, string) ,
ControllerBase.RedirectToActionPermanent(string) ,
ControllerBase.RedirectToActionPermanent(string, object) ,
ControllerBase.RedirectToActionPermanent(string, string) ,
ControllerBase.RedirectToActionPermanent(string, string, string) ,
ControllerBase.RedirectToActionPermanent(string, string, object) ,
ControllerBase.RedirectToActionPermanent(string, string, object, string) ,
ControllerBase.RedirectToActionPermanentPreserveMethod(string, string, object, string) ,
ControllerBase.RedirectToRoute(string) , ControllerBase.RedirectToRoute(object) ,
ControllerBase.RedirectToRoute(string, object) , ControllerBase.RedirectToRoute(string, string) ,

# Class WeatherForecastController

```
[ApiController]
[Route("weather")]
public class WeatherForecastController : ControllerBase
```
#####  


ControllerBase.RedirectToRoute(string, object, string) ,
ControllerBase.RedirectToRoutePreserveMethod(string, object, string) ,
ControllerBase.RedirectToRoutePermanent(string) ,
ControllerBase.RedirectToRoutePermanent(object) ,
ControllerBase.RedirectToRoutePermanent(string, object) ,
ControllerBase.RedirectToRoutePermanent(string, string) ,
ControllerBase.RedirectToRoutePermanent(string, object, string) ,
ControllerBase.RedirectToRoutePermanentPreserveMethod(string, object, string) ,
ControllerBase.RedirectToPage(string) , ControllerBase.RedirectToPage(string, object) ,
ControllerBase.RedirectToPage(string, string) , ControllerBase.RedirectToPage(string, string, object) ,
ControllerBase.RedirectToPage(string, string, string) ,
ControllerBase.RedirectToPage(string, string, object, string) ,
ControllerBase.RedirectToPagePermanent(string) ,
ControllerBase.RedirectToPagePermanent(string, object) ,
ControllerBase.RedirectToPagePermanent(string, string) ,
ControllerBase.RedirectToPagePermanent(string, string, string) ,
ControllerBase.RedirectToPagePermanent(string, string, object, string) ,
ControllerBase.RedirectToPagePreserveMethod(string, string, object, string) ,
ControllerBase.RedirectToPagePermanentPreserveMethod(string, string, object, string) ,
ControllerBase.File(byte[], string) , ControllerBase.File(byte[], string, bool) ,
ControllerBase.File(byte[], string, string) , ControllerBase.File(byte[], string, string, bool) ,
ControllerBase.File(byte[], string, DateTimeOffset?, EntityTagHeaderValue) ,
ControllerBase.File(byte[], string, DateTimeOffset?, EntityTagHeaderValue, bool) ,
ControllerBase.File(byte[], string, string, DateTimeOffset?, EntityTagHeaderValue) ,
ControllerBase.File(byte[], string, string, DateTimeOffset?, EntityTagHeaderValue, bool) ,
ControllerBase.File(Stream, string) , ControllerBase.File(Stream, string, bool) ,
ControllerBase.File(Stream, string, string) , ControllerBase.File(Stream, string, string, bool) ,
ControllerBase.File(Stream, string, DateTimeOffset?, EntityTagHeaderValue) ,
ControllerBase.File(Stream, string, DateTimeOffset?, EntityTagHeaderValue, bool) ,
ControllerBase.File(Stream, string, string, DateTimeOffset?, EntityTagHeaderValue) ,
ControllerBase.File(Stream, string, string, DateTimeOffset?, EntityTagHeaderValue, bool) ,
ControllerBase.File(string, string) , ControllerBase.File(string, string, bool) ,
ControllerBase.File(string, string, string) , ControllerBase.File(string, string, string, bool) ,
ControllerBase.File(string, string, DateTimeOffset?, EntityTagHeaderValue) ,
ControllerBase.File(string, string, DateTimeOffset?, EntityTagHeaderValue, bool) ,
ControllerBase.File(string, string, string, DateTimeOffset?, EntityTagHeaderValue) ,
ControllerBase.File(string, string, string, DateTimeOffset?, EntityTagHeaderValue, bool) ,
ControllerBase.PhysicalFile(string, string) , ControllerBase.PhysicalFile(string, string, bool) ,
ControllerBase.PhysicalFile(string, string, string) ,
ControllerBase.PhysicalFile(string, string, string, bool) ,


ControllerBase.PhysicalFile(string, string, DateTimeOffset?, EntityTagHeaderValue) ,
ControllerBase.PhysicalFile(string, string, DateTimeOffset?, EntityTagHeaderValue, bool) ,
ControllerBase.PhysicalFile(string, string, string, DateTimeOffset?, EntityTagHeaderValue) ,
ControllerBase.PhysicalFile(string, string, string, DateTimeOffset?, EntityTagHeaderValue, bool) ,
ControllerBase.Unauthorized() , ControllerBase.Unauthorized(object) , ControllerBase.NotFound() ,
ControllerBase.NotFound(object) , ControllerBase.BadRequest() ,
ControllerBase.BadRequest(object) , ControllerBase.BadRequest(ModelStateDictionary) ,
ControllerBase.UnprocessableEntity() , ControllerBase.UnprocessableEntity(object) ,
ControllerBase.UnprocessableEntity(ModelStateDictionary) , ControllerBase.Conflict() ,
ControllerBase.Conflict(object) , ControllerBase.Conflict(ModelStateDictionary) ,
ControllerBase.Problem(string, string, int?, string, string) ,
ControllerBase.ValidationProblem(ValidationProblemDetails) ,
ControllerBase.ValidationProblem(ModelStateDictionary) , ControllerBase.ValidationProblem() ,
ControllerBase.ValidationProblem(string, string, int?, string, string, ModelStateDictionary) ,
ControllerBase.Created() , ControllerBase.Created(string, object) ,
ControllerBase.Created(Uri, object) , ControllerBase.CreatedAtAction(string, object) ,
ControllerBase.CreatedAtAction(string, object, object) ,
ControllerBase.CreatedAtAction(string, string, object, object) ,
ControllerBase.CreatedAtRoute(string, object) , ControllerBase.CreatedAtRoute(object, object) ,
ControllerBase.CreatedAtRoute(string, object, object) , ControllerBase.Accepted() ,
ControllerBase.Accepted(object) , ControllerBase.Accepted(Uri) , ControllerBase.Accepted(string) ,
ControllerBase.Accepted(string, object) , ControllerBase.Accepted(Uri, object) ,
ControllerBase.AcceptedAtAction(string) , ControllerBase.AcceptedAtAction(string, string) ,
ControllerBase.AcceptedAtAction(string, object) ,
ControllerBase.AcceptedAtAction(string, string, object) ,
ControllerBase.AcceptedAtAction(string, object, object) ,
ControllerBase.AcceptedAtAction(string, string, object, object) ,
ControllerBase.AcceptedAtRoute(object) , ControllerBase.AcceptedAtRoute(string) ,
ControllerBase.AcceptedAtRoute(string, object) , ControllerBase.AcceptedAtRoute(object, object) ,
ControllerBase.AcceptedAtRoute(string, object, object) , ControllerBase.Challenge() ,
ControllerBase.Challenge(params string[]) , ControllerBase.Challenge(AuthenticationProperties) ,
ControllerBase.Challenge(AuthenticationProperties, params string[]) , ControllerBase.Forbid() ,
ControllerBase.Forbid(params string[]) , ControllerBase.Forbid(AuthenticationProperties) ,
ControllerBase.Forbid(AuthenticationProperties, params string[]) ,
ControllerBase.SignIn(ClaimsPrincipal) , ControllerBase.SignIn(ClaimsPrincipal, string) ,
ControllerBase.SignIn(ClaimsPrincipal, AuthenticationProperties) ,
ControllerBase.SignIn(ClaimsPrincipal, AuthenticationProperties, string) , ControllerBase.SignOut() ,
ControllerBase.SignOut(AuthenticationProperties) , ControllerBase.SignOut(params string[]) ,
ControllerBase.SignOut(AuthenticationProperties, params string[]) ,
ControllerBase.TryUpdateModelAsync<TModel>(TModel) ,


ControllerBase.TryUpdateModelAsync<TModel>(TModel, string) ,
ControllerBase.TryUpdateModelAsync<TModel>(TModel, string, IValueProvider) ,
ControllerBase.TryUpdateModelAsync<TModel>(TModel, string, params Expression<Func<TModel,
object>>[]) ,
ControllerBase.TryUpdateModelAsync<TModel>(TModel, string, Func<ModelMetadata, bool>) ,
ControllerBase.TryUpdateModelAsync<TModel>(TModel, string, IValueProvider, params
Expression<Func<TModel, object>>[]) ,
ControllerBase.TryUpdateModelAsync<TModel>(TModel, string, IValueProvider, Func<ModelMetadata,
bool>) ,
ControllerBase.TryUpdateModelAsync(object, Type, string) ,
ControllerBase.TryUpdateModelAsync(object, Type, string, IValueProvider, Func<ModelMetadata, bool>)
 ,
ControllerBase.TryValidateModel(object) , ControllerBase.TryValidateModel(object, string) ,
ControllerBase.HttpContext , ControllerBase.Request , ControllerBase.Response ,
ControllerBase.RouteData , ControllerBase.ModelState , ControllerBase.ControllerContext ,
ControllerBase.MetadataProvider , ControllerBase.ModelBinderFactory , ControllerBase.Url ,
ControllerBase.ObjectValidator , ControllerBase.ProblemDetailsFactory , ControllerBase.User ,
ControllerBase.Empty , object.Equals(object) , object.Equals(object, object) ,
object.GetHashCode() , object.GetType() , object.MemberwiseClone() ,
object.ReferenceEquals(object, object) , object.ToString()

## Remarks

This controller exposes three weather forecast endpoints that communicate with the IWeatherService to
retrieve current weather conditions and forecast data.

All endpoints currently use hardcoded coordinates for a fixed location (40.3247°N, 74.3369°W). Future
enhancements should make these coordinates configurable via query parameters or route parameters.

The controller implements comprehensive error handling and logging for all weather service operations.

## Constructors

Initializes a new instance of the WeatherForecastController class.

### WeatherForecastController(IWeatherService,

### ILogger<WeatherForecastController>)

```
public WeatherForecastController(IWeatherService weatherService,
ILogger<WeatherForecastController> logger)
```

#### Parameters

weatherService IWeatherService

```
The weather service for retrieving forecast data.
```
logger ILogger<WeatherForecastController>

```
The logger for recording controller operations and errors.
```
#### Exceptions

ArgumentNullException

```
Thrown when weatherService or logger is null.
```
## Methods

Retrieves the current weather conditions for the configured location.

#### Parameters

latitude double

longitude double

temperatureUnit string

windSpeedUnit string

precipitationUnit string

#### Returns

Task<IActionResult>

### GetCurrentWeather(double, double, string, string, string)

```
[HttpGet("current")]
public Task<IActionResult> GetCurrentWeather(double latitude = 40.3025, double longitude =
74.3038, string temperatureUnit = "celsius", string windSpeedUnit = "kmh", string
precipitationUnit = "millimeters")
```

```
An IActionResult containing:
```
```
200 OK with a CurrentWeather object on success
500 Internal Server Error with an error message if an exception occurs
```
#### Remarks

This endpoint queries the weather service for real-time weather conditions including temperature,
humidity, wind, precipitation, visibility, UV index, and more.

Currently uses hardcoded coordinates (40.3247°N, 74.3369°W). Future improvements should make
location configurable via query parameters.

Retrieves daily weather forecasts for the configured location.

#### Parameters

latitude double

longitude double

temperatureUnit string

windSpeedUnit string

precipitationUnit string

#### Returns

Task<IActionResult>

```
An IActionResult containing:
```
```
200 OK with an enumerable collection of DailyForecast objects on success
500 Internal Server Error with an error message if an exception occurs
```
### GetDailyForecast(double, double, string, string, string)

```
[HttpGet("daily")]
public Task<IActionResult> GetDailyForecast(double latitude = 40.3025, double longitude =
74.3038, string temperatureUnit = "celsius", string windSpeedUnit = "kmh", string
precipitationUnit = "millimeters")
```

#### Remarks

This endpoint queries the weather service for daily weather summaries with maximum/minimum
temperatures, total precipitation, wind conditions, and other aggregated metrics. Returns a default of 7
days of forecast data.

Currently uses hardcoded coordinates (40.3247°N, 74.3369°W). Future improvements should make
location and number of days configurable via query parameters.

Retrieves hourly weather forecasts for the configured location.

#### Parameters

latitude double

longitude double

temperatureUnit string

windSpeedUnit string

precipitationUnit string

#### Returns

Task<IActionResult>

```
An IActionResult containing:
```
```
200 OK with an enumerable collection of HourlyForecast objects on success
500 Internal Server Error with an error message if an exception occurs
```
#### Remarks

This endpoint queries the weather service for detailed hour-by-hour weather predictions. Returns a
default of 7 days of hourly forecasts, which is approximately 168 data points.

### GetHourlyForecast(double, double, string, string, string)

```
[HttpGet("hourly")]
public Task<IActionResult> GetHourlyForecast(double latitude = 40.3025, double longitude =
74.3038, string temperatureUnit = "celsius", string windSpeedUnit = "kmh", string
precipitationUnit = "millimeters")
```

Currently uses hardcoded coordinates (40.3247°N, 74.3369°W). Future improvements should make
location and number of days configurable via query parameters.


## Classes

TheWeatherNodeModule

# Namespace TheWeatherNode.Server.IoC


Namespace:TheWeatherNode.Server.IoC

Assembly:TheWeatherNode.Server.dll

**Inheritance**

object Module TheWeatherNodeModule

**Implements**
IModule

**Inherited Members**
Module.Configure(IComponentRegistryBuilder) ,
Module.AttachToComponentRegistration(IComponentRegistryBuilder, IComponentRegistration) ,
Module.AttachToRegistrationSource(IComponentRegistryBuilder, IRegistrationSource) ,
Module.ThisAssembly , object.Equals(object) , object.Equals(object, object) , object.GetHashCode() ,
object.GetType() , object.MemberwiseClone() , object.ReferenceEquals(object, object) ,
object.ToString()

## Constructors

Initializes a new instance of the TheWeatherNodeModule class.

## Methods

Override to add registrations to the container.

# Class TheWeatherNodeModule

```
public class TheWeatherNodeModule : Module, IModule
```
#####  

## TheWeatherNodeModule()

```
public TheWeatherNodeModule()
```
## Load(ContainerBuilder)

```
protected override void Load(ContainerBuilder builder)
```

#### Parameters

builder ContainerBuilder

```
The builder through which components can be registered.
```
#### Remarks

Note that the ContainerBuilder parameter is unique to this module.


## Classes

LocationControllerTests

WeatherForecastControllerTests

# Namespace TheWeatherNode.Server.Tests.

# Controllers


Namespace:TheWeatherNode.Server.Tests.Controllers

Assembly:TheWeatherNode.Server.Tests.dll

**Inheritance**

object LocationControllerTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Constructors

## Methods

## Returns

Task

# Class LocationControllerTests

```
public class LocationControllerTests
```
##### 

## LocationControllerTests()

```
public LocationControllerTests()
```
## SearchLocations_WhenServiceThrowsException_ShouldLogError(

## )

```
[Fact]
public Task SearchLocations_WhenServiceThrowsException_ShouldLogError()
```

#### Returns

Task

#### Returns

Task

#### Returns

Task

### SearchLocations_WhenServiceThrowsException_ShouldReturnInt

### ernalServerError()

```
[Fact]
public Task SearchLocations_WhenServiceThrowsException_ShouldReturnInternalServerError()
```
### SearchLocations_WithEmptyQuery_ShouldReturnBadRequest()

```
[Fact]
public Task SearchLocations_WithEmptyQuery_ShouldReturnBadRequest()
```
### SearchLocations_WithEmptyResults_ShouldReturnOkWithEmpty

### List()

```
[Fact]
public Task SearchLocations_WithEmptyResults_ShouldReturnOkWithEmptyList()
```
### SearchLocations_WithNullQuery_ShouldReturnBadRequest()

```
[Fact]
public Task SearchLocations_WithNullQuery_ShouldReturnBadRequest()
```

#### Returns

Task

#### Returns

Task

#### Returns

Task

#### Returns

Task

### SearchLocations_WithValidQuery_ShouldCallGeocodingService()

```
[Fact]
public Task SearchLocations_WithValidQuery_ShouldCallGeocodingService()
```
### SearchLocations_WithValidQuery_ShouldReturnOkWithLocation

### s()

```
[Fact]
public Task SearchLocations_WithValidQuery_ShouldReturnOkWithLocations()
```
### SearchLocations_WithWhitespaceQuery_ShouldReturnBadReque

### st()

```
[Fact]
public Task SearchLocations_WithWhitespaceQuery_ShouldReturnBadRequest()
```

Namespace:TheWeatherNode.Server.Tests.Controllers

Assembly:TheWeatherNode.Server.Tests.dll

**Inheritance**

object WeatherForecastControllerTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Constructors

## Methods

## Returns

Task

# Class WeatherForecastControllerTests

```
public class WeatherForecastControllerTests
```
##### 

## WeatherForecastControllerTests()

```
public WeatherForecastControllerTests()
```
## GetCurrentWeather_WhenServiceThrowsException_ShouldLogEr

## ror()

```
[Fact]
public Task GetCurrentWeather_WhenServiceThrowsException_ShouldLogError()
```

#### Returns

Task

#### Returns

Task

#### Returns

Task

### GetCurrentWeather_WhenServiceThrowsException_ShouldRetur

### nInternalServerError()

```
[Fact]
public Task GetCurrentWeather_WhenServiceThrowsException_ShouldReturnInternalServerError()
```
### GetCurrentWeather_WithDefaultParameters_ShouldUseDefaults(

### )

```
[Fact]
public Task GetCurrentWeather_WithDefaultParameters_ShouldUseDefaults()
```
### GetCurrentWeather_WithValidParameters_ShouldReturnOkWith

### CurrentWeather()

```
[Fact]
public Task GetCurrentWeather_WithValidParameters_ShouldReturnOkWithCurrentWeather()
```
### GetDailyForecast_WhenServiceReturnsEmpty_ShouldReturnOkW

### ithEmptyList()


#### Returns

Task

#### Returns

Task

#### Returns

Task

#### Returns

```
[Fact]
public Task GetDailyForecast_WhenServiceReturnsEmpty_ShouldReturnOkWithEmptyList()
```
### GetDailyForecast_WhenServiceThrowsException_ShouldReturnIn

### ternalServerError()

```
[Fact]
public Task GetDailyForecast_WhenServiceThrowsException_ShouldReturnInternalServerError()
```
### GetDailyForecast_WithDefaultParameters_ShouldUseDefaults()

```
[Fact]
public Task GetDailyForecast_WithDefaultParameters_ShouldUseDefaults()
```
### GetDailyForecast_WithValidParameters_ShouldReturnOkWithDai

### lyForecasts()

```
[Fact]
public Task GetDailyForecast_WithValidParameters_ShouldReturnOkWithDailyForecasts()
```

Task

#### Returns

Task

#### Returns

Task

#### Returns

Task

### GetHourlyForecast_WhenServiceReturnsEmpty_ShouldReturnOk

### WithEmptyList()

```
[Fact]
public Task GetHourlyForecast_WhenServiceReturnsEmpty_ShouldReturnOkWithEmptyList()
```
### GetHourlyForecast_WhenServiceThrowsException_ShouldReturn

### InternalServerError()

```
[Fact]
public Task GetHourlyForecast_WhenServiceThrowsException_ShouldReturnInternalServerError()
```
### GetHourlyForecast_WithDefaultParameters_ShouldUseDefaults()

```
[Fact]
public Task GetHourlyForecast_WithDefaultParameters_ShouldUseDefaults()
```
### GetHourlyForecast_WithValidParameters_ShouldReturnOkWithH

### ourlyForecasts()


#### Returns

Task

```
[Fact]
public Task GetHourlyForecast_WithValidParameters_ShouldReturnOkWithHourlyForecasts()
```

## Classes

TheWeatherNodeModuleTests

# Namespace TheWeatherNode.Server.Tests.IoC


Namespace:TheWeatherNode.Server.Tests.IoC

Assembly:TheWeatherNode.Server.Tests.dll

**Inheritance**

object TheWeatherNodeModuleTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Methods

# Class TheWeatherNodeModuleTests

```
public class TheWeatherNodeModuleTests
```
##### 

## TheWeatherNodeModule_CanResolveMultipleLoggerInstances()

```
[Fact]
public void TheWeatherNodeModule_CanResolveMultipleLoggerInstances()
```
## TheWeatherNodeModule_GeocodingServiceShouldBeInstanceP

## erLifetimeScope()

```
[Fact]
public void TheWeatherNodeModule_GeocodingServiceShouldBeInstancePerLifetimeScope()
```
## TheWeatherNodeModule_ShouldRegisterGeocodingService()

```
[Fact]
public void TheWeatherNodeModule_ShouldRegisterGeocodingService()
```

### TheWeatherNodeModule_ShouldRegisterLoggerFactory()

```
[Fact]
public void TheWeatherNodeModule_ShouldRegisterLoggerFactory()
```
### TheWeatherNodeModule_ShouldRegisterOpenMeteoGeocodin

### gClient()

```
[Fact]
public void TheWeatherNodeModule_ShouldRegisterOpenMeteoGeocodingClient()
```
### TheWeatherNodeModule_ShouldRegisterOpenMeteoWeatherCl

### ient()

```
[Fact]
public void TheWeatherNodeModule_ShouldRegisterOpenMeteoWeatherClient()
```
### TheWeatherNodeModule_ShouldRegisterWeatherService()

```
[Fact]
public void TheWeatherNodeModule_ShouldRegisterWeatherService()
```
### TheWeatherNodeModule_ShouldResolveGeocodingService()

```
[Fact]
public void TheWeatherNodeModule_ShouldResolveGeocodingService()
```
### TheWeatherNodeModule_ShouldResolveOpenMeteoGeocoding

### Client()


```
[Fact]
public void TheWeatherNodeModule_ShouldResolveOpenMeteoGeocodingClient()
```
### TheWeatherNodeModule_ShouldResolveOpenMeteoWeatherCli

### ent()

```
[Fact]
public void TheWeatherNodeModule_ShouldResolveOpenMeteoWeatherClient()
```
### TheWeatherNodeModule_ShouldResolveWeatherService()

```
[Fact]
public void TheWeatherNodeModule_ShouldResolveWeatherService()
```
### TheWeatherNodeModule_WeatherServiceShouldBeInstancePerL

### ifetimeScope()

```
[Fact]
public void TheWeatherNodeModule_WeatherServiceShouldBeInstancePerLifetimeScope()
```

## Classes

OpenMeteoParameterLists

OpenMeteoRequestBuilder
Builds and configures request parameters for the Open-Meteo weather API.

# Namespace TheWeatherNode.WeatherService.

# OpenMeteo.Builders


Namespace:TheWeatherNode.WeatherService.OpenMeteo.Builders

Assembly:TheWeatherNode.WeatherService.OpenMeteo.dll

**Inheritance**

object OpenMeteoParameterLists

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Fields

## Field Value

List<string>

## Field Value

List<string>

# Class OpenMeteoParameterLists

```
public static class OpenMeteoParameterLists
```
##### 

## Current

```
public static readonly List<string> Current
```
## Daily

```
public static readonly List<string> Daily
```
## Hourly


#### Field Value

List<string>

```
public static readonly List<string> Hourly
```

Namespace:TheWeatherNode.WeatherService.OpenMeteo.Builders

Assembly:TheWeatherNode.WeatherService.OpenMeteo.dll

Builds and configures request parameters for the Open-Meteo weather API.

**Inheritance**

object OpenMeteoRequestBuilder

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Remarks

This static utility class constructs properly formatted query parameters for Open-Meteo API requests. It
handles unit conversions and parameter mappings, transforming domain enums into API-compatible
string values.

The builder maintains unit mappings as static dictionaries to ensure consistency across all API requests
and provides a centralized location for managing unit format standards expected by Open-Meteo.

## Fields

Gets or sets the mapping of temperature unit enums to their Open-Meteo API string representations.

## Field Value

IDictionary<TemperatureUnit, string>

## Remarks

# Class OpenMeteoRequestBuilder

```
public static class OpenMeteoRequestBuilder
```
##### 

## TemperatureMappings

```
public static IDictionary<TemperatureUnit, string> TemperatureMappings
```

Maps TemperatureUnit enum values to the string format expected by the Open-Meteo API. The Open-
Meteo API accepts lowercase temperature unit strings.

Mapping:

```
Celsius → "celsius"
Fahrenheit → "fahrenheit"
```
This mapping is used in all weather requests to specify the desired temperature unit for API responses.

## Methods

Builds a dictionary of query parameters for Open-Meteo weather forecast API requests.

#### Parameters

weatherRequest WeatherRequest

```
The weather request containing geographic coordinates and unit preferences. Required and cannot be
null.
```
includeCurrent bool

```
If true, adds current weather data parameters to the request. Default: false
```
includeHourly bool

```
If true, adds hourly forecast data parameters to the request. Default: false
```
includeDaily bool

```
If true, adds daily forecast data parameters to the request. Default: false
```
#### Returns

Dictionary<string, object>

### BuildForecastParameters(WeatherRequest, bool, bool, bool)

```
public static Dictionary<string, object> BuildForecastParameters(WeatherRequest
weatherRequest, bool includeCurrent = false, bool includeHourly = false, bool includeDaily
= false)
```

```
A dictionary of query parameters with string keys and object values. The dictionary always contains
geographic and unit parameters. It conditionally includes current, hourly, and/or daily parameters
based on the flags.
```
#### Examples

#### Remarks

This method constructs a parameter dictionary suitable for the Open-Meteo forecast endpoint. It
converts domain models (WeatherRequest) into API-compatible parameters, including unit conversions
and conditional parameter inclusion.

The resulting dictionary contains:

```
Geographic coordinates (latitude, longitude)
Unit preferences (temperature, wind speed, precipitation)
Optional forecast data sections (current, hourly, daily)
```
The dictionary is then passed to an HTTP client which converts it into a query string.

```
var weatherRequest = new WeatherRequest(40.7128, -74.0060, "celsius", "kmh", "mm");
var parameters = OpenMeteoRequestBuilder.BuildForecastParameters(
weatherRequest,
includeCurrent: true,
includeHourly: true,
includeDaily: false);
```
```
// Result:
// {
// "latitude": 40.7128,
// "longitude": -74.0060,
// "temperature_unit": "celsius",
// "wind_speed_unit": "kmh",
// "precipitation_unit": "mm",
// "current": [list of current weather variables],
// "hourly": [list of hourly weather variables]
// }
```

## Classes

OpenMeteoGeocodingClient

OpenMeteoWeatherClient

# Namespace TheWeatherNode.WeatherService.

# OpenMeteo.Clients


Namespace:TheWeatherNode.WeatherService.OpenMeteo.Clients

Assembly:TheWeatherNode.WeatherService.OpenMeteo.dll

**Inheritance**

object OpenMeteoGeocodingClient

**Implements**
IOpenMeteoGeocodingClient

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Constructors

## Parameters

httpClient HttpClient

settings OpenMeteoGeocodingClientSettings

## Methods

# Class OpenMeteoGeocodingClient

```
public class OpenMeteoGeocodingClient : IOpenMeteoGeocodingClient
```
##### 

## OpenMeteoGeocodingClient(HttpClient,

## OpenMeteoGeocodingClientSettings)

```
public OpenMeteoGeocodingClient(HttpClient httpClient, OpenMeteoGeocodingClientSettings
settings)
```
## GetLocationsAsync(string)

```
public Task<IList<OpenMeteoGeocodingDto>> GetLocationsAsync(string search)
```

#### Parameters

search string

#### Returns

Task<IList<OpenMeteoGeocodingDto>>


Namespace:TheWeatherNode.WeatherService.OpenMeteo.Clients

Assembly:TheWeatherNode.WeatherService.OpenMeteo.dll

**Inheritance**

object OpenMeteoWeatherClient

**Implements**
IOpenMeteoWeatherClient

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Constructors

## Parameters

httpClient HttpClient

settings OpenMeteoWeatherClientSettings

## Methods

# Class OpenMeteoWeatherClient

```
public class OpenMeteoWeatherClient : IOpenMeteoWeatherClient
```
##### 

## OpenMeteoWeatherClient(HttpClient,

## OpenMeteoWeatherClientSettings)

```
public OpenMeteoWeatherClient(HttpClient httpClient, OpenMeteoWeatherClientSettings
settings)
```
## GetForcastAsync<T>(Dictionary<string, object>)

```
public Task<T> GetForcastAsync<T>(Dictionary<string, object> parameters)
```

#### Parameters

parameters Dictionary<string, object>

#### Returns

Task<T>

#### Type Parameters

##### T


## Interfaces

IOpenMeteoGeocodingClient

IOpenMeteoWeatherClient

# Namespace TheWeatherNode.WeatherService.

# OpenMeteo.Clients.Interfaces


Namespace:TheWeatherNode.WeatherService.OpenMeteo.Clients.Interfaces

Assembly:TheWeatherNode.WeatherService.OpenMeteo.dll

## Methods

## Parameters

search string

## Returns

Task<IList<OpenMeteoGeocodingDto>>

# Interface IOpenMeteoGeocodingClient

```
public interface IOpenMeteoGeocodingClient
```
## GetLocationsAsync(string)

```
Task<IList<OpenMeteoGeocodingDto>> GetLocationsAsync(string search)
```

Namespace:TheWeatherNode.WeatherService.OpenMeteo.Clients.Interfaces

Assembly:TheWeatherNode.WeatherService.OpenMeteo.dll

## Methods

## Parameters

parameters Dictionary<string, object>

## Returns

Task<T>

## Type Parameters

##### T

# Interface IOpenMeteoWeatherClient

```
public interface IOpenMeteoWeatherClient
```
## GetForcastAsync<T>(Dictionary<string, object>)

```
Task<T> GetForcastAsync<T>(Dictionary<string, object> parameters)
```

## Classes

OpenMeteoClientSettingsBase
Base class for Open-Meteo API client configuration _settings.

OpenMeteoGeocodingClientSettings
Configuration _settings specific to the Open-Meteo Geocoding API client.

OpenMeteoWeatherClientSettings
Configuration _settings specific to the Open-Meteo weather API client.

# Namespace TheWeatherNode.WeatherService.

# OpenMeteo.Clients.Settings


Namespace:TheWeatherNode.WeatherService.OpenMeteo.Clients.Settings

Assembly:TheWeatherNode.WeatherService.OpenMeteo.dll

Base class for Open-Meteo API client configuration _settings.

**Inheritance**

object OpenMeteoClientSettingsBase

**Derived**
OpenMeteoGeocodingClientSettings, OpenMeteoWeatherClientSettings

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Remarks

This abstract base class provides common configuration properties shared across different Open-Meteo
API clients (weather forecasting, geocoding, etc.). It establishes a consistent contract for API client
initialization and HTTP communication setup.

Derived classes should extend this base class to add API-specific endpoint configurations and custom
_settings as needed.

Example derived classes:

```
OpenMeteoWeatherClientSettings: Configuration for weather forecast API
OpenMeteoGeocodingClientSettings: Configuration for geocoding API
```
## Properties

Gets or sets the base URL for the Open-Meteo API.

# Class OpenMeteoClientSettingsBase

```
public abstract class OpenMeteoClientSettingsBase
```
##### 

## BaseUrl

```
public string BaseUrl { get; set; }
```

#### Property Value

string

#### Examples

https://api.open-meteo.com/v1/

#### Remarks

The base URL should point to the root endpoint of the Open-Meteo API service. Different Open-Meteo
services may use different base URLs:

```
Weather API: https://api.open-meteo.com/v1/
Geocoding API: https://geocoding-api.open-meteo.com/v1/
```
This value is used as the foundation for all API requests made by derived client implementations.
Individual endpoint paths are appended to this base URL to form complete request URIs.

Gets or sets the HTTP request timeout duration in seconds.

#### Property Value

double

#### Examples

##### 30.0

#### Remarks

Specifies the maximum amount of time (in seconds) the HTTP client will wait for a response from the
Open-Meteo API before timing out and throwing an exception.

This setting applies to all HTTP requests made through derived client implementations.

Recommended values:

```
10-15 seconds: For typical weather forecast and geocoding requests
```
### Timeout

```
public double Timeout { get; set; }
```

```
20-30 seconds: For requests with large amounts of data or slow network connections
5 seconds or less: For critical operations requiring fast failure detection
```
A value of 0 or negative indicates infinite timeout (not recommended for production environments).


Namespace:TheWeatherNode.WeatherService.OpenMeteo.Clients.Settings

Assembly:TheWeatherNode.WeatherService.OpenMeteo.dll

Configuration _settings specific to the Open-Meteo Geocoding API client.

**Inheritance**

object OpenMeteoClientSettingsBase OpenMeteoGeocodingClientSettings

**Inherited Members**
OpenMeteoClientSettingsBase.BaseUrl , OpenMeteoClientSettingsBase.Timeout , object.Equals(object) ,
object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Remarks

This class extends OpenMeteoClientSettingsBase to provide geocoding-specific configuration
parameters. It encapsulates all runtime _settings required to initialize and configure the HTTP client for
geocoding operations.

These _settings are typically loaded from application configuration (appsettings.json or environment
variables) during dependency injection setup and passed to the geocoding client.

Example configuration in appsettings.json:

Inherits from OpenMeteoClientSettingsBase:

```
BaseUrl: Base URL for the geocoding API
Timeout: HTTP request timeout in seconds
```
# Class OpenMeteoGeocodingClientSettings

```
public class OpenMeteoGeocodingClientSettings : OpenMeteoClientSettingsBase
```
#####  

```
{
"OpenMeteoGeocodingClientSettings": {
"BaseUrl": "https://geocoding-api.open-meteo.com/v1/",
"Timeout": 15.0,
"SearchEndPoint": "search"
}
}
```

## Properties

Gets or sets the API endpoint path for geocoding search operations.

#### Property Value

string

#### Examples

search

#### Remarks

This endpoint path is appended to the BaseUrl to form the complete URL for geocoding search requests.

The endpoint supports both forward geocoding (searching by location name) and reverse geocoding
(searching by coordinates). The actual geocoding type is determined by the query parameters sent with
the request.

The default value "search" is the standard endpoint used by the Open-Meteo Geocoding API. This
setting allows for flexibility if the API structure changes in future versions or if alternative endpoint paths
need to be supported.

Complete URL example: BaseUrl: "https://geocoding-api.open-meteo.com/v1/" SearchEndPoint: "search"
Final URL: "https://geocoding-api.open-meteo.com/v1/search"

### SearchEndPoint

```
public string SearchEndPoint { get; set; }
```

Namespace:TheWeatherNode.WeatherService.OpenMeteo.Clients.Settings

Assembly:TheWeatherNode.WeatherService.OpenMeteo.dll

Configuration _settings specific to the Open-Meteo weather API client.

**Inheritance**

object OpenMeteoClientSettingsBase OpenMeteoWeatherClientSettings

**Inherited Members**
OpenMeteoClientSettingsBase.BaseUrl , OpenMeteoClientSettingsBase.Timeout , object.Equals(object) ,
object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Remarks

This class extends OpenMeteoClientSettingsBase to provide weather-specific configuration parameters.
It encapsulates all runtime _settings required to initialize and configure the HTTP client for weather
forecast operations.

These _settings are typically loaded from application configuration (appsettings.json or environment
variables) during dependency injection setup and passed to the weather client.

Example configuration in appsettings.json:

Inherits from OpenMeteoClientSettingsBase:

```
BaseUrl: Base URL for the weather API
Timeout: HTTP request timeout in seconds
```
# Class OpenMeteoWeatherClientSettings

```
public class OpenMeteoWeatherClientSettings : OpenMeteoClientSettingsBase
```
#####  

```
{
"OpenMeteoWeatherClientSettings": {
"BaseUrl": "https://api.open-meteo.com/v1/",
"Timeout": 30.0,
"ForcastEndPoint": "forecast"
}
}
```

## Properties

Gets or sets the API endpoint path for weather forecast operations.

#### Property Value

string

#### Examples

forecast

#### Remarks

This endpoint path is appended to the BaseUrl to form the complete URL for weather forecast requests.

The endpoint supports retrieving multiple types of weather data through query parameters:

```
Current weather conditions
Hourly weather forecasts
Daily weather forecasts
```
The actual data returned is determined by the query parameters (current, hourly, daily) sent with the
request, not by different endpoint paths.

The default value "forecast" is the standard endpoint used by the Open-Meteo Weather API. This setting
allows for flexibility if the API structure changes in future versions or if alternative endpoint paths need
to be supported.

Complete URL example: BaseUrl: "https://api.open-meteo.com/v1/" ForcastEndPoint: "forecast" Final
URL: "https://api.open-meteo.com/v1/forecast"

### ForcastEndPoint

```
public string ForcastEndPoint { get; set; }
```

## Classes

OpenMeteoCurrentDto
Represents current weather conditions from the Open-Meteo API.

OpenMeteoDailyDto
Represents daily weather forecast data from the Open-Meteo API.

OpenMeteoForecastResponseDto
Represents the root response object from the Open-Meteo API forecast endpoint.

OpenMeteoGeocodingDto
Represents a geolocation response from the Open-Meteo API.

OpenMeteoGeocodingResponseDto

OpenMeteoHourlyDto
Represents hourly weather forecast data from the Open-Meteo API.

# Namespace TheWeatherNode.WeatherService.

# OpenMeteo.DTOs


Namespace:TheWeatherNode.WeatherService.OpenMeteo.DTOs

Assembly:TheWeatherNode.WeatherService.OpenMeteo.dll

Represents current weather conditions from the Open-Meteo API.

**Inheritance**

object OpenMeteoCurrentDto

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Remarks

Contains real-time weather data including temperature, wind, precipitation, and atmospheric
measurements at the time of API request.

## Properties

Gets or sets the cloud cover as a percentage (0-100).

## Property Value

double

Gets or sets the dew point temperature in degrees Celsius.

# Class OpenMeteoCurrentDto

```
public class OpenMeteoCurrentDto
```
##### 

## CloudCover

```
[JsonPropertyName("cloud_cover")]
public double CloudCover { get; set; }
```
## DewPoint


#### Property Value

double

Gets or sets the apparent temperature (wind chill) in degrees Celsius.

#### Property Value

double

Gets or sets the relative humidity as a percentage (0-100).

#### Property Value

double

Gets or sets a value indicating whether it is currently daytime.

```
[JsonPropertyName("dewpoint_2m")]
public double DewPoint { get; set; }
```
### FeelsLike

```
[JsonPropertyName("apparent_temperature")]
public double FeelsLike { get; set; }
```
### Humidity

```
[JsonPropertyName("relative_humidity_2m")]
public double Humidity { get; set; }
```
### IsDay

```
[JsonPropertyName("is_day")]
public int IsDay { get; set; }
```

#### Property Value

int

#### Remarks

0 = Night, 1 = Day

Gets or sets the current precipitation amount in millimeters.

#### Property Value

double

Gets or sets the surface air pressure in hectopascals (hPa).

#### Property Value

double

Gets or sets the current air temperature in degrees Celsius.

### Precipitation

```
[JsonPropertyName("precipitation")]
public double Precipitation { get; set; }
```
### Pressure

```
[JsonPropertyName("surface_pressure")]
public double Pressure { get; set; }
```
### Temperature

```
[JsonPropertyName("temperature_2m")]
public double Temperature { get; set; }
```

#### Property Value

double

Gets or sets the ISO 8601 timestamp of the current weather observation.

#### Property Value

string

#### Examples

##### 2024-02-25T14:30:00Z

Gets or sets the UV index value.

#### Property Value

double

#### Remarks

0-2: Low, 3-5: Moderate, 6-7: High, 8-10: Very High, 11+: Extreme

Gets or sets the visibility distance in meters.

### Time

```
[JsonPropertyName("time")]
public string Time { get; set; }
```
### UvIndex

```
[JsonPropertyName("uv_index")]
public double UvIndex { get; set; }
```
### Visibility


#### Property Value

double

Gets or sets the WMO Weather Code representing current weather conditions.

#### Property Value

int

#### Remarks

See WMO 4677 standard for weather code definitions.

Gets or sets the wind direction at 10 meters height in degrees (0-359).

#### Property Value

double

#### Remarks

0° = North, 90° = East, 180° = South, 270° = West

```
[JsonPropertyName("visibility")]
public double Visibility { get; set; }
```
### WeatherCode

```
[JsonPropertyName("weather_code")]
public int WeatherCode { get; set; }
```
### WindDirection

```
[JsonPropertyName("wind_direction_10m")]
public double WindDirection { get; set; }
```

Gets or sets the wind gust speed at 10 meters height in km/h.

#### Property Value

double

Gets or sets the wind speed at 10 meters height in km/h.

#### Property Value

double

### WindGusts

```
[JsonPropertyName("wind_gusts_10m")]
public double WindGusts { get; set; }
```
### WindSpeed

```
[JsonPropertyName("wind_speed_10m")]
public double WindSpeed { get; set; }
```

Namespace:TheWeatherNode.WeatherService.OpenMeteo.DTOs

Assembly:TheWeatherNode.WeatherService.OpenMeteo.dll

Represents daily weather forecast data from the Open-Meteo API.

**Inheritance**

object OpenMeteoDailyDto

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Remarks

Contains arrays of aggregated weather measurements for each day, providing daily summaries of
temperature extremes, precipitation, wind conditions, and other meteorological parameters. Each
property contains data points aligned with corresponding time stamps.

Temperature, wind speed, and precipitation values are received in metric units (Celsius, km/h, mm) from
the API and can be converted to imperial units (Fahrenheit, mph, inches) as needed by the consuming
application.

## Properties

Gets or sets the daily maximum apparent temperature (feels-like) forecasts.

## Property Value

List<double>

# Class OpenMeteoDailyDto

```
public class OpenMeteoDailyDto
```
##### 

## FeelsLikeMax

```
[JsonPropertyName("apparent_temperature_max")]
public List<double> FeelsLikeMax { get; set; }
```

#### Remarks

Values are in degrees Celsius. Accounts for wind chill and humidity effects on how temperature feels to
humans. To convert to Fahrenheit: (°C × 9/5) + 32 = °F

Gets or sets the daily minimum apparent temperature (feels-like) forecasts.

#### Property Value

List<double>

#### Remarks

Values are in degrees Celsius. Accounts for wind chill and humidity effects on how temperature feels to
humans. To convert to Fahrenheit: (°C × 9/5) + 32 = °F

Gets or sets the daily maximum relative humidity forecasts.

#### Property Value

List<double>

#### Remarks

Values are percentages (0-100), representing the ratio of actual water vapor to maximum water vapor the
air can hold at that temperature.

### FeelsLikeMin

```
[JsonPropertyName("apparent_temperature_min")]
public List<double> FeelsLikeMin { get; set; }
```
### HumidityMax

```
[JsonPropertyName("relative_humidity_2m_max")]
public List<double> HumidityMax { get; set; }
```
### HumidityMin


Gets or sets the daily minimum relative humidity forecasts.

#### Property Value

List<double>

#### Remarks

Values are percentages (0-100), representing the ratio of actual water vapor to maximum water vapor the
air can hold at that temperature.

Gets or sets the daily maximum precipitation probability forecasts.

#### Property Value

List<double>

#### Remarks

Values are percentages (0-100), indicating the probability of precipitation occurring during the day.

Gets or sets the daily total precipitation amount forecasts.

#### Property Value

```
[JsonPropertyName("relative_humidity_2m_min")]
public List<double> HumidityMin { get; set; }
```
### PrecipitationProbabilityMax

```
[JsonPropertyName("precipitation_probability_max")]
public List<double> PrecipitationProbabilityMax { get; set; }
```
### PrecipitationSum

```
[JsonPropertyName("precipitation_sum")]
public List<double> PrecipitationSum { get; set; }
```

List<double>

#### Remarks

Values are in millimeters. To convert to inches: mm × 0.0393701 = inches Includes rain, snow, and other
forms of precipitation combined.

Gets or sets the daily mean atmospheric pressure at mean sea level.

#### Property Value

List<double>

#### Remarks

Values are in hectopascals (hPa). To convert to inches of mercury: hPa × 0.02953 = inHg To convert to
millibars: 1 hPa = 1 mb

Gets or sets the ISO 8601 timestamps for sunrise at the requested location for each day.

#### Property Value

List<string>

#### Examples

##### 2024-02-25T06:45:00Z

#### Remarks

### PressureMean

```
[JsonPropertyName("pressure_msl_mean")]
public List<double> PressureMean { get; set; }
```
### Sunrise

```
[JsonPropertyName("sunrise")]
public List<string> Sunrise { get; set; }
```

Timestamp is in UTC (Zulu time). Time should be converted to local timezone using the timezone
information from the parent forecast response.

Gets or sets the ISO 8601 timestamps for sunset at the requested location for each day.

#### Property Value

List<string>

#### Examples

##### 2024-02-25T18:30:00Z

#### Remarks

Timestamp is in UTC (Zulu time). Time should be converted to local timezone using the timezone
information from the parent forecast response.

Gets or sets the daily maximum temperature forecasts.

#### Property Value

List<double>

#### Remarks

Values are in degrees Celsius. To convert to Fahrenheit: (°C × 9/5) + 32 = °F

### Sunset

```
[JsonPropertyName("sunset")]
public List<string> Sunset { get; set; }
```
### TemperatureMax

```
[JsonPropertyName("temperature_2m_max")]
public List<double> TemperatureMax { get; set; }
```

Gets or sets the daily minimum temperature forecasts.

#### Property Value

List<double>

#### Remarks

Values are in degrees Celsius. To convert to Fahrenheit: (°C × 9/5) + 32 = °F

Gets or sets the list of date strings in YYYY-MM-DD format for each daily data point.

#### Property Value

List<string>

#### Remarks

Each element represents the date for the corresponding index in other properties.

Gets or sets the daily maximum UV index forecasts.

#### Property Value

### TemperatureMin

```
[JsonPropertyName("temperature_2m_min")]
public List<double> TemperatureMin { get; set; }
```
### Time

```
[JsonPropertyName("time")]
public List<string> Time { get; set; }
```
### UvIndexMax

```
[JsonPropertyName("uv_index_max")]
public List<double> UvIndexMax { get; set; }
```

List<double>

#### Remarks

UV Index scale: 0-2: Low exposure 3-5: Moderate exposure 6-7: High exposure 8-10: Very high exposure
11+: Extreme exposure

Gets or sets the daily WMO Weather Codes representing forecasted weather conditions.

#### Property Value

List<int>

#### Remarks

Values follow the WMO 4677 standard for weather code definitions. Represents the most severe weather
condition occurring during the day. See WMO Weather Code documentation for specific code meanings.

Gets or sets the daily dominant wind direction forecasts.

#### Property Value

List<double>

#### Remarks

Values are in degrees (0-359), representing the most frequent wind direction during the day. 0° = North,
45° = Northeast, 90° = East, 135° = Southeast, 180° = South, 225° = Southwest, 270° = West, 315° =
Northwest

### WeatherCode

```
[JsonPropertyName("weather_code")]
public List<int> WeatherCode { get; set; }
```
### WindDirectionDominant

```
[JsonPropertyName("wind_direction_10m_dominant")]
public List<double> WindDirectionDominant { get; set; }
```

Gets or sets the daily maximum wind gust speed forecasts at 10 meters height.

#### Property Value

List<double>

#### Remarks

Values are in kilometers per hour (km/h). Wind gusts are short-duration peak wind speeds. To convert to
miles per hour: km/h × 0.621371 = mph To convert to knots: km/h × 0.539957 = knots

Gets or sets the daily maximum wind speed forecasts at 10 meters height.

#### Property Value

List<double>

#### Remarks

Values are in kilometers per hour (km/h). To convert to miles per hour: km/h × 0.621371 = mph To
convert to knots: km/h × 0.539957 = knots

### WindGustsMax

```
[JsonPropertyName("wind_gusts_10m_max")]
public List<double> WindGustsMax { get; set; }
```
### WindSpeedMax

```
[JsonPropertyName("wind_speed_10m_max")]
public List<double> WindSpeedMax { get; set; }
```

Namespace:TheWeatherNode.WeatherService.OpenMeteo.DTOs

Assembly:TheWeatherNode.WeatherService.OpenMeteo.dll

Represents the root response object from the Open-Meteo API forecast endpoint.

**Inheritance**

object OpenMeteoForecastResponseDto

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Remarks

This DTO maps the JSON response from Open-Meteo's weather forecast API, containing geographic
information and weather data aggregated at current, hourly, and daily intervals.

## Properties

Gets or sets the current weather conditions.

## Property Value

OpenMeteoCurrentDto

Gets or sets the daily weather forecast data.

# Class OpenMeteoForecastResponseDto

```
public class OpenMeteoForecastResponseDto
```
##### 

## Current

```
[JsonPropertyName("current")]
public OpenMeteoCurrentDto? Current { get; set; }
```
## Daily


#### Property Value

OpenMeteoDailyDto

Gets or sets the hourly weather forecast data.

#### Property Value

OpenMeteoHourlyDto

Gets or sets the latitude coordinate of the requested location.

#### Property Value

double

Gets or sets the longitude coordinate of the requested location.

```
[JsonPropertyName("daily")]
public OpenMeteoDailyDto? Daily { get; set; }
```
### Hourly

```
[JsonPropertyName("hourly")]
public OpenMeteoHourlyDto? Hourly { get; set; }
```
### Latitude

```
[JsonPropertyName("latitude")]
public double Latitude { get; set; }
```
### Longitude

```
[JsonPropertyName("longitude")]
public double Longitude { get; set; }
```

#### Property Value

double

Gets or sets the IANA time zone identifier for the location.

#### Property Value

string

#### Examples

Europe/London, America/New_York

Gets or sets the abbreviated time zone name.

#### Property Value

string

#### Examples

##### GMT, EST, PST

### Timezone

```
[JsonPropertyName("timezone")]
public string Timezone { get; set; }
```
### TimezoneAbbreviation

```
[JsonPropertyName("timezone_abbreviation")]
public string TimezoneAbbreviation { get; set; }
```

Namespace:TheWeatherNode.WeatherService.OpenMeteo.DTOs

Assembly:TheWeatherNode.WeatherService.OpenMeteo.dll

Represents a geolocation response from the Open-Meteo API.

**Inheritance**

object OpenMeteoGeocodingDto

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Properties

Gets or sets the name of administrative division 1 (state/province).

## Property Value

string

Gets or sets the administrative division 1 identifier (state/province).

# Class OpenMeteoGeocodingDto

```
public class OpenMeteoGeocodingDto
```
##### 

## Admin1

```
[JsonPropertyName("admin1")]
public string? Admin1 { get; set; }
```
## Admin1Id

```
[JsonPropertyName("admin1_id")]
public int Admin1Id { get; set; }
```

#### Property Value

int

Gets or sets the name of administrative division 2 (county/district).

#### Property Value

string

Gets or sets the administrative division 2 identifier (county/district).

#### Property Value

int

Gets or sets the name of administrative division 3 (city/municipality).

#### Property Value

string

### Admin2

```
[JsonPropertyName("admin2")]
public string? Admin2 { get; set; }
```
### Admin2Id

```
[JsonPropertyName("admin2_id")]
public int Admin2Id { get; set; }
```
### Admin3

```
[JsonPropertyName("admin3")]
public string? Admin3 { get; set; }
```

Gets or sets the administrative division 3 identifier (city/municipality).

#### Property Value

int

Gets or sets the full country name.

#### Property Value

string

Gets or sets the ISO 3166-1 alpha-2 country code.

#### Property Value

string

Gets or sets the unique identifier for the country.

### Admin3Id

```
[JsonPropertyName("admin3_id")]
public int Admin3Id { get; set; }
```
### Country

```
[JsonPropertyName("country")]
public string? Country { get; set; }
```
### CountryCode

```
[JsonPropertyName("country_code")]
public string? CountryCode { get; set; }
```
### CountryId


#### Property Value

int

Gets or sets the elevation in meters above sea level.

#### Property Value

double

Gets or sets the feature code (e.g., PPLA2 for administrative division).

#### Property Value

string

Gets or sets the unique identifier for this location.

```
[JsonPropertyName("country_id")]
public int CountryId { get; set; }
```
### Elevation

```
[JsonPropertyName("elevation")]
public double Elevation { get; set; }
```
### FeatureCode

```
[JsonPropertyName("feature_code")]
public string? FeatureCode { get; set; }
```
### Id

```
[JsonPropertyName("id")]
public int Id { get; set; }
```

#### Property Value

int

Gets or sets the latitude coordinate in degrees.

#### Property Value

double

Gets or sets the longitude coordinate in degrees.

#### Property Value

double

Gets or sets the name of the location (city/town).

#### Property Value

string

### Latitude

```
[JsonPropertyName("latitude")]
public double Latitude { get; set; }
```
### Longitude

```
[JsonPropertyName("longitude")]
public double Longitude { get; set; }
```
### Name

```
[JsonPropertyName("name")]
public string? Name { get; set; }
```

Gets or sets the estimated population of this location.

#### Property Value

int

Gets or sets the list of postal codes associated with this location.

#### Property Value

List<string>

Gets or sets the IANA timezone identifier for this location.

#### Property Value

string

### Population

```
[JsonPropertyName("population")]
public int Population { get; set; }
```
### Postcodes

```
[JsonPropertyName("postcodes")]
public List<string>? Postcodes { get; set; }
```
### Timezone

```
[JsonPropertyName("timezone")]
public string? Timezone { get; set; }
```

Namespace:TheWeatherNode.WeatherService.OpenMeteo.DTOs

Assembly:TheWeatherNode.WeatherService.OpenMeteo.dll

**Inheritance**

object OpenMeteoGeocodingResponseDto

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Properties

## Property Value

IList<OpenMeteoGeocodingDto>

# Class OpenMeteoGeocodingResponseDto

```
public class OpenMeteoGeocodingResponseDto
```
##### 

## Results

```
[JsonPropertyName("results")]
public IList<OpenMeteoGeocodingDto> Results { get; set; }
```

Namespace:TheWeatherNode.WeatherService.OpenMeteo.DTOs

Assembly:TheWeatherNode.WeatherService.OpenMeteo.dll

Represents hourly weather forecast data from the Open-Meteo API.

**Inheritance**

object OpenMeteoHourlyDto

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Remarks

Contains arrays of weather measurements sampled at hourly intervals, allowing for detailed time-series
analysis of forecasted weather conditions. Each property contains data points aligned with
corresponding time stamps.

## Properties

Gets or sets the hourly Convective Available Potential Energy (CAPE) values in J/kg.

## Property Value

List<double>

## Remarks

Indicates atmospheric instability and potential for severe weather.

# Class OpenMeteoHourlyDto

```
public class OpenMeteoHourlyDto
```
##### 

## Cape

```
[JsonPropertyName("cape")]
public List<double> Cape { get; set; }
```

Gets or sets the hourly cloud cover forecasts as percentages (0-100).

#### Property Value

List<double>

Gets or sets the hourly dew point temperature forecasts in degrees Celsius.

#### Property Value

List<double>

Gets or sets the hourly apparent temperature (wind chill) forecasts in degrees Celsius.

#### Property Value

List<double>

Gets or sets the hourly relative humidity forecasts as percentages (0-100).

### CloudCover

```
[JsonPropertyName("cloud_cover")]
public List<double> CloudCover { get; set; }
```
### DewPoint

```
[JsonPropertyName("dewpoint_2m")]
public List<double> DewPoint { get; set; }
```
### FeelsLike

```
[JsonPropertyName("apparent_temperature")]
public List<double> FeelsLike { get; set; }
```
### Humidity


#### Property Value

List<double>

Gets or sets the hourly daytime indicator values.

#### Property Value

List<int>

#### Remarks

0 = Night, 1 = Day

Gets or sets the hourly Lifted Index values in Kelvin.

#### Property Value

List<double>

#### Remarks

Negative values indicate atmospheric instability and thunderstorm potential.

```
[JsonPropertyName("relative_humidity_2m")]
public List<double> Humidity { get; set; }
```
### IsDay

```
[JsonPropertyName("is_day")]
public List<int> IsDay { get; set; }
```
### LiftedIndex

```
[JsonPropertyName("lifted_index")]
public List<double> LiftedIndex { get; set; }
```

Gets or sets the hourly precipitation amount forecasts in millimeters.

#### Property Value

List<double>

Gets or sets the hourly precipitation probability forecasts as percentages (0-100).

#### Property Value

List<double>

Gets or sets the hourly surface air pressure forecasts in hectopascals (hPa).

#### Property Value

List<double>

Gets or sets the hourly air temperature forecasts in degrees Celsius.

### Precipitation

```
[JsonPropertyName("precipitation")]
public List<double> Precipitation { get; set; }
```
### PrecipitationProbability

```
[JsonPropertyName("precipitation_probability")]
public List<double> PrecipitationProbability { get; set; }
```
### Pressure

```
[JsonPropertyName("surface_pressure")]
public List<double> Pressure { get; set; }
```
### Temperature


#### Property Value

List<double>

Gets or sets the list of ISO 8601 timestamps for each hourly data point.

#### Property Value

List<string>

Gets or sets the hourly visibility distance forecasts in meters.

#### Property Value

List<double>

Gets or sets the hourly WMO Weather Codes representing forecasted weather conditions.

```
[JsonPropertyName("temperature_2m")]
public List<double> Temperature { get; set; }
```
### Time

```
[JsonPropertyName("time")]
public List<string> Time { get; set; }
```
### Visibility

```
[JsonPropertyName("visibility")]
public List<double> Visibility { get; set; }
```
### WeatherCode

```
[JsonPropertyName("weather_code")]
public List<int> WeatherCode { get; set; }
```

#### Property Value

List<int>

#### Remarks

See WMO 4677 standard for weather code definitions.

Gets or sets the hourly wind direction forecasts at 10 meters height in degrees (0-359).

#### Property Value

List<double>

#### Remarks

0° = North, 90° = East, 180° = South, 270° = West

Gets or sets the hourly wind gust speed forecasts at 10 meters height in km/h.

#### Property Value

List<double>

Gets or sets the hourly wind speed forecasts at 10 meters height in km/h.

### WindDirection

```
[JsonPropertyName("wind_direction_10m")]
public List<double> WindDirection { get; set; }
```
### WindGusts

```
[JsonPropertyName("wind_gusts_10m")]
public List<double> WindGusts { get; set; }
```
### WindSpeed


#### Property Value

List<double>

```
[JsonPropertyName("wind_speed_10m")]
public List<double> WindSpeed { get; set; }
```

## Classes

OpenMeteoGeocodingService

OpenMeteoWeatherService
Implements weather forecast data retrieval using the Open-Meteo API.

# Namespace TheWeatherNode.WeatherService.

# OpenMeteo.Services


Namespace:TheWeatherNode.WeatherService.OpenMeteo.Services

Assembly:TheWeatherNode.WeatherService.OpenMeteo.dll

**Inheritance**

object OpenMeteoGeocodingService

**Implements**
IGeocodingService

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Constructors

## Parameters

openMeteoGeocodingClient IOpenMeteoGeocodingClient

logger ILogger<OpenMeteoGeocodingService>

## Methods

Retrieves a specific location by city name, with optional country filtering asynchronously.

# Class OpenMeteoGeocodingService

```
public class OpenMeteoGeocodingService : IGeocodingService
```
##### 

## OpenMeteoGeocodingService(IOpenMeteoGeocodingClient,

## ILogger<OpenMeteoGeocodingService>)

```
public OpenMeteoGeocodingService(IOpenMeteoGeocodingClient openMeteoGeocodingClient,
ILogger<OpenMeteoGeocodingService> logger)
```
## GetLocationAsync(string, string?)


#### Parameters

city string

```
The city name to search for (e.g., "York", "London", "Paris"). Cannot be null or empty.
```
country string

```
Optional country name or country code to filter results geographically. When provided, only locations
within the specified country are considered. If null or not specified, searches across all countries.
Examples: "United States", "US", "France", "FR"
```
#### Returns

Task<Location>

```
A task that represents the asynchronous operation. The task result contains a Location object if a
matching location is found; otherwise, null.
```
#### Remarks

Performs a targeted location lookup by city name, optionally narrowed by country. When a country is
provided, the search results are filtered to locations within that country, reducing ambiguity for cities
that share names across regions.

Returns the first matching location if multiple results are found, typically the one with the largest
population or highest relevance score.

#### Exceptions

ArgumentNullException

```
Thrown when city is null.
```
ArgumentException

```
Thrown when city is empty or whitespace.
```
HttpRequestException

```
Thrown when the geocoding API request fails.
```
```
public Task<Location?> GetLocationAsync(string city, string? country = null)
```

Searches for locations matching the specified query string asynchronously.

#### Parameters

query string

```
The search query string (e.g., "New York", "Paris, France", "40.7128, -74.0060"). Cannot be null or
empty.
```
#### Returns

Task<IEnumerable<Location>>

```
A task that represents the asynchronous operation. The task result contains an enumerable collection
of Location objects matching the query. Returns an empty collection if no matches are found.
```
#### Remarks

Performs a forward geocoding search to find locations matching the provided query. The query can be a
city name, address, or any location identifier supported by the underlying geocoding provider.

Multiple results may be returned if the query matches several locations. Results are typically ordered by
relevance or population size.

#### Exceptions

ArgumentNullException

```
Thrown when query is null.
```
ArgumentException

```
Thrown when query is empty or whitespace.
```
HttpRequestException

```
Thrown when the geocoding API request fails.
```
### SearchLocationsAsync(string)

```
public Task<IEnumerable<Location>> SearchLocationsAsync(string query)
```

Namespace:TheWeatherNode.WeatherService.OpenMeteo.Services

Assembly:TheWeatherNode.WeatherService.OpenMeteo.dll

Implements weather forecast data retrieval using the Open-Meteo API.

**Inheritance**

object OpenMeteoWeatherService

**Implements**
IWeatherService

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Remarks

This service acts as an adapter between the application's weather interface (IWeatherService) and the
Open-Meteo weather data provider. It handles the transformation of Open-Meteo DTO objects into
domain models, manages unit conversions based on request preferences, and manages error handling
and logging for weather data operations.

The service supports three types of weather forecast data:

```
Current weather conditions
Hourly forecasts
Daily forecasts
```
All weather data is retrieved from Open-Meteo in metric units (Celsius, km/h, mm, hPa) and returned to
clients in the units specified in their request objects.

## Constructors

# Class OpenMeteoWeatherService

```
public class OpenMeteoWeatherService : IWeatherService
```
##### 

## OpenMeteoWeatherService(IOpenMeteoWeatherClient,

## ILogger<OpenMeteoWeatherService>)


Initializes a new instance of the OpenMeteoWeatherService class.

#### Parameters

openMeteoClient IOpenMeteoWeatherClient

```
The Open-Meteo API client for making HTTP requests to the weather API.
```
logger ILogger<OpenMeteoWeatherService>

```
The logger for recording service operations, warnings, and errors.
```
#### Exceptions

ArgumentNullException

```
Thrown when openMeteoClient or logger is null.
```
## Methods

Retrieves the current weather conditions for the specified location and unit preferences.

#### Parameters

weatherRequest WeatherRequest

```
The current weather request containing geographic coordinates and desired unit preferences. See
CurrentWeatherRequest for details on supported unit types and defaults.
```
#### Returns

Task<CurrentWeather>

```
public OpenMeteoWeatherService(IOpenMeteoWeatherClient openMeteoClient,
ILogger<OpenMeteoWeatherService> logger)
```
### GetCurrentWeatherAsync(WeatherRequest)

```
public Task<CurrentWeather> GetCurrentWeatherAsync(WeatherRequest weatherRequest)
```

```
A task representing the asynchronous operation that returns a CurrentWeather object containing
current weather data including temperature, humidity, wind, precipitation, visibility, UV index, and
more. All values are converted to the units specified in the request.
```
#### Remarks

This method queries the Open-Meteo forecast API with the current=true parameter to retrieve real-time
weather conditions. The API request is built using BuildForecastParameters(WeatherRequest, bool, bool,
bool) which configures all necessary parameters for current weather retrieval based on the request
object.

Open-Meteo returns data in metric units (Celsius, km/h, hPa, meters, mm). The returned CurrentWeather
object contains the raw metric values, with unit conversions handled by the consuming application based
on the request's CurrentWeatherRequest.TemperatureUnit, CurrentWeatherRequest.WindSpeedUnit, and
CurrentWeatherRequest.PrecipitationUnit properties.

#### Exceptions

ArgumentNullException

```
Thrown when weatherRequest is null.
```
InvalidOperationException

```
Thrown when the Open-Meteo API call fails or returns null. Thrown when the API response does not
contain current weather data.
```
Retrieves daily weather forecasts for the specified location and unit preferences.

#### Parameters

weatherRequest WeatherRequest

```
The daily weather forecast request containing geographic coordinates, forecast duration, and desired
unit preferences. See DailyForecastRequest for details on supported unit types, defaults, and the days
parameter.
```
### GetDailyForecastAsync(WeatherRequest)

```
public Task<IEnumerable<DailyForecast>> GetDailyForecastAsync(WeatherRequest weatherRequest)
```

#### Returns

Task<IEnumerable<DailyForecast>>

```
A task representing the asynchronous operation that returns an enumerable collection of Daily
Forecast objects, each representing aggregated weather conditions for a specific day. The collection is
ordered chronologically from earliest to latest. All values are converted to the units specified in the
request.
```
#### Remarks

This method queries the Open-Meteo forecast API with the daily=true parameter to retrieve daily
weather summaries with maximum/minimum temperatures, total precipitation, and other aggregated
metrics. The API request is built using BuildForecastParameters(WeatherRequest, bool, bool, bool) based
on the request object.

The returned collection contains one forecast object per day for the number of days specified in the
request. The Open-Meteo API typically supports forecasts up to 16 days. Dates are in date-only format
and should be converted to local timezone for display to end users. Sunrise and sunset times are in UTC.

Open-Meteo returns data in metric units (Celsius, km/h, hPa, millimeters). The returned DailyForecast
objects contain the raw metric values, with unit conversions handled by the consuming application based
on the request's DailyForecastRequest.TemperatureUnit, DailyForecastRequest.WindSpeedUnit, and
DailyForecastRequest.PrecipitationUnit properties.

#### Exceptions

ArgumentNullException

```
Thrown when weatherRequest is null.
```
InvalidOperationException

```
Thrown when the Open-Meteo API call fails or returns null. Thrown when the API response does not
contain daily weather data.
```
Retrieves hourly weather forecasts for the specified location and unit preferences.

### GetHourlyForecastAsync(WeatherRequest)

```
public Task<IEnumerable<HourlyForecast>> GetHourlyForecastAsync(WeatherRequest
weatherRequest)
```

#### Parameters

weatherRequest WeatherRequest

```
The hourly weather forecast request containing geographic coordinates, forecast duration, and desired
unit preferences. See HourlyWeatherRequest for details on supported unit types, defaults, and the
hours parameter.
```
#### Returns

Task<IEnumerable<HourlyForecast>>

```
A task representing the asynchronous operation that returns an enumerable collection of Hourly
Forecast objects, each representing weather conditions at a specific hour. The collection is ordered
chronologically from earliest to latest. All values are converted to the units specified in the request.
```
#### Remarks

This method queries the Open-Meteo forecast API with the hourly=true parameter to retrieve detailed
hour-by-hour weather predictions. The API request is built using BuildForecastParameters(Weather
Request, bool, bool, bool) based on the request object.

The returned collection contains one forecast object per hour for the number of hours specified in the
request. The Open-Meteo API typically supports forecasts up to 16 days (384 hours). All timestamps are
in UTC and should be converted to local timezone for display to end users.

Open-Meteo returns data in metric units (Celsius, km/h, hPa, meters, mm). The returned HourlyForecast
objects contain the raw metric values, with unit conversions handled by the consuming application based
on the request's HourlyWeatherRequest.TemperatureUnit, HourlyWeatherRequest.WindSpeedUnit, and
properties.

#### Exceptions

ArgumentNullException

```
Thrown when weatherRequest is null.
```
InvalidOperationException

```
Thrown when the Open-Meteo API call fails or returns null. Thrown when the API response does not
contain hourly weather data.
```

## Classes

OpenMeteoParameterListsTests

OpenMeteoRequestBuilderTests

# Namespace TheWeatherNode.WeatherService.

# OpenMeteo.Tests.Builders


Namespace:TheWeatherNode.WeatherService.OpenMeteo.Tests.Builders

Assembly:TheWeatherNode.WeatherService.OpenMeteo.Tests.dll

**Inheritance**

object OpenMeteoParameterListsTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Methods

# Class OpenMeteoParameterListsTests

```
public class OpenMeteoParameterListsTests
```
##### 

## Current_ShouldContainAllRequiredCurrentWeatherParameters()

```
[Fact]
public void Current_ShouldContainAllRequiredCurrentWeatherParameters()
```
## Daily_ShouldContainAllRequiredDailyWeatherParameters()

```
[Fact]
public void Daily_ShouldContainAllRequiredDailyWeatherParameters()
```
## Hourly_ShouldContainAllRequiredHourlyWeatherParameters()

```
[Fact]
public void Hourly_ShouldContainAllRequiredHourlyWeatherParameters()
```

Namespace:TheWeatherNode.WeatherService.OpenMeteo.Tests.Builders

Assembly:TheWeatherNode.WeatherService.OpenMeteo.Tests.dll

**Inheritance**

object OpenMeteoRequestBuilderTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Methods

# Class OpenMeteoRequestBuilderTests

```
public class OpenMeteoRequestBuilderTests
```
##### 

## BuildForecastParameters_ExcludingAllDataTypes_ShouldOnlyIncl

## udeCoordinatesAndUnits()

```
[Fact]
public void
BuildForecastParameters_ExcludingAllDataTypes_ShouldOnlyIncludeCoordinatesAndUnits()
```
## BuildForecastParameters_IncludingAll_ShouldAddAllDataTypes()

```
[Fact]
public void BuildForecastParameters_IncludingAll_ShouldAddAllDataTypes()
```
## BuildForecastParameters_IncludingCurrent_ShouldAddCurrentPa

## rameters()

```
[Fact]
public void BuildForecastParameters_IncludingCurrent_ShouldAddCurrentParameters()
```

### BuildForecastParameters_IncludingDaily_ShouldAddDailyParame

### ters()

```
[Fact]
public void BuildForecastParameters_IncludingDaily_ShouldAddDailyParameters()
```
### BuildForecastParameters_IncludingHourly_ShouldAddHourlyPar

### ameters()

```
[Fact]
public void BuildForecastParameters_IncludingHourly_ShouldAddHourlyParameters()
```
### BuildForecastParameters_WithCelsiusUnit_ShouldMapCorrectly()

```
[Fact]
public void BuildForecastParameters_WithCelsiusUnit_ShouldMapCorrectly()
```
### BuildForecastParameters_WithKnotsWindUnit_ShouldMapToKn()

```
[Fact]
public void BuildForecastParameters_WithKnotsWindUnit_ShouldMapToKn()
```
### BuildForecastParameters_WithNegativeCoordinates_ShouldAcce

### ptValidValues()

```
[Fact]
public void BuildForecastParameters_WithNegativeCoordinates_ShouldAcceptValidValues()
```
### BuildForecastParameters_WithValidRequest_ShouldIncludeCoor

### dinates()


```
[Fact]
public void BuildForecastParameters_WithValidRequest_ShouldIncludeCoordinates()
```
### BuildForecastParameters_WithValidRequest_ShouldIncludeUnitC

### onversions()

```
[Fact]
public void BuildForecastParameters_WithValidRequest_ShouldIncludeUnitConversions()
```
### TemperatureMappings_ShouldContainAllUnits()

```
[Fact]
public void TemperatureMappings_ShouldContainAllUnits()
```

## Classes

OpenMeteoGeocodingClientTests

OpenMeteoWeatherClientTests

# Namespace TheWeatherNode.WeatherService.

# OpenMeteo.Tests.Clients


Namespace:TheWeatherNode.WeatherService.OpenMeteo.Tests.Clients

Assembly:TheWeatherNode.WeatherService.OpenMeteo.Tests.dll

**Inheritance**

object OpenMeteoGeocodingClientTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Constructors

## Methods

## Returns

# Class OpenMeteoGeocodingClientTests

```
public class OpenMeteoGeocodingClientTests
```
##### 

## OpenMeteoGeocodingClientTests()

```
public OpenMeteoGeocodingClientTests()
```
## Constructor_WithValidSettings_ShouldInitialize()

```
[Fact]
public void Constructor_WithValidSettings_ShouldInitialize()
```
## GetLocationsAsync_WithEmptySearch_ShouldStillMakeRequest()

```
[Fact]
public Task GetLocationsAsync_WithEmptySearch_ShouldStillMakeRequest()
```

Task

#### Returns

Task

#### Returns

Task

### GetLocationsAsync_WithHttpErrorStatus_ShouldThrowHttpRequ

### estException()

```
[Fact]
public Task GetLocationsAsync_WithHttpErrorStatus_ShouldThrowHttpRequestException()
```
### GetLocationsAsync_WithValidSearch_ShouldReturnLocations()

```
[Fact]
public Task GetLocationsAsync_WithValidSearch_ShouldReturnLocations()
```

Namespace:TheWeatherNode.WeatherService.OpenMeteo.Tests.Clients

Assembly:TheWeatherNode.WeatherService.OpenMeteo.Tests.dll

**Inheritance**

object OpenMeteoWeatherClientTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Constructors

## Methods

# Class OpenMeteoWeatherClientTests

```
public class OpenMeteoWeatherClientTests
```
##### 

## OpenMeteoWeatherClientTests()

```
public OpenMeteoWeatherClientTests()
```
## Constructor_ShouldSetBaseUrlAndTimeout()

```
[Fact]
public void Constructor_ShouldSetBaseUrlAndTimeout()
```
## Constructor_WithNullHttpClient_ShouldThrowArgumentNullExc

## eption()

```
[Fact]
public void Constructor_WithNullHttpClient_ShouldThrowArgumentNullException()
```

#### Returns

Task

#### Returns

Task

#### Returns

Task

### GetForcastAsync_WithEmptyParameters_ShouldStillMakeReques

### t()

```
[Fact]
public Task GetForcastAsync_WithEmptyParameters_ShouldStillMakeRequest()
```
### GetForcastAsync_WithHttpErrorStatus_ShouldThrowHttpReques

### tException()

```
[Fact]
public Task GetForcastAsync_WithHttpErrorStatus_ShouldThrowHttpRequestException()
```
### GetForcastAsync_WithValidParameters_ShouldReturnDeserialize

### dResponse()

```
[Fact]
public Task GetForcastAsync_WithValidParameters_ShouldReturnDeserializedResponse()
```

## Classes

OpenMeteoGeocodingServiceTests

OpenMeteoWeatherServiceTests

# Namespace TheWeatherNode.WeatherService.

# OpenMeteo.Tests.Services


Namespace:TheWeatherNode.WeatherService.OpenMeteo.Tests.Services

Assembly:TheWeatherNode.WeatherService.OpenMeteo.Tests.dll

**Inheritance**

object OpenMeteoGeocodingServiceTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Constructors

## Methods

## Returns

Task

# Class OpenMeteoGeocodingServiceTests

```
public class OpenMeteoGeocodingServiceTests
```
##### 

## OpenMeteoGeocodingServiceTests()

```
public OpenMeteoGeocodingServiceTests()
```
## GetLocationAsync_WithCityAndCountry_ShouldFilterByBoth()

```
[Fact]
public Task GetLocationAsync_WithCityAndCountry_ShouldFilterByBoth()
```
## GetLocationAsync_WithCity_ShouldReturnFirstMatch()


#### Returns

Task

#### Returns

Task

#### Returns

Task

#### Returns

Task

```
[Fact]
public Task GetLocationAsync_WithCity_ShouldReturnFirstMatch()
```
### GetLocationAsync_WithExactMatch_ShouldReturnLocation()

```
[Fact]
public Task GetLocationAsync_WithExactMatch_ShouldReturnLocation()
```
### GetLocationAsync_WithNonexistentLocation_ShouldReturnNull()

```
[Fact]
public Task GetLocationAsync_WithNonexistentLocation_ShouldReturnNull()
```
### SearchLocationsAsync_WithEmptyResults_ShouldReturnEmptyC

### ollection()

```
[Fact]
public Task SearchLocationsAsync_WithEmptyResults_ShouldReturnEmptyCollection()
```

#### Returns

Task

#### Returns

Task

#### Returns

Task

### SearchLocationsAsync_WithMultipleResults_ShouldReturnAllLoc

### ations()

```
[Fact]
public Task SearchLocationsAsync_WithMultipleResults_ShouldReturnAllLocations()
```
### SearchLocationsAsync_WithNullAdminField_ShouldUseEmptyStr

### ing()

```
[Fact]
public Task SearchLocationsAsync_WithNullAdminField_ShouldUseEmptyString()
```
### SearchLocationsAsync_WithNullPostcodes_ShouldUseEmptyEnu

### merable()

```
[Fact]
public Task SearchLocationsAsync_WithNullPostcodes_ShouldUseEmptyEnumerable()
```
### SearchLocationsAsync_WithValidQuery_ShouldReturnLocations()

```
[Fact]
public Task SearchLocationsAsync_WithValidQuery_ShouldReturnLocations()
```

#### Returns

Task


Namespace:TheWeatherNode.WeatherService.OpenMeteo.Tests.Services

Assembly:TheWeatherNode.WeatherService.OpenMeteo.Tests.dll

**Inheritance**

object OpenMeteoWeatherServiceTests

**Inherited Members**
object.Equals(object) , object.Equals(object, object) , object.GetHashCode() , object.GetType() ,
object.MemberwiseClone() , object.ReferenceEquals(object, object) , object.ToString()

## Constructors

## Methods

## Returns

Task

# Class OpenMeteoWeatherServiceTests

```
public class OpenMeteoWeatherServiceTests
```
##### 

## OpenMeteoWeatherServiceTests()

```
public OpenMeteoWeatherServiceTests()
```
## GetCurrentWeatherAsync_WhenClientReturnsNull_ShouldThrowI

## nvalidOperationException()

```
[Fact]
public Task
GetCurrentWeatherAsync_WhenClientReturnsNull_ShouldThrowInvalidOperationException()
```

#### Returns

Task

#### Returns

Task

#### Returns

Task

### GetCurrentWeatherAsync_WhenCurrentDataIsNull_ShouldThrow

### InvalidOperationException()

```
[Fact]
public Task
GetCurrentWeatherAsync_WhenCurrentDataIsNull_ShouldThrowInvalidOperationException()
```
### GetCurrentWeatherAsync_WithNullRequest_ShouldThrowArgum

### entNullException()

```
[Fact]
public Task GetCurrentWeatherAsync_WithNullRequest_ShouldThrowArgumentNullException()
```
### GetCurrentWeatherAsync_WithValidRequest_ShouldReturnCurre

### ntWeather()

```
[Fact]
public Task GetCurrentWeatherAsync_WithValidRequest_ShouldReturnCurrentWeather()
```
### GetDailyForecastAsync_WhenDailyDataIsNull_ShouldThrowInvali

### dOperationException()


#### Returns

Task

#### Returns

Task

#### Returns

Task

```
[Fact]
public Task GetDailyForecastAsync_WhenDailyDataIsNull_ShouldThrowInvalidOperationException()
```
### GetDailyForecastAsync_WithNullRequest_ShouldThrowArgumen

### tNullException()

```
[Fact]
public Task GetDailyForecastAsync_WithNullRequest_ShouldThrowArgumentNullException()
```
### GetDailyForecastAsync_WithValidRequest_ShouldReturnDailyFor

### ecasts()

```
[Fact]
public Task GetDailyForecastAsync_WithValidRequest_ShouldReturnDailyForecasts()
```
### GetHourlyForecastAsync_WhenHourlyDataIsNull_ShouldThrowIn

### validOperationException()

```
[Fact]
public Task
GetHourlyForecastAsync_WhenHourlyDataIsNull_ShouldThrowInvalidOperationException()
```

#### Returns

Task

#### Returns

Task

#### Returns

Task

### GetHourlyForecastAsync_WithNullRequest_ShouldThrowArgum

### entNullException()

```
[Fact]
public Task GetHourlyForecastAsync_WithNullRequest_ShouldThrowArgumentNullException()
```
### GetHourlyForecastAsync_WithValidRequest_ShouldReturnHourly

### Forecasts()

```
[Fact]
public Task GetHourlyForecastAsync_WithValidRequest_ShouldReturnHourlyForecasts()
```

