import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ArancelDTO } from '../models/DTOs/PaqueteDTO.model';

@Injectable({
  providedIn: 'root'
})
export class ArancelesService {

  constructor(private http: HttpClient) { }

  getAranceles(): Observable<ArancelDTO[]>{
    return this.http.get<ArancelDTO[]>(`${environment.urlAPI}/Arancel`);
  }

  crearArancel(arancel: ArancelDTO): Observable<any>{
    return this.http.post<any>(`${environment.urlAPI}/Arancel`, arancel);
  }
  
  editarArancel(arancel: ArancelDTO): Observable<any>{
    return this.http.put<any>(`${environment.urlAPI}/Arancel`, arancel);
  }

  eliminarArancel(arancel: any): Observable<any>{
    return this.http.delete<any>(`${environment.urlAPI}/Arancel/${arancel}`);
  }
}
