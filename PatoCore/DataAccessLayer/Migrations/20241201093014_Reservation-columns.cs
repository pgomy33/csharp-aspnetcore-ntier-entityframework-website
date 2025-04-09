using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Reservationcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CapacityID",
                table: "reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HourID",
                table: "reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "rCapacityID",
                table: "reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "rHoursID",
                table: "reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reservations_rCapacityID",
                table: "reservations",
                column: "rCapacityID");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_rHoursID",
                table: "reservations",
                column: "rHoursID");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_rCapacities_rCapacityID",
                table: "reservations",
                column: "rCapacityID",
                principalTable: "rCapacities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_rHours_rHoursID",
                table: "reservations",
                column: "rHoursID",
                principalTable: "rHours",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_rCapacities_rCapacityID",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_reservations_rHours_rHoursID",
                table: "reservations");

            migrationBuilder.DropIndex(
                name: "IX_reservations_rCapacityID",
                table: "reservations");

            migrationBuilder.DropIndex(
                name: "IX_reservations_rHoursID",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "CapacityID",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "HourID",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "rCapacityID",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "rHoursID",
                table: "reservations");
        }
    }
}
