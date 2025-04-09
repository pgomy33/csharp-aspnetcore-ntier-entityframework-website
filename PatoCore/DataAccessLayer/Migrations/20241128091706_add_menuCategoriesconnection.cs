using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class add_menuCategoriesconnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "repeat3s",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuCategoryID",
                table: "repeat3s",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_repeat3s_CategoryId",
                table: "repeat3s",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_repeat3s_MenuCategoryID",
                table: "repeat3s",
                column: "MenuCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_repeat3s_categories_CategoryId",
                table: "repeat3s",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_repeat3s_menuCategories_MenuCategoryID",
                table: "repeat3s",
                column: "MenuCategoryID",
                principalTable: "menuCategories",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_repeat3s_categories_CategoryId",
                table: "repeat3s");

            migrationBuilder.DropForeignKey(
                name: "FK_repeat3s_menuCategories_MenuCategoryID",
                table: "repeat3s");

            migrationBuilder.DropIndex(
                name: "IX_repeat3s_CategoryId",
                table: "repeat3s");

            migrationBuilder.DropIndex(
                name: "IX_repeat3s_MenuCategoryID",
                table: "repeat3s");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "repeat3s");

            migrationBuilder.DropColumn(
                name: "MenuCategoryID",
                table: "repeat3s");
        }
    }
}
