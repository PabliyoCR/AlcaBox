import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  baseUrl = 'https://localhost:44314/api'

  login(userName : string, password: string) 
  {

  let headers = new HttpHeaders();
  headers.append('Content-Type', 'application/json');

  return this.http.post(
        this.baseUrl + '/auth/login',
        JSON.stringify({ userName, password }),{ headers })
        .pipe(map((res : any) => {
          res.json()
        })).subscribe(result => {
          console.log(result);
        })


       /*  .map((res : any) => res.json())
        .map((res : any) => {
          localStorage.setItem('auth_token', res.auth_token);
          this.loggedIn = true;
          this._authNavStatusSource.next(true);
          return true;
        })
        .catch(this.handleError); */
  }
}
