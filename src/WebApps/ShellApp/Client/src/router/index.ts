import { Service } from 'typedi';
import routeTable, { RouterTable } from './route.table';

@Service()
export default class Router {

    isRouteMatch(routeItem: RouterTable, relpath: string): boolean {
        if (!routeItem.isregex) {
            return routeItem.path === relpath;
        } else {
            return relpath.match(routeItem.path) === null;
        }
    }

    matchAndLoadComponent() {
        const match = window.location.href.match(/http(s)*:\/\/.+?(?<relpath>\/.*)/);

        if (match === null || match === undefined || match.groups === undefined) return;
        console.log(match);
        const relpath = match.groups['relpath'];
        console.log(relpath);
        const item = routeTable.filter(x => this.isRouteMatch(x, relpath))[0];
        console.log(item);
        if (item !== undefined) {
            item.component();
        }
    }

    public loadRouter(): void {
        const fn = this.matchAndLoadComponent;

        this.matchAndLoadComponent();

        window.addEventListener('locationchange', function () {
            fn();
        });
    }



}