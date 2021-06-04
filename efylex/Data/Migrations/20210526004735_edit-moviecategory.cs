using Microsoft.EntityFrameworkCore.Migrations;

namespace efylex.Data.Migrations
{
    public partial class editmoviecategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesCategory_Categories_CategoryId",
                table: "MoviesCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesCategory_Movies_MovieId",
                table: "MoviesCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesCategory",
                table: "MoviesCategory");

            migrationBuilder.RenameTable(
                name: "MoviesCategory",
                newName: "MoviesCategories");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesCategory_CategoryId",
                table: "MoviesCategories",
                newName: "IX_MoviesCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesCategories",
                table: "MoviesCategories",
                columns: new[] { "MovieId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesCategories_Categories_CategoryId",
                table: "MoviesCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesCategories_Movies_MovieId",
                table: "MoviesCategories",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesCategories_Categories_CategoryId",
                table: "MoviesCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesCategories_Movies_MovieId",
                table: "MoviesCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesCategories",
                table: "MoviesCategories");

            migrationBuilder.RenameTable(
                name: "MoviesCategories",
                newName: "MoviesCategory");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesCategories_CategoryId",
                table: "MoviesCategory",
                newName: "IX_MoviesCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesCategory",
                table: "MoviesCategory",
                columns: new[] { "MovieId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesCategory_Categories_CategoryId",
                table: "MoviesCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesCategory_Movies_MovieId",
                table: "MoviesCategory",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
