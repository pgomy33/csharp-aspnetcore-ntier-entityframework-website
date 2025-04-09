using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class add_blog_testimonial_revise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_blogTestimonials_BlogTestimonialsID",
                table: "blogs");

            migrationBuilder.DropIndex(
                name: "IX_blogs_BlogTestimonialsID",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "BlogTestimonialId",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "BlogTestimonialsID",
                table: "blogs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "blogTestimonials",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "blogTestimonials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_blogTestimonials_BlogId",
                table: "blogTestimonials",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_blogTestimonials_blogs_BlogId",
                table: "blogTestimonials",
                column: "BlogId",
                principalTable: "blogs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogTestimonials_blogs_BlogId",
                table: "blogTestimonials");

            migrationBuilder.DropIndex(
                name: "IX_blogTestimonials_BlogId",
                table: "blogTestimonials");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "blogTestimonials");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "blogTestimonials",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<int>(
                name: "BlogTestimonialId",
                table: "blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BlogTestimonialsID",
                table: "blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_blogs_BlogTestimonialsID",
                table: "blogs",
                column: "BlogTestimonialsID");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_blogTestimonials_BlogTestimonialsID",
                table: "blogs",
                column: "BlogTestimonialsID",
                principalTable: "blogTestimonials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
