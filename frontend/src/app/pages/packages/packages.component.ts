import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ConfirmComponent } from 'src/app/shared/components/dialogs/confirm/confirm.component';
import { PaqueteDTO } from 'src/app/shared/models/DTOs/PaqueteDTO.model';
import { FormService } from 'src/app/shared/services/form.service';
import { PackageService } from 'src/app/shared/services/package.service';
import { UserService } from 'src/app/shared/services/user.service';
import { PaqueteDetailComponent } from './paquete-detail/paquete-detail.component';

@Component({
  selector: 'app-packages',
  templateUrl: './packages.component.html',
  styleUrls: ['./packages.component.scss']
})
export class PackagesComponent implements OnInit {
  permisosAdmin : boolean;
  dataSource = new MatTableDataSource<PaqueteDTO>();

  paquetes : PaqueteDTO[] = []
  displayedColumns = [
    { name: 'paqueteId', display: 'ID Paquete' },
    { name: 'descripcion', display: 'Descripcion' },
    { name: 'usuario', display: 'Usuario (Cédula)' },
    { name: 'fechaRegistro', display: 'Fecha de Registro' },
    { name: 'peso', display: 'Peso' },
    { name: 'arancel', display: 'Arancel' },
    { name: 'estado', display: 'Estado' },
    { name: 'precio', display: 'Precio' },
    { name: 'tracking', display: 'Tracking' }
  ];
  displayCols = this.displayedColumns.map(col => col.name)

  readonly filtrosControl: FormGroup;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  bsModalRef?: BsModalRef;

  constructor(private packageService : PackageService,  private formService : FormService, public dialog: MatDialog, fb: FormBuilder, private modalService: BsModalService, private userService : UserService) { 

    this.dataSource.filterPredicate = ((data : PaqueteDTO, filter : any) => {
      const a = !filter.paqueteID || data.paqueteId == filter.paqueteID;
      const b = !filter.usuario || data.usuario['cedula'] == filter.usuario;
      return a && b;
    })

    this.filtrosControl = fb.group({
      paqueteID: [],
      usuario: []
    })
    
    this.filtrosControl.valueChanges.subscribe(value => {
      const filter = {...value};
      this.dataSource.filter = filter;
    });

    this.permisosAdmin = userService.isAuthorizated(['Admin','Funcionario'])
    if(!this.permisosAdmin){
      this.displayCols.splice(this.displayCols.indexOf('usuario'), 1);
    }else{
      this.displayCols.push('acciones')
    }
  }

  ngOnInit(): void { 
    this.getPaquetes()
  }

  getPaquetes() : void{
    this.packageService.getPaquetes().subscribe( res => {
      this.paquetes = res
      this.dataSource.data = this.paquetes
      this.dataSource.paginator = this.paginator;
    })
  }

  showDetail(e : Event, row : PaqueteDTO){
    const target = e.target as HTMLElement
    if(!target.classList.contains('action')){
      this.bsModalRef = this.modalService.show(PaqueteDetailComponent,{ initialState : { detail : row }});
    }
  }

  cargarPaqueteEnForm(id : number){
    var paquete : PaqueteDTO  = this.paquetes.find(paq => paq.paqueteId == id) || this.paquetes[0];
    this.formService.cargarPaqueteEdit(paquete)
  }

  wipePaqueteForm(){
    this.formService.wipeForm()
  }

  openDeleteDialog(paqueteId : string){
    var dialogRef = this.dialog.open(ConfirmComponent, { data: { titulo: "Eliminar Paquete", mensaje : "¿Deseas Eliminar el Paquete?", params : { paqueteId } } });
    dialogRef.componentInstance.procederEvent.subscribe(result => {
      this.packageService.eliminaPaquete(result.paqueteId).subscribe( res => {
        this.getPaquetes()
      })
    })
  }
}
