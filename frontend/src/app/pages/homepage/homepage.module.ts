import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomepageComponent } from './homepage.component';
import { CardInfoModule } from 'src/app/shared/components/card-info/card-info.module';

@NgModule({
  declarations: [
    HomepageComponent
  ],
  imports: [
    CommonModule,
    CardInfoModule
  ]
})
export class HomepageModule { }
