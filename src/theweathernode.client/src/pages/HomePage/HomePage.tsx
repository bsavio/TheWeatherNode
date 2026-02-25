import { useEffect } from "react";
import { useOutletContext } from "react-router-dom";
import HomePageSidebar from "./HomePageSidebar";
import type { LayoutContextType } from "../../types/LayoutContextType";

export default function HomePage() {
    const { setSidebarContent } = useOutletContext<LayoutContextType>();

    useEffect(() => {
        setSidebarContent(<HomePageSidebar />);
        return () => setSidebarContent(null);
    }, []);


    return <h1>HomePage</h1>
};