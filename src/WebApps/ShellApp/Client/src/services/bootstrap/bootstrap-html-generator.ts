import IHtmlGenerator from "../html-generator"

export default class BootstrapHtmlGenerator implements IHtmlGenerator {
    getHtml(): string {
        return "bootstrap";
    }
}