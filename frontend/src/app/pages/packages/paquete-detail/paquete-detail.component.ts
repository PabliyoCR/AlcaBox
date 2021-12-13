import { KeyValue } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { PaqueteDTO } from 'src/app/shared/models/DTOs/PaqueteDTO.model';

@Component({
  selector: 'div [app-paquete-detail]',
  templateUrl: './paquete-detail.component.html',
  styleUrls: ['./paquete-detail.component.scss']
})
export class PaqueteDetailComponent implements OnInit {

  detail? : PaqueteDTO;
  
  constructor() { }

  ngOnInit(): void {
  }

  onCompare(_left: KeyValue<any, any>, _right: KeyValue<any, any>): number {
    return 1;
  }
}
