import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

import { Page } from "shell-models";

@Injectable()
export class PageService {
    constructor(private http: HttpClient) {
    }

    getPages(): Promise<Page[]> {
        return new Promise();
    }

    getPage(pageName: string): Promise<Page> {

    }
}