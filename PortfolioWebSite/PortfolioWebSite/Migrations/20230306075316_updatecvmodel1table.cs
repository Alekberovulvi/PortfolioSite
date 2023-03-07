using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioWebSite.Migrations
{
    public partial class updatecvmodel1table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Cvs",
                newName: "FileName");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Cvs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Cvs");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Cvs",
                newName: "FilePath");
        }
    }
}
