"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const toolkit_1 = require("@reduxjs/toolkit");
const settingSlice_1 = __importDefault(require("./reducers/settingSlice"));
const store = toolkit_1.configureStore({
    reducer: {
        setting: settingSlice_1.default
    }
});
exports.default = store;
//# sourceMappingURL=index.js.map