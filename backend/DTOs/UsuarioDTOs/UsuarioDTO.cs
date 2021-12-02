using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class UsuarioDTO
    {
        public string id { get; set; }

        public string cedula { get; set; }

        public string nombre { get; set; }

        public string primerApellido { get; set; }

        public string segundoApellido { get; set; }

        public int tipoCedula { get; set; }

        public int genero { get; set; }

        public string direccion { get; set; }

        public bool recibeOfertas { get; set; }

        public int tipoCuenta { get; set; }

        public string email { get; set; }

        public string emailConfirmed { get; set; }

        public string roleId { get; set; }
    }
}
