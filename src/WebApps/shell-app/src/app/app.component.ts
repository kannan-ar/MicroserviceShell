import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppConfig } from './core/models';

import { AuthService } from './core/services';
import { getConfig } from './store/platform';
import { selectConfig } from './store/platform';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'shell-app';

  constructor(
    private authService: AuthService,
    private store: Store<{ config: AppConfig }>) {
      //store.dispatch(getConfig());
  }

  public async onLogin() {
    /*this.store.select(selectConfig).subscribe(x => {
      console.log(x);
      this.authService.init(x);
    });*/
    await this.authService.login();
  }

  public async onLogout() {
    console.log(await this.authService.getUser());
  }
}
