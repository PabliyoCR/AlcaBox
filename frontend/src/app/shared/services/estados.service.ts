import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EstadoDTO } from '../models/DTOs/PaqueteDTO.model';

@Injectable({
  providedIn: 'root'
})
export class EstadosService {

  constructor(private http: HttpClient) { }

  getEstados(): Observable<EstadoDTO[]>{
    return this.http.get<EstadoDTO[]>(`${environment.urlAPI}/Estado`);
  }

  crearEstado(estado: EstadoDTO): Observable<any>{
    return this.http.post<any>(`${environment.urlAPI}/Estado`, estado);
  }

  editarEstado(estado: EstadoDTO): Observable<any>{
    return this.http.put<any>(`${environment.urlAPI}/Estado`, estado);
  }

  eliminarEstado(estado: any): Observable<any>{
    return this.http.delete<any>(`${environment.urlAPI}/Estado/${estado}`);
  }
}
