import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PaqueteCreacionDTO, PaqueteDTO } from '../models/DTOs/PaqueteDTO.model';

@Injectable({
  providedIn: 'root'
})
export class PackageService {

  constructor(private http: HttpClient) { }

  getPaquetes(metodoOrden : string): Observable<PaqueteDTO[]>{
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'responseType': 'json',
      'metodoOrden' : metodoOrden
    });
    return this.http.get<PaqueteDTO[]>(`${environment.urlAPI}/Paquetes`, { headers });
  }

  crearPaquete(paquete: PaqueteCreacionDTO): Observable<number>{
    return this.http.post<number>(`${environment.urlAPI}/Paquetes`, paquete);
  }

  actualizarPaquete(paquete: PaqueteCreacionDTO): Observable<number>{
    return this.http.put<number>(`${environment.urlAPI}/Paquetes`, paquete);
  }

  eliminaPaquete(paqueteId : string) {
    return this.http.delete(`${environment.urlAPI}/Paquetes/${paqueteId}`);
  }
}
