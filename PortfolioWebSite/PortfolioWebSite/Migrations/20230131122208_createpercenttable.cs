using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioWebSite.Migrations
{
    public partial class createpercenttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Percents",
                newName: "Min");

            migrationBuilder.AddColumn<int>(
                name: "Max",
                table: "Percents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Max",
                table: "Percents");

            migrationBuilder.RenameColumn(
                name: "Min",
                table: "Percents",
                newName: "Number");
        }
    }
}
