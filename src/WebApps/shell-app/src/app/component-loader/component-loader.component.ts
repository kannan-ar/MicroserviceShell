import { Component, OnInit, ViewContainerRef } from '@angular/core';
import {FileType, MfeUtil} from "utils";

export const mfe = new MfeUtil();

@Component({
  selector: 'app-component-loader',
  templateUrl: './component-loader.component.html',
  styleUrls: ['./component-loader.component.scss']
})
export class ComponentLoaderComponent implements OnInit {

  constructor(private viewCRef: ViewContainerRef) { }

  async ngOnInit() {
    const LoginComponent =  await mfe.loadRemoteFile({
      remoteName: "identity",
      remoteEntry: `http://localhost:8001/remoteIdentity.js`,
      exposedFile: "LoginComponent",
      exposeFileType: FileType.Component,
    }).then((m) => m.LoginComponent);

    this.viewCRef.createComponent(LoginComponent);
  }
}
