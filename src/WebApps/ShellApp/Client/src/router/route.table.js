"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const shellFeature_1 = __importDefault(require("../features/shellFeature"));
const authCallbackFeature_1 = __importDefault(require("../features/authCallbackFeature"));
const routeTable = [
    {
        path: '/',
        isregex: false,
        component: () => {
            shellFeature_1.default();
        }
    },
    {
        path: '/Shell/Index',
        isregex: false,
        component: () => {
            shellFeature_1.default();
        }
    },
    {
        path: '\/Shell\/Callback?(.*)',
        isregex: true,
        component: () => {
            authCallbackFeature_1.default();
        }
    }
];
exports.default = routeTable;
//# sourceMappingURL=route.table.js.map