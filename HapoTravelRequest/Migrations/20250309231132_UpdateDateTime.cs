using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HapoTravelRequest.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "TravelRequests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NonEmployeeDOB",
                table: "TravelRequests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepartureDate",
                table: "TravelRequests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ConferenceStartDate",
                table: "TravelRequests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ConferenceEndDate",
                table: "TravelRequests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10684443-90ea-4553-86a3-49d08b55dffe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1ee3531-1d81-4486-a719-f6aa82fa8183", "AQAAAAIAAYagAAAAEEl1Ei4oai9B80baOrutDBGdnZngSSotoolZrvJCFk9xwd62Xy4J/KQSAataBp1ILA==", "d9bb2ba9-e8c0-42ab-89d3-b1be80234445" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "ReturnDate",
                table: "TravelRequests",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "NonEmployeeDOB",
                table: "TravelRequests",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DepartureDate",
                table: "TravelRequests",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ConferenceStartDate",
                table: "TravelRequests",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ConferenceEndDate",
                table: "TravelRequests",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10684443-90ea-4553-86a3-49d08b55dffe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4269bae-67b7-49d0-926e-37ce7f77b19a", "AQAAAAIAAYagAAAAELSHbzmQKErRA5AB6zy62Z4IYmsYHQYIJkqD7Bh1h7YtklJrThTIYRH6edvVKfj+Wg==", "e188bf58-8e92-4a78-8137-01229d511f93" });
        }
    }
}
