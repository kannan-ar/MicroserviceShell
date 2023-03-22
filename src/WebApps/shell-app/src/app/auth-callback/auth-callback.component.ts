import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { filter, first } from 'rxjs/operators';
import { AppConfig } from '../core/models';
import { AuthService } from '../core/services';
import { selectConfig } from '../store/platform';

@Component({
  selector: 'app-auth-callback',
  templateUrl: './auth-callback.component.html',
  styleUrls: ['./auth-callback.component.scss']
})
export class AuthCallbackComponent implements OnInit {

  authService: AuthService | undefined;
  
  constructor(private store: Store<{ config: AppConfig }>) {
  }

  ngOnInit() {
    this.store.select(selectConfig).pipe(filter(x => x.auth_authority !== "")).pipe(first()).subscribe(x => {
      this.authService = new AuthService(x);
      this.authService.signinRedirect();
    });
  }
}
