using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Api101.Migrations
{
    public partial class peep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "locations",
                columns: new[] { "id", "location_name" },
                values: new object[] { 2, "qous" });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "LocationId", "gender", "name", "speciality" },
                values: new object[] { 3, 2, "m", "ragab", "Pediatrics" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "locations",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
