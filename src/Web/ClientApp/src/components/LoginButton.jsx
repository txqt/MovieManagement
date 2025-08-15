import { useAuth0 } from "@auth0/auth0-react";
import { useTranslation } from 'react-i18next';
import {
    Button,
} from '@mui/joy';
import { useNavigate } from 'react-router-dom';

const LoginButton = () => {
    const { t } = useTranslation();
    const { loginWithRedirect } = useAuth0();
    const navigate = useNavigate();

    return (<Button onClick={() => window.location.href = '/Identity/Account/Login'} variant="outlined" size="sm">
        {t('loginButtonText')}
    </Button>)
};

export default LoginButton;