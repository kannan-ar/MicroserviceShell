import Container from "typedi";
import AuthService from "../services/auth.service";

const runAuthCallbackFeature = () => {
    const authService = Container.get(AuthService);
    authService.signinRedirect();
}

export default runAuthCallbackFeature;