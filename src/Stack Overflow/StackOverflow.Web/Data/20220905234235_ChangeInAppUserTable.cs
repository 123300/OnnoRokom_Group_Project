using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflow.Web.Data
{
    public partial class ChangeInAppUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVoteDone",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "Vote",
                table: "Questions",
                newName: "TotalQutnVote");

            migrationBuilder.AddColumn<bool>(
                name: "IsAnsVoteDone",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsQutnVoteDone",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TotalAnsVote",
                table: "Answers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "637980397527658931");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "637980397527659016");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2e343c5-4a94-4218-a85f-7568ff4c198d", "AQAAAAEAACcQAAAAEAOj7lXRqFUu818Sg5Kd3SZ2eBOl9sFpijOjQ8JB4sfQIadLJ1DOLjQBL8aJ+5YvTg==", "76cc7bc2-15b7-4c00-95e6-2c85ad3f81be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de7dfe33-305e-48f4-9ca4-e92a0a2d1f29", "AQAAAAEAACcQAAAAECdZ4ioGQ2elNrH4duJfZU9zKUUZfuR6G+pImuSJeYKCDVWyQMW4GmFYRSuePc8HuA==", "53547410-d788-4f44-9655-d36dcfa7a7e1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnsVoteDone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsQutnVoteDone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TotalAnsVote",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "TotalQutnVote",
                table: "Questions",
                newName: "Vote");

            migrationBuilder.AddColumn<bool>(
                name: "IsVoteDone",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "637980236307738571");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "637980236307738722");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66f3d202-2136-43c1-812f-bc8d639e07bd", "AQAAAAEAACcQAAAAELpyzq3yqjeXZKGAySQQhTqv8ewf2VD1AVqAduQxZEAcdnL77PYYG4GL8WOHvyTBuQ==", "c3e3adda-1140-4e22-9c0c-c78902496197" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14f5e790-2d07-4094-84fa-72c1bf510992", "AQAAAAEAACcQAAAAELXB1wndoyit/2tOG/L/dnEqgu3hF0/37zX7lvvlLj+vFtAbF5EYauCK2nnC620ALg==", "f736450d-e1f2-485a-992b-0b05b8a3a745" });
        }
    }
}
