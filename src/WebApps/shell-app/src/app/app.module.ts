import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ComponentLoaderComponent } from './component-loader/component-loader.component';
import { ComponentRegisterComponent } from './component-register/component-register.component';
import { CellContainerComponent } from './cell-container/cell-container.component';

import { PageComponent } from './page/page.component';
import { ModalComponent } from './shared/modal/modal.component';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { reducers, metaReducers } from './store';
import { PlatformEffects } from './store/platform';
import { AuthService, ConfigService } from './core/services';
import { AuthInterceptor } from './core/services/auth.interceptor';
import { configServiceFactory } from './core/services/config-service.factory';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    ComponentLoaderComponent,
    ComponentRegisterComponent,
    CellContainerComponent,
    PageComponent,
    ModalComponent,
    AuthCallbackComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    StoreModule.forRoot(reducers, {
      metaReducers
    }),
    EffectsModule.forRoot([PlatformEffects])
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: configServiceFactory,
      deps: [ConfigService],
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      deps: [AuthService],
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
