import { Component, OnInit } from '@angular/core';
import{  FormGroup, FormControl, Validators, FormBuilder}from'@angular/forms'
import { FORM } from 'src/app/shared/models/Form.model';

@Component({
  selector: 'div[app-formulario-paquete]',
  templateUrl: './formulario-paquete.component.html',
  styleUrls: ['./formulario-paquete.component.scss']
})
export class FormularioPaqueteComponent implements OnInit {

  paqueteForm: FormGroup; 
  controls : FORM[] = [
    { id : "tracking", type : "number"},
    { id : "usuario", type : "string", placeholder : "usuario"},
    { id : "fechaRegistro", type : "date"},
    { id : "descripcion", type : "string", placeholder : "descripcion"},
    { id : "peso", type : "number"},
    { id : "arancel", type : "number"},
    { id : "estado", type : "number"},
    { id : "precio", type : "number"}
  ]

  constructor(private fb : FormBuilder) { 
    this.paqueteForm = this.fb.group({
      tracking: [],
      usuario: [],
      fechaRegistro: [],
      descripcion: [],
      peso: [],
      arancel: [],
      estado: [],
      precio: []
    });
  }
  

  ngOnInit(): void {
  }

}
