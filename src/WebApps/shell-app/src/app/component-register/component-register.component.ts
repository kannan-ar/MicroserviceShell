import { Component, OnInit } from '@angular/core';

import { ComponentService } from 'shell-service';

@Component({
  selector: 'app-component-register',
  templateUrl: './component-register.component.html',
  styleUrls: ['./component-register.component.scss']
})
export class ComponentRegisterComponent implements OnInit {

  constructor(private componentService: ComponentService) { }

  ngOnInit(): void {
  }

  onOk() {
    console.log('onOk');
  }

  onCancel() {
    console.log('onCancel');
  }
}
