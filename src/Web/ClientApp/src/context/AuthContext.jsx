import React, { createContext, useEffect, useState } from "react";

export const AuthContext = createContext();

const STORAGE_KEY = "auth";

export function AuthProvider({ children }) {
  const [auth, setAuth] = useState(() => {
    try {
      const raw = localStorage.getItem(STORAGE_KEY);
      return raw ? JSON.parse(raw) : null;
    } catch {
      return null;
    }
  });

  // helper: save auth object with expiresAt
  const saveAuth = (payload) => {
    const expiresAt = payload.expiresIn ? Date.now() + payload.expiresIn * 1000 : null;
    const next = { ...payload, expiresAt };
    setAuth(next);
    localStorage.setItem(STORAGE_KEY, JSON.stringify(next));
  };

  const login = (payload) => {
    // payload expected to be { tokenType, accessToken, expiresIn, refreshToken }
    saveAuth(payload);
  };

  const logout = () => {
    setAuth(null);
    localStorage.removeItem(STORAGE_KEY);
  };

  const updateTokens = (payload) => {
    // called after refresh
    if (!auth) {
      saveAuth(payload);
    } else {
      saveAuth({ ...auth, ...payload });
    }
  };

  // optional: auto-logout when expired (simple)
  useEffect(() => {
    if (!auth || !auth.expiresAt) return;
    const ttl = auth.expiresAt - Date.now();
    if (ttl <= 0) {
      logout();
      return;
    }
    const id = setTimeout(() => {
      logout();
    }, ttl);
    return () => clearTimeout(id);
  }, [auth]);

  return (
    <AuthContext.Provider value={{ auth, login, logout, updateTokens }}>
      {children}
    </AuthContext.Provider>
  );
}
