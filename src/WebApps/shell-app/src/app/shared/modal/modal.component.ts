import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss']
})
export class ModalComponent implements OnInit {

  @Input() title: string = '';
  @Input() isModal: boolean = false;

  @Output() ok = new EventEmitter();
  @Output() cancel = new EventEmitter();

  modalClass: string = 'block';
  clickHandled: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  get hasTitle(): boolean  {
    return this.title !== '';
  }

  hide() {
    this.modalClass = 'hidden';
  }

  show() {
    this.modalClass = 'show';
  }

  onModalClick() {
    this.clickHandled = true;
  }

  onBackgroundClick() {
    if(this.clickHandled) {
      this.clickHandled = false;
      return;
    }

    if(this.isModal) {
      return;
    }

    this.hide();
  }

  onOk() {
    this.ok.emit();
    this.hide();
  }

  onCancel() {
    this.cancel.emit();
    this.hide();
  }
}
