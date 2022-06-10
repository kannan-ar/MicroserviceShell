"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
require("./app.scss");
const html_generator_factory_1 = require("./services/html-generator-factory");
domReady(function () {
    const htmlGenerator = html_generator_factory_1.htmlGeneratorFactory();
    document.getElementById("app").innerHTML = htmlGenerator.getHtml();
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