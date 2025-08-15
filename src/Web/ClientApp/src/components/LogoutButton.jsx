import { useAuth0 } from "@auth0/auth0-react";
import { useTranslation } from 'react-i18next';
import {
  Button,
} from '@mui/joy';

const LogoutButton = () => {
    const { t } = useTranslation();
    const { logout } = useAuth0();

    return (<Button onClick={() => logout({ logoutParams: { returnTo: window.location.origin } })} variant="outlined" size="sm">
        {t('logoutButtonText')}
    </Button>)
};

export default LogoutButton;