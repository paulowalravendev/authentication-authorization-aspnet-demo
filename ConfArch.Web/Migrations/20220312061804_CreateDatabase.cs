using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfArch.Web.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConferenceId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendees_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConferenceId = table.Column<long>(type: "bigint", nullable: false),
                    Speaker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Conferences",
                columns: new[] { "Id", "Location", "Name", "Start" },
                values: new object[] { 1L, "Salt Lake City", "Pluralsight Live", new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Conferences",
                columns: new[] { "Id", "Location", "Name", "Start" },
                values: new object[] { 2L, "London", "Pluralsight Live", new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Id", "ConferenceId", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, "Lisa Overthere" },
                    { 2L, 1L, "Robin Eisenberg" },
                    { 3L, 2L, "Sue Mashmellow" }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "Approved", "ConferenceId", "Speaker", "Title" },
                values: new object[,]
                {
                    { 1L, false, 1L, "Roland Guijt", "Authentication and Authorization in ASP.NET Core" },
                    { 2L, false, 2L, "Cindy Reynolds", "Authentication and Authorization in ASP.NET Core" },
                    { 3L, false, 2L, "Heather Lipens", "ASP.NET Core TagHelpers" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_ConferenceId",
                table: "Attendees",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_ConferenceId",
                table: "Proposals",
                column: "ConferenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Conferences");
        }
    }
}
