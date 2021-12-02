
// Paquetes
export interface PaqueteDTO{
    paqueteId: number
    tracking: number
    usuario: any
    fechaRegistro: Date
    descripcion: string
    peso: number
    arancel: ArancelDTO
    estado: EstadoDTO
    precio: number
}

export interface PaqueteCreacionDTO{
    paqueteId?: number
    tracking: number
    usuarioId : string
    fechaRegistro: Date
    descripcion: string
    peso: number
    arancelId: number
    estadoId: number
    precio: number
}

export interface ArancelDTO{
    arancelId : number
    nombre : string
}

export interface EstadoDTO{
    estadoId : number
    nombre : string
}