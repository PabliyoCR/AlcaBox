import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PaqueteCreacionDTO, PaqueteDTO } from '../models/DTOs/PaqueteDTO.model';

@Injectable({
  providedIn: 'root'
})
export class PackageService {

  constructor(private http: HttpClient) { }

  getPaquetes(): Observable<PaqueteDTO[]>{
    return this.http.get<PaqueteDTO[]>(`${environment.urlAPI}/Paquetes`);
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
