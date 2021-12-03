import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './pages/about/about.component';
import { LoginComponent } from './pages/authentication/login/login.component';
import { SignupComponent } from './pages/authentication/signup/signup.component';
import { HelpComponent } from './pages/help/help.component';
import { HomepageComponent } from './pages/homepage/homepage.component';
import { MaintenanceComponent } from './pages/maintenance/maintenance.component';
import { PackagesComponent } from './pages/packages/packages.component';
import { ReportsComponent } from './pages/reports/reports.component';
import { AdminAuthorizationGuard, AuthenticationGuard, FouncionarioAuthorizationGuard, UsuarioAuthorizationGuard } from './shared/guards/authentication.guard';

const routes: Routes = [
  {
    path : '',
    component : HomepageComponent,
    loadChildren : () => import('./pages/homepage/homepage.module').then(m => m.HomepageModule)
  },
  {
    path : 'login',
    component : LoginComponent,
    loadChildren : () => import('./pages/authentication/login/login.module').then(m => m.LoginModule)
  },
  {
    path : 'signup',
    component : SignupComponent,
    loadChildren : () => import('./pages/authentication/signup/signup.module').then(m => m.SignupModule)
  },
  {
    path : 'packages',
    component : PackagesComponent,
    loadChildren : () => import('./pages/packages/packages.module').then(m => m.PackagesModule),
    canActivate:[AuthenticationGuard, UsuarioAuthorizationGuard]
  },
  {
    path : 'reports',
    component : ReportsComponent,
    loadChildren : () => import('./pages/reports/reports.module').then(m => m.ReportsModule),
    canActivate:[AuthenticationGuard, FouncionarioAuthorizationGuard]
  },
   {
    path : 'maintenance',
    component : MaintenanceComponent,
    loadChildren : () => import('./pages/maintenance/maintenance.module').then(m => m.MaintenanceModule),
    canActivate:[AuthenticationGuard, FouncionarioAuthorizationGuard]
  },
  {
    path : 'about',
    component : AboutComponent,
    loadChildren : () => import('./pages/about/about.module').then(m => m.AboutModule),
  },
  {
    path : 'help',
    component : HelpComponent,
    loadChildren : () => import('./pages/help/help.module').then(m => m.HelpModule)

  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
