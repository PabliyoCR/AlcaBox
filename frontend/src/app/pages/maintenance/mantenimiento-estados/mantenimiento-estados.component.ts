import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { EstadoDTO } from 'src/app/shared/models/DTOs/PaqueteDTO.model';
import { FORM } from 'src/app/shared/models/Form.model';
import { EstadosService } from 'src/app/shared/services/estados.service';
import { FormService } from 'src/app/shared/services/form.service';

@Component({
  selector: 'div[app-mantenimiento-estados]',
  templateUrl: './mantenimiento-estados.component.html',
  styleUrls: ['./mantenimiento-estados.component.scss']
})
export class MantenimientoEstadosComponent implements OnInit {

  dataSource = new MatTableDataSource<EstadoDTO>();
  estados : EstadoDTO[] = []

  infoToDisplay = [
    { name: 'estadoId', display: 'ID' },
    { name: 'nombre', display: 'Nombre Estado' }
  ];

  displayCols = this.infoToDisplay.map(col => col.name)

  estadoForm: FormGroup; 

  controls : FORM[] = [
    { id : "nombre", type : "text", placeholder: "Nombre Estado"},
  ]

  constructor(private estadosService : EstadosService, private fb : FormBuilder, private estadoService : EstadosService, private formService : FormService) {
    this.estadoForm = this.fb.group({
      estadoId: [{ value: 0, disabled: true }, Validators.required],
      nombre: [null, Validators.required]
    });
  }

  ngOnInit(): void {
    this. getEstados()
  }

  getEstados() : void{
    this.estadosService.getEstados().subscribe( res => {
      this.estados = res
      this.dataSource.data = this.estados
    })
  }

  crearEstado(res : any){
    if(!res.edit){
      this.estadoService.crearEstado(res.formValue).subscribe((res : any) => {
        this.getEstados()
        this.formService.successToast("Guardado Exitósamente", 'bottom-start')
      })
    }else{
      this.estadoService.editarEstado(res.formValue).subscribe((res : any) => {
        this.getEstados()
        this.formService.successToast("Guardado Exitósamente", 'bottom-start')
      })
    }
  }

  eliminarEstado(pk : number){
    this.estadoService.eliminarEstado(pk).subscribe((res : any) => {
      this.getEstados()
    })
  }

}
