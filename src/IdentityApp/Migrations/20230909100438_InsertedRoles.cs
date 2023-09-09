using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityApp.Migrations
{
    /// <inheritdoc />
    public partial class InsertedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01H9WPD3DJ6TZE9ECDSCC9C874", null, "Administrator", "ADMINISTRATOR" },
                    { "01H9WPD3DJJ6ZEMKDB0EDTVGJ6", null, "Visitor", "VISITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "01H9WPD3DJ6TZE9ECDSCC9C874");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "01H9WPD3DJJ6ZEMKDB0EDTVGJ6");
        }
    }
}
