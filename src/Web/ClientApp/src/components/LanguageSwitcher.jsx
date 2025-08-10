import { useState } from 'react';
import { Dropdown } from 'react-bootstrap';
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

  const [showDefaultList, setShowDefaultList] = useState(false);
  const [showFallbackList, setShowFallbackList] = useState(false);

  return (
    <Dropdown align="end" autoClose="outside">
      <Dropdown.Toggle variant="light" size="sm" id="dropdown-language">
        🌐 {defaultLang.toUpperCase()} / {fallbackLang.toUpperCase()}
      </Dropdown.Toggle>

      <Dropdown.Menu style={{ minWidth: '220px' }}>
        {/* Nút mở danh sách Default */}
        <Dropdown.Item
          onClick={(e) => {
            e.preventDefault();
            setShowDefaultList(!showDefaultList);
            setShowFallbackList(false);
          }}
        >
          📌 Default Language: <strong>{defaultLang.toUpperCase()}</strong>
        </Dropdown.Item>
        {showDefaultList &&
          languages.map(lang => (
            <Dropdown.Item
              key={`def-${lang.code}`}
              active={defaultLang === lang.code}
              onClick={(e) => {
                e.preventDefault();
                selectDefaultLanguage(lang.code);
              }}
              className="ps-4"
            >
              {lang.label}
            </Dropdown.Item>
          ))}

        {/* Nút mở danh sách Fallback */}
        <Dropdown.Item
          onClick={(e) => {
            e.preventDefault();
            setShowFallbackList(!showFallbackList);
            setShowDefaultList(false);
          }}
        >
          🛟 Fallback Language: <strong>{fallbackLang.toUpperCase()}</strong>
        </Dropdown.Item>
        {showFallbackList &&
          languages.map(lang => (
            <Dropdown.Item
              key={`fb-${lang.code}`}
              active={fallbackLang === lang.code}
              onClick={(e) => {
                e.preventDefault();
                selectFallbackLanguage(lang.code);
              }}
              className="ps-4"
            >
              {lang.label}
            </Dropdown.Item>
          ))}

        <Dropdown.Divider />

        {/* Reload */}
        {changed && (
          <Dropdown.Item className="text-success" onClick={() => applyChanges()}>
            🔄 Reload
          </Dropdown.Item>
        )}

        {/* Reset */}
        <Dropdown.Item className="text-danger" onClick={() => resetLanguageSettings()}>
          ♻️ Reset to Default
        </Dropdown.Item>
      </Dropdown.Menu>
    </Dropdown>
  );
}

export default LanguageSwitcher;