using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_res2_again_jdsjsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation2s_AspNetUsers_AppUserId",
                table: "Reservation2s");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Reservation2s",
                newName: "Status2");

            migrationBuilder.RenameColumn(
                name: "ReservationDate",
                table: "Reservation2s",
                newName: "ReservationDate2");

            migrationBuilder.RenameColumn(
                name: "PersonCount",
                table: "Reservation2s",
                newName: "PersonCount2");

            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "Reservation2s",
                newName: "Destination2");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Reservation2s",
                newName: "Description2");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Reservation2s",
                newName: "AppUserrId");

            migrationBuilder.RenameColumn(
                name: "ReservationID",
                table: "Reservation2s",
                newName: "ReservationnID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation2s_AppUserId",
                table: "Reservation2s",
                newName: "IX_Reservation2s_AppUserrId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation2s_AspNetUsers_AppUserrId",
                table: "Reservation2s",
                column: "AppUserrId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation2s_AspNetUsers_AppUserrId",
                table: "Reservation2s");

            migrationBuilder.RenameColumn(
                name: "Status2",
                table: "Reservation2s",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ReservationDate2",
                table: "Reservation2s",
                newName: "ReservationDate");

            migrationBuilder.RenameColumn(
                name: "PersonCount2",
                table: "Reservation2s",
                newName: "PersonCount");

            migrationBuilder.RenameColumn(
                name: "Destination2",
                table: "Reservation2s",
                newName: "Destination");

            migrationBuilder.RenameColumn(
                name: "Description2",
                table: "Reservation2s",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "AppUserrId",
                table: "Reservation2s",
                newName: "AppUserId");

            migrationBuilder.RenameColumn(
                name: "ReservationnID",
                table: "Reservation2s",
                newName: "ReservationID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation2s_AppUserrId",
                table: "Reservation2s",
                newName: "IX_Reservation2s_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation2s_AspNetUsers_AppUserId",
                table: "Reservation2s",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
