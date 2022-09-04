"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
require("reflect-metadata");
const typedi_1 = require("typedi");
require("./app.scss");
const router_1 = __importDefault(require("./router"));
const config_service_1 = __importDefault(require("./services/config.service"));
const store_1 = __importDefault(require("./store"));
const settingSlice_1 = require("./store/reducers/settingSlice");
domReady(function () {
    const configService = typedi_1.Container.get(config_service_1.default);
    configService.loadConfiguration().then(config => {
        console.log(config === null || config === void 0 ? void 0 : config.auth_client_id);
        store_1.default.dispatch(settingSlice_1.configUpdated({
            authority: config === null || config === void 0 ? void 0 : config.auth_authority,
            client_id: config === null || config === void 0 ? void 0 : config.auth_client_id,
            scope: config === null || config === void 0 ? void 0 : config.auth_scope,
            redirect_uri: config === null || config === void 0 ? void 0 : config.auth_redirect_uri
        }));
        const router = typedi_1.Container.get(router_1.default);
        router.loadRouter();
    });
});
function domReady(fn) {
    if (document.readyState === "complete" || document.readyState === "interactive") {
        setTimeout(fn, 1);
    }
    else {
        document.addEventListener("DOMContentLoaded", fn);
    }
}
//# sourceMappingURL=app.js.map