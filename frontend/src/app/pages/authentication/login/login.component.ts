import { Component, OnInit } from '@angular/core';
import{  FormGroup, FormControl, Validators, FormBuilder}from'@angular/forms'
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';
import { IAutentificacion } from 'src/app/shared/models/DTOs/authenticationDTOs/IAutentificacion.model';
import { AuthenticationResponse } from 'src/app/shared/models/DTOs/authenticationDTOs/security';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {

  loginForm: FormGroup; 

  constructor(private fb : FormBuilder, private UserService : UserService, private router: Router) { 
    this.loginForm = this.fb.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(8)]]
    });
  }

   ngOnInit(): void {
    if (localStorage.getItem('token') != null) {
      this.router.navigateByUrl('');
    }
  }

  login(){
    this.UserService.login(this.loginForm.value).subscribe(
      (res: AuthenticationResponse) => {
        localStorage.setItem('token', res.message);
        this.UserService.cargarPerfilUsuario();
        this.router.navigateByUrl('');
      },
      err => {
        console.log(err);
      }
    );
  }

  logout(){

  }

}
