import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'div[app-generic-confirm]',
  templateUrl: './generic-confirm.component.html',
  styleUrls: ['./generic-confirm.component.scss']
})
export class GenericConfirmComponent implements OnInit {

  constructor(public bsModalRef: BsModalRef) { }

  title = ''
  message = ''
  confirmText = ''
  data : any

  @Output() confirmed = new EventEmitter<any>();

  ngOnInit(): void {
  }

  confirmar(){
    this.confirmed.emit(this.data)
    this.bsModalRef.hide()
  }
}
