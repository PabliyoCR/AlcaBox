import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxCaptchaModule } from 'ngx-captcha';


@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    CommonModule,
    NgxCaptchaModule,
    ReactiveFormsModule
  ]
})
export class LoginModule { }
 