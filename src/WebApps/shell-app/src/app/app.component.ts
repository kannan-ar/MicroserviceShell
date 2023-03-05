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
    store.dispatch(getConfig());
    this.store.select(selectConfig).subscribe(x => this.authService.init(x));
  }

  public onLogin() {
    this.authService.login();
  }
}
