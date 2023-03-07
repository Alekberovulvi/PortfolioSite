using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioWebSite.Migrations
{
    public partial class updateaboutmodel2table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Abouts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
