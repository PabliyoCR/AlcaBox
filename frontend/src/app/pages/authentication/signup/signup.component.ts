import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';
import { UserCreacionDTO } from 'src/app/shared/models/DTOs/authenticationDTOs/CredencialesDTO.model';
import { AuthenticationResponse } from 'src/app/shared/models/DTOs/authenticationDTOs/security';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  usuarioForm: FormGroup; 
  
  constructor(private fb : FormBuilder, private userService : UserService, private router: Router) { 
    this.usuarioForm = this.fb.group({
      cedula: [null, Validators.required],
      nombre: [null, Validators.required],
      primerApellido: [null, Validators.required],
      segundoApellido: [null, Validators.required],
      tipoCedula: [null, Validators.required],
      genero: [null, Validators.required],
      recibeOfertas: [null, Validators.required],
      tipoCuenta: [null, Validators.required],
      email: [null, Validators.required],
      password: [null, Validators.required],
      confirmPassword: [null, Validators.required]
    });
  }

  ngOnInit(): void {
  }

  signup(){
    const user: UserCreacionDTO = {
          cedula : (document.getElementById("cedula") as HTMLInputElement).value,
          email: (document.getElementById("email") as HTMLInputElement).value,
          password: (document.getElementById("password") as HTMLInputElement).value,
          confirmPassword: (document.getElementById("confirm_password") as HTMLInputElement).value,
          nombre: (document.getElementById("nombre") as HTMLInputElement).value,
          aceptaTerminos :  true,
          primerApellido : (document.getElementById("primerApellido") as HTMLInputElement).value,
          segundoApellido : (document.getElementById("segundoApellido") as HTMLInputElement).value,
          tipoCedula : 1,
          genero : 1,
          direccion : (document.getElementById("direccion") as HTMLInputElement).value,
          recibeOfertas :  true,
          tipoCuenta : 1,
          roleId : "Usuario"
        }
        
        this.userService.guardarUsuario(user).subscribe(
          (res: AuthenticationResponse) => {
            console.log(res.message);
            this.userService.logOut()
            this.router.navigateByUrl('login');
          },
          err => {
          }
        );
  }
}
