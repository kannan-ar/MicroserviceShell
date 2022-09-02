import { createSlice } from '@reduxjs/toolkit';

interface SettingState {
    authority: string;
    client_id: string;
    scope: string;
    redirect_uri: string;
}

const initialState: SettingState = {
    authority: '',
    client_id: '',
    scope: '',
    redirect_uri: ''
}

const configSlice = createSlice({
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
})

export const { configUpdated } = configSlice.actions;
export default configSlice.reducer;