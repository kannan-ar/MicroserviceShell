import 'reflect-metadata';
import { Container } from 'typedi';

import './app.scss';
import { htmlGeneratorFactory } from './html/html-generator-factory';
import ConfigService from './services/config.service';
import store from './store';
import { configUpdated } from './store/reducers/settingSlice';

domReady(function () {
    const app = document!.getElementById("app");
    const configService = Container.get(ConfigService);
    const text = document.createTextNode("Loading...")
    app!.appendChild(text);

    configService.loadConfiguration().then(config => {
        store.dispatch(configUpdated({
            authority: config?.auth_authority,
            client_id: config?.auth_client_id,
            scope: config?.auth_scope,
            redirect_uri: config?.auth_redirect_uri
        }));

        loadHtml(app);
    });
});

const loadHtml = (app: HTMLElement | null) => {

    while (app?.hasChildNodes()) {
        app?.removeChild(app.firstChild!);
    }

    const htmlGenerator = htmlGeneratorFactory();
    app!.appendChild(htmlGenerator.getHtml());
}


function domReady(fn: EventListener) {
    if (document.readyState === "complete" || document.readyState === "interactive") {
        setTimeout(fn, 1);
    }
    else {
        document.addEventListener("DOMContentLoaded", fn);
    }
}