import './app.scss';
import { htmlGeneratorFactory } from './services/html-generator-factory';

domReady(function () {
    const htmlGenerator = htmlGeneratorFactory();
    document!.getElementById("app")!.innerHTML = htmlGenerator.getHtml();
});

function domReady(fn: EventListener) {
    if (document.readyState === "complete" || document.readyState === "interactive") {
        setTimeout(fn, 1);
    }
    else {
        document.addEventListener("DOMContentLoaded", fn);
    }
}