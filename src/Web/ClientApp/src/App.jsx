import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Login from './pages/Login'
import Register from './pages/Register'
import Profile from './pages/Profile'
import PrivateRoute from './components/PrivateRoute'
import BaseLayout from './components/BaseLayout'
import { CssVarsProvider } from '@mui/joy';

export default function App() {
  return (
    <CssVarsProvider>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<BaseLayout />} />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route
            path="/profile"
            element={
              <PrivateRoute>
                <Profile />
              </PrivateRoute>
            }
          />
        </Routes>
      </BrowserRouter>
    </CssVarsProvider>
  )
}
