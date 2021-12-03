import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { UsuarioDTO } from '../models/DTOs/authenticationDTOs/CredencialesDTO.model';
import { PaqueteDTO } from '../models/DTOs/PaqueteDTO.model';
import { FORM_OPT } from '../models/Form.model';

@Injectable({
  providedIn: 'root'
})
export class FormService {

  public formCreateSubject = new Subject();
  public formEditSubject = new Subject<PaqueteDTO>();

  constructor(private http: HttpClient) { }

  public gesList(entidad : string): Observable<any>{
    return this.http.get(`${environment.urlAPI}/${entidad}`);
  }

  getFormOpts(entidad :string, name : string, value: string) : Observable<FORM_OPT[]>{
    var subject = new Subject<FORM_OPT[]>();
    this.gesList(entidad).subscribe(res => {
      res = res.map((item : any) => { return { name : item[value], value : item[name]} })
      subject.next(res)
    })
    return subject.asObservable();
  } 

  getUsersByRole(role : string) : Observable<UsuarioDTO[]>{
    return this.http.get<UsuarioDTO[]>(`${environment.urlAPI}/User/byRole/${role}`);
  }

  cargarPaqueteEdit(paquete : PaqueteDTO){
    this.formEditSubject.next(paquete)
  }

  wipeForm(){
    this.formCreateSubject.next()
  }

  successToast(){
    const Toast = Swal.mixin({
      toast: true,
      position: 'bottom-start',
      showConfirmButton: false,
      timer: 3000,
      timerProgressBar: true,
      didOpen: (toast) => {
        toast.addEventListener('mouseenter', Swal.stopTimer)
        toast.addEventListener('mouseleave', Swal.resumeTimer)
      }
    })

    Toast.fire({
      icon: 'success',
      title: 'Guardado con Éxito'
    })
  }
}
