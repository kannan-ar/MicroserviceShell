import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';

import { AuthService } from './core/services/auth.service';
import ConfigService from './core/services/config.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,   
    AppRoutingModule
  ],
  providers: [
    ConfigService,
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
