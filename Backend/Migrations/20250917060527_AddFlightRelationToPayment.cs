using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlamingoAirways.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddFlightRelationToPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // remove old flight-related columns from Payment
            migrationBuilder.DropColumn(
                name: "FlightNumber",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "TravelDate",
                table: "Payment");

            // rename Id -> PaymentID
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payment",
                newName: "PaymentID");

            // make some fields required
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PassengerName",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PNR",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            // add new columns
            migrationBuilder.AddColumn<int>(
                name: "FlightID",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassengerCount",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // create index + foreign key (to existing Flights table)
            migrationBuilder.CreateIndex(
                name: "IX_Payment_FlightID",
                table: "Payment",
                column: "FlightID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Flights_FlightID",
                table: "Payment",
                column: "FlightID",
                principalTable: "Flights",
                principalColumn: "FlightID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Flights_FlightID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_FlightID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "FlightID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PassengerCount",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "PaymentID",
                table: "Payment",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PassengerName",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PNR",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FlightNumber",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TravelDate",
                table: "Payment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
