using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class add_all_bool_state : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "sSSes",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "sliders",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "rHours",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "reservations",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "repeat3s",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "repeat2s",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "rCapacities",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "menuCategories",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "galleryCategories",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "galleries",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "blogs",
                type: "tinyint(1)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "sSSes");

            migrationBuilder.DropColumn(
                name: "State",
                table: "sliders");

            migrationBuilder.DropColumn(
                name: "State",
                table: "rHours");

            migrationBuilder.DropColumn(
                name: "State",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "State",
                table: "repeat3s");

            migrationBuilder.DropColumn(
                name: "State",
                table: "repeat2s");

            migrationBuilder.DropColumn(
                name: "State",
                table: "rCapacities");

            migrationBuilder.DropColumn(
                name: "State",
                table: "menuCategories");

            migrationBuilder.DropColumn(
                name: "State",
                table: "galleryCategories");

            migrationBuilder.DropColumn(
                name: "State",
                table: "galleries");

            migrationBuilder.DropColumn(
                name: "State",
                table: "blogs");
        }
    }
}
