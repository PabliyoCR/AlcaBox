import { Component, Input, OnInit } from '@angular/core';
import {KeyValue} from '@angular/common';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'div[app-generic-detail-modal]',
  templateUrl: './generic-detail-modal.component.html',
  styleUrls: ['./generic-detail-modal.component.scss']
})
export class GenericDetailModalComponent implements OnInit {

  @Input() data : any;
  @Input() title : string

  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
  }

  onCompare(_left: KeyValue<any, any>, _right: KeyValue<any, any>): number {
    return 1;
  }

}
