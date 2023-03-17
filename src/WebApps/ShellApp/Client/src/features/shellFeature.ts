import { htmlGeneratorFactory } from '../html/html-generator-factory';
import Container from "typedi";
import AuthService from "../services/auth.service";

const runShellFeature = () => {
    const app: HTMLElement | null = document!.getElementById("app");
    const text = document.createTextNode("Loading...")
    app!.appendChild(text);

    while (app?.hasChildNodes()) {
        app?.removeChild(app.firstChild!);
    }

    const htmlGenerator = htmlGeneratorFactory();
    app!.appendChild(htmlGenerator.getHtml());

    const authService = Container.get(AuthService);
    console.log(authService.getUser());
};

export default runShellFeature;