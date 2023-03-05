import { htmlGeneratorFactory } from '../html/html-generator-factory';

const runShellFeature = () => {
    const app: HTMLElement | null = document!.getElementById("app");
    const text = document.createTextNode("Loading...")
    app!.appendChild(text);

    while (app?.hasChildNodes()) {
        app?.removeChild(app.firstChild!);
    }

    const htmlGenerator = htmlGeneratorFactory();
    app!.appendChild(htmlGenerator.getHtml());
};

export default runShellFeature;