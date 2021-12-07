import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';
import { UserCreacionDTO } from 'src/app/shared/models/DTOs/authenticationDTOs/CredencialesDTO.model';
import { AuthenticationResponse } from 'src/app/shared/models/DTOs/authenticationDTOs/security';
import Swal from 'sweetalert2';
import { ReCaptchaV3Service } from 'ngx-captcha';
import { FormService } from 'src/app/shared/services/form.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  usuarioForm: FormGroup; 
  siteKey : string = "6Ldo03kdAAAAAJw5W7ba6Jh52c1Pp84atSE3F_83";
  
  constructor(private fb : FormBuilder, private userService : UserService, private router: Router, private reCaptchaV3Service: ReCaptchaV3Service, private formService : FormService) { 
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
      aceptaTerminos: [false, Validators.required],
      recaptcha: [false, Validators.required]
    });
  }

  ngOnInit(): void {
     this.reCaptchaV3Service.execute(this.siteKey, 'homepage', (token) => {
      console.log('This is your token: ', token);
    }, {
        useGlobalDomain: false
    });
  }

  signup(){

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

    if(!this.usuarioForm.get('recaptcha')?.value){
      Swal.fire({
        icon: 'error',
        title: 'Debes validar que no eres un bot',
      })
      return
    }

    const user: UserCreacionDTO = this.usuarioForm.value
        
        this.userService.guardarUsuario(user).subscribe(
          (res: AuthenticationResponse) => {
            console.log(res.message);
            this.userService.logOut()
            this.router.navigateByUrl('login');
            this.formService.successToast("Usuario Creado Exitósamente", 'top-start')
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
