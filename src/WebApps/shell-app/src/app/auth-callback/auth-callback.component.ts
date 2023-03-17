import { Component, OnInit } from '@angular/core';

import { AuthService } from '../core/services';
//import { AppConfig } from '../core/models';

@Component({
  selector: 'app-auth-callback',
  templateUrl: './auth-callback.component.html',
  styleUrls: ['./auth-callback.component.scss']
})
export class AuthCallbackComponent implements OnInit {

  constructor(private authService: AuthService) {
  }

  async ngOnInit() {
    await this.authService.signinCallback();
  }
}
