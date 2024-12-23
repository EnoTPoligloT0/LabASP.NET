using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabProject.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    phone = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "BirthDate", "Category", "Created", "Email", "FirstName", "LastName", "phone" },
                values: new object[,]
                {
                    { 1, new DateOnly(1980, 1, 1), 0, new DateTime(2024, 11, 6, 11, 39, 26, 567, DateTimeKind.Local).AddTicks(4086), "johndoe@gmail.com", "John", "Doe", "123456789" },
                    { 2, new DateOnly(1980, 1, 1), 0, new DateTime(2024, 11, 6, 11, 39, 26, 567, DateTimeKind.Local).AddTicks(4135), "paulfoe@gmail.com", "Paul", "Foe", "123456789" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
