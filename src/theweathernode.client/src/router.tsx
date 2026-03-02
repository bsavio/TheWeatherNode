import React from "react";
import { createBrowserRouter } from "react-router";
import App from "./App";

/**
 * Simple router for TheWeatherNode client.
 *
 * - Defines application routes
 * - Provides a minimal navigation header
 * - Exposes a NotFound route for unknown paths
 */

/* Route path constants */
export const ROUTES = {
  HOME: "/",
} as const;

export const router = createBrowserRouter([
  {
    path: ROUTES.HOME,
    element: <App />,
  },
]);

const NotFound: React.FC = () => {
  const location = useLocation();
  return (
    <main>
      <h1>404 - Not Found</h1>
      <p>
        No route matches <code>{location.pathname}</code>
      </p>
      <p>
        Go back to <Link to={ROUTES.HOME}>home</Link>.
      </p>
    </main>
  );
};

/**
 * Main router component exported as default.
 * Import and render <Router /> inside your application entry point.
 */
const Router: React.FC = () => {
  return (
    <BrowserRouter>
      <AppLayout>
        <Routes>
          <Route path={ROUTES.HOME} element={<Home />} />
          <Route path="/home" element={<Navigate to={ROUTES.HOME} replace />} />
          <Route path="*" element={<NotFound />} />
        </Routes>
      </AppLayout>
    </BrowserRouter>
  );
};

export default Router;
