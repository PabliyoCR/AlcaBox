import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';
import { UserDTO } from 'src/app/shared/models/authenticationDTOs/CredencialesDTO.model';
import { AuthenticationResponse } from 'src/app/shared/models/authenticationDTOs/security';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  constructor(private fb : FormBuilder, private UserService : UserService, private router: Router) { }

  ngOnInit(): void {
  }

  signup(e : Event){
    const user: UserDTO = {
          email: (document.getElementById("email") as HTMLInputElement).value,
          password: (document.getElementById("password") as HTMLInputElement).value,
          confirmPassword: (document.getElementById("confirm_password") as HTMLInputElement).value,
          name: (document.getElementById("name") as HTMLInputElement).value
        }
        e.preventDefault()
        
        this.UserService.guardarUsuario(user).subscribe(
          (res: AuthenticationResponse) => {
            console.log(res.message);
          },
          err => {
          }
        );
  }
}
