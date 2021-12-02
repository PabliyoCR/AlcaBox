import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericDetailModalComponent } from './generic-detail-modal.component';

@NgModule({
  declarations: [
    GenericDetailModalComponent
  ],
  imports: [
    CommonModule
  ],
  exports : [
    GenericDetailModalComponent
  ]
})
export class GenericDetailModalModule { }
