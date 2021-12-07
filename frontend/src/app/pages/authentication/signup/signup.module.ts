import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignupComponent } from './signup.component';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxCaptchaModule } from 'ngx-captcha';


@NgModule({
  declarations: [
    SignupComponent
  ],
  imports: [
    ReactiveFormsModule,
    NgxCaptchaModule,
    CommonModule
  ]
})
export class SignupModule { }
