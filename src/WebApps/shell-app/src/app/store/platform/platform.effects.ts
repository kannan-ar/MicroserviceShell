
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { ConfigService } from '../../core/services';
import * as PlatformActions from './platform.actions';
import { catchError, map, switchMap, tap } from 'rxjs/operators';

@Injectable()
export class PlatformEffects {
    constructor(
        private actions$: Actions<any>,
        private configService: ConfigService
    ) { }

    fetchConfig$ = createEffect(() =>
        this.actions$.pipe(
            ofType(PlatformActions.getConfig.type, PlatformActions.loadConfigSuccess),
            switchMap(() =>
                this.configService.loadConfiguration().pipe(
                    //tap(config => console.log(config)),
                    map((config) =>
                        PlatformActions.loadConfigSuccess({
                            payload: {
                                auth_authority: config.auth_authority,
                                auth_client_id: config.auth_client_id,
                                auth_scope: config.auth_scope,
                                auth_redirect_uri: config.auth_redirect_uri
                            }
                        }))
                )
            )
        )
    )
}