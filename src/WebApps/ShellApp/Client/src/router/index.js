"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const typedi_1 = require("typedi");
const route_table_1 = __importDefault(require("./route.table"));
let Router = class Router {
    isRouteMatch(routeItem, relpath) {
        if (!routeItem.isregex) {
            return routeItem.path === relpath;
        }
        else {
            return relpath.match(routeItem.path) === null;
        }
    }
    matchAndLoadComponent() {
        const match = window.location.href.match(/http(s)*:\/\/.+?(?<relpath>\/.*)/);
        if (match === null || match === undefined || match.groups === undefined)
            return;
        console.log(match);
        const relpath = match.groups['relpath'];
        console.log(relpath);
        const item = route_table_1.default.filter(x => this.isRouteMatch(x, relpath))[0];
        console.log(item);
        if (item !== undefined) {
            item.component();
        }
    }
    loadRouter() {
        const fn = this.matchAndLoadComponent;
        this.matchAndLoadComponent();
        window.addEventListener('locationchange', function () {
            fn();
        });
    }
};
Router = __decorate([
    typedi_1.Service()
], Router);
exports.default = Router;
//# sourceMappingURL=index.js.map