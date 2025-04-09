using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addGalleryTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_galleries_GalleryCategory_GCategoryID",
                table: "galleries");

            migrationBuilder.DropTable(
                name: "GalleryCategory");

            migrationBuilder.DropIndex(
                name: "IX_galleries_GCategoryID",
                table: "galleries");

            migrationBuilder.DropColumn(
                name: "GCategoryID",
                table: "galleries");

            migrationBuilder.CreateTable(
                name: "GTag",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GTag", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GalleryTag",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GalleryID = table.Column<int>(type: "int", nullable: false),
                    TagID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryTag", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GalleryTag_GTag_TagID",
                        column: x => x.TagID,
                        principalTable: "GTag",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GalleryTag_galleries_GalleryID",
                        column: x => x.GalleryID,
                        principalTable: "galleries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryTag_GalleryID",
                table: "GalleryTag",
                column: "GalleryID");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryTag_TagID",
                table: "GalleryTag",
                column: "TagID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalleryTag");

            migrationBuilder.DropTable(
                name: "GTag");

            migrationBuilder.AddColumn<int>(
                name: "GCategoryID",
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
                name: "IX_galleries_GCategoryID",
                table: "galleries",
                column: "GCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_galleries_GalleryCategory_GCategoryID",
                table: "galleries",
                column: "GCategoryID",
                principalTable: "GalleryCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
