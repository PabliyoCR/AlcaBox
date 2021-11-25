using backend.Models;
using Microsoft.AspNetCore.Identity;
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

        public DbSet<Paquete> Paquete { get; set; }

        public DbSet<Estado> Estado { get; set; }

        public DbSet<Arancel> Arancel { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            this.SeedUsers(modelBuilder);
            this.SeedRoles(modelBuilder);
            this.SeedUserRoles(modelBuilder);
            this.SeedEstados(modelBuilder);
            this.SeedAranceles(modelBuilder);
        }

        private string idAdmin = Guid.NewGuid().ToString();
        private string idFuncionario = Guid.NewGuid().ToString();
        private string idUsuario = Guid.NewGuid().ToString();

        // Pregarga de usuarios
        private void SeedUsers(ModelBuilder modelBuilder)
        {
            // Usuario Admin
            ApplicationUser adminUser = new ApplicationUser()
            {
                Id = idAdmin,
                UserName = "Admin",
                Email = "admin@alcabox.com",
                NormalizedEmail = "ADMIN@ALCABOX.COM"
            };
            PasswordHasher<ApplicationUser> adminPH = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = adminPH.HashPassword(adminUser, "2021Proyecto.");

            // Usuario Funcionario
            ApplicationUser funcionarioUser = new ApplicationUser()
            {
                Id = idFuncionario,
                UserName = "Billy",
                Email = "billy@alcabox.com",
                NormalizedEmail = "BILLY@ALCABOX.COM"
            };
            PasswordHasher<ApplicationUser> funcionarioPH = new PasswordHasher<ApplicationUser>();
            funcionarioUser.PasswordHash = funcionarioPH.HashPassword(funcionarioUser, "2021Proyecto.");

            // Usuario
            ApplicationUser user = new ApplicationUser()
            {
                Id = idUsuario,
                UserName = "Pablo",
                Email = "pablo@alcabox.com",
                NormalizedEmail = "PABLO@ALCABOX.COM"
            };
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = ph.HashPassword(user, "2021Proyecto.");

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser, funcionarioUser, user);
        }


        // Precarga de Roles
        private string idAdminRole = Guid.NewGuid().ToString();
        private string idFuncionarioRole = Guid.NewGuid().ToString();
        private string idUsuarioRole = Guid.NewGuid().ToString();

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = idAdminRole, Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                     new IdentityRole() { Id = idFuncionarioRole, Name = "Funcionario", ConcurrencyStamp = "2", NormalizedName = "Funcionario" },
                     new IdentityRole() { Id = idUsuarioRole, Name = "Usuario", ConcurrencyStamp = "3", NormalizedName = "Usuario" }
                );
        }

        // Asignacion de Usuario precargados a Roles precargados
        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = idAdminRole, UserId = idAdmin },
                    new IdentityUserRole<string>() { RoleId = idFuncionarioRole, UserId = idFuncionario },
                    new IdentityUserRole<string>() { RoleId = idUsuarioRole, UserId = idUsuario }
                );
        }

        // Precarga de Estados
        private void SeedEstados(ModelBuilder builder)
        {
            builder.Entity<Estado>().HasData(
                   new Estado() { Estado_Id = 1, Nombre = "En espera a Courier" },
                    new Estado() { Estado_Id = 2, Nombre = "Recibido en Courier" },
                    new Estado() { Estado_Id = 3, Nombre = "En Tránsito a CR" },
                    new Estado() { Estado_Id = 4, Nombre = "En vuelo" },
                    new Estado() { Estado_Id = 5, Nombre = "Recibido en Aduanas" },
                    new Estado() { Estado_Id = 6, Nombre = "En trámite Aduanal" },
                    new Estado() { Estado_Id = 7, Nombre = "En proceso de Entrega" },
                    new Estado() { Estado_Id = 8, Nombre = "Entregado" },
                    new Estado() { Estado_Id = 9, Nombre = "Finalizado" }
                );
        }

        // Precarga de Aranceles
        private void SeedAranceles(ModelBuilder builder)
        {
            builder.Entity<Arancel>().HasData(
                   new Arancel() { Arancel_Id = 1, Nombre = "Arancel_1" },
                   new Arancel() { Arancel_Id = 2, Nombre = "Arancel_2" }
                );
        }
    }
}
