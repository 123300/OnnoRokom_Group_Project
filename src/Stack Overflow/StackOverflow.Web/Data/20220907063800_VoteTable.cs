using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflow.Web.Data
{
    public partial class VoteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalQutnVote",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsAnsVoteDone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsQutnVoteDone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsVoteDone",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "TotalAnsVote",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Vote",
                table: "Answers");

            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    AnswerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vote_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Vote_ApplicationUserId",
                table: "Vote",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.AddColumn<int>(
                name: "TotalQutnVote",
                table: "Questions",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddColumn<bool>(
                name: "IsVoteDone",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TotalAnsVote",
                table: "Answers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Vote",
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
    }
}
