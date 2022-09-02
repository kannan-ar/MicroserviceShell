"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.configUpdated = void 0;
const toolkit_1 = require("@reduxjs/toolkit");
const initialState = {
    authority: '',
    client_id: '',
    scope: '',
    redirect_uri: ''
};
const configSlice = toolkit_1.createSlice({
    name: 'settings',
    initialState,
    reducers: {
        configUpdated(state, action) {
            state.authority = action.payload.authority;
            state.client_id = action.payload.client_id;
            state.scope = action.payload.scope;
            state.redirect_uri = action.payload.redirect_uri;
        }
    }
});
exports.configUpdated = configSlice.actions.configUpdated;
exports.default = configSlice.reducer;
//# sourceMappingURL=settingSlice.js.map