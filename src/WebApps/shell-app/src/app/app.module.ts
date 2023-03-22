import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
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
    StoreModule.forRoot(reducers, {
      metaReducers
    }),
    EffectsModule.forRoot([PlatformEffects])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
