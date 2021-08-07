using Microsoft.EntityFrameworkCore.Migrations;

namespace Wizlib_DataAccess.Migrations
{
    public partial class ChangeNameToGenreName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Genres");

            migrationBuilder.AddColumn<string>(
                name: "GenreName",
                table: "Genres",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenreName",
                table: "Genres");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
