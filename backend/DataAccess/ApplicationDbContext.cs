using backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<ApplicationUser> ApplicationsUser { get; set; }

        public DbSet<BitacoraAccion> BitacoraAccion { get; set; }

        public DbSet<Estado> Estado { get; set; }

        public DbSet<backend.Models.Paquete> Paquete { get; set; }


    }
}
