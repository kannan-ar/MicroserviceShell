"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const typedi_1 = __importDefault(require("typedi"));
const auth_service_1 = __importDefault(require("../services/auth.service"));
const runAuthCallbackFeature = () => {
    const authService = typedi_1.default.get(auth_service_1.default);
    authService.signinRedirect();
};
exports.default = runAuthCallbackFeature;
//# sourceMappingURL=authCallbackFeature.js.map