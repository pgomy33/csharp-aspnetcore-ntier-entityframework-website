using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addGalleryTag1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryTag_GTag_TagID",
                table: "GalleryTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GTag",
                table: "GTag");

            migrationBuilder.RenameTable(
                name: "GTag",
                newName: "gTags");

            migrationBuilder.AddPrimaryKey(
                name: "PK_gTags",
                table: "gTags",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryTag_gTags_TagID",
                table: "GalleryTag",
                column: "TagID",
                principalTable: "gTags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryTag_gTags_TagID",
                table: "GalleryTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_gTags",
                table: "gTags");

            migrationBuilder.RenameTable(
                name: "gTags",
                newName: "GTag");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GTag",
                table: "GTag",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryTag_GTag_TagID",
                table: "GalleryTag",
                column: "TagID",
                principalTable: "GTag",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
