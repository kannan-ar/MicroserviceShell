"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const typedi_1 = __importDefault(require("typedi"));
const auth_service_1 = __importDefault(require("../../services/auth.service"));
class BootstrapHtmlGenerator {
    getHtml() {
        const a = document.createElement('a');
        a.addEventListener("click", this.login, false);
        a.innerHTML = "login";
        return a;
    }
    login() {
        var authService = typedi_1.default.get(auth_service_1.default);
        authService.login();
        console.log("login");
    }
}
exports.default = BootstrapHtmlGenerator;
//# sourceMappingURL=bootstrap-html-generator.js.map