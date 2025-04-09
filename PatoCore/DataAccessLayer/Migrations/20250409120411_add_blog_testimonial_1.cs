using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class add_blog_testimonial_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_blogTestimonials_BlogTestimonialsID",
                table: "blogs");

            migrationBuilder.AlterColumn<int>(
                name: "BlogTestimonialsID",
                table: "blogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlogTestimonialId",
                table: "blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_blogTestimonials_BlogTestimonialsID",
                table: "blogs",
                column: "BlogTestimonialsID",
                principalTable: "blogTestimonials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_blogTestimonials_BlogTestimonialsID",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "BlogTestimonialId",
                table: "blogs");

            migrationBuilder.AlterColumn<int>(
                name: "BlogTestimonialsID",
                table: "blogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_blogTestimonials_BlogTestimonialsID",
                table: "blogs",
                column: "BlogTestimonialsID",
                principalTable: "blogTestimonials",
                principalColumn: "ID");
        }
    }
}
