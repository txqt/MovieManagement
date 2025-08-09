import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  https: true,
  host: 'localhost',
  css: {
    preprocessorOptions: {
      scss: {
        silenceDeprecations: ['color-functions'],
      }
    }
  }
})