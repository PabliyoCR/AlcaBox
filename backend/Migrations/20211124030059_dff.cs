using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class dff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "2b911654-0dac-43f2-8c96-81baa2a5c6e0", "1", "Admin", "Admin" },
                    { "b102b20d-883d-48ed-9842-4e3f2c9005c9", "2", "Funcionario", "Funcionario" },
                    { "dcbd3641-594e-4815-9fbc-38ed34c7f6eb", "3", "Usuario", "Usuario" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Acepta_Terminos", "Cedula", "ConcurrencyStamp", "Direccion", "Discriminator", "Email", "EmailConfirmed", "Genero", "LockoutEnabled", "LockoutEnd", "Nombre", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Primer_Apellido", "Recibe_Ofertas", "SecurityStamp", "Segundo_Apellido", "TipoCedula", "TipoCuenta", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "63426d6a-3f3b-4e05-b689-a5f6288ff013", 0, false, null, "81fbfd26-442b-4cbe-976a-c78fd4b838b0", null, "ApplicationUser", "admin@alcabox.com", false, null, false, null, null, null, null, "AQAAAAEAACcQAAAAEELJlbOV7ykKe5WM7OBR9m5E5X3F6pH6d/uxLPJ7L+2QeEn0dNfOW97edrVOJT+rjQ==", null, false, null, false, "303e0bd8-e510-4ea0-b774-047bda104747", null, null, null, false, "Admin" },
                    { "15849084-e7b4-44d8-b1e2-084d229a912f", 0, false, null, "cc24440d-9f5c-47e1-af68-b7e949cadc4b", null, "ApplicationUser", "billy@alcabox.com", false, null, false, null, null, null, null, "AQAAAAEAACcQAAAAELwuDERdlkyBrV8p+pPficClGPFJr8fH8pS1Ye0SgL9YhVb7sTGFUC8VgvSz4cYw3w==", null, false, null, false, "def73113-a916-4d7b-83be-36edddff686a", null, null, null, false, "Billy" },
                    { "215d7a96-568e-4469-81fd-780744a633d6", 0, false, null, "5aaad363-863e-4af0-8f90-69d260bd3b49", null, "ApplicationUser", "pablo@alcabox.com", false, null, false, null, null, null, null, "AQAAAAEAACcQAAAAEEtzGD5U6CmPDM9Dwd7jooEg2Qsr6IqC3VpcP/I1zdit5HCEyt2BsFPa63ELeLw3ZQ==", null, false, null, false, "98eacc14-5cf7-46cf-ad9f-238f4e9faad8", null, null, null, false, "Pablo" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2b911654-0dac-43f2-8c96-81baa2a5c6e0", "63426d6a-3f3b-4e05-b689-a5f6288ff013" },
                    { "b102b20d-883d-48ed-9842-4e3f2c9005c9", "15849084-e7b4-44d8-b1e2-084d229a912f" },
                    { "dcbd3641-594e-4815-9fbc-38ed34c7f6eb", "215d7a96-568e-4469-81fd-780744a633d6" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b102b20d-883d-48ed-9842-4e3f2c9005c9", "15849084-e7b4-44d8-b1e2-084d229a912f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dcbd3641-594e-4815-9fbc-38ed34c7f6eb", "215d7a96-568e-4469-81fd-780744a633d6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2b911654-0dac-43f2-8c96-81baa2a5c6e0", "63426d6a-3f3b-4e05-b689-a5f6288ff013" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b911654-0dac-43f2-8c96-81baa2a5c6e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b102b20d-883d-48ed-9842-4e3f2c9005c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcbd3641-594e-4815-9fbc-38ed34c7f6eb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15849084-e7b4-44d8-b1e2-084d229a912f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "215d7a96-568e-4469-81fd-780744a633d6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "63426d6a-3f3b-4e05-b689-a5f6288ff013");

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
    }
}
