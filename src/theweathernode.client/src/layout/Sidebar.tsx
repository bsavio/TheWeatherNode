interface SidebarProps {
  content: React.ReactNode;
}

export default function Sidebar({ content }: SidebarProps) {
  return (
    <div className="sidebar p-3" style={{ width: "220px" }}>
      {content || null}
    </div>
  );
}
