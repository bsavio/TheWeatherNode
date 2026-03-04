// store/weatherStore.ts
import { create } from 'zustand';
import type { TemperatureUnit, WindSpeedUnit, PrecipitationUnit } from '../types/units';

interface WeatherState {
    temperatureUnit: TemperatureUnit;
    windSpeedUnit: WindSpeedUnit;
    precipitationUnit: PrecipitationUnit;
    setTemperatureUnit: (unit: TemperatureUnit) => void;
    setWindSpeedUnit: (unit: WindSpeedUnit) => void;
    setPrecipitationUnit: (unit: PrecipitationUnit) => void;
}

export const useWeatherStore = create<WeatherState>((set) => ({
    temperatureUnit: 'fahrenheit',
    windSpeedUnit: 'mph',
    precipitationUnit: 'inch',

    setTemperatureUnit: (unit) =>
        set({ temperatureUnit: unit }),

    setWindSpeedUnit: (unit) =>
        set({ windSpeedUnit: unit }),

    setPrecipitationUnit: (unit) =>
        set({ precipitationUnit: unit }),
}));