import { Injectable } from "@angular/core";
import { User, UserManager } from 'oidc-client-ts';
import { Store } from '@ngrx/store';

import { AppConfig } from "../models";
import { selectConfig } from '../../store/platform';
import { getConfig } from '../../store/platform';
import { take } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    userManager: UserManager | undefined;

    constructor(private store: Store<{ config: AppConfig }>) {
        /*store.dispatch(getConfig());
        this.store.select(selectConfig).subscribe(x => {
            this.userManager = new UserManager({
                authority: x.auth_authority,
                client_id: x.auth_client_id,
                response_type: 'code',
                scope: x.auth_scope,
                redirect_uri: x.auth_redirect_uri
            });
          });

          let c: AppConfig | undefined;
          this.store.select(selectConfig).pipe(take(1)).subscribe(x => c = x);
          console.log(c);*/
          this.userManager = new UserManager({
                authority: 'http://host.docker.internal:8001/',
                client_id: 'shellappclient',
                response_type: 'code',
                scope: 'openid profile shellappscope',
                redirect_uri: 'http://host.docker.internal:7000/auth_callback'
            });
    }

    /*public init(config: AppConfig) {
        this.userManager = new UserManager({
            authority: config.auth_authority,
            client_id: config.auth_client_id,
            response_type: 'code',
            scope: config.auth_scope,
            redirect_uri: config.auth_redirect_uri
        });
    }*/

    public login(): Promise<void> {
        return this.userManager!.signinRedirect();
    }

    public renewToken(): Promise<User | null> {
        return this.userManager!.signinSilent();
    }

    public logout(): Promise<void> {
        return this.userManager!.signoutRedirect();
    }

    public async signinCallback() {
        console.log(this.userManager);
        await this.userManager!.signinCallback();
    }

    public signinRedirect() {
        this.userManager!.signinRedirectCallback().then(function () {
            window.location.href = "/";
        }).catch(function (e: any) {
            console.error(e);
        });
    }

    public async isLogged(): Promise<boolean> {
        return await this.userManager!.getUser() !== null;
    }

    public async getUser(): Promise<User | null> {
        return await this.userManager!.getUser();
    }
}
