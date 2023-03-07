using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioWebSite.Migrations
{
    public partial class updatedbtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "AboutsSites",
                newName: "Website");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "AboutsSites",
                newName: "Phone");

            migrationBuilder.AddColumn<DateTime>(
                name: "Brithday",
                table: "AboutsSites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AboutsSites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "AboutsSites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AboutsSites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Freelance",
                table: "AboutsSites",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AboutsSites",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brithday",
                table: "AboutsSites");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AboutsSites");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "AboutsSites");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AboutsSites");

            migrationBuilder.DropColumn(
                name: "Freelance",
                table: "AboutsSites");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AboutsSites");

            migrationBuilder.RenameColumn(
                name: "Website",
                table: "AboutsSites",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "AboutsSites",
                newName: "Description");
        }
    }
}
