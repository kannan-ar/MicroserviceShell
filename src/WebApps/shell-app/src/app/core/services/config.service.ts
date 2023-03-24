import { Injectable } from "@angular/core";
import { HttpClient, HttpBackend } from "@angular/common/http";

import { AppConfig } from '../models';
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";

//https://betterprogramming.pub/how-to-handle-async-providers-in-angular-51884647366

@Injectable({
    providedIn: 'root'
})
export class ConfigService {

    private http: HttpClient;

    constructor(private handler: HttpBackend) {
        this.http = new HttpClient(this.handler);
    }

    private _appConfig: AppConfig | undefined;

    get appConfig(): AppConfig | undefined {
        return this._appConfig;
    }

    public loadConfiguration(): Observable<AppConfig> {
        let configPath = `${window.location.origin}/assets/config.json`;
        return this.http.get<AppConfig>(configPath);
    }

    public getConfiguration(): Observable<AppConfig> {
        return this.loadConfiguration().pipe(tap(config => (this._appConfig = config)));
    }
}