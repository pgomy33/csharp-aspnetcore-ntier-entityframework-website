using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addGalleryViewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "galleryTags");

            migrationBuilder.DropTable(
                name: "gTags");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "galleries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GalleryCategoryID",
                table: "galleries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GalleryCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryCategory", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_galleries_GalleryCategoryID",
                table: "galleries",
                column: "GalleryCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_galleries_GalleryCategory_GalleryCategoryID",
                table: "galleries",
                column: "GalleryCategoryID",
                principalTable: "GalleryCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_galleries_GalleryCategory_GalleryCategoryID",
                table: "galleries");

            migrationBuilder.DropTable(
                name: "GalleryCategory");

            migrationBuilder.DropIndex(
                name: "IX_galleries_GalleryCategoryID",
                table: "galleries");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "galleries");

            migrationBuilder.DropColumn(
                name: "GalleryCategoryID",
                table: "galleries");

            migrationBuilder.CreateTable(
                name: "gTags",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gTags", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "galleryTags",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GalleryID = table.Column<int>(type: "int", nullable: false),
                    TagID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_galleryTags", x => x.ID);
                    table.ForeignKey(
                        name: "FK_galleryTags_gTags_TagID",
                        column: x => x.TagID,
                        principalTable: "gTags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_galleryTags_galleries_GalleryID",
                        column: x => x.GalleryID,
                        principalTable: "galleries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_galleryTags_GalleryID",
                table: "galleryTags",
                column: "GalleryID");

            migrationBuilder.CreateIndex(
                name: "IX_galleryTags_TagID",
                table: "galleryTags",
                column: "TagID");
        }
    }
}
