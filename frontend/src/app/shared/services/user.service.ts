import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { IPerfilUsuaio } from '../models/IPerfilUsuaio.model';
import { Usuario } from '../models/Usuario.model';
import jwt_decode from "jwt-decode";


@Injectable({
  providedIn: 'root'
})
export class UserService {

    //Url del servidor
  private urlApp: string;
  //Url servicio
  private urlAPI: string;
  //public list: Usuarios[];
  
  private _refres$ = new Subject<void>();
  private actualizarFormulario = new BehaviorSubject<Usuario>({} as any);

  constructor(private http: HttpClient) {
    this.urlApp = 'https://localhost:44314/';
    this.urlAPI = 'api';
  }

  login(formData:any) {
    console.log(this.urlApp + this.urlAPI + "/auth/login", formData);
    return this.http.post(this.urlApp + this.urlAPI + "/auth/login", formData);
  }

  guardarUsuario(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(this.urlApp + this.urlAPI, usuario);
  }

  obtenerUsuario(id: string): Observable<Usuario> {
    return this.http.get<Usuario>(this.urlApp + this.urlAPI + id);
  }

  actualizarUsuario(id:string, usuario:Usuario) :Observable<Usuario>{
    return this.http.put<Usuario>(this.urlApp + this.urlAPI + '/' + id, usuario);
  }

  actualizar(usuario: Usuario){
    this.actualizarFormulario.next(usuario);
  }

  obtenerUsuarios$():Observable<Usuario>{
    return this.actualizarFormulario.asObservable();
  // ===================================     MAIKOL    ==========================
  }

  //Trae la lista de los objetos
  /* obtenerUsuarios(): Observable<Usuario[]> {
    return this.http.get<Mensaje>(`${this.urlApp + this.urlAPI}`)
      .pipe(
        map(this.tranformarUsurarios)
      )
  } */

  get refresh$() {
    return this._refres$;
  }

 /*  private tranformarUsurarios(respuesta: Mensaje): Usuarios[] {
    //metodo crea el
    const usuarioList: Usuarios[] = respuesta.object.map(usua => {
      return {
        pK_idUsuario: usua.pK_idUsuario,
        cedulaUsuario: usua.cedulaUsuario,
        nombreUsuario: usua.nombreUsuario,
        primerApellidoUsuario: usua.primerApellidoUsuario,
        segundoApellidoUsuario: usua.segundoApellidoUsuario,
        telefonoUsuario: usua.telefonoUsuario,
        emailUsuario: usua.emailUsuario,
        contrasenaUsuario: usua.contrasenaUsuario,
        // fotoPerfil:             null;
        // rutaFoto:               null;
        estadoUsuario: usua.estadoUsuario,
        fK_idDepartamento1: usua.fK_idDepartamento1,
        fK_idParqueNacional1: usua.fK_idParqueNacional1,
        fK_idRolUsuario1: usua.fK_idRolUsuario1
      }
    })
    return usuarioList;
  } */

  /* deshabilitarUsuario(id: string): Observable<Usuarios> {
    return this.http.get<Usuarios>(this.urlApp + this.urlAPI + "/cambiarEstado/" + id).pipe(
      tap(() => {
        this._refres$.next();
      })
    );
  }

  editarUsuario(id: string): Observable<Usuarios> {
    return this.http.get<Usuarios>(this.urlApp + this.urlAPI + id).pipe(
      tap(() => {
        this._refres$.next();
      })
    );
  } */

  /*    cmabiar contrasena   */
  /* recuperarContrasena(correoElectronico: string): Observable<Usuarios> {
    return this.http.get<Usuarios>(this.urlApp + this.urlAPI + "/recuperarContrasena/" + correoElectronico);
  } */


  public cargarPerfilUsuario(): IPerfilUsuaio{

    let token = localStorage.getItem("token");

    let decoded = JSON.parse(JSON.stringify(jwt_decode(token!)));
    let perfilU : IPerfilUsuaio = decoded;

    return perfilU
  }
}
