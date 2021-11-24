import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/shared/services/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationGuard implements CanActivate {
  constructor(private router: Router) {
  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    if (localStorage.getItem('token') != null){
      return true;
    }
    this.router.navigate(['/login']);
    return false;
  }
}

@Injectable({
  providedIn: 'root'
})
export class AdminAuthorizationGuard implements CanActivate {

  constructor(private UserService : UserService, private router: Router){}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    
      if (['Admin'].includes(this.UserService.getRole())){
        return true;
      }

    this.router.navigate(['/login']);      
      return false;
  }
}

@Injectable({
  providedIn: 'root'
})
export class FouncionarioAuthorizationGuard implements CanActivate {

  constructor(private UserService : UserService, private router: Router){}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    
      if (['Admin', 'Funcionario'].includes(this.UserService.getRole())){
        return true;
      }

    this.router.navigate(['/login']);      
      return false;
  }
}

@Injectable({
  providedIn: 'root'
})
export class UsuarioAuthorizationGuard implements CanActivate {

  constructor(private UserService : UserService, private router: Router){}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    
      if (['Admin', 'Funcionario', 'Usuario'].includes(this.UserService.getRole())){
        return true;
      }

    this.router.navigate(['/login']);      
      return false;
  }
}