import weatherClient from "../api/weatherClient";
import type {
  CurrentWeather,
  DailyForecast,
  HourlyForecast,
} from "../types/weather";

export const getCurrentWeather = async (
  weatherRequest: WeatherRequest,
): Promise<CurrentWeather> => {
  //TODO: Remove hardcoded values and use the passed in weatherRequest
  weatherRequest.latitude = 40.3025;
  weatherRequest.Longitude = 74.3036;
  weatherRequest.tempeeratureUnit = "fahrenheit";
  weatherRequest.windSpeedUnit = "mph";
  weatherRequest.precipitationUnit = "inch";
  const { data } = await weatherClient.get<CurrentWeather>("/weather/current", {
    params: weatherRequest,
  });
  return data;
};

export const getDailyForecast = async (
  request: WeatherRequest,
): Promise<DailyForecast[]> => {
  const { data } = await weatherClient.get<DailyForecast[]>("/weather/daily", {
    params: request,
  });
  return data;
};

export const getHourlyForecast = async (
  request: WeatherRequest,
): Promise<HourlyForecast[]> => {
  const { data } = await weatherClient.get<HourlyForecast[]>(
    "/weather/hourly",
    {
      params: request,
    },
  );
  return data;
};
