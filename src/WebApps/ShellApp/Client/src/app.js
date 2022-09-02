"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
require("reflect-metadata");
const typedi_1 = require("typedi");
require("./app.scss");
const html_generator_factory_1 = require("./html/html-generator-factory");
const config_service_1 = __importDefault(require("./services/config.service"));
const store_1 = __importDefault(require("./store"));
const settingSlice_1 = require("./store/reducers/settingSlice");
domReady(function () {
    const app = document.getElementById("app");
    const configService = typedi_1.Container.get(config_service_1.default);
    const text = document.createTextNode("Loading...");
    app.appendChild(text);
    configService.loadConfiguration().then(config => {
        store_1.default.dispatch(settingSlice_1.configUpdated({
            authority: config === null || config === void 0 ? void 0 : config.auth_authority,
            client_id: config === null || config === void 0 ? void 0 : config.auth_client_id,
            scope: config === null || config === void 0 ? void 0 : config.auth_scope,
            redirect_uri: config === null || config === void 0 ? void 0 : config.auth_redirect_uri
        }));
        loadHtml(app);
    });
});
const loadHtml = (app) => {
    while (app === null || app === void 0 ? void 0 : app.hasChildNodes()) {
        app === null || app === void 0 ? void 0 : app.removeChild(app.firstChild);
    }
    const htmlGenerator = html_generator_factory_1.htmlGeneratorFactory();
    app.appendChild(htmlGenerator.getHtml());
};
function domReady(fn) {
    if (document.readyState === "complete" || document.readyState === "interactive") {
        setTimeout(fn, 1);
    }
    else {
        document.addEventListener("DOMContentLoaded", fn);
    }
}
//# sourceMappingURL=app.js.map