// layouts/components/LocationSearch.tsx
import { useState } from 'react';
import SearchDropdown from '../../../components/SearchDropdown';
import { useLocationSearch } from '../../../hooks/useLocationSearch';
import { useLocationStore } from '../../../store/locationStore';
import type { Location } from '../../../types/location';

const LocationSearch = () => {
    const [query, setQuery] = useState('');
    const { data, isLoading } = useLocationSearch(query);
    const setLocation = useLocationStore(state => state.setSelectedLocation);

    const handleSelect = (location: Location) => {
        setLocation(location);
    };

    return (
        <div className="mb-3">
            <label className="form-label text-muted small">Location</label>
            <SearchDropdown<Location>
                placeholder="Search city..."
                onSearch={setQuery}
                options={data ?? []}
                getOptionLabel={loc => `${loc.name}, ${loc.state}, ${loc.country}`}
                onSelect={handleSelect}
                isLoading={isLoading}
                minChars={3}
            />
        </div>
    );
};

export default LocationSearch;