import { useColorScheme, Button } from '@mui/joy';

export default function ToggleThemeButton() {
  const { mode, setMode } = useColorScheme();

  return (
    <Button
      onClick={() => setMode(mode === 'light' ? 'dark' : 'light')}
      variant="outlined"
    >
      {mode === 'light' ? '🌙 Dark' : '☀️ Light'}
    </Button>
  );
}