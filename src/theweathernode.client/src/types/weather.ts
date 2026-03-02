// Mirrors C# WeatherRequest
export interface WeatherRequest {
  latitude: number;
  longitude: number;
  temperatureUnit: string;
  windSpeedUnit: string;
  precipitationUnit: string;
}

// Mirrors C# CurrentWeather
export interface CurrentWeather {
  temperature: number;
  feelsLike: number;
  dewPoint: number;
  humidity: number;
  windSpeed: number;
  windDirection: number;
  windGusts: number;
  precipitation: number;
  pressure: number;
  visibility: number;
  uvIndex: number;
  cloudCover: number;
  weatherCode: number;
  isDay: boolean;
  time: string; // ISO format from API
}

// Mirrors C# HourlyForecast
export interface HourlyForecast {
  time: string; // ISO 8601 timestamp in UTC
  temperature: number;
  feelsLike: number;
  dewPoint: number;
  humidity: number;
  windSpeed: number;
  windDirection: number;
  windGusts: number;
  precipitation: number;
  precipitationProbability: number;
  pressure: number;
  cloudCover: number;
  visibility: number;
  weatherCode: number;
  isDay: boolean;
}

// Mirrors C# DailyForecast
export interface DailyForecast {
  date: string; // ISO date format (YYYY-MM-DD)
  temperatureMax: number;
  temperatureMin: number;
  feelsLikeMax: number;
  feelsLikeMin: number;
  humidityMax: number;
  humidityMin: number;
  pressureMean: number;
  precipitationSum: number;
  precipitationProbabilityMax: number;
  windSpeedMax: number;
  windGustsMax: number;
  windDirectionDominant: number;
  uvIndexMax: number;
  weatherCode: number;
  sunrise: string; // ISO datetime in UTC
  sunset: string; // ISO datetime in UTC
}
