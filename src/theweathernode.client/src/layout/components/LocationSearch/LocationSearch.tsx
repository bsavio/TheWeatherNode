// layouts/components/LocationSearch.tsx
import { useEffect } from 'react';
import { useLocationSearch } from '../../../hooks/useLocationSearch';
import { useLocationStore } from '../../../store/locationStore';
import type { Location } from '../../../types/location';
import SearchDropdown from '../../../components/SearchDropdown';

const LocationSearch = () => {
    const { setQuery, results, isLoading } = useLocationSearch();
    const { setLocation, selectedLocation } = useLocationStore(state => ({
        setLocation: state.setSelectedLocation,
        selectedLocation: state.selectedLocation
    }));

    const handleSelect = (location: Location) => {
        setLocation(location);
        setQuery(''); // Clear search after selection
    };

    // Initialize input with selected location on mount
    useEffect(() => {
        if (selectedLocation) {
            const locationLabel = `${selectedLocation.name}${
                selectedLocation.state ? ', ' + selectedLocation.state : ''
            }, ${selectedLocation.countryCode}`;
            setQuery(locationLabel);
        }
    }, [selectedLocation, setQuery]);

    return (
        <div className="mb-3">
            <label className="form-label text-muted small">Location</label>
            <SearchDropdown<Location>
                placeholder="Search city..."
                onSearch={setQuery}
                options={results}
                getOptionLabel={loc => `${loc.name}${loc.state ? ', ' + loc.state : ''}, ${loc.countryCode}`}
                onSelect={handleSelect}
                isLoading={isLoading}
                minChars={3}
            />
        </div>
    );
};

export default LocationSearch;