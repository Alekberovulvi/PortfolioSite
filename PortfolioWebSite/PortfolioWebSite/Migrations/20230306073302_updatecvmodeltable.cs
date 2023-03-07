using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioWebSite.Migrations
{
    public partial class updatecvmodeltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Cvs",
                newName: "FilePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Cvs",
                newName: "FileName");
        }
    }
}
