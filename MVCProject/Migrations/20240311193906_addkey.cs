

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCProject.Migrations
{
    /// <inheritdoc />
    public partial class addkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tickets_customers_CustomerId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_trips_TripId",
                table: "tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tickets",
                table: "tickets");

            migrationBuilder.AlterColumn<int>(
                name: "TripId",
                table: "tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "tickets",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tickets",
                table: "tickets",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_CustomerId",
                table: "tickets",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_customers_CustomerId",
                table: "tickets",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_trips_TripId",
                table: "tickets",
                column: "TripId",
                principalTable: "trips",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tickets_customers_CustomerId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_trips_TripId",
                table: "tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tickets",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_tickets_CustomerId",
                table: "tickets");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tickets");

            migrationBuilder.AlterColumn<int>(
                name: "TripId",
                table: "tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tickets",
                table: "tickets",
                columns: new[] { "CustomerId", "TripId" });

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_customers_CustomerId",
                table: "tickets",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_trips_TripId",
                table: "tickets",
                column: "TripId",
                principalTable: "trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
