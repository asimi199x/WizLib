using Microsoft.EntityFrameworkCore.Migrations;

namespace Wizlib_DataAccess.Migrations
{
    public partial class AddRawCategoryToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories VALUES('Cat 1')");
            migrationBuilder.Sql("INSERT INTO Categories VALUES('Cat 2')");
            migrationBuilder.Sql("INSERT INTO Categories VALUES('Cat 3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
