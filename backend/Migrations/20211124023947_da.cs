using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class da : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf0b109-a0af-4a17-8685-611ac69ab770");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f49a7fb8-a906-48ee-a44d-e2d4e2a2d2a9", "1", "Admin", "Admin" },
                    { "fd778ff3-ea98-41b0-82c3-7a13fc9ce463", "2", "Funcionario", "Funcionario" },
                    { "6fd60599-b050-4772-b0aa-615ddff5a418", "3", "Usuario", "Usuario" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Acepta_Terminos", "Cedula", "ConcurrencyStamp", "Direccion", "Discriminator", "Email", "EmailConfirmed", "Genero", "LockoutEnabled", "LockoutEnd", "Nombre", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Primer_Apellido", "Recibe_Ofertas", "SecurityStamp", "Segundo_Apellido", "TipoCedula", "TipoCuenta", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5081589f-db19-46de-a0d0-c44f8965e708", 0, false, null, "ec9adfda-2bcc-4a80-9c11-29c06ad3e29e", null, "ApplicationUser", "admin@alcabox.com", false, null, false, null, null, null, null, "AQAAAAEAACcQAAAAEADbBdYNZnzwvdsYC+MsoFEHOgn+ujw5J18mcoQ69VRPArmkiCMCymJuMB4mV9N5gw==", null, false, null, false, "aa609b30-ee95-4034-9863-1712f9af3970", null, null, null, false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fd60599-b050-4772-b0aa-615ddff5a418");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f49a7fb8-a906-48ee-a44d-e2d4e2a2d2a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd778ff3-ea98-41b0-82c3-7a13fc9ce463");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5081589f-db19-46de-a0d0-c44f8965e708");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Acepta_Terminos", "Cedula", "ConcurrencyStamp", "Direccion", "Discriminator", "Email", "EmailConfirmed", "Genero", "LockoutEnabled", "LockoutEnd", "Nombre", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Primer_Apellido", "Recibe_Ofertas", "SecurityStamp", "Segundo_Apellido", "TipoCedula", "TipoCuenta", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5cf0b109-a0af-4a17-8685-611ac69ab770", 0, false, null, "47612d55-ccce-4d87-9a4e-1b2fe84fc7b7", null, "ApplicationUser", "admin@alcabox.com", false, null, false, null, null, null, null, "AQAAAAEAACcQAAAAEHhLAFuPxq8vzn+jYHgS1a22gpFCCW3j6u9lWqC6CiLxK9PT06IxHnwFxrhX+s0Fqw==", null, false, null, false, "e035b96a-6f03-402c-8eb2-ba650f56d100", null, null, null, false, "Admin" });
        }
    }
}
