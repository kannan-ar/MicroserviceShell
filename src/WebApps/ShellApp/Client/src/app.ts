import 'reflect-metadata';
import { Container } from 'typedi';

import './app.scss';
import Router from './router';
import ConfigService from './services/config.service';
import store from './store';
import { configUpdated } from './store/reducers/settingSlice';

domReady(function () {
    const configService = Container.get(ConfigService);

    configService.loadConfiguration().then(config => {
        console.log(config?.auth_client_id);
        store.dispatch(configUpdated({
            authority: config?.auth_authority,
            client_id: config?.auth_client_id,
            scope: config?.auth_scope,
            redirect_uri: config?.auth_redirect_uri
        }));

        const router = Container.get(Router);
        router.loadRouter();
    });
});


function domReady(fn: EventListener) {
    if (document.readyState === "complete" || document.readyState === "interactive") {
        setTimeout(fn, 1);
    }
    else {
        document.addEventListener("DOMContentLoaded", fn);
    }
}