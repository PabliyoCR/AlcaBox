using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class PaqueteCreacionDTO
    {
        public int PaqueteId { get; set; }

        public int Tracking { get; set; }

        public string UsuarioID { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string Descripcion { get; set; }

        public double Peso { get; set; }

        public int ArancelID { get; set; }

        public int EstadoID { get; set; }

        public double Precio { get; set; }
    }
}
