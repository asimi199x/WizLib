using Microsoft.EntityFrameworkCore.Migrations;

namespace Wizlib_DataAccess.Migrations
{
    public partial class addRelationBookandCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Categor_Id",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Categor_Id",
                table: "Books",
                column: "Categor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_Categor_Id",
                table: "Books",
                column: "Categor_Id",
                principalTable: "Categories",
                principalColumn: "Category_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_Categor_Id",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Categor_Id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Categor_Id",
                table: "Books");
        }
    }
}
