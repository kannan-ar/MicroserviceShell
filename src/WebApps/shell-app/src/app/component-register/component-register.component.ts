import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-component-register',
  templateUrl: './component-register.component.html',
  styleUrls: ['./component-register.component.scss']
})
export class ComponentRegisterComponent implements OnInit {


  ngOnInit(): void {
  }

  onOk() {
    console.log('onOk');
  }

  onCancel() {
    console.log('onCancel');
  }
}
