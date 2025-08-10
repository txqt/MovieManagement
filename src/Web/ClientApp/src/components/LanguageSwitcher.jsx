import { useState } from 'react';
import { Button, Menu, MenuItem, Divider, Typography } from '@mui/joy';
import { useLanguage } from '../context/LanguageContext';

function LanguageSwitcher() {
  const {
    languages,
    defaultLang,
    fallbackLang,
    selectDefaultLanguage,
    selectFallbackLanguage,
    applyChanges,
    resetLanguageSettings,
    changed
  } = useLanguage();

  const [anchorEl, setAnchorEl] = useState(null);
  const [showDefaultList, setShowDefaultList] = useState(false);
  const [showFallbackList, setShowFallbackList] = useState(false);

  const open = Boolean(anchorEl);

  const handleToggleMenu = (event) => {
    setAnchorEl(anchorEl ? null : event.currentTarget);
    setShowDefaultList(false);
    setShowFallbackList(false);
  };

  return (
    <>
      <Button
        variant="outlined"
        size="sm"
        onClick={handleToggleMenu}
        aria-controls={open ? 'language-menu' : undefined}
        aria-haspopup="true"
        aria-expanded={open ? 'true' : undefined}
      >
        🌐 {defaultLang.toUpperCase()} / {fallbackLang.toUpperCase()}
      </Button>

      <Menu
        id="language-menu"
        anchorEl={anchorEl}
        open={open}
        onClose={() => setAnchorEl(null)}
        placement="bottom-end"
        variant="outlined"
        sx={{ minWidth: 220 }}
      >
        {/* Default Language Toggle */}
        <MenuItem
          onClick={() => {
            setShowDefaultList(!showDefaultList);
            setShowFallbackList(false);
          }}
          sx={{ justifyContent: 'space-between' }}
        >
          <Typography>
            📌 Default Language: <strong>{defaultLang.toUpperCase()}</strong>
          </Typography>
          <Typography fontSize="sm">{showDefaultList ? '▲' : '▼'}</Typography>
        </MenuItem>

        {showDefaultList &&
          languages.map(lang => (
            <MenuItem
              key={`def-${lang.code}`}
              selected={defaultLang === lang.code}
              onClick={() => selectDefaultLanguage(lang.code)}
              sx={{ pl: 4 }}
            >
              {lang.label}
            </MenuItem>
          ))}

        {/* Fallback Language Toggle */}
        <MenuItem
          onClick={() => {
            setShowFallbackList(!showFallbackList);
            setShowDefaultList(false);
          }}
          sx={{ justifyContent: 'space-between' }}
        >
          <Typography>
            🛟 Fallback Language: <strong>{fallbackLang.toUpperCase()}</strong>
          </Typography>
          <Typography fontSize="sm">{showFallbackList ? '▲' : '▼'}</Typography>
        </MenuItem>

        {showFallbackList &&
          languages.map(lang => (
            <MenuItem
              key={`fb-${lang.code}`}
              selected={fallbackLang === lang.code}
              onClick={() => selectFallbackLanguage(lang.code)}
              sx={{ pl: 4 }}
            >
              {lang.label}
            </MenuItem>
          ))}

        <Divider />

        {changed && (
          <MenuItem
            onClick={() => {
              applyChanges();
              setAnchorEl(null);
            }}
            sx={{ color: 'success.main' }}
          >
            🔄 Reload
          </MenuItem>
        )}

        <MenuItem
          onClick={() => {
            resetLanguageSettings();
            setAnchorEl(null);
          }}
          sx={{ color: 'danger.main' }}
        >
          ♻️ Reset to Default
        </MenuItem>
      </Menu>
    </>
  );
}

export default LanguageSwitcher;