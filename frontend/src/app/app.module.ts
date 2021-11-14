import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterModule } from './shared/components/footer/footer.module';
import { HeroModule } from './shared/components/hero/hero.module';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AuthInterceptor } from './shared/guards/AuthInterceptor';
import { UserService } from './shared/services/user.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [BrowserModule,
    AppRoutingModule,
    HeroModule,
    FooterModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [UserService,{
    provide:HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi:true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
