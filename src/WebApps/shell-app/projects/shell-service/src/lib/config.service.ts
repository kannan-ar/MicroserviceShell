import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { AppConfig } from "shell-models";
import { Observable } from "rxjs";

@Injectable()
export default class ConfigService {
    constructor(private http: HttpClient) {
    }

    public loadConfiguration(): Observable<AppConfig> | undefined {
        try {
            let configPath = `${window.location.origin}/config.json`;
            return this.http.get<AppConfig>(configPath);
        } catch (error) {
            return undefined;
        }
    }
}