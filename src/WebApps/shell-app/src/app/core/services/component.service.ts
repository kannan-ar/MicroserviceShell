import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ComponentBase } from "../models/component-base";
import { ConfigService } from "./config.service";

@Injectable({
    providedIn: 'root'
})
export class ComponentService {
    constructor(
        private http: HttpClient,
        private configService: ConfigService) {
    }

    getComponents(): Observable<ComponentBase> {
        return this.http.get<ComponentBase>(`${this.configService.appConfig?.api_base_url}/components`);
    }
}