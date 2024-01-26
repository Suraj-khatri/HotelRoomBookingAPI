using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_Room_RoomId",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "IX_bookings_RoomId",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "bookings");

            migrationBuilder.CreateTable(
                name: "roomBooking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_roomBooking_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_roomBooking_bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_roomBooking_BookingId",
                table: "roomBooking",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_roomBooking_RoomId",
                table: "roomBooking",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "roomBooking");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "bookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_bookings_RoomId",
                table: "bookings",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_Room_RoomId",
                table: "bookings",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
