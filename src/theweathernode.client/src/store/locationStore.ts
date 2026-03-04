import { create } from 'zustand';
import type { Location } from '../types/location';

interface LocationState {
    selectedLocation: Location | null;
    savedLocations: Location[];
    recentSearches: Location[];
    setSelectedLocation: (location: Location) => void;
    saveLocation: (location: Location) => void;
    removeLocation: (location: Location) => void;
    addRecentSearch: (location: Location) => void;
    clearRecentSearches: () => void;
}

export const useLocationStore = create<LocationState>((set) => ({
    selectedLocation: null,
    savedLocations: [],
    recentSearches: [],

    setSelectedLocation: (location) =>
        set({ selectedLocation: location }),

    saveLocation: (location) =>
        set((state) => ({
            savedLocations: [...state.savedLocations, location]
        })),

    removeLocation: (location) =>
        set((state) => ({
            savedLocations: state.savedLocations.filter(
                (loc) => loc.name !== location.name
            )
        })),

    addRecentSearch: (location) =>
        set((state) => ({
            recentSearches: [
                location,
                ...state.recentSearches
                    .filter((loc) => loc.name !== location.name)
                    .slice(0, 4) // keep last 5 searches
            ]
        })),

    clearRecentSearches: () =>
        set({ recentSearches: [] }),
}));