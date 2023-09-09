using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeConcurrecyStamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "01H9WPD3DJ6TZE9ECDSCC9C874");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "01H9WPD3DJJ6ZEMKDB0EDTVGJ6");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01H9X57PT58F3Q0MCD78JCQKKY", "01H9X57PT5B3KQTGJPVG2EWN3K", "Visitor", "VISITOR" },
                    { "01H9X57PT5FCYFP9ACX61PSF65", "01H9X57PT5GKXSH2NGKY3FC16A", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "01H9X57PT58F3Q0MCD78JCQKKY");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "01H9X57PT5FCYFP9ACX61PSF65");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01H9WPD3DJ6TZE9ECDSCC9C874", null, "Administrator", "ADMINISTRATOR" },
                    { "01H9WPD3DJJ6ZEMKDB0EDTVGJ6", null, "Visitor", "VISITOR" }
                });
        }
    }
}
