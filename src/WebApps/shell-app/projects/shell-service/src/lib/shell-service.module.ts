import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ComponentService } from './component.service';
import ConfigService from './config.service';
import { AuthService } from './auth.service';

@NgModule({
    imports: [
        HttpClientModule,
    ],
    providers: [
        ConfigService,
        AuthService,
        ComponentService
    ]
})
export class ShellServiceModule {
}