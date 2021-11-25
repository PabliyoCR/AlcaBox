using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class PaqueteDTO
    {
        public int Paquete_Id { get; set; }
        public int Tracking { get; set; }
        public ApplicationUser Usuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Descripcion { get; set; }
        public double Peso { get; set; }
        public Arancel Arancel { get; set; }
        public Estado Estado { get; set; }
        public double Precio { get; set; }
    }
}
