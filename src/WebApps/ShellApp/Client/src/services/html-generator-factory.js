"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.htmlGeneratorFactory = void 0;
const bootstrap_html_generator_1 = __importDefault(require("./bootstrap/bootstrap-html-generator"));
const htmlGeneratorFactory = () => {
    return new bootstrap_html_generator_1.default();
};
exports.htmlGeneratorFactory = htmlGeneratorFactory;
//# sourceMappingURL=html-generator-factory.js.map