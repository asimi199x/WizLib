﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Wizlib_DataAccess.Migrations
{
    public partial class AddOneToOneRelBookandBookDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_Categor_Id",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Books_Categor_Id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Categor_Id",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookDetail_Id",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookDetail",
                columns: table => new
                {
                    BookDetail_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfChapters = table.Column<int>(nullable: false),
                    NumberOfPages = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDetail", x => x.BookDetail_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookDetail_Id",
                table: "Books",
                column: "BookDetail_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetail_BookDetail_Id",
                table: "Books",
                column: "BookDetail_Id",
                principalTable: "BookDetail",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetail_BookDetail_Id",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookDetail");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookDetail_Id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookDetail_Id",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "Categor_Id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Category_Id);
                });

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
    }
}
