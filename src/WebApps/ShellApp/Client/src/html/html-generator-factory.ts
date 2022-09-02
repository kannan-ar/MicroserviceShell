import BootstrapHtmlGenerator from "./bootstrap/bootstrap-html-generator";
import IHtmlGenerator from "./html-generator";

export const htmlGeneratorFactory = (): IHtmlGenerator => {
    return new BootstrapHtmlGenerator()
}
