﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backend.DataAccess;

namespace backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "561d0cb1-5b93-401c-b465-6011c3bef6b9",
                            ConcurrencyStamp = "1",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        },
                        new
                        {
                            Id = "953ecffe-3889-4c70-9200-aa4af3e8ad0f",
                            ConcurrencyStamp = "2",
                            Name = "Funcionario",
                            NormalizedName = "Funcionario"
                        },
                        new
                        {
                            Id = "e812d859-a09f-4f6e-96d0-ea3a8b28f21a",
                            ConcurrencyStamp = "3",
                            Name = "Usuario",
                            NormalizedName = "Usuario"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "f92d6735-5a1f-460d-a542-230a2c920247",
                            RoleId = "561d0cb1-5b93-401c-b465-6011c3bef6b9"
                        },
                        new
                        {
                            UserId = "0e19ee5d-12c5-4db8-97ea-79364552dc52",
                            RoleId = "953ecffe-3889-4c70-9200-aa4af3e8ad0f"
                        },
                        new
                        {
                            UserId = "e463086e-f4f3-4cef-ab22-d0a893f66f55",
                            RoleId = "e812d859-a09f-4f6e-96d0-ea3a8b28f21a"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("backend.Models.Arancel", b =>
                {
                    b.Property<int>("Arancel_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("Arancel_Id");

                    b.ToTable("Arancel");
                });

            modelBuilder.Entity("backend.Models.BitacoraAccion", b =>
                {
                    b.Property<int>("Accion_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Accion")
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Usuarios")
                        .HasColumnType("text");

                    b.HasKey("Accion_Id");

                    b.HasIndex("Usuarios");

                    b.ToTable("BitacoraAccion");
                });

            modelBuilder.Entity("backend.Models.Estado", b =>
                {
                    b.Property<int>("Estado_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("Estado_Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("backend.Models.Paquete", b =>
                {
                    b.Property<int>("Paquete_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Aranceles")
                        .HasColumnType("integer");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<int>("Estado_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Peso")
                        .HasColumnType("double precision");

                    b.Property<double>("Precio")
                        .HasColumnType("double precision");

                    b.Property<int>("Tracking")
                        .HasColumnType("integer");

                    b.Property<string>("Usuarios")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Paquete_Id");

                    b.HasIndex("Aranceles");

                    b.HasIndex("Estado_id");

                    b.HasIndex("Usuarios");

                    b.ToTable("Paquete");
                });

            modelBuilder.Entity("backend.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<bool>("Acepta_Terminos")
                        .HasColumnType("boolean");

                    b.Property<string>("Cedula")
                        .HasColumnType("text");

                    b.Property<string>("Direccion")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Genero")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<string>("Primer_Apellido")
                        .HasColumnType("text");

                    b.Property<bool>("Recibe_Ofertas")
                        .HasColumnType("boolean");

                    b.Property<string>("Segundo_Apellido")
                        .HasColumnType("text");

                    b.Property<string>("TipoCedula")
                        .HasColumnType("text");

                    b.Property<string>("TipoCuenta")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "f92d6735-5a1f-460d-a542-230a2c920247",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b1a88ae2-2293-464e-a2c5-41fc4813bd20",
                            Email = "admin@alcabox.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ALCABOX.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEMlHMyXh228p88/x60H0oYLIIiCCjskKt7y1Giml/YvYMArN/KV+gWTo0w4PfpZcig==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "842d89ba-be84-49cf-b77e-3466de3f8437",
                            TwoFactorEnabled = false,
                            UserName = "Admin",
                            Acepta_Terminos = false,
                            Recibe_Ofertas = false
                        },
                        new
                        {
                            Id = "0e19ee5d-12c5-4db8-97ea-79364552dc52",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c39ba87b-93c3-422d-83a1-a4ae413d736d",
                            Email = "billy@alcabox.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "BILLY@ALCABOX.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEE3GB0lPuKByiD7Rh33ljyVqwOUvR/sEbxP8YhKLbUuqHueLdB4qOZ22I9YffMA4Yw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2b796b8c-d2a8-4fd0-9cee-c2da2e779f47",
                            TwoFactorEnabled = false,
                            UserName = "Billy",
                            Acepta_Terminos = false,
                            Recibe_Ofertas = false
                        },
                        new
                        {
                            Id = "e463086e-f4f3-4cef-ab22-d0a893f66f55",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0c3d9cfa-9e57-478f-98d0-ff8997fb3a8e",
                            Email = "pablo@alcabox.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "PABLO@ALCABOX.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEC3w/qrM0N/uyp0rt6L+QbpAadrjKfFUeLfOuP8KnIMhbG3gZTASEH4pm0SoyrECvg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3fd31634-3c9f-472f-afad-84feaa85c0c2",
                            TwoFactorEnabled = false,
                            UserName = "Pablo",
                            Acepta_Terminos = false,
                            Recibe_Ofertas = false
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backend.Models.BitacoraAccion", b =>
                {
                    b.HasOne("backend.Models.ApplicationUser", "Usuario")
                        .WithMany()
                        .HasForeignKey("Usuarios");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("backend.Models.Paquete", b =>
                {
                    b.HasOne("backend.Models.Arancel", "Arancel")
                        .WithMany()
                        .HasForeignKey("Aranceles")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("Estado_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.ApplicationUser", "Usuario")
                        .WithMany()
                        .HasForeignKey("Usuarios")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arancel");

                    b.Navigation("Estado");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
