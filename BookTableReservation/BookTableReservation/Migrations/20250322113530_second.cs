using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookTableReservation.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Table_TableId",
                table: "Booking");

            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "Booking",
                newName: "SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_TableId",
                table: "Booking",
                newName: "IX_Booking_SeatId");

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Seat_SeatId",
                table: "Booking",
                column: "SeatId",
                principalTable: "Seat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Seat_SeatId",
                table: "Booking");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "Booking",
                newName: "TableId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_SeatId",
                table: "Booking",
                newName: "IX_Booking_TableId");

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false),
                    TableNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Table_TableId",
                table: "Booking",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
