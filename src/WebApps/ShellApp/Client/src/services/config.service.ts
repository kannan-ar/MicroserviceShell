import axios from "axios";
import { Service } from 'typedi';
import AppConfig from "../models/app.config.model";

@Service()
export default class ConfigService {
    public async loadConfiguration(): Promise<AppConfig | undefined> {
        try {
            let configPath = '';

            if (process.env.NODE_ENV === 'production') {
                configPath = `${window.location.origin}/config.json`;
            } else {
                configPath = `${window.location.origin}/config.local.json`;
            }

            return (await axios.get<AppConfig>(configPath)).data;
        } catch (error) {
            return undefined;
        }
    }
}