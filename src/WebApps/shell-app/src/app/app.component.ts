import { Component } from '@angular/core';

import { AuthService } from './core/services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'shell-app';
  isLoggedIn: Promise<boolean> | null = null;

  constructor(private authService: AuthService) {
  }

  ngOnInit() {
    this.isLoggedIn = new Promise((resolve, reject) => {
      this.authService!.isLogged().then(result => resolve(result));
    });
  }

  public async onLogin() {
    await this.authService!.login();
  }

  public async onLogout() {
    await this.authService!.logout();
  }

  public async onRegister() {
    
  }
}
