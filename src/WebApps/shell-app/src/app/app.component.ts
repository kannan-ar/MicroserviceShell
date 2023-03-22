import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { filter, first } from 'rxjs/operators';

import { AppConfig } from './core/models';
import { AuthService } from './core/services';
import { getConfig, selectConfig } from './store/platform';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'shell-app';
  authService: AuthService | undefined;
  
  constructor(private store: Store<{ config: AppConfig }>) {
    store.dispatch(getConfig());
  }

  ngOnInit() {
    this.store.select(selectConfig).pipe(filter(x => x.auth_authority !== "")).pipe(first()).subscribe(x => {
      this.authService = new AuthService(x);
    });
  }

  public async onLogin() {
    await this.authService!.login();
  }

  public async onLogout() {
    console.log(await this.authService!.getUser());
  }
}
