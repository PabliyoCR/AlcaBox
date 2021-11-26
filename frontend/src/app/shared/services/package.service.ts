import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PaqueteDTO } from '../models/DTOs/PaqueteDTO.model';

@Injectable({
  providedIn: 'root'
})
export class PackageService {

  constructor(private http: HttpClient) { }

  public getPaquetes(): Observable<PaqueteDTO[]>{
    return this.http.get<PaqueteDTO[]>(`${environment.urlAPI}/Paquetes`);
  }
}
