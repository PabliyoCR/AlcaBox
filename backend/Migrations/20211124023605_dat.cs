using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class dat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6fb39e29-be76-4c13-9c49-e7d05efbabd5");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Acepta_Terminos", "Cedula", "ConcurrencyStamp", "Direccion", "Discriminator", "Email", "EmailConfirmed", "Genero", "LockoutEnabled", "LockoutEnd", "Nombre", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Primer_Apellido", "Recibe_Ofertas", "SecurityStamp", "Segundo_Apellido", "TipoCedula", "TipoCuenta", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5cf0b109-a0af-4a17-8685-611ac69ab770", 0, false, null, "47612d55-ccce-4d87-9a4e-1b2fe84fc7b7", null, "ApplicationUser", "admin@alcabox.com", false, null, false, null, null, null, null, "AQAAAAEAACcQAAAAEHhLAFuPxq8vzn+jYHgS1a22gpFCCW3j6u9lWqC6CiLxK9PT06IxHnwFxrhX+s0Fqw==", null, false, null, false, "e035b96a-6f03-402c-8eb2-ba650f56d100", null, null, null, false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf0b109-a0af-4a17-8685-611ac69ab770");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Acepta_Terminos", "Cedula", "ConcurrencyStamp", "Direccion", "Discriminator", "Email", "EmailConfirmed", "Genero", "LockoutEnabled", "LockoutEnd", "Nombre", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Primer_Apellido", "Recibe_Ofertas", "SecurityStamp", "Segundo_Apellido", "TipoCedula", "TipoCuenta", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6fb39e29-be76-4c13-9c49-e7d05efbabd5", 0, false, null, "1862478e-4d2e-417a-9b5f-f1b2e06e2dcc", null, "ApplicationUser", "admin@alcabox.com", false, null, false, null, null, null, null, "AQAAAAEAACcQAAAAEHQNqBV1ujSwkzSG++pkkeOqQ8/d/HIgPJwO2BdPWIiWl7T4eLuGT0jTHmn9bAe+NA==", null, false, null, false, "0deaf985-20d9-4bc7-8271-60f7a2d1276e", null, null, null, false, "Admin" });
        }
    }
}
