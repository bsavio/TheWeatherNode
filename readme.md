
## Projects

### 1. **TheWeatherNode.Server**
**Purpose**: ASP.NET Core 8 REST API backend

**Responsibilities**:
- Exposes REST endpoints for weather and geocoding operations
- Request validation and error handling
- Dependency injection configuration
- CORS and security policies
- Logging and request/response handling

**Key Components**:
- `Controllers/WeatherForecastController.cs`: Weather data endpoints
- `Controllers/GeocodingController.cs`: Location search endpoints
- Middleware for error handling and logging

---

### 2. **TheWeatherNode.Client**
**Purpose**: React 19 TypeScript frontend application

**Responsibilities**:
- User interface for weather queries and location search
- State management with Zustand
- HTTP client for API communication
- Responsive UI with Bootstrap 5 and React-Bootstrap
- Client-side routing with React Router

**Key Features**:
- Location search with autocomplete
- Current weather display
- Hourly and daily forecast visualization
- Unit preference management
- Timezone-aware time displays

**Technology Stack**:
- React 19.2.0
- TypeScript 5.9.3
- Vite (build tool)
- Bootstrap 5.3.8
- React-Bootstrap 2.10.10
- Zustand 5.0.11 (state management)
- React Router DOM 7.13.0
- Sass 1.97.3

---

### 3. **TheWeatherNode.Core**
**Purpose**: Shared core business logic and domain models

**Responsibilities**:
- Domain models representing weather and location data
- Service interfaces defining contracts
- Extension methods for unit conversions
- Request/response models
- Shared utilities and helpers

**Key Components**:

#### Models
- `WeatherRequest`: Input parameters for weather queries
- `CurrentWeather`: Current weather conditions
- `HourlyForecast`: Hourly forecast data point
- `DailyForecast`: Daily aggregate forecast
- `Location`: Geocoding result with coordinates and metadata

#### Interfaces
- `IWeatherService`: Contract for weather operations
- `IGeocodingService`: Contract for location search
- `IWeatherRequest`: Request builder interface

#### Extensions
- `UnitTypeExtensions`: Conversion between unit type enums and strings
- Temperature unit conversion (Celsius ↔ Fahrenheit)
- Wind speed unit conversion (km/h ↔ mph ↔ knots)
- Precipitation unit conversion (mm ↔ inches)

---

### 4. **TheWeatherNode.WeatherService.OpenMeteo**
**Purpose**: Open-Meteo API integration layer

**Responsibilities**:
- HTTP client abstraction for Open-Meteo services
- DTO mapping and deserialization
- Request parameter building
- API response transformation
- Configuration management

**Key Components**:

#### Clients
- `OpenMeteoClient`: Generic HTTP client for forecast API
- `OpenMeteoGeocodingClient`: HTTP client for geocoding API
- `IOpenMeteoClient`: Contract for weather API calls
- `IOpenMeteoGeocodingClient`: Contract for geocoding API calls

#### DTOs
- `OpenMeteoForecastResponseDto`: Weather API response
- `OpenMeteoDailyDto`: Daily forecast data from API
- `OpenMeteoHourlyDto`: Hourly forecast data from API
- `OpenMeteoCurrentDto`: Current weather data from API
- `OpenMeteoGeoLocationDto`: Location data from geocoding API

#### Services
- `OpenMeteoWeatherService`: Implements `IWeatherService`
- `OpenMeteoGeocodingService`: Implements `IGeocodingService`

#### Builders
- `OpenMeteoRequestBuilder`: Constructs query parameters for weather requests
- `HttpQueryBuilder`: Utility for building URL query strings
- `OpenMeteoParameterLists`: Predefined parameter sets (current, hourly, daily)

#### Configuration
- `OpenMeteoWeatherClientSettings`: Configuration for weather API
- `OpenMeteoGeocodingClientSettings`: Configuration for geocoding API
- `OpenMeteoClientSettingsBase`: Base configuration class

---

## Technology Stack

### Backend
- **.NET 8.0**: Modern, high-performance runtime
- **ASP.NET Core 8**: Web API framework
- **C# 12**: Latest language features
- **Dependency Injection**: Built-in .NET DI container
- **System.Text.Json**: JSON serialization

### Frontend
- **React 19.2.0**: UI library
- **TypeScript 5.9.3**: Type-safe JavaScript
- **Vite 7.3.1**: Fast build tool and dev server
- **Bootstrap 5.3.8**: CSS framework
- **React-Bootstrap 2.10.10**: React components for Bootstrap
- **Zustand 5.0.11**: Lightweight state management
- **React Router DOM 7.13.0**: Client-side routing
- **Sass 1.97.3**: CSS preprocessing

### External Services
- **Open-Meteo API**: Free weather and geocoding data
  - Weather forecast: https://api.open-meteo.com/v1/
  - Geocoding: https://geocoding-api.open-meteo.com/v1/

---
