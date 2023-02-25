import { User, UserManager } from 'oidc-client-ts';
import { Service } from 'typedi';
import store from '../store';

@Service()
export default class AuthService {
    userManager: UserManager;

    constructor() {
        const { setting } = store.getState();
        console.log(setting);
        this.userManager = new UserManager({
            authority: setting.authority,
            client_id: setting.client_id,
            response_type: 'code',
            scope: setting.scope,
            redirect_uri: setting.redirect_uri
        });
    }

    public login(): Promise<void> {
        return this.userManager.signinRedirect();
    }

    public renewToken(): Promise<User | null> {
        return this.userManager.signinSilent();
    }

    public logout(): Promise<void> {
        return this.userManager.signoutRedirect();
    }

    public signinRedirect() {
        console.log(this.userManager.settings);
        this.userManager.signinRedirectCallback().then(function () {
            window.location.href = "/Shell/Index";
        }).catch(function (e) {
            console.error(e);
        });

    }
}