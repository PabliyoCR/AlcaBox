import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import{  FormGroup, FormControl, Validators, FormBuilder}from'@angular/forms'
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';
import { IAutentificacion } from 'src/app/shared/models/IAutentificacion.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {

  loginForm: FormGroup; 

  constructor(private fb : FormBuilder, private UserService : UserService, private router: Router) { 
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(8)]]
    });
  }

   ngOnInit(): void {
    if (localStorage.getItem('token') != null) {
      this.router.navigateByUrl('');
    }
  }

  login(e : Event){

    const autenticacionModel: IAutentificacion = {
      email: (document.getElementById("email") as HTMLInputElement).value,
      password: (document.getElementById("password") as HTMLInputElement).value
    }

    console.log(e);
    e.preventDefault()
    console.log(autenticacionModel.email, autenticacionModel.password);

    this.UserService.login(autenticacionModel).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.message);
        //Variable que carga los datos del token desde el localstorege
        let perfilU = this.UserService.cargarPerfilUsuario();
        //generala descripción de la actividad de usuario
        //let descripcion: string = this.generarDescripcion(perfilU.Cedula, Accion.InicioSesion );
        //variable que genera la actividada de usuario
        //let actividad = new ActividadUsuario(parseInt(perfilU.UserID), descripcion);
        //registra la actividad de usuario(ingreso al sistema)
        //this.registrarActividad(actividad)
        this.router.navigateByUrl('');
      },
      err => {
        //if (err.status == 400)
          //this.toastr.error('Usuario o contraseña incorrectos', 'Autentificación fallida');
        //else
          //console.log(err);
      }
    );
    //console.warn(this.loginForm.value);
    //this.authenticationService.login()
  }

  logout(){

  }

}
