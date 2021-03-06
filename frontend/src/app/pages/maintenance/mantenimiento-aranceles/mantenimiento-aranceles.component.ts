import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { ArancelDTO } from 'src/app/shared/models/DTOs/PaqueteDTO.model';
import { FORM } from 'src/app/shared/models/Form.model';
import { ArancelesService } from 'src/app/shared/services/aranceles.service';
import { FormService } from 'src/app/shared/services/form.service';

@Component({
  selector: 'div[app-mantenimiento-aranceles]',
  templateUrl: './mantenimiento-aranceles.component.html',
  styleUrls: ['./mantenimiento-aranceles.component.scss']
})
export class MantenimientoArancelesComponent implements OnInit {

  dataSource = new MatTableDataSource<ArancelDTO>();
  aranceles : ArancelDTO[] = []

  infoToDisplay = [
    { name: 'arancelId', display: 'ID' },
    { name: 'nombre', display: 'Nombre Arancel' },
  ];

  displayCols = this.infoToDisplay.map(col => col.name)

  arancelForm: FormGroup; 

  controls : FORM[] = [
    { id : "nombre", type : "text", placeholder: "Nombre Arancel"},
  ]

  constructor(private arancelesService : ArancelesService, private fb : FormBuilder, private formService : FormService) { 
    this.arancelForm = this.fb.group({
      arancelId: [{ value: 0, disabled: true }, Validators.required],
      nombre: [null, Validators.required]
    });
  }

  ngOnInit(): void {
    this. getAranceles()
  }

  getAranceles() : void{
    this.arancelesService.getAranceles().subscribe( res => {
      this.aranceles = res
      this.dataSource.data = this.aranceles
    })
  }

  crearArancel(res : any){
    if(!res.edit){
      this.arancelesService.crearArancel(res.formValue).subscribe((res : any) => {
        this.getAranceles()
        this.formService.successToast("Guardado Exitósamente", 'bottom-start')
      })
    }else{
      this.arancelesService.editarArancel(res.formValue).subscribe((res : any) => {
        this.getAranceles()
        this.formService.successToast("Guardado Exitósamente", 'bottom-start')
      })
    }
  }

  eliminarArancel(pk : number){
    this.arancelesService.eliminarArancel(pk).subscribe((res : any) => {
      this.getAranceles()
    })
  }
}
