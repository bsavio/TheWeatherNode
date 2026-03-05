import LocationSearch from './components/LocationSearch/LocationSearch';

interface SidebarProps {
  content: React.ReactNode;
}

export default function Sidebar({ content }: SidebarProps) {
  return (
    <div className="sidebar p-3" style={{ width: "220px" }}>
      <LocationSearch />
      {content || null}
    </div>
  );
}
