import weatherClient from "../api/weatherClient";
import type { Location } from "../types/location";

export const searchLocations = async (query: string): Promise<Location[]> => {
    const params = { query: query };
    const { data } = await weatherClient.get<Location[]>("/location/search", {
        params: params,
    });
    return data;
}