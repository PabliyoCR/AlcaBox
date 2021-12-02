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
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        }

        //public DbSet<ApplicationUser> ApplicationsUser { get; set; }

        public DbSet<Paquete> Paquete { get; set; }

        public DbSet<BitacoraAccion> BitacoraAccion { get; set; }

        public DbSet<Arancel> Arancel { get; set; }

        public DbSet<Estado> Estado { get; set; }


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
        private string idUsuario1 = Guid.NewGuid().ToString();
        private string idUsuario2 = Guid.NewGuid().ToString();

        // Pregarga de usuarios
        private void SeedUsers(ModelBuilder modelBuilder)
        {
            // Usuario Admin
            ApplicationUser adminUser = new ApplicationUser()
            {
                Id = idAdmin, UserName = "Admin", nombre = "AlcaBox Admin", cedula = "11111111", Email = "admin@alcabox.com", NormalizedEmail = "ADMIN@ALCABOX.COM", primerApellido = "Alca", segundoApellido = "Box", tipoCedula = 1, genero = 1, direccion = "Direcion Admin", recibeOfertas = false, tipoCuenta = 1
            };
            PasswordHasher<ApplicationUser> adminPH = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = adminPH.HashPassword(adminUser, "2021Proyecto.");

            // Usuario Funcionario
            ApplicationUser funcionarioUser = new ApplicationUser()
            {
                Id = idFuncionario, UserName = "Billy", nombre = "Billy", cedula = "87654321", Email = "billy@alcabox.com", NormalizedEmail = "BILLY@ALCABOX.COM", primerApellido = "H", segundoApellido = "", tipoCedula = 1, genero = 1, direccion = "Direcion Funcionario", recibeOfertas = false, tipoCuenta = 1
            };
            PasswordHasher<ApplicationUser> funcionarioPH = new PasswordHasher<ApplicationUser>();
            funcionarioUser.PasswordHash = funcionarioPH.HashPassword(funcionarioUser, "2021Proyecto.");

            // Usuario 1
            ApplicationUser user1 = new ApplicationUser()
            {
                Id = idUsuario1, UserName = "Pablo", nombre = "Pablo J.", cedula = "12345678", Email = "pablo@alcabox.com", NormalizedEmail = "PABLO@ALCABOX.COM", primerApellido = "J", segundoApellido = "", tipoCedula = 1, genero = 1, direccion = "Direcion Usuario", recibeOfertas = true, tipoCuenta = 1
            };
            PasswordHasher<ApplicationUser> usuario1PH = new PasswordHasher<ApplicationUser>();
            user1.PasswordHash = usuario1PH.HashPassword(user1, "2021Proyecto.");

            // Usuario 1
            ApplicationUser user2 = new ApplicationUser()
            {
                Id = idUsuario2, UserName = "Bot", nombre = "Bot R.", cedula = "55555555", Email = "bot@alcabox.com", NormalizedEmail = "BOT@ALCABOX.COM", primerApellido = "B", segundoApellido = "", tipoCedula = 1, genero = 1, direccion = "Direcion Bot", recibeOfertas = false, tipoCuenta = 1
            };
            PasswordHasher<ApplicationUser> usuario2PH = new PasswordHasher<ApplicationUser>();
            user2.PasswordHash = usuario2PH.HashPassword(user2, "2021Proyecto.");

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser, funcionarioUser, user1, user2);
        }


        // Precarga de Roles
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "Admin", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                     new IdentityRole() { Id = "Funcionario", Name = "Funcionario", ConcurrencyStamp = "2", NormalizedName = "FUNCIONARIO" },
                     new IdentityRole() { Id = "Usuario", Name = "Usuario", ConcurrencyStamp = "3", NormalizedName = "USUARIO" }
                );
        }

        // Asignacion de Usuario precargados a Roles precargados
        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "Admin", UserId = idAdmin },
                    new IdentityUserRole<string>() { RoleId = "Funcionario", UserId = idFuncionario },
                    new IdentityUserRole<string>() { RoleId = "Usuario", UserId = idUsuario1 },
                    new IdentityUserRole<string>() { RoleId = "Usuario", UserId = idUsuario2 }
                );
        }

        // Precarga de Estados
        private void SeedEstados(ModelBuilder builder)
        {
            builder.Entity<Estado>().HasData(
                   new Estado() { EstadoId = 1, Nombre = "En espera a Courier" },
                    new Estado() { EstadoId = 2, Nombre = "Recibido en Courier" },
                    new Estado() { EstadoId = 3, Nombre = "En Tránsito a CR" },
                    new Estado() { EstadoId = 4, Nombre = "En vuelo" },
                    new Estado() { EstadoId = 5, Nombre = "Recibido en Aduanas" },
                    new Estado() { EstadoId = 6, Nombre = "En trámite Aduanal" },
                    new Estado() { EstadoId = 7, Nombre = "En proceso de Entrega" },
                    new Estado() { EstadoId = 8, Nombre = "Entregado" },
                    new Estado() { EstadoId = 9, Nombre = "Finalizado" }
                );
        }

        // Precarga de Aranceles
        private void SeedAranceles(ModelBuilder builder)
        {
            builder.Entity<Arancel>().HasData(
                   new Arancel() { ArancelId = 1, Nombre = "Arancel_1" },
                   new Arancel() { ArancelId = 2, Nombre = "Arancel_2" }
                );
        }
    }
}
