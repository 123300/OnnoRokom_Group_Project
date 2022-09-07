using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflow.Web.Data
{
    public partial class AddAuthorName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "637981715771974995");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "637981715771975075");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acd4251d-a513-4b11-8207-1bffd17d8aaf", "AQAAAAEAACcQAAAAEKH3/8Y7wgO7izCYKFU1gWs8txsSaTFNkofkdcWIOLYIWnBxzrceLZ09ZSswaOAvGQ==", "dca8943e-82c8-4b81-8886-4a84c166a5f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86a2e49a-edc6-481e-a418-6ef9e83f26ce", "AQAAAAEAACcQAAAAEDSa4I/WNdLfgBSMPuzCuoMGGkQlZD/24Ya4M4B2jfhHA0e2fNhhSPW7Ot2/9z+dWg==", "5e0308c3-6a9c-4faa-aa64-43bb2d72910a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Answers");

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
    }
}
