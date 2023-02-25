import { Component, OnInit } from '@angular/core';
import { of } from 'rxjs';
import { delay } from 'rxjs/operators';

import { AuthService } from '../core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    const o1 = of([]);
    const o2 = o1.pipe(delay(6000));

    /*(async () => {
      await this.authService.init();
      this.authService.login();
    });*/

    this.authService.init();

    o2.subscribe(result => {
      this.authService.login();
    });
    
  }
}
