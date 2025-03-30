using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HapoTravelRequest.Migrations
{
    /// <inheritdoc />
    public partial class AddRegistrationDeadline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDeadline",
                table: "TravelRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10684443-90ea-4553-86a3-49d08b55dffe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59f83417-3856-4bab-9da2-fddd7ebfe376", "AQAAAAIAAYagAAAAEBjdQ8Nk+dbCg8nkMiB2uV4xRmyPbp3sygD4sFBOFeGxI4sDgvdvos+onPHQDkMIjw==", "ffe4cf36-6735-4f95-93a9-5b66a580730f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationDeadline",
                table: "TravelRequests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10684443-90ea-4553-86a3-49d08b55dffe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1945ee04-6747-4426-bf27-31cba23b149a", "AQAAAAIAAYagAAAAEFzjlIgMZPEFyaxOgbT6QVRa4k/Npx03ODxH4Gbo2S54gq/nVX6QJFNCAJcu8j6u/w==", "81bdce6f-d3ca-42e2-a9bf-c49ac1596bb5" });
        }
    }
}
