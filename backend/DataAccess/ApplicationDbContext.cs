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

        public DbSet<Estado> Estado { get; set; }

        public DbSet<backend.Models.Paquete> Paquete { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            this.SeedUsers(modelBuilder);
            this.SeedRoles(modelBuilder);
            this.SeedUserRoles(modelBuilder);
        }

        private string idAdmin = Guid.NewGuid().ToString();
        private string idFuncionario = Guid.NewGuid().ToString();
        private string idUsuario = Guid.NewGuid().ToString();

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            // ADMIN
            ApplicationUser adminUser = new ApplicationUser()
            {
                Id = idAdmin,
                UserName = "Admin",
                Email = "admin@alcabox.com",
                NormalizedEmail = "ADMIN@ALCABOX.COM"
            };
            PasswordHasher<ApplicationUser> adminPH = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = adminPH.HashPassword(adminUser, "2021Proyecto.");
            
            // FUNCIONARIO
            ApplicationUser funcionarioUser = new ApplicationUser()
            {
                Id = idFuncionario,
                UserName = "Billy",
                Email = "billy@alcabox.com",
                NormalizedEmail = "BILLY@ALCABOX.COM"
            };
            PasswordHasher<ApplicationUser> funcionarioPH = new PasswordHasher<ApplicationUser>();
            funcionarioUser.PasswordHash = funcionarioPH.HashPassword(funcionarioUser, "2021Proyecto.");

            // USUARIO
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

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = idAdminRole, UserId = idAdmin },
                    new IdentityUserRole<string>() { RoleId = idFuncionarioRole, UserId = idFuncionario },
                    new IdentityUserRole<string>() { RoleId = idUsuarioRole, UserId = idUsuario }
                );
        }
    }
}
