using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HapoTravelRequest.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldsToModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CorporateCard",
                table: "TravelRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DepartureReturnDates",
                table: "TravelRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactPhoneNumber",
                table: "TravelRequests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactname",
                table: "TravelRequests",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GroundOptions",
                table: "TravelRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "NonEmployeeGuests",
                table: "TravelRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Registered",
                table: "TravelRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RegisteredForConference",
                table: "TravelRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TSANumber",
                table: "TravelRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "TravelRequests",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ValueExplination",
                table: "TravelRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39e088b2-cd8e-40d2-8d14-7abd2662987b",
                column: "NormalizedName",
                value: "ADMINISTRATOR");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ec66596-f421-42a1-832c-365951b19e7d",
                column: "NormalizedName",
                value: "VP");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7641d7a-e9ba-47f3-bef7-f9bf36e935be",
                column: "NormalizedName",
                value: "PROCESSOR");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6429c0b-cc83-474e-8851-243fbcd898eb",
                column: "NormalizedName",
                value: "CEO");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc391dc9-7793-4ac2-b51e-474635c7d0d7",
                column: "NormalizedName",
                value: "EMPLOYEE");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10684443-90ea-4553-86a3-49d08b55dffe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ec032df-efe5-4587-9489-c5c7734e152f", "AQAAAAIAAYagAAAAEAlJIj6DR/+h+s+nfbsFK29Q06fmjX6aWw/tzQjHactjEuj+9EEkD7pBm5UAhq839g==", "2d90c271-2962-486a-b30d-4de5bb1c7695" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorporateCard",
                table: "TravelRequests");

            migrationBuilder.DropColumn(
                name: "DepartureReturnDates",
                table: "TravelRequests");

            migrationBuilder.DropColumn(
                name: "EmergencyContactPhoneNumber",
                table: "TravelRequests");

            migrationBuilder.DropColumn(
                name: "EmergencyContactname",
                table: "TravelRequests");

            migrationBuilder.DropColumn(
                name: "GroundOptions",
                table: "TravelRequests");

            migrationBuilder.DropColumn(
                name: "NonEmployeeGuests",
                table: "TravelRequests");

            migrationBuilder.DropColumn(
                name: "Registered",
                table: "TravelRequests");

            migrationBuilder.DropColumn(
                name: "RegisteredForConference",
                table: "TravelRequests");

            migrationBuilder.DropColumn(
                name: "TSANumber",
                table: "TravelRequests");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "TravelRequests");

            migrationBuilder.DropColumn(
                name: "ValueExplination",
                table: "TravelRequests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39e088b2-cd8e-40d2-8d14-7abd2662987b",
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ec66596-f421-42a1-832c-365951b19e7d",
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7641d7a-e9ba-47f3-bef7-f9bf36e935be",
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6429c0b-cc83-474e-8851-243fbcd898eb",
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc391dc9-7793-4ac2-b51e-474635c7d0d7",
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10684443-90ea-4553-86a3-49d08b55dffe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "babc7323-c865-4601-a20b-c6ca1066e7f4", "AQAAAAIAAYagAAAAEJl6Fsa1J0lC2JHEZm2XL/6NyicZeC2XuOkQQpJhk/Bo2zQBSn1VAENB1tqsb2gKzw==", "67e19da4-88f5-4dfb-8506-16a2e6850c8a" });
        }
    }
}
