export interface UserCreacionDTO {
  id?: string
  nombre: string;
  primerApellido : string
  segundoApellido : string
  cedula : string
  tipoCedula : number
  email: string;
  genero : number
  direccion : string
  tipoCuenta : number
  recibeOfertas :  boolean
  password?: string;
  confirmPassword?: string;
  aceptaTerminos? :  boolean
  roleId? :  string
}

export interface UsuarioDTO {
    id :  string
    cedula : string
    nombre : string
    primerApellido : string
    segundoApellido : string
    tipoCedula : number
    genero : number
    direccion : string
    recibeOfertas :  boolean
    tipoCuenta : number
    email :  string
    emailConfirmed :  boolean
    roleId : string
}