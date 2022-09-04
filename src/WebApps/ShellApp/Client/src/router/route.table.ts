import runShellFeature from '../features/shellFeature';
import runAuthCallbackFeature from '../features/authCallbackFeature';

export interface RouterTable {
    path: string;
    isregex: boolean;
    component: () => void;
}

const routeTable: RouterTable[] = [
    {
        path: '/',
        isregex: false,
        component: () => {
            runShellFeature();
        }
    },
    {
        path: '/Shell/Index',
        isregex: false,
        component: () => {
            runShellFeature();
        }
    },
    {
        path: '\/Shell\/Callback?(.*)',
        isregex: true,
        component: () => {
            runAuthCallbackFeature();
        }
    }
];

export default routeTable;