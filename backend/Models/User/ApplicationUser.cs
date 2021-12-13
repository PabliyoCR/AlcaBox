using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class ApplicationUser : IdentityUser
    {
        //[Required]
        public string cedula { get; set; }

        //[Required]
        public string nombre { get; set; }

        //[Required]
        public string primerApellido { get; set; }

        //[Required]
        public string segundoApellido { get; set; }

        //[Required]
        public int tipoCedula { get; set; }

        //[Required]
        public int genero { get; set; }

        //[Required]
        [MaxLength(150)]
        public string direccion { get; set; }

        public bool recibeOfertas { get; set; }

        //[Required]
        public int tipoCuenta { get; set; }

        public bool habilitado { get; set; }

    }
}
