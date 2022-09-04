"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const html_generator_factory_1 = require("../html/html-generator-factory");
const runShellFeature = () => {
    const app = document.getElementById("app");
    const text = document.createTextNode("Loading...");
    app.appendChild(text);
    while (app === null || app === void 0 ? void 0 : app.hasChildNodes()) {
        app === null || app === void 0 ? void 0 : app.removeChild(app.firstChild);
    }
    const htmlGenerator = html_generator_factory_1.htmlGeneratorFactory();
    app.appendChild(htmlGenerator.getHtml());
};
exports.default = runShellFeature;
//# sourceMappingURL=shellFeature.js.map