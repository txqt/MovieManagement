import { createContext, useContext, useCallback, useEffect, useState } from 'react';
import { useTranslation } from 'react-i18next';

const languages = [
  { code: 'en', label: 'English' },
  { code: 'vi', label: 'Tiếng Việt' },
];

const LanguageContext = createContext();

export const LanguageProvider = ({ children }) => {
  const { i18n } = useTranslation();
  const [currentLang, setCurrentLang] = useState(i18n.language);
  const [defaultLang, setDefaultLang] = useState('en');
  const [fallbackLang, setFallbackLang] = useState('en');
  const [changed, setChanged] = useState(false);

  // Khi load trang
  useEffect(() => {
    const savedLang = localStorage.getItem('lang');
    const savedDefault = localStorage.getItem('defaultLang');
    const savedFallback = localStorage.getItem('fallbackLang');

    if (savedLang) {
      i18n.changeLanguage(savedLang);
      setCurrentLang(savedLang);
    }
    if (savedDefault) setDefaultLang(savedDefault);
    if (savedFallback) setFallbackLang(savedFallback);
  }, [i18n]);

  // Đổi ngôn ngữ tạm (chưa apply)
  const selectDefaultLanguage = (lng) => {
    setDefaultLang(lng);
    setChanged(true);
  };

  const selectFallbackLanguage = (lng) => {
    setFallbackLang(lng);
    setChanged(true);
  };

  // Apply ngôn ngữ
  const applyChanges = () => {
    i18n.changeLanguage(defaultLang);
    setCurrentLang(defaultLang);
    localStorage.setItem('lang', defaultLang);
    localStorage.setItem('defaultLang', defaultLang);
    localStorage.setItem('fallbackLang', fallbackLang);
    setChanged(false);
  };

  // Reset về mặc định
  const resetLanguageSettings = () => {
    setDefaultLang('en');
    setFallbackLang('en');
    i18n.changeLanguage('en');
    setCurrentLang('en');
    localStorage.removeItem('lang');
    localStorage.removeItem('defaultLang');
    localStorage.removeItem('fallbackLang');
    setChanged(false);
  };

  return (
    <LanguageContext.Provider
      value={{
        languages,
        currentLang,
        defaultLang,
        fallbackLang,
        selectDefaultLanguage,
        selectFallbackLanguage,
        applyChanges,
        resetLanguageSettings,
        changed
      }}
    >
      {children}
    </LanguageContext.Provider>
  );
};

export const useLanguage = () => useContext(LanguageContext);