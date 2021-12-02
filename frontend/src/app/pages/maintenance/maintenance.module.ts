import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaintenanceComponent } from './maintenance.component';
import {MatExpansionModule} from '@angular/material/expansion';
import { MantenimientoUsuariosComponent } from './mantenimiento-usuarios/mantenimiento-usuarios.component';
import { MantenimientoArancelesComponent } from './mantenimiento-aranceles/mantenimiento-aranceles.component';
import { GenericTableModule } from 'src/app/shared/components/global/generic-table/generic-table.module';
import { MantenimientoEstadosComponent } from './mantenimiento-estados/mantenimiento-estados.component';


@NgModule({
  declarations: [
    MaintenanceComponent,
    MantenimientoUsuariosComponent,
    MantenimientoArancelesComponent,
    MantenimientoEstadosComponent,
  ],
  imports: [
    MatExpansionModule,
    CommonModule,
    GenericTableModule
  ]
})
export class MaintenanceModule { }
