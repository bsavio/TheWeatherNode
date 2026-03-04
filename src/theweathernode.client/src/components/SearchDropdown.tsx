import { useState, useRef, useEffect } from 'react';
import classNames from 'classnames';
import './SearchDropdown.scss';

interface SearchDropdownProps<T> {
    placeholder?: string;
    onSearch: (query: string) => void;
    options: T[];
    getOptionLabel: (option: T) => string;
    onSelect: (option: T) => void;
    isLoading?: boolean;
    minChars?: number;
    className?: string;
    inputClassName?: string;
}

function SearchDropdown<T>({
    placeholder = 'Search...',
    onSearch,
    options,
    getOptionLabel,
    onSelect,
    isLoading = false,
    minChars = 3,
    className,
    inputClassName
}: SearchDropdownProps<T>) {
    const [query, setQuery] = useState('');
    const [isOpen, setIsOpen] = useState(false);
    const containerRef = useRef<HTMLDivElement>(null);

    useEffect(() => {
        const handleClickOutside = (e: MouseEvent) => {
            if (containerRef.current && !containerRef.current.contains(e.target as Node)) {
                setIsOpen(false);
            }
        };
        document.addEventListener('mousedown', handleClickOutside);
        return () => document.removeEventListener('mousedown', handleClickOutside);
    }, []);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const value = e.target.value;
        setQuery(value);
        if (value.length >= minChars) {
            onSearch(value);
            setIsOpen(true);
        } else {
            setIsOpen(false);
        }
    };

    const handleSelect = (option: T) => {
        setQuery(getOptionLabel(option));
        setIsOpen(false);
        onSelect(option);
    };

    return (
        <div
            className={classNames('search-dropdown', 'position-relative', className)}
            ref={containerRef}
        >
            <input
                type="text"
                className={classNames('form-control', inputClassName)}
                placeholder={placeholder}
                value={query}
                onChange={handleChange}
            />
            {isOpen && (
                <ul className={classNames('search-dropdown__menu', 'dropdown-menu', 'show', 'w-100')}>
                    {isLoading && (
                        <li className="dropdown-item text-muted">Searching...</li>
                    )}
                    {!isLoading && options.length === 0 && (
                        <li className="dropdown-item text-muted">No results found</li>
                    )}
                    {!isLoading && options.map((option, index) => (
                        <li key={index}>
                            <button
                                className="dropdown-item"
                                onClick={() => handleSelect(option)}
                            >
                                {getOptionLabel(option)}
                            </button>
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
}

export default SearchDropdown;