using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3248aa9b-4e89-49ee-8175-97eba81997eb", "6508e7e0-1a08-49ba-bcfe-8cca48645dbb", "Administrator", "ADMINISTRATOR" },
                    { "c300428c-8f4d-4caa-a8ab-2b0cb4b59cdd", "345c9081-ab17-4444-b39b-9de60032fed1", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3248aa9b-4e89-49ee-8175-97eba81997eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c300428c-8f4d-4caa-a8ab-2b0cb4b59cdd");
        }
    }
}
