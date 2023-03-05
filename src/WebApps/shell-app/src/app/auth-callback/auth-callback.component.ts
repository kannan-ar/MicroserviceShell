import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';

import { AuthService } from '../core/services';
import { AppConfig } from '../core/models';
import { getConfig } from '../store/platform';
import { selectConfig } from '../store/platform';

@Component({
  selector: 'app-auth-callback',
  templateUrl: './auth-callback.component.html',
  styleUrls: ['./auth-callback.component.scss']
})
export class AuthCallbackComponent implements OnInit {

  constructor(
    private store: Store<{ config: AppConfig }>,
    private authService: AuthService) {
    store.dispatch(getConfig());
    
  }

  ngOnInit(): void {
    this.store.select(selectConfig).subscribe(x => {
      this.authService.init(x);
      this.authService.signinRedirect();
    });
    
  }

}
