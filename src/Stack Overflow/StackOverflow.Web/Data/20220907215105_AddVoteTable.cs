using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflow.Web.Data
{
    public partial class AddVoteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vote_AspNetUsers_ApplicationUserId",
                table: "Vote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vote",
                table: "Vote");

            migrationBuilder.RenameTable(
                name: "Vote",
                newName: "Votes");

            migrationBuilder.RenameIndex(
                name: "IX_Vote_ApplicationUserId",
                table: "Votes",
                newName: "IX_Votes_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votes",
                table: "Votes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "637982058632865429");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "637982058632865508");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63d43d25-1bf4-4a11-bbb7-968bb4d1765c", "AQAAAAEAACcQAAAAEMRAxkii5SXa5B1ADeRc6i+ddkAYuiLeoT8oUPOUGIjqUrd9sIOyQeTdiKwqub19RA==", "9db84437-121a-4b59-beb6-9dc069f9076b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95791690-023c-4951-a932-90e200236820", "AQAAAAEAACcQAAAAEK3wMMebJn0LcIkHCmzoVlPYLNypYMAoNuMIiXyVl4Z5+7jjmB5zJ8Bf8fcGOLIFkQ==", "54447caa-99a9-4e89-a677-ffc01f340085" });

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_AspNetUsers_ApplicationUserId",
                table: "Votes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_AspNetUsers_ApplicationUserId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votes",
                table: "Votes");

            migrationBuilder.RenameTable(
                name: "Votes",
                newName: "Vote");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_ApplicationUserId",
                table: "Vote",
                newName: "IX_Vote_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vote",
                table: "Vote",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_AspNetUsers_ApplicationUserId",
                table: "Vote",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
