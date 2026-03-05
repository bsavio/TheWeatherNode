import { useState } from 'react';
import { Dropdown } from 'react-bootstrap';
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
  dropdownWidth?: string;
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
  inputClassName,
  dropdownWidth = '400px'
}: SearchDropdownProps<T>) {
  const [query, setQuery] = useState('');
  const [isOpen, setIsOpen] = useState(false);

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
    <Dropdown
      className={classNames('search-dropdown', className)}
      show={isOpen}
      onToggle={(show) => setIsOpen(show)}
    >
      <Dropdown.Toggle
        as="div"
        id="search-dropdown-toggle"
        className="search-dropdown__toggle"
        bsPrefix="search-dropdown"
      >
        <input
          type="text"
          className={classNames('form-control', inputClassName)}
          placeholder={placeholder}
          value={query}
          onChange={handleChange}
          onClick={() => query.length >= minChars && setIsOpen(true)}
          aria-label={placeholder}
          aria-expanded={isOpen}
          aria-autocomplete="list"
        />
      </Dropdown.Toggle>

      <Dropdown.Menu className="search-dropdown__menu" style={{ width: dropdownWidth, minWidth: '100%' }}>
        {isLoading && (
          <Dropdown.Item disabled className="text-muted">
            Searching...
          </Dropdown.Item>
        )}
        {!isLoading && options.length === 0 && (
          <Dropdown.Item disabled className="text-muted">
            No results found
          </Dropdown.Item>
        )}
        {!isLoading && options.map((option, index) => (
          <Dropdown.Item
            key={index}
            onClick={() => handleSelect(option)}
            className="search-dropdown__item"
          >
            {getOptionLabel(option)}
          </Dropdown.Item>
        ))}
      </Dropdown.Menu>
    </Dropdown>
  );
}

export default SearchDropdown;