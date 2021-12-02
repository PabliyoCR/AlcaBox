import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PackagesComponent } from './packages.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { FormularioPaqueteComponent } from './formulario-paquete/formulario-paquete.component';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { MatSelectModule } from '@angular/material/select';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatIconModule} from '@angular/material/icon';
import { ConfirmModule } from 'src/app/shared/components/dialogs/confirm/confirm.module';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { PaqueteDetailComponent } from './paquete-detail/paquete-detail.component';
import { ModalModule } from 'ngx-bootstrap/modal';


@NgModule({
  declarations: [
    PackagesComponent,
    FormularioPaqueteComponent,
    PaqueteDetailComponent
  ],
  imports: [
    CommonModule,
    MatAutocompleteModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatIconModule,
    MatDatepickerModule,
    MatButtonModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule,
    ConfirmModule,
    ModalModule.forRoot()
  ]
})
export class PackagesModule { }
