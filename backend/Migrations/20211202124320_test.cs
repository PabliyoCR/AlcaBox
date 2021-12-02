using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace backend.Migrations
{
    public partial class test : Migration
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
                    { "432e0b12-6f62-4a9e-8f77-7e4c2440aa8f", 0, "330983d8-39c4-497a-a0bf-b5be751c189a", "admin@alcabox.com", false, false, null, "ADMIN@ALCABOX.COM", null, "AQAAAAEAACcQAAAAEHHysBNJsqz26DN7/oUDkt+mU0ZXMCTD8fSquZG9FhKl37FOugpz6Dp50hCKzUIIog==", null, false, "00ad4e9a-3230-4fab-9c19-2cbd1ebca9f6", false, "Admin", "11111111", "Direcion Admin", 1, "AlcaBox Admin", "Alca", false, "Box", 1, 1 },
                    { "dc5214ae-d794-4da1-a4b8-4c32883a026e", 0, "e2af34ab-a66e-4c46-9f6c-648b966cd61d", "billy@alcabox.com", false, false, null, "BILLY@ALCABOX.COM", null, "AQAAAAEAACcQAAAAENLtbroaBVGLd8PplJXprnZJ9UMQts3yYYn9GH6ojTlxhqsZ3Ot9qrT8yT7kAhxs1Q==", null, false, "13d73cdc-26f5-496c-8758-1b695b10c83b", false, "Billy", "87654321", "Direcion Funcionario", 1, "Billy", "H", false, "", 1, 1 },
                    { "0414ef00-51f7-4cc5-aae8-b783ad4f3769", 0, "65671a1a-9ff5-4fac-a7e2-5ec8fe1c255d", "pablo@alcabox.com", false, false, null, "PABLO@ALCABOX.COM", null, "AQAAAAEAACcQAAAAEGP0753CNzZD3cy1MY+KpGQL8v8Il6UsArn0WKbiFc86VnFkTiAr4VWxP5gbreXakQ==", null, false, "ff8384df-9221-443d-9880-5cf9e78bb5bf", false, "Pablo", "12345678", "Direcion Usuario", 1, "Pablo J.", "J", true, "", 1, 1 },
                    { "51596782-b6e5-43de-9a9b-0087a57ec613", 0, "1764921b-c157-448c-b791-a45d3c0b4479", "bot@alcabox.com", false, false, null, "BOT@ALCABOX.COM", null, "AQAAAAEAACcQAAAAEJ1eyj9nEtBMbk26vR0TFTSqg2/eO04M7rBh5wp7f3KsswKFaYPpx+dH2tqxBXa/Jg==", null, false, "43149d2d-5c29-4178-a302-762b52c1eb95", false, "Bot", "55555555", "Direcion Bot", 1, "Bot R.", "B", false, "", 1, 1 }
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
                    { "Admin", "432e0b12-6f62-4a9e-8f77-7e4c2440aa8f" },
                    { "Funcionario", "dc5214ae-d794-4da1-a4b8-4c32883a026e" },
                    { "Usuario", "0414ef00-51f7-4cc5-aae8-b783ad4f3769" },
                    { "Usuario", "51596782-b6e5-43de-9a9b-0087a57ec613" }
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
