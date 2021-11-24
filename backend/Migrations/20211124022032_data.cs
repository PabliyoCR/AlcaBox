using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Acepta_Terminos",
                table: "AspNetUsers",
                type: "boolean",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Acepta_Terminos", "Cedula", "ConcurrencyStamp", "Direccion", "Discriminator", "Email", "EmailConfirmed", "Genero", "LockoutEnabled", "LockoutEnd", "Nombre", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Primer_Apellido", "Recibe_Ofertas", "SecurityStamp", "Segundo_Apellido", "TipoCedula", "TipoCuenta", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6fb39e29-be76-4c13-9c49-e7d05efbabd5", 0, false, null, "1862478e-4d2e-417a-9b5f-f1b2e06e2dcc", null, "ApplicationUser", "admin@alcabox.com", false, null, false, null, null, null, null, "AQAAAAEAACcQAAAAEHQNqBV1ujSwkzSG++pkkeOqQ8/d/HIgPJwO2BdPWIiWl7T4eLuGT0jTHmn9bAe+NA==", null, false, null, false, "0deaf985-20d9-4bc7-8271-60f7a2d1276e", null, null, null, false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6fb39e29-be76-4c13-9c49-e7d05efbabd5");

            migrationBuilder.DropColumn(
                name: "Acepta_Terminos",
                table: "AspNetUsers");
        }
    }
}
