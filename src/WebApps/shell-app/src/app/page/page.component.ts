import { Component, OnInit } from '@angular/core';
import { ComponentService } from '../core/services/component.service';

@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.scss']
})
export class PageComponent implements OnInit {

  constructor(private componentService: ComponentService) { }

  ngOnInit() {
    //this.componentService.getComponents().subscribe(x => console.log(x));
  }
}
