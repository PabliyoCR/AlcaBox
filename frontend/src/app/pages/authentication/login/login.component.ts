import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import{  FormGroup, FormControl, Validators, FormBuilder}from'@angular/forms'
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {

  loginForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(private fb : FormBuilder, private authenticationService : AuthenticationService, private router: Router) { 
    
  }

   ngOnInit(): void {
    if (localStorage.getItem('token') != null) {
      this.router.navigateByUrl('/sidebar');
    }
  }

  login(){
    console.warn(this.loginForm.value);
    //this.authenticationService.login()
  }

  logout(){

  }

}
