import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-component-register',
  templateUrl: './component-register.component.html',
  styleUrls: ['./component-register.component.scss']
})
export class ComponentRegisterComponent implements OnInit {

  public readonly myFormGroup: FormGroup;

  constructor(private readonly formBuilder: FormBuilder) {
    this.myFormGroup = this.formBuilder.group({
      remoteName: ['', Validators.required],
      remoteEndpoint: ['', Validators.required],
      componentName: ['', Validators.required],
      requrireAuthentication: false
    });
  }

  ngOnInit(): void {
  }

  onOk() {
    console.log('onOk');
  }

  onCancel() {
    console.log('onCancel');
  }
}
