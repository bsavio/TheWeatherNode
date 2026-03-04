export interface Location {
    name: string;
    latitude: number;
    longitude: number;
    country: string;
    countryCode: string;
    state: string;
    postalCodes: string[];
    population: number;
    timezone: string;
}