using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Models
{
    public class BitacoraAccion
    {
        [Key]
        public int Accion_Id { get; set; }

        public string UsuarioId { get; set; }
        [ForeignKey(nameof(UsuarioId))]
        public ApplicationUser Usuario { get; set; }

        public DateTime Fecha { get; set; }

        public string Accion { get; set; }



    }
}
