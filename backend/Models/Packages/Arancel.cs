﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Arancel
    {
        [Key]
        public int Arancel_Id { get; set; }

        public string Nombre { get; set; }
    }
}
