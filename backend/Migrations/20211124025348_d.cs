using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a204248-bd2d-4e78-af7a-8c4348601864", "1", "Admin", "Admin" },
                    { "bf9ff2d2-1b53-4b17-a408-bbfb6594bc60", "2", "Funcionario", "Funcionario" },
                    { "916f5763-8838-4430-84ea-687c949a6fdf", "3", "Usuario", "Usuario" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Acepta_Terminos", "Cedula", "ConcurrencyStamp", "Direccion", "Discriminator", "Email", "EmailConfirmed", "Genero", "LockoutEnabled", "LockoutEnd", "Nombre", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Primer_Apellido", "Recibe_Ofertas", "SecurityStamp", "Segundo_Apellido", "TipoCedula", "TipoCuenta", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "f331ff8b-ab5b-410a-b080-b96e10e6c87a", 0, false, null, "e57bd329-eee2-4846-ae35-bf3da751342f", null, "ApplicationUser", "admin@alcabox.com", false, null, false, null, null, null, null, "AQAAAAEAACcQAAAAEA9rJ+F32Ac2CvljA9poMjUpOxNEK9BJLBXgRg4Z7fbVaHx01ICXkH2s5CU82ZFyHw==", null, false, null, false, "8e96a83f-646e-481c-8cf8-d631c7c14b0d", null, null, null, false, "Admin" },
                    { "127a32d4-f781-49e6-8818-4825a60bb88b", 0, false, null, "e313d357-5a55-4603-8827-8152c6dd5547", null, "ApplicationUser", "billy@alcabox.com", false, null, false, null, null, null, null, "AQAAAAEAACcQAAAAEOwKtAL7xKIpTWYsOHzUAH0FW0zQqMmEjvcMnprBEyuHnO/Da5FJgqX6jHb2t2LiLA==", null, false, null, false, "473384d1-f8d6-4602-b5bb-567313644b92", null, null, null, false, "Billy" },
                    { "26fa41fc-eb42-4a53-879e-389c331e059a", 0, false, null, "898b434a-efdb-4763-9638-a27333820abc", null, "ApplicationUser", "pablo@alcabox.com", false, null, false, null, null, null, null, "AQAAAAEAACcQAAAAEBh1tttLryAntmn+4JRU1X3czF2ymZiqeMhsWhthigM2VJHjY3xFLLmg1XEbdRAqJA==", null, false, null, false, "72c53197-f9b1-46bb-9fb2-5deac1251d0e", null, null, null, false, "Pablo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a204248-bd2d-4e78-af7a-8c4348601864");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "916f5763-8838-4430-84ea-687c949a6fdf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf9ff2d2-1b53-4b17-a408-bbfb6594bc60");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "127a32d4-f781-49e6-8818-4825a60bb88b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26fa41fc-eb42-4a53-879e-389c331e059a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f331ff8b-ab5b-410a-b080-b96e10e6c87a");

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
    }
}
