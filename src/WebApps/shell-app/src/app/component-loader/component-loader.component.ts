import { Component, Input, OnInit, ViewContainerRef } from '@angular/core';
import { MfeService } from '../core/services';

@Component({
  selector: 'app-component-loader',
  templateUrl: './component-loader.component.html',
  styleUrls: ['./component-loader.component.scss']
})
export class ComponentLoaderComponent implements OnInit {

  @Input()
  remoteName: string = '';

  @Input()
  remoteEndpoint: string = '';

  @Input()
  componentName: string = '';

  constructor(private viewCRef: ViewContainerRef, private mfe: MfeService) { }

  async ngOnInit() {
    const LoginComponent =  await this.mfe.loadRemoteFile({
      remoteName: this.remoteName,
      remoteEntry: this.remoteEndpoint,
      exposedFile: this.componentName,
    }).then((m) => m.LoginComponent);

    this.viewCRef.createComponent(LoginComponent);
  }
}
