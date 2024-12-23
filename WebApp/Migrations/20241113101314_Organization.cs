using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabProject.Migrations
{
    /// <inheritdoc />
    public partial class Organization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OgranizationId",
                table: "Contacts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Contacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 101);

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NIP = table.Column<string>(type: "TEXT", nullable: false),
                    REGON = table.Column<string>(type: "TEXT", nullable: false),
                    Adress_City = table.Column<string>(type: "TEXT", nullable: false),
                    Adress_Street = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "OgranizationId", "OrganizationId" },
                values: new object[] { new DateTime(2024, 11, 13, 11, 13, 14, 355, DateTimeKind.Local).AddTicks(9769), null, 101 });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "OgranizationId", "OrganizationId" },
                values: new object[] { new DateTime(2024, 11, 13, 11, 13, 14, 355, DateTimeKind.Local).AddTicks(9813), null, 101 });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Adress_City", "Adress_Street", "NIP", "Name", "REGON" },
                values: new object[,]
                {
                    { 101, "Krakow", "sw. Filipa 17", "123456", "Wsei", "929382382" },
                    { 102, "Lodz", "Dworcowa", "654321", "Halo", "929382382" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_OgranizationId",
                table: "Contacts",
                column: "OgranizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Organizations_OgranizationId",
                table: "Contacts",
                column: "OgranizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Organizations_OgranizationId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_OgranizationId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OgranizationId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Contacts");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 6, 11, 41, 56, 610, DateTimeKind.Local).AddTicks(4084));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 6, 11, 41, 56, 610, DateTimeKind.Local).AddTicks(4128));
        }
    }
}
