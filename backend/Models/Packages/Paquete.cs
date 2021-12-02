using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Paquete
    {
        [Key]
        public int PaqueteId { get; set; }

        //[Required]
        public int Tracking { get; set; }

        
        public string UsuarioId { get; set; }
        //[Required]
        [ForeignKey(nameof(UsuarioId))]
        public ApplicationUser Usuario { get; set; }

        //[Required]
        public DateTime FechaRegistro { get; set; }

        public string Descripcion { get; set; }

        //[Required]
        public double Peso { get; set; }

        
        public int ArancelId { get; set; }
        //[Required]
        [ForeignKey(nameof(ArancelId))]
        public Arancel Arancel { get; set; }

        
        public int EstadoId { get; set; }
        //[Required]
        [ForeignKey(nameof(EstadoId))]
        public Estado Estado { get; set; }

        //[Required]
        public double Precio { get; set; }


    }
}
