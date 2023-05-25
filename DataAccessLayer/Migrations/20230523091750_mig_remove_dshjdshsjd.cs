using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_remove_dshjdshsjd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation2s");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservation2s",
                columns: table => new
                {
                    ReservationnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserrId = table.Column<int>(type: "int", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonCount2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservationDate2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation2s", x => x.ReservationnID);
                    table.ForeignKey(
                        name: "FK_Reservation2s_AspNetUsers_AppUserrId",
                        column: x => x.AppUserrId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation2s_AppUserrId",
                table: "Reservation2s",
                column: "AppUserrId");
        }
    }
}
