import { Component, OnInit } from '@angular/core';
import{  FormGroup, FormControl, Validators, FormBuilder}from'@angular/forms'
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';
import { IAutentificacion } from 'src/app/shared/models/authenticationDTOs/IAutentificacion.model';
import { AuthenticationResponse } from 'src/app/shared/models/authenticationDTOs/security';

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
    e.preventDefault()
    
    this.UserService.login(autenticacionModel).subscribe(
      (res: AuthenticationResponse) => {
        localStorage.setItem('token', res.message);
        this.UserService.cargarPerfilUsuario();
        this.router.navigateByUrl('');
      },
      err => {
      }
    );
  }

  logout(){

  }

}
