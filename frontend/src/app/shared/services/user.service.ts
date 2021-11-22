import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { IPerfilUsuaio } from '../models/authenticationDTOs/IPerfilUsuaio.model';
import { UserDTO } from '../models/authenticationDTOs/CredencialesDTO.model';
import jwt_decode from "jwt-decode";
import { environment } from 'src/environments/environment';
import { AuthenticationResponse } from '../models/authenticationDTOs/security';
import { IAutentificacion } from '../models/authenticationDTOs/IAutentificacion.model';


@Injectable({
  providedIn: 'root'
})

export class UserService {
  private _refres$ = new Subject<void>();
  private actualizarFormulario = new BehaviorSubject<UserDTO>({} as any);
  urlAPI = environment.urlAPI
  private readonly keyToken = 'token';
  private readonly roleField = 'role';

  constructor(private http: HttpClient) {
  }

  login(usuario:IAutentificacion) : Observable<AuthenticationResponse> {
    return this.http.post<AuthenticationResponse>(this.urlAPI + "/auth/login", usuario);
  }

  guardarUsuario(usuario: UserDTO): Observable<AuthenticationResponse> {
    return this.http.post<AuthenticationResponse>(this.urlAPI+ "/auth/register", usuario);
  }

  isLogIn(){
    const token = localStorage.getItem(this.keyToken);

    if (!token){
      return false;
    }

    return true;
  }

  logOut(){
    localStorage.removeItem(this.keyToken);
  }

  getRole(): string {
    return this.getFieldJWT(this.roleField);
  }

  getFieldJWT(field: string): string{
    const token = localStorage.getItem(this.keyToken);
    if (!token){return '';}
    var dataToken = JSON.parse(atob(token.split('.')[1]));
    return dataToken[field];
  }

  obtenerUsuario(id: string): Observable<UserDTO> {
    return this.http.get<UserDTO>(this.urlAPI + id);
  }

  actualizarUsuario(id:string, usuario:UserDTO) :Observable<UserDTO>{
    return this.http.put<UserDTO>(this.urlAPI + '/' + id, usuario);
  }

  actualizar(usuario: UserDTO){
    this.actualizarFormulario.next(usuario);
  }

  obtenerUsuarios$():Observable<UserDTO>{
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
