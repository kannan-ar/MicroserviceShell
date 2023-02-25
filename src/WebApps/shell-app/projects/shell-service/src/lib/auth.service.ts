import { Injectable } from "@angular/core";
import { User, UserManager } from 'oidc-client-ts';
import { AppConfig } from "shell-models";
import ConfigService from "./config.service";

@Injectable()
export class AuthService {
    userManager: UserManager | undefined;

    constructor(private configService: ConfigService) {
    }

    public init() {
        this.configService.loadConfiguration().subscribe((authModel: AppConfig) => {
            console.log(authModel);
            this.userManager = new UserManager({
                authority: authModel.auth_authority,
                client_id: authModel.auth_client_id,
                response_type: 'code',
                scope: authModel.auth_scope,
                redirect_uri: authModel.auth_redirect_uri
            });
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