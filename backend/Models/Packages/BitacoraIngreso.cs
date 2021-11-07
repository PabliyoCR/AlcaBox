﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Models
{
    public class BitacoraIngreso
    {

        [Key]
        public int Ingreso_Id { get; set; }

        [ForeignKey("Usuarios")]
        public ApplicationUser Usuario { get; set; }

        public DateTime Fecha { get; set; }




    }
}
