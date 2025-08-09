import axios from "axios";

const BASE_URL = "https://localhost:5001/api"; // đổi thành server của bạn

// client dùng để call refresh (không có interceptor để tránh vòng lặp)
const refreshClient = axios.create({ baseURL: BASE_URL });

// main api client
const api = axios.create({ baseURL: BASE_URL });

// read auth from localStorage helper
function readAuth() {
  try {
    const raw = localStorage.getItem("auth");
    return raw ? JSON.parse(raw) : null;
  } catch {
    return null;
  }
}

// queue to avoid multiple parallel refreshes
let isRefreshing = false;
let refreshQueue = [];

function processQueue(error, tokenData = null) {
  refreshQueue.forEach(({ resolve, reject }) => {
    if (error) reject(error);
    else resolve(tokenData);
  });
  refreshQueue = [];
}

api.interceptors.request.use((config) => {
  const auth = readAuth();
  if (auth && auth.accessToken) {
    const scheme = auth.tokenType || "Bearer";
    config.headers = config.headers || {};
    config.headers.Authorization = `${scheme} ${auth.accessToken}`;
  }
  return config;
});

// response interceptor: on 401 try refresh once
api.interceptors.response.use(
  (res) => res,
  async (error) => {
    const originalRequest = error.config;

    // if no response or not 401, reject
    if (!error.response || error.response.status !== 401) {
      return Promise.reject(error);
    }

    // prevent retry loop
    if (originalRequest._retry) {
      return Promise.reject(error);
    }
    originalRequest._retry = true;

    const auth = readAuth();
    if (!auth || !auth.refreshToken) {
      // no refresh token -> force logout (client should handle)
      return Promise.reject(error);
    }

    if (isRefreshing) {
      // queue this request until refreshing done
      return new Promise((resolve, reject) => {
        refreshQueue.push({
          resolve: (tokenData) => {
            // set header and retry
            originalRequest.headers.Authorization = `${tokenData.tokenType} ${tokenData.accessToken}`;
            resolve(api(originalRequest));
          },
          reject: (err) => reject(err),
        });
      });
    }

    isRefreshing = true;

    try {
      const r = await refreshClient.post("/auth/refresh", {
        refreshToken: auth.refreshToken,
      });

      // expect r.data = { tokenType, accessToken, expiresIn, refreshToken }
      const tokenData = r.data;
      // save to localStorage
      const expiresAt = tokenData.expiresIn ? Date.now() + tokenData.expiresIn * 1000 : null;
      const merged = { ...tokenData, expiresAt };
      localStorage.setItem("auth", JSON.stringify(merged));

      processQueue(null, tokenData);

      // set header and retry original
      originalRequest.headers.Authorization = `${tokenData.tokenType} ${tokenData.accessToken}`;
      return api(originalRequest);
    } catch (refreshError) {
      processQueue(refreshError, null);
      // refresh failed -> clear auth
      localStorage.removeItem("auth");
      return Promise.reject(refreshError);
    } finally {
      isRefreshing = false;
    }
  }
);

export default api;