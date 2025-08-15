import { StrictMode, Suspense } from 'react'
import { createRoot } from 'react-dom/client'
import { CssVarsProvider } from '@mui/joy'

import './index.css'
import './styles/main.scss'
import 'bootstrap/dist/css/bootstrap.min.css'

import App from './App'
import './i18n'

import { AuthProvider } from './context/AuthContext'
import { LanguageProvider } from './context/LanguageContext'

import { Auth0Provider } from '@auth0/auth0-react';

createRoot(document.getElementById('root')).render(
  <Auth0Provider
    domain="brochat.us.auth0.com"
    clientId="ASj2jcYVk3IXkdEgHPSIjVGuPZMZoQVJ"
    authorizationParams={{
      redirect_uri: window.location.origin,
      scope: "openid profile email"
    }}
  >
    <StrictMode>
      <CssVarsProvider>
        <AuthProvider>
          <LanguageProvider>
            <Suspense fallback={<div>Đang tải...</div>}>
              <App />
            </Suspense>
          </LanguageProvider>
        </AuthProvider>
      </CssVarsProvider>
    </StrictMode>
  </Auth0Provider>
)