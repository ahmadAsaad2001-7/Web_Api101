using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Api101.Migrations
{
    public partial class cp0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "clinics",
                columns: new[] { "Id", "locid" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "clinics",
                columns: new[] { "Id", "locid" },
                values: new object[] { 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "clinics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "clinics",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
