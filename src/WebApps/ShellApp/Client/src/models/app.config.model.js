"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class AppConfig {
    constructor(auth_authority, auth_client_id, auth_scope, auth_redirect_uri) {
        this._auth_authority = '';
        this._auth_client_id = '';
        this._auth_scope = '';
        this._auth_redirect_uri = '';
        this._auth_authority = auth_authority;
        this._auth_client_id = auth_client_id;
        this._auth_scope = auth_scope;
        this._auth_redirect_uri = auth_redirect_uri;
    }
    get auth_authority() {
        return this._auth_authority;
    }
    get auth_client_id() {
        return this._auth_client_id;
    }
    get auth_scope() {
        return this._auth_scope;
    }
    get auth_redirect_uri() {
        return this._auth_redirect_uri;
    }
}
exports.default = AppConfig;
//# sourceMappingURL=app.config.model.js.map