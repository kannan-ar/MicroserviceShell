import { Injectable } from "@angular/core";
import { User, UserManager } from 'oidc-client-ts';
import { AppConfig } from "shell-models";

@Injectable()
export class AuthService {
    userManager: UserManager;

    constructor() {
        const setting: AppConfig = {};

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
            window.location.href = "/";
        }).catch(function (e: any) {
            console.error(e);
        });

    }
}