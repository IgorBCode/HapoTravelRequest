using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HapoTravelRequest.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMileageReimbursementToBool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "MileageReimbursement",
                table: "TravelRequests",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10684443-90ea-4553-86a3-49d08b55dffe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5893dbbf-6668-4b1d-a10b-2f8a0033933c", "AQAAAAIAAYagAAAAEL89YuTrg56v3KYTG+zrAD0LiH2zO0oYMmfJHjUxBIY5Ni72EpXMrU8BakpgB1WF5A==", "76154e16-4831-4636-9297-b659e234331b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MileageReimbursement",
                table: "TravelRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10684443-90ea-4553-86a3-49d08b55dffe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59f83417-3856-4bab-9da2-fddd7ebfe376", "AQAAAAIAAYagAAAAEBjdQ8Nk+dbCg8nkMiB2uV4xRmyPbp3sygD4sFBOFeGxI4sDgvdvos+onPHQDkMIjw==", "ffe4cf36-6735-4f95-93a9-5b66a580730f" });
        }
    }
}
