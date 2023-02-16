export default class AppConfig {
    private _auth_authority: string = '';
    private _auth_client_id: string = '';
    private _auth_scope: string = '';
    private _auth_redirect_uri: string = '';

    constructor(
        auth_authority: string,
        auth_client_id: string,
        auth_scope: string,
        auth_redirect_uri: string) {
        this._auth_authority = auth_authority;
        this._auth_client_id = auth_client_id;
        this._auth_scope = auth_scope;
        this._auth_redirect_uri = auth_redirect_uri;
    }

    get auth_authority(): string {
        return this._auth_authority;
    }

    get auth_client_id(): string {
        return this._auth_client_id;
    }

    get auth_scope(): string {
        return this._auth_scope;
    }

    get auth_redirect_uri(): string {
        return this._auth_redirect_uri;
    }
}