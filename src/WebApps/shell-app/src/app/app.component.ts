import { Component } from '@angular/core';
import { AuthService } from 'shell-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'shell-app';

  constructor(private authService: AuthService) {
    authService.init();
  }

  public onLogin() {
    this.authService.login();
  }
}
