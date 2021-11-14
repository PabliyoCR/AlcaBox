import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './pages/about/about.component';
import { LoginComponent } from './pages/authentication/login/login.component';
import { HelpComponent } from './pages/help/help.component';
import { HomepageComponent } from './pages/homepage/homepage.component';
import { PackagesComponent } from './pages/packages/packages.component';
import { ReportsComponent } from './pages/reports/reports.component';
import { AuthenticationGuard } from './shared/guards/authentication.guard';

const routes: Routes = [
 /*  {
    path : '',
    loadChildren : () => import('./pages/homepage/homepage.module').then(m => m.HomepageModule)
  }, */
  {
    path : '',
    component : HomepageComponent
  },
  {
    path : 'login',
    component : LoginComponent
  },
  {
    path : 'packages',
    component : PackagesComponent,
    canActivate:[AuthenticationGuard]
  },
  {
    path : 'reports',
    component : ReportsComponent,
    canActivate:[AuthenticationGuard]
  },
  {
    path : 'about',
    component : AboutComponent
  },
  {
    path : 'help',
    component : HelpComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
