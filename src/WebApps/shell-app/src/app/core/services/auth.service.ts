import { Injectable } from "@angular/core";
import { User, UserManager } from 'oidc-client-ts';

import { AppConfig } from "../models";

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    userManager: UserManager | undefined;

    public init(config: AppConfig) {
        this.userManager = new UserManager({
            authority: config.auth_authority,
            client_id: config.auth_client_id,
            response_type: 'code',
            scope: config.auth_scope,
            redirect_uri: config.auth_redirect_uri
        });
    }

    public login(): Promise<void> {
        return this.userManager!.signinRedirect();
    }

    public renewToken(): Promise<User | null> {
        return this.userManager!.signinSilent();
    }

    public logout(): Promise<void> {
        return this.userManager!.signoutRedirect();
    }

    public signinRedirect() {
        this.userManager!.signinRedirectCallback().then(function () {
            window.location.href = "/";
        }).catch(function (e: any) {
            console.error(e);
        });
    }
}
