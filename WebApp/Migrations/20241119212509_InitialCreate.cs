using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Organizations_OgranizationId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_OgranizationId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OgranizationId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Organizations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 19, 22, 25, 9, 627, DateTimeKind.Local).AddTicks(9883));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 19, 22, 25, 9, 627, DateTimeKind.Local).AddTicks(9924));

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_OrganizationId",
                table: "Contacts",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Organizations_OrganizationId",
                table: "Contacts",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Organizations_OrganizationId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_OrganizationId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Organizations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "OgranizationId",
                table: "Contacts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "OgranizationId" },
                values: new object[] { new DateTime(2024, 11, 13, 11, 13, 14, 355, DateTimeKind.Local).AddTicks(9769), null });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "OgranizationId" },
                values: new object[] { new DateTime(2024, 11, 13, 11, 13, 14, 355, DateTimeKind.Local).AddTicks(9813), null });

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
    }
}
