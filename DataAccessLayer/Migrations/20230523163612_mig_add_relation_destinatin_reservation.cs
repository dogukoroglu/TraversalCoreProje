using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_relation_destinatin_reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationID",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationID1",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DestinationID",
                table: "Reservations",
                column: "DestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationID1",
                table: "Reservations",
                column: "ReservationID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Destinations_DestinationID",
                table: "Reservations",
                column: "DestinationID",
                principalTable: "Destinations",
                principalColumn: "DestinationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Reservations_ReservationID1",
                table: "Reservations",
                column: "ReservationID1",
                principalTable: "Reservations",
                principalColumn: "ReservationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Destinations_DestinationID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Reservations_ReservationID1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_DestinationID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservationID1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DestinationID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationID1",
                table: "Reservations");
        }
    }
}
