import { configureStore } from '@reduxjs/toolkit';
import settingReducer from './reducers/settingSlice';

const store = configureStore({
    reducer: {
        setting: settingReducer
    }
});

export type RootState = ReturnType<typeof store.getState>
export default store