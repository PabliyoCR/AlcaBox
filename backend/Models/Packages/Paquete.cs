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
        public int Paquete_Id { get; set; }

        [Required]
        public int Tracking { get; set; }

        [Required]
        [ForeignKey("Usuarios")]

        public ApplicationUser Usuario { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }

        public string Descripcion { get; set; }
        [Required]
        public double Peso { get; set; }

        [ForeignKey("Aranceles")]
        [Required]
        public Arancel Arancel { get; set; }


        [ForeignKey("Estado")]
        [Required]
        public int Estado_id { get; set; }
        public Estado Estado { get; set; }
        [Required]
        public double Precio { get; set; }


    }
}
