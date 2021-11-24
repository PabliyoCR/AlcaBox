using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class xd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "561d0cb1-5b93-401c-b465-6011c3bef6b9", "1", "Admin", "Admin" },
                    { "953ecffe-3889-4c70-9200-aa4af3e8ad0f", "2", "Funcionario", "Funcionario" },
                    { "e812d859-a09f-4f6e-96d0-ea3a8b28f21a", "3", "Usuario", "Usuario" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Acepta_Terminos", "Cedula", "ConcurrencyStamp", "Direccion", "Discriminator", "Email", "EmailConfirmed", "Genero", "LockoutEnabled", "LockoutEnd", "Nombre", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Primer_Apellido", "Recibe_Ofertas", "SecurityStamp", "Segundo_Apellido", "TipoCedula", "TipoCuenta", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "f92d6735-5a1f-460d-a542-230a2c920247", 0, false, null, "b1a88ae2-2293-464e-a2c5-41fc4813bd20", null, "ApplicationUser", "admin@alcabox.com", false, null, false, null, null, "ADMIN@ALCABOX.COM", null, "AQAAAAEAACcQAAAAEMlHMyXh228p88/x60H0oYLIIiCCjskKt7y1Giml/YvYMArN/KV+gWTo0w4PfpZcig==", null, false, null, false, "842d89ba-be84-49cf-b77e-3466de3f8437", null, null, null, false, "Admin" },
                    { "0e19ee5d-12c5-4db8-97ea-79364552dc52", 0, false, null, "c39ba87b-93c3-422d-83a1-a4ae413d736d", null, "ApplicationUser", "billy@alcabox.com", false, null, false, null, null, "BILLY@ALCABOX.COM", null, "AQAAAAEAACcQAAAAEE3GB0lPuKByiD7Rh33ljyVqwOUvR/sEbxP8YhKLbUuqHueLdB4qOZ22I9YffMA4Yw==", null, false, null, false, "2b796b8c-d2a8-4fd0-9cee-c2da2e779f47", null, null, null, false, "Billy" },
                    { "e463086e-f4f3-4cef-ab22-d0a893f66f55", 0, false, null, "0c3d9cfa-9e57-478f-98d0-ff8997fb3a8e", null, "ApplicationUser", "pablo@alcabox.com", false, null, false, null, null, "PABLO@ALCABOX.COM", null, "AQAAAAEAACcQAAAAEC3w/qrM0N/uyp0rt6L+QbpAadrjKfFUeLfOuP8KnIMhbG3gZTASEH4pm0SoyrECvg==", null, false, null, false, "3fd31634-3c9f-472f-afad-84feaa85c0c2", null, null, null, false, "Pablo" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "561d0cb1-5b93-401c-b465-6011c3bef6b9", "f92d6735-5a1f-460d-a542-230a2c920247" },
                    { "953ecffe-3889-4c70-9200-aa4af3e8ad0f", "0e19ee5d-12c5-4db8-97ea-79364552dc52" },
                    { "e812d859-a09f-4f6e-96d0-ea3a8b28f21a", "e463086e-f4f3-4cef-ab22-d0a893f66f55" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "953ecffe-3889-4c70-9200-aa4af3e8ad0f", "0e19ee5d-12c5-4db8-97ea-79364552dc52" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e812d859-a09f-4f6e-96d0-ea3a8b28f21a", "e463086e-f4f3-4cef-ab22-d0a893f66f55" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "561d0cb1-5b93-401c-b465-6011c3bef6b9", "f92d6735-5a1f-460d-a542-230a2c920247" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "561d0cb1-5b93-401c-b465-6011c3bef6b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "953ecffe-3889-4c70-9200-aa4af3e8ad0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e812d859-a09f-4f6e-96d0-ea3a8b28f21a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e19ee5d-12c5-4db8-97ea-79364552dc52");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e463086e-f4f3-4cef-ab22-d0a893f66f55");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f92d6735-5a1f-460d-a542-230a2c920247");

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
    }
}
