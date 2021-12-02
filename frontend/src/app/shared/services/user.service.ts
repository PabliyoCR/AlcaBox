import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { IPerfilUsuaio } from '../models/DTOs/authenticationDTOs/IPerfilUsuaio.model';
import { UserCreacionDTO, UsuarioDTO } from '../models/DTOs/authenticationDTOs/CredencialesDTO.model';
import jwt_decode from "jwt-decode";
import { environment } from 'src/environments/environment';
import { AuthenticationResponse } from '../models/DTOs/authenticationDTOs/security';
import { IAutentificacion } from '../models/DTOs/authenticationDTOs/IAutentificacion.model';


@Injectable({
  providedIn: 'root'
})

export class UserService {

  private readonly keyToken = 'token';

  constructor(private http: HttpClient) {
  }

  login(usuario:IAutentificacion) : Observable<AuthenticationResponse> {
    return this.http.post<AuthenticationResponse>(environment.urlAPI + "/auth/login", usuario);
  }

  guardarUsuario(usuario: UserCreacionDTO): Observable<AuthenticationResponse> {
    console.log(usuario);
    return this.http.post<AuthenticationResponse>(environment.urlAPI+ "/auth/register", usuario);
  }

  editarUsuario(usuario:UserCreacionDTO) :Observable<any>{
    return this.http.put(environment.urlAPI + '/User', usuario);
  }

  isAuthenticated(){
    const token = localStorage.getItem(this.keyToken);

    if (!token){
      return false;
    }

    return true;
  }

   isAuthorizated(roles : string[]){
    if(!roles.includes(this.getFieldJWT('Role'))){
      return false
    }
    return true;
  }

  logOut(){
    localStorage.removeItem(this.keyToken);
  }

  getRole(): string {
    return this.getFieldJWT('Role');
  }

  getFieldJWT(field: string): string{
    const token = localStorage.getItem(this.keyToken);
    if (!token){return '';}
    var dataToken = JSON.parse(atob(token.split('.')[1]));
    return dataToken[field];
  }

  // CRUD

  getUsuarios(): Observable<UsuarioDTO[]>{
    return this.http.get<UsuarioDTO[]>(`${environment.urlAPI}/User`);
  }

  obtenerUsuario(id: string): Observable<UserCreacionDTO> {
    return this.http.get<UserCreacionDTO>(environment.urlAPI + id);
  }

  //Trae la lista de los objetos
  /* obtenerUsuarios(): Observable<Usuario[]> {
    return this.http.get<Mensaje>(`${this.urlApp + environment.urlAPI}`)
      .pipe(
        map(this.tranformarUsurarios)
      )
  } */

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
    return this.http.get<Usuarios>(this.urlApp + environment.urlAPI + "/cambiarEstado/" + id).pipe(
      tap(() => {
        this._refres$.next();
      })
    );
  }

  editarUsuario(id: string): Observable<Usuarios> {
    return this.http.get<Usuarios>(this.urlApp + environment.urlAPI + id).pipe(
      tap(() => {
        this._refres$.next();
      })
    );
  } */

  /*    cmabiar contrasena   */
  /* recuperarContrasena(correoElectronico: string): Observable<Usuarios> {
    return this.http.get<Usuarios>(this.urlApp + environment.urlAPI + "/recuperarContrasena/" + correoElectronico);
  } */


  public cargarPerfilUsuario(): IPerfilUsuaio{

    let token = localStorage.getItem("token");

    let decoded = JSON.parse(JSON.stringify(jwt_decode(token!)));
    let perfilU : IPerfilUsuaio = decoded;

    return perfilU
  }
}
