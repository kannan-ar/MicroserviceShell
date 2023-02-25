import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import AuthModel from '../models/auth.model'
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export default class ConfigService {
    constructor(private http: HttpClient) {
    }

    public loadConfiguration(): Observable<AuthModel> {
        let configPath = `http://localhost:7001/assets/config.json`;
        return this.http.get<AuthModel>(configPath);
    }
}