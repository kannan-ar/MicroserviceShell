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

  constructor(private authService: AuthService) {
  }

  ngOnInit() {
    this.authService.signinRedirect();
  }
}
