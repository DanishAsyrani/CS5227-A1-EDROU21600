 using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CS5227_A1_EDROU21600.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6da18151-335f-4b39-b865-2cd952111ec7", null, "client", "client" },
                    { "9faeb97f-d9da-4ba4-8e1c-95b98f92c8f0", null, "seller", "seller" },
                    { "cc9cd88d-4e30-491b-9eb4-b650bfcb7cb3", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6da18151-335f-4b39-b865-2cd952111ec7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9faeb97f-d9da-4ba4-8e1c-95b98f92c8f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc9cd88d-4e30-491b-9eb4-b650bfcb7cb3");
        }
    }
}
