import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmComponent } from './confirm.component';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';



@NgModule({
  declarations: [
    ConfirmComponent
  ],
  imports: [
    MatButtonModule,
    MatDialogModule,
    CommonModule
  ],
  exports : [
    ConfirmComponent
  ]
})
export class ConfirmModule { }
