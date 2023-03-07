using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioWebSite.Migrations
{
    public partial class updateabouttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Paragraph",
                table: "Abouts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Paragraph",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
