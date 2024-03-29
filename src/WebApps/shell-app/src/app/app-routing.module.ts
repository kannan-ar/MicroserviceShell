import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { ComponentRegisterComponent } from './component-register/component-register.component';
import { AuthGuardService } from './core/services/auth-guard.service';
import { PageComponent } from './page/page.component';

const routes: Routes = [
  {
    path: '',
    component: PageComponent
  },
  {
    path: 'auth_callback',
    component: AuthCallbackComponent
  },
  {
    path: 'register',
    component: ComponentRegisterComponent,
    canActivate: [AuthGuardService]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
