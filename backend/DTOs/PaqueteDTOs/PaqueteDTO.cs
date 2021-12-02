using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class PaqueteDTO
    {
        public int PaqueteId { get; set; }

        public int Tracking { get; set; }

        public string UsuarioId { get; set; }

        public UsuarioDTO Usuario { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string Descripcion { get; set; }

        public double Peso { get; set; }

        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

        public int ArancelId { get; set; }
        public Arancel Arancel { get; set; }

        public double Precio { get; set; }
    }
}
