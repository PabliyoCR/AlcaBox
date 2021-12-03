import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';
import { UserCreacionDTO } from 'src/app/shared/models/DTOs/authenticationDTOs/CredencialesDTO.model';
import { AuthenticationResponse } from 'src/app/shared/models/DTOs/authenticationDTOs/security';
import Swal from 'sweetalert2';

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
      direccion : [null, Validators.required],
      recibeOfertas: [true, Validators.required],
      tipoCuenta: [null, Validators.required],
      email: [null, Validators.required],
      password: [null, [Validators.required]],
      confirmPassword: [null, [Validators.required]],
      aceptaTerminos: [false, Validators.required]
    });
  }

  ngOnInit(): void {
  }

  signup(){
    console.log(this.usuarioForm.value);

    if(this.usuarioForm.invalid){
      this.usuarioForm.markAllAsTouched()
      return
    }

    if(!this.usuarioForm.get('aceptaTerminos')?.value){
      Swal.fire({
        icon: 'error',
        title: 'Debes aceptar los términos y condiciones para utilizar el sitio',
      })
      return
    }

    const user: UserCreacionDTO = this.usuarioForm.value
        
        this.userService.guardarUsuario(user).subscribe(
          (res: AuthenticationResponse) => {
            console.log(res.message);
            this.userService.logOut()
            this.router.navigateByUrl('login');
          },
          err => {
            let html = ''
            if(err.error.errors){
              html = '<ul>';
              err.error.errors.forEach((error : any) => {
                html += `<li>${error}</li>`;
              });
              html += '</ul>';
            }
            Swal.fire({
              icon: 'error',
              title: err.error.message,
              html
            })
          }
        );
  }

  
}
