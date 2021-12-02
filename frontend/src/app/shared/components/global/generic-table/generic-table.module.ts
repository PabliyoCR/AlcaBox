import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericTableComponent } from './generic-table.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { GenericDetailModalModule } from '../generic-detail-modal/generic-detail-modal.module';
import { GenericFormModule } from '../generic-form/generic-form.module';

@NgModule({
  declarations: [
    GenericTableComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatIconModule,
    GenericDetailModalModule,
    GenericFormModule
  ],
  exports : [
    GenericTableComponent
  ]
})
export class GenericTableModule { }
