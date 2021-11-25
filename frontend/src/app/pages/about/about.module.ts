import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AboutComponent } from './about.component';
import { CardInfoModule } from 'src/app/shared/components/card-info/card-info.module';



@NgModule({
  declarations: [
    AboutComponent
  ],
  imports: [
    CommonModule,
    CardInfoModule
  ]
})
export class AboutModule { }
