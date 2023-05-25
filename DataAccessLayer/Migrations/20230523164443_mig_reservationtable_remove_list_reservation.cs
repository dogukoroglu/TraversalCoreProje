using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_reservationtable_remove_list_reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Reservations_ReservationID1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservationID1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationID1",
                table: "Reservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationID1",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationID1",
                table: "Reservations",
                column: "ReservationID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Reservations_ReservationID1",
                table: "Reservations",
                column: "ReservationID1",
                principalTable: "Reservations",
                principalColumn: "ReservationID");
        }
    }
}
