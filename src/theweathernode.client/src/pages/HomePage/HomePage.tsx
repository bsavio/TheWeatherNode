import { useEffect } from "react";
import { useOutletContext } from "react-router-dom";
import HomePageSidebar from "./HomePageSidebar";
import type { LayoutContextType } from "../../types/LayoutContextType";
import type { WeatherRequest, CurrentWeather } from "../../types/weather";
import { useFetchCurrentWeather } from "../../hooks/useFetchCurrentWeather";

export default function HomePage() {
    const { setSidebarContent } = useOutletContext<LayoutContextType>();
    const request: WeatherRequest = {
        latitude: 40.3025,
        longitude: -74.3036,
        temperatureUnit: 'fahrenheit',
        windSpeedUnit: 'mph',
        precipitationUnit: 'inch',
    };

    const { data, isLoading, isError, error } = useFetchCurrentWeather(request);
    useEffect(() => {
        setSidebarContent(<HomePageSidebar />);
        return () => setSidebarContent(null);
    }, []);
    if (isLoading) return <div>Loading...</div>;
    if (isError) return <div>Error: {(error as Error).message}</div>;
    return (
        <div>
            <h4>Current Weather (Debug)</h4>
            <pre>{JSON.stringify(data, null, 2)}</pre>
        </div>
    );
};