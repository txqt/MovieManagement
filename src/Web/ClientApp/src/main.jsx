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

createRoot(document.getElementById('root')).render(
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
)