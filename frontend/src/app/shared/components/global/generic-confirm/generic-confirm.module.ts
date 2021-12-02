import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericConfirmComponent } from './generic-confirm.component';



@NgModule({
  declarations: [
    GenericConfirmComponent
  ],
  imports: [
    CommonModule
  ],
  exports : [
    GenericConfirmComponent
  ]
})
export class GenericConfirmModule { }
