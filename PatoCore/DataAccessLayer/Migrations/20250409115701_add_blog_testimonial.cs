using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class add_blog_testimonial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeWrite",
                table: "blogs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlogTestimonialsID",
                table: "blogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "blogTestimonials",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogTestimonials", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_BlogTestimonialsID",
                table: "blogs",
                column: "BlogTestimonialsID");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_blogTestimonials_BlogTestimonialsID",
                table: "blogs",
                column: "BlogTestimonialsID",
                principalTable: "blogTestimonials",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_blogTestimonials_BlogTestimonialsID",
                table: "blogs");

            migrationBuilder.DropTable(
                name: "blogTestimonials");

            migrationBuilder.DropIndex(
                name: "IX_blogs_BlogTestimonialsID",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "BlogTestimonialsID",
                table: "blogs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeWrite",
                table: "blogs",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}
