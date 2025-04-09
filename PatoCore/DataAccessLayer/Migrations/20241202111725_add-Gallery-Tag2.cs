using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addGalleryTag2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryTag_gTags_TagID",
                table: "GalleryTag");

            migrationBuilder.DropForeignKey(
                name: "FK_GalleryTag_galleries_GalleryID",
                table: "GalleryTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GalleryTag",
                table: "GalleryTag");

            migrationBuilder.RenameTable(
                name: "GalleryTag",
                newName: "galleryTags");

            migrationBuilder.RenameIndex(
                name: "IX_GalleryTag_TagID",
                table: "galleryTags",
                newName: "IX_galleryTags_TagID");

            migrationBuilder.RenameIndex(
                name: "IX_GalleryTag_GalleryID",
                table: "galleryTags",
                newName: "IX_galleryTags_GalleryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_galleryTags",
                table: "galleryTags",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_galleryTags_gTags_TagID",
                table: "galleryTags",
                column: "TagID",
                principalTable: "gTags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_galleryTags_galleries_GalleryID",
                table: "galleryTags",
                column: "GalleryID",
                principalTable: "galleries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_galleryTags_gTags_TagID",
                table: "galleryTags");

            migrationBuilder.DropForeignKey(
                name: "FK_galleryTags_galleries_GalleryID",
                table: "galleryTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_galleryTags",
                table: "galleryTags");

            migrationBuilder.RenameTable(
                name: "galleryTags",
                newName: "GalleryTag");

            migrationBuilder.RenameIndex(
                name: "IX_galleryTags_TagID",
                table: "GalleryTag",
                newName: "IX_GalleryTag_TagID");

            migrationBuilder.RenameIndex(
                name: "IX_galleryTags_GalleryID",
                table: "GalleryTag",
                newName: "IX_GalleryTag_GalleryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GalleryTag",
                table: "GalleryTag",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryTag_gTags_TagID",
                table: "GalleryTag",
                column: "TagID",
                principalTable: "gTags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryTag_galleries_GalleryID",
                table: "GalleryTag",
                column: "GalleryID",
                principalTable: "galleries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
