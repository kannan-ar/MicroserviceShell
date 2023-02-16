import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-cell-container',
  templateUrl: './cell-container.component.html',
  styleUrls: ['./cell-container.component.scss']
})
export class CellContainerComponent implements OnInit {

  @Input()
  remoteName: string = '';

  @Input()
  remoteEndpoint: string = '';

  @Input()
  componentName: string = '';
  
  constructor() { }

  ngOnInit(): void {
  }

}
