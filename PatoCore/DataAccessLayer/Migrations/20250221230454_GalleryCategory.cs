using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class GalleryCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_galleries_GalleryCategory_GalleryCategoryID",
                table: "galleries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GalleryCategory",
                table: "GalleryCategory");

            migrationBuilder.RenameTable(
                name: "GalleryCategory",
                newName: "galleryCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_galleryCategories",
                table: "galleryCategories",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_galleries_galleryCategories_GalleryCategoryID",
                table: "galleries",
                column: "GalleryCategoryID",
                principalTable: "galleryCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_galleries_galleryCategories_GalleryCategoryID",
                table: "galleries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_galleryCategories",
                table: "galleryCategories");

            migrationBuilder.RenameTable(
                name: "galleryCategories",
                newName: "GalleryCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GalleryCategory",
                table: "GalleryCategory",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_galleries_GalleryCategory_GalleryCategoryID",
                table: "galleries",
                column: "GalleryCategoryID",
                principalTable: "GalleryCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
