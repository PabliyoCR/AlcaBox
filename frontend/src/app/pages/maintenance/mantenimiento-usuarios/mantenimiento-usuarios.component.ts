import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { UsuarioDTO } from 'src/app/shared/models/DTOs/authenticationDTOs/CredencialesDTO.model';
import { AuthenticationResponse } from 'src/app/shared/models/DTOs/authenticationDTOs/security';
import { FORM } from 'src/app/shared/models/Form.model';
import { FormService } from 'src/app/shared/services/form.service';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'div[app-mantenimiento-usuarios]',
  templateUrl: './mantenimiento-usuarios.component.html',
  styleUrls: ['./mantenimiento-usuarios.component.scss']
})
export class MantenimientoUsuariosComponent implements OnInit {

  dataSource = new MatTableDataSource<UsuarioDTO>();
  usuarios : UsuarioDTO[] = []

  infoToDisplay = [
    { name: 'cedula', display: 'Identificación (Cédula)' },
    { name: 'tipoCedula', display: 'Tipo de Cédula' },
    { name: 'nombre', display: 'Nombre' },
    { name: 'primerApellido', display: 'Primer Apellido' },
    { name: 'segundoApellido', display: 'Segundo Apellido' },
    { name: 'genero', display: 'Género' },
    { name: 'direccion', display: 'Dirección' },
    { name: 'recibeOfertas', display: 'Recibe Ofertas' },
    { name: 'tipoCuenta', display: 'Tipo de Cuenta' },
    { name: 'email', display: 'Email' },
    { name: 'emailConfirmed', display: 'Cuenta Confirmada' }
  ];

  displayCols = this.infoToDisplay.map(col => col.name)

  usuarioForm: FormGroup; 

  controls : FORM[] = [
    { id : "nombre", type : "text", placeholder : "Nombre"},
    { id : "primerApellido", type : "text", placeholder: "Primer Apellido"},
    { id : "segundoApellido", type : "text", placeholder : "Segundo Apellido"},
    { id : "cedula", type : "number", placeholder: "Cédula" },
    { id : "tipoCedula", type : "select", placeholder: "Tipo de Cédula", options : [{name : "cedula", value : 1, display : "Cédula"}, {name :"pasaporte", value : 2, display : "Pasaporte"}]},
    { id : "email", type : "email", placeholder: "Email"},
    { id : "genero", type : "select", placeholder: "Género", options : [{name : "masculino", value : 1, display : "Masculino"}, {name :"femenino", value : 2, display : "Femenino"}]},
    { id : "direccion", type : "textarea", placeholder: "Dirección"},
    { id : "tipoCuenta", type : "select", placeholder: "Tipo de Cuenta",  options : [{name : "empresarial", value : 1, display : "Empresarial"}, {name :"personal", value : 2, display : "Personal"}]},
    { id : "recibeOfertas", type : "checkbox", placeholder: "Recibe Ofertas"},
    { id : "roleId", type : "select", placeholder: "Role", options : [{name : "usuario", value : "Usuario", display : "Usuario"}, {name :"funcionario", value : "Funcionario", display : "Funcionario"}, {name :"admin", value : "Admin", display : "Admin"}]},
  ]

  constructor(private userService : UserService, private fb : FormBuilder, private formService : FormService) { 
    this.usuarioForm = this.fb.group({
      id: [{ value: 0, disabled: true }, Validators.required],
      nombre: [null, Validators.required],
      primerApellido: [null, Validators.required],
      segundoApellido: [null, Validators.required],
      cedula: [null, Validators.required],
      tipoCedula: [null, Validators.required],
      email: [null, Validators.required],
      genero: [null, Validators.required],
      direccion: [null, Validators.required],
      tipoCuenta: [null, Validators.required],
      recibeOfertas: [true],
      roleId: [null, Validators.required]
    });
  }

  ngOnInit(): void {
    this. getUsuarios()
  }

  getUsuarios() : void{
    this.userService.getUsuarios().subscribe( res => {
      this.usuarios = res
      this.dataSource.data = this.usuarios
    })
  }

  crearUsuario(res : any){
    if(!res.edit){
      this.userService.guardarUsuario(res.formValue).subscribe((res : AuthenticationResponse) => {
        this.getUsuarios()
      })
    }else{
      this.userService.editarUsuario(res.formValue).subscribe((res : any) => {
        this.getUsuarios()
        this.formService.successToast("Guardado Exitósamente", 'bottom-start')
      })
    }
  }

}
