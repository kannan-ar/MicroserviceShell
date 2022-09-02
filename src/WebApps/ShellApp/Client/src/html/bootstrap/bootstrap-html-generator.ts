import Container from "typedi";
import AuthService from "../../services/auth.service";
import IHtmlGenerator from "../html-generator"

export default class BootstrapHtmlGenerator implements IHtmlGenerator {
    getHtml(): HTMLElement {
        

        const a = document.createElement('a');
        a.addEventListener("click", this.login, false);
        a.innerHTML = "login";
        return a;
    }

    public login() {
        var authService = Container.get(AuthService);
        authService.login();
        console.log("login");
    }
}