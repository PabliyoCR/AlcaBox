using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "31341e48-b5a1-4551-9e21-0a42120798b2", "1", "Admin", "Admin" },
                    { "9e8fcaa8-b550-4306-8643-1372d46a43f7", "2", "Funcionario", "Funcionario" },
                    { "5eb663e1-39f4-4647-8120-014224d5b7bb", "3", "Usuario", "Usuario" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Acepta_Terminos", "Cedula", "ConcurrencyStamp", "Direccion", "Discriminator", "Email", "EmailConfirmed", "Genero", "LockoutEnabled", "LockoutEnd", "Nombre", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Primer_Apellido", "Recibe_Ofertas", "SecurityStamp", "Segundo_Apellido", "TipoCedula", "TipoCuenta", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "299bf095-0596-4b16-b99b-facfd684c022", 0, false, null, "5a9cde58-6c0b-4d90-ab56-71ac6bd67d72", null, "ApplicationUser", "admin@alcabox.com", false, null, false, null, null, null, null, "AQAAAAEAACcQAAAAEEkgpKaTudXTpShGD/GppheYWfRqMBxm85UUmHagkT1lgCkp7n1GVMUe+Qf0zoUtsA==", null, false, null, false, "8a2da455-5922-41cc-9f66-cfb7b0e54816", null, null, null, false, "Admin" },
                    { "ae6b8a7a-459a-42d3-bc95-02cdad84b192", 0, false, null, "e2d6faf1-7821-4a7f-889b-d1b0573bb01f", null, "ApplicationUser", "billy@alcabox.com", false, null, false, null, null, null, null, "AQAAAAEAACcQAAAAEKzqq7tHijycngee2vLxQczlUqWRtUpa938MaFtHBmBjcFdB+3YsDFiq0dEvw1zCPQ==", null, false, null, false, "fc396a88-191e-4755-8c05-34ccb0c5a201", null, null, null, false, "Billy" },
                    { "85697de7-a829-46ef-9074-942d6e181658", 0, false, null, "14c79fd4-684b-4ff5-ba3c-6cce4d128281", null, "ApplicationUser", "pablo@alcabox.com", false, null, false, null, null, null, null, "AQAAAAEAACcQAAAAEKs0b3HWu2ggRJk9sUT6ltacFd7VVNF/RwmHrKVhXP5XmZ7f/oNA1uGeAAtqOb/qRg==", null, false, null, false, "dd086083-4f97-49b9-bf6d-ae48f4a8c9ea", null, null, null, false, "Pablo" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "31341e48-b5a1-4551-9e21-0a42120798b2", "299bf095-0596-4b16-b99b-facfd684c022" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5eb663e1-39f4-4647-8120-014224d5b7bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e8fcaa8-b550-4306-8643-1372d46a43f7");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "31341e48-b5a1-4551-9e21-0a42120798b2", "299bf095-0596-4b16-b99b-facfd684c022" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85697de7-a829-46ef-9074-942d6e181658");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae6b8a7a-459a-42d3-bc95-02cdad84b192");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31341e48-b5a1-4551-9e21-0a42120798b2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "299bf095-0596-4b16-b99b-facfd684c022");

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
    }
}
