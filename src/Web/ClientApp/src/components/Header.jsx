import { Link, useNavigate } from 'react-router-dom';
import { useState, useContext } from 'react';
import { AuthContext } from '../context/AuthContext';
import { Trans, useTranslation } from 'react-i18next';

import {
  Box,
  Button,
  Input,
  IconButton,
  Sheet,
  Typography,
  Stack,
  Dropdown,
  Menu,
  MenuButton,
  MenuItem
} from '@mui/joy';
import { Search, Film, Menu as MenuIcon } from 'lucide-react';
import LanguageSwitcher from './LanguageSwitcher';
import ThemeSwitcher from './ThemeSwitcher';
import LoginButton from './LoginButton'
import LogoutButton from './LogoutButton'
import { useAuth0 } from "@auth0/auth0-react";

function Header() {
  const [searchTerm, setSearchTerm] = useState('');
  const navigate = useNavigate();
  const { auth, logout } = useContext(AuthContext);
  const { t } = useTranslation();
  const { user, isAuthenticated, isLoading } = useAuth0();

  const handleSearch = (e) => {
    e.preventDefault();
    if (searchTerm.trim()) {
      navigate(`/search?q=${encodeURIComponent(searchTerm)}`);
    }
  };

  return (
    <Sheet
      component="header"
      variant="outlined"
      sx={{
        position: 'sticky',
        top: 0,
        zIndex: 1000,
        px: 2,
        py: 1,
        display: 'flex',
        alignItems: 'center',
        gap: 2,
        flexWrap: 'wrap', // cho phép xuống dòng khi nhỏ
      }}
    >
      {/* Logo */}
      <Stack
        direction="row"
        alignItems="center"
        spacing={1}
        component={Link}
        to="/"
        sx={{ textDecoration: 'none', color: 'inherit' }}
      >
        <Film size={20} />
        <Typography level="title-lg">MovieHub</Typography>
      </Stack>

      {/* Menu responsive */}
      <Stack
        direction="row"
        spacing={2}
        sx={{
          flexGrow: 1,
          ml: 4,
          display: { xs: 'none', md: 'flex' }, // Ẩn menu khi nhỏ hơn md
        }}
      >
        <Button component={Link} to="/category/action" variant="plain">
          {t('header:categories.action')}
        </Button>
        <Button component={Link} to="/category/comedy" variant="plain">
          {t('header:categories.comedy')}
        </Button>
        <Button component={Link} to="/category/horror" variant="plain">
          {t('header:categories.horror')}
        </Button>
      </Stack>

      {/* Menu icon cho mobile */}
      <Box sx={{ display: { xs: 'block', md: 'none' } }}>
        <Dropdown>
          <MenuButton variant="soft">
            <MenuIcon size={20} />
          </MenuButton>
          <Menu>
            <MenuItem component={Link} to="/category/action">
              {t('header:categories.action')}
            </MenuItem>
            <MenuItem component={Link} to="/category/comedy">
              {t('header:categories.comedy')}
            </MenuItem>
            <MenuItem component={Link} to="/category/horror">
              {t('header:categories.horror')}
            </MenuItem>
          </Menu>
        </Dropdown>
      </Box>

      {/* Search */}
      <Box
        component="form"
        onSubmit={handleSearch}
        sx={{
          display: 'flex',
          gap: 1,
          flexGrow: { xs: 1, md: 0 },
          order: { xs: 3, md: 0 },
          width: { xs: '100%', md: 'auto' },
        }}
      >
        <Input
          placeholder={t('header:searchMovieText')}
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          size="sm"
          sx={{ flex: 1, marginLeft: { xs: 2, md: 0 } }}
        />
        <IconButton type="submit" variant="soft" color="neutral">
          <Search size={18} />
        </IconButton>
      </Box>

      {/* Auth buttons */}
      <Stack
        direction={{ xs: 'column', sm: 'row' }}
        spacing={1}
        sx={{
          ml: 2,
          order: { xs: 2, md: 0 },
          width: { xs: '100%', sm: 'auto' },
        }}
      >
        {!isAuthenticated ? (
          <>
            <LoginButton />
            <Button component={Link} to="/register" variant="solid" size="sm">
              {t('registerButtonText')}
            </Button>
          </>
        ) : (
          <>
          <Button variant="solid" size="sm">
              {user?.name}
            </Button>
            <LogoutButton />
          </>
        )}
      </Stack>

      {/* Language & Theme */}
      <Box sx={{ ml: 2, order: { xs: 4, md: 0 } }}>
        <LanguageSwitcher />
      </Box>
      <Box sx={{ ml: 1, order: { xs: 5, md: 0 } }}>
        <ThemeSwitcher />
      </Box>
    </Sheet>
  );
}

export default Header;