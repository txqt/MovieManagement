import React from "react";
import { Navigate } from "react-router-dom";
import { useAuth0 } from "@auth0/auth0-react";

export default function PrivateRoute({ children, roles }) {
  const { isAuthenticated, user, isLoading } = useAuth0();

  if (isLoading) return <div>Loading...</div>;

  // Nếu chưa login → redirect về /login
  if (!isAuthenticated) {
    return <Navigate to="/login" />;
  }

  if (roles && roles.length > 0) {
    const userRoles = user["https://yourapp.com/roles"] || [];
    const hasRole = roles.some(r => userRoles.includes(r));
    if (!hasRole) {
      return <h2>Access Denied</h2>;
    }
  }

  return children;
}