using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class add_Blog_Categories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogCategoryId",
                table: "blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "blogCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogCategories", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_BlogCategoryId",
                table: "blogs",
                column: "BlogCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_blogCategories_BlogCategoryId",
                table: "blogs",
                column: "BlogCategoryId",
                principalTable: "blogCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_blogCategories_BlogCategoryId",
                table: "blogs");

            migrationBuilder.DropTable(
                name: "blogCategories");

            migrationBuilder.DropIndex(
                name: "IX_blogs_BlogCategoryId",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "BlogCategoryId",
                table: "blogs");
        }
    }
}
