import { useQuery } from "@tanstack/react-query";
import { getCurrentWeather } from "../services/weatherService";
import type { WeatherRequest, CurrentWeather } from "../types/weather";

export function useFetchCurrentWeather(weatherRequest: WeatherRequest) {
  return useQuery<CurrentWeather>({
    queryKey: ["currentWeather", weatherRequest],
    queryFn: async () => {
      return await getCurrentWeather(weatherRequest);
    },
  });
}
