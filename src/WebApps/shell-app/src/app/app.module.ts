import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ComponentLoaderComponent } from './component-loader/component-loader.component';
import { ComponentRegisterComponent } from './component-register/component-register.component';
import { CellContainerComponent } from './cell-container/cell-container.component';

import { ShellServiceModule } from 'shell-service';
import { MfeService } from "shell-service";
import { PageComponent } from './page/page.component';
import { ModalComponent } from './shared/modal/modal.component';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';

@NgModule({
  declarations: [
    AppComponent,
    ComponentLoaderComponent,
    ComponentRegisterComponent,
    CellContainerComponent,
    PageComponent,
    ModalComponent,
    AuthCallbackComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ShellServiceModule
  ],
  providers: [
    MfeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
