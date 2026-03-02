import { useState } from "react";
import { Outlet } from "react-router";
import Sidebar from "./Sidebar";
import TopNavbar from "./TopNavbar";
import type { LayoutContextType } from "../types/LayoutContextType";

export default function Layout() {
  const [sidebarContent, setSidebarContent] = useState<React.ReactNode>(null);

  return (
    <div className="d-flex flex-column vh-100">
      <TopNavbar />
      <div className="d-flex flex-grow-1 overflow-hidden">
        <Sidebar content={sidebarContent} />
        <main className="flex-grow-1 overflow-auto p-3">
          <Outlet context={{ setSidebarContent } as LayoutContextType} />
        </main>
      </div>
    </div>
  );
}
