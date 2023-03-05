import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class ComponentService {
    constructor(private http: HttpClient) {
    }

    getComponents(): string {
        return "ok";
    }
}