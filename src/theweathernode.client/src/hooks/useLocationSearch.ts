import { useState, useEffect } from 'react';
import { useDebounce } from './useDebounce';
import { searchLocations } from '../services/locationService';
import type { Location } from '../types/location';

export function useLocationSearch() {
    const [query, setQuery] = useState('');
    const [results, setResults] = useState<Location[]>([]);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    // Debounce the query (wait 300ms after user stops typing)
    const debouncedQuery = useDebounce(query, 300);

    // Search effect - runs when debounced query changes
    useEffect(() => {
        if (!debouncedQuery.trim()) {
            setResults([]);
            return;
        }

        const performSearch = async () => {
            try {
                setIsLoading(true);
                setError(null);
                const locations = await searchLocations(debouncedQuery);
                setResults(locations);
            } catch (err) {
                setError('Failed to search locations');
                setResults([]);
            } finally {
                setIsLoading(false);
            }
        };

        performSearch();
    }, [debouncedQuery]);

    return {
        query,
        setQuery,
        results,
        isLoading,
        error
    };
}