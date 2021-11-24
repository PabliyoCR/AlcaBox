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
        public string Cedula { get; set; }

        //[Required]
        public string Nombre { get; set; }

        //[Required]
        public string Primer_Apellido { get; set; }

        //[Required]
        public string Segundo_Apellido { get; set; }

        //[Required]
        public string TipoCedula { get; set; }

        //[Required]
        public string Genero { get; set; }

        //[Required]
        [MaxLength(150)]
        public string Direccion { get; set; }

        public bool Recibe_Ofertas { get; set; }

        //[NotMapped]
        public bool Acepta_Terminos { get; set; }

        //[Required]
        public string TipoCuenta { get; set; }

    }
}
