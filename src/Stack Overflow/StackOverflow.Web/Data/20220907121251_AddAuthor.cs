using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflow.Web.Data
{
    public partial class AddAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "637981711684495697");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "637981711684495786");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66c7c406-eddc-4145-a4c6-23f669e92ca6", "AQAAAAEAACcQAAAAENdkng2u5yOMmWTFEoYopSBRk3OYKMee0uXozu4kwgvN6Vskdy8hHhy5mQkcciGvRw==", "5d9e454b-abe6-4996-9e8d-b0954b509d69" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f23ab084-c5ea-46bd-86b0-e256bb79ecd3", "AQAAAAEAACcQAAAAEHrMrztwrV8i95L8MNlzSkmqv92OJi2r+HpRZPWFuBJaUKmHVfu840NnASRnik51TA==", "ebdedaf3-8db1-4bb3-8849-41aca51399e0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "637981510778766098");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "637981510778766172");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f751d42-1328-4fe9-a005-469a22baf92d", "AQAAAAEAACcQAAAAECLgOBmlwLHNXvpPOAVlAmmU/Rpw5irVIXYQbIFOGfes/MdPyD8JS7B67bHnVFuccg==", "63cef47e-2034-4730-abf5-43426f0bd486" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa666466-5c3c-4d72-9e4c-51940e65154c", "AQAAAAEAACcQAAAAEBk5MH1Muy6kTzOBE0g1l85jiiQwN3fGNeoodDNyUUedUuETKGfJojI244erixM/cA==", "4fb753e3-5a89-4c4d-9c5d-1270a9a28702" });
        }
    }
}
