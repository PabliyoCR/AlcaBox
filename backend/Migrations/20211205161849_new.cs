using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace backend.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arancel",
                columns: table => new
                {
                    ArancelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arancel", x => x.ArancelId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    cedula = table.Column<string>(type: "text", nullable: true),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    primerApellido = table.Column<string>(type: "text", nullable: true),
                    segundoApellido = table.Column<string>(type: "text", nullable: true),
                    tipoCedula = table.Column<int>(type: "integer", nullable: false),
                    genero = table.Column<int>(type: "integer", nullable: false),
                    direccion = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    recibeOfertas = table.Column<bool>(type: "boolean", nullable: false),
                    tipoCuenta = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BitacoraAccion",
                columns: table => new
                {
                    Accion_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Usuarios = table.Column<string>(type: "text", nullable: true),
                    Fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Accion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitacoraAccion", x => x.Accion_Id);
                    table.ForeignKey(
                        name: "FK_BitacoraAccion_AspNetUsers_Usuarios",
                        column: x => x.Usuarios,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paquete",
                columns: table => new
                {
                    PaqueteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tracking = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<string>(type: "text", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Peso = table.Column<double>(type: "double precision", nullable: false),
                    ArancelId = table.Column<int>(type: "integer", nullable: false),
                    EstadoId = table.Column<int>(type: "integer", nullable: false),
                    Precio = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquete", x => x.PaqueteId);
                    table.ForeignKey(
                        name: "FK_Paquete_Arancel_ArancelId",
                        column: x => x.ArancelId,
                        principalTable: "Arancel",
                        principalColumn: "ArancelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paquete_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paquete_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Arancel",
                columns: new[] { "ArancelId", "Nombre" },
                values: new object[,]
                {
                    { 2, "Arancel_2" },
                    { 1, "Arancel_1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "Admin", "1", "Admin", "ADMIN" },
                    { "Funcionario", "2", "Funcionario", "FUNCIONARIO" },
                    { "Usuario", "3", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "cedula", "direccion", "genero", "nombre", "primerApellido", "recibeOfertas", "segundoApellido", "tipoCedula", "tipoCuenta" },
                values: new object[,]
                {
                    { "1b78746d-4fc2-4134-be69-2ca041a2fd9e", 0, "63832b5c-37a9-455a-943d-bfa74a292023", "admin@alcabox.com", false, false, null, "ADMIN@ALCABOX.COM", null, "AQAAAAEAACcQAAAAECeO2MEsNvNL1El3EYUghNvSHekx76SpAjT7bnr96X/+IFGsktJif04osbHsxZ16yg==", null, false, "a03cbec8-32c8-4630-ad5f-517329d0c326", false, "Admin", "11111111", "Direcion Admin", 1, "AlcaBox Admin", "Alca", false, "Box", 1, 1 },
                    { "5ff95fa9-027e-4a4d-b8db-5fc5a18f89c5", 0, "47356310-000e-4681-ac3b-227be23e0446", "billy@alcabox.com", false, false, null, "BILLY@ALCABOX.COM", null, "AQAAAAEAACcQAAAAEGUepLn9+miK+UYSMlDIoY2f+UGlUiPka0a9sA4xw4X5T+r8goJQuT/D+W5wOqJwAA==", null, false, "2939d8b0-9393-4318-b9ba-03891308b413", false, "Billy", "87654321", "Direcion Funcionario", 1, "Billy", "H", false, "", 1, 1 },
                    { "5fce9bf7-687d-490e-8458-59628d28551c", 0, "80b452f1-e830-4850-a040-850b9aafab96", "pablo@alcabox.com", false, false, null, "PABLO@ALCABOX.COM", null, "AQAAAAEAACcQAAAAEOdhZk8qafJrNDNFUNcPV02zsD9P0ZBc6q43xXiWkDLe7+ocjTSHvCtGq2aiDEgPMg==", null, false, "19f0ea5c-dbef-4fe9-86e3-6a6e15b90fb2", false, "Pablo", "12345678", "Direcion Usuario", 1, "Pablo J.", "J", true, "", 1, 1 },
                    { "76ece59b-af44-4eb8-92a1-437d17fa7502", 0, "0f6ff550-d2f9-4826-8ec5-a65b57ea8b06", "bot@alcabox.com", false, false, null, "BOT@ALCABOX.COM", null, "AQAAAAEAACcQAAAAEN2jmqZCjBHMUBGS5iHT3epbHda1/i4RCLGw15a2qEEUcVlY723vHsU93kzoE1/SGQ==", null, false, "3443ad55-4c22-42cf-914d-3afb668c02ad", false, "Bot", "55555555", "Direcion Bot", 1, "Bot R.", "B", false, "", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "EstadoId", "Nombre" },
                values: new object[,]
                {
                    { 8, "Entregado" },
                    { 1, "En espera a Courier" },
                    { 2, "Recibido en Courier" },
                    { 3, "En Tránsito a CR" },
                    { 4, "En vuelo" },
                    { 5, "Recibido en Aduanas" },
                    { 6, "En trámite Aduanal" },
                    { 7, "En proceso de Entrega" },
                    { 9, "Finalizado" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "Admin", "1b78746d-4fc2-4134-be69-2ca041a2fd9e" },
                    { "Funcionario", "5ff95fa9-027e-4a4d-b8db-5fc5a18f89c5" },
                    { "Usuario", "5fce9bf7-687d-490e-8458-59628d28551c" },
                    { "Usuario", "76ece59b-af44-4eb8-92a1-437d17fa7502" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraAccion_Usuarios",
                table: "BitacoraAccion",
                column: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "IX_Paquete_ArancelId",
                table: "Paquete",
                column: "ArancelId");

            migrationBuilder.CreateIndex(
                name: "IX_Paquete_EstadoId",
                table: "Paquete",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paquete_UsuarioId",
                table: "Paquete",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BitacoraAccion");

            migrationBuilder.DropTable(
                name: "Paquete");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Arancel");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
