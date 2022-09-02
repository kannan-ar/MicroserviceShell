"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const oidc_client_ts_1 = require("oidc-client-ts");
const typedi_1 = require("typedi");
const store_1 = __importDefault(require("../store"));
let AuthService = class AuthService {
    constructor() {
        const { setting } = store_1.default.getState();
        this.userManager = new oidc_client_ts_1.UserManager({
            authority: setting.authority,
            client_id: setting.client_id,
            response_type: 'code',
            scope: setting.scope,
            redirect_uri: setting.redirect_uri
        });
    }
    login() {
        return this.userManager.signinRedirect();
    }
    renewToken() {
        return this.userManager.signinSilent();
    }
    logout() {
        return this.userManager.signoutRedirect();
    }
    signinRedirect() {
        this.userManager.signinRedirectCallback().then(function () {
            window.location.href = "/Shell/Index";
        }).catch(function (e) {
            console.error(e);
        });
    }
};
AuthService = __decorate([
    typedi_1.Service(),
    __metadata("design:paramtypes", [])
], AuthService);
exports.default = AuthService;
//# sourceMappingURL=auth.service.js.map