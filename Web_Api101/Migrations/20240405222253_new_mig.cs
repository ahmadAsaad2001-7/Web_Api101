using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Api101.Migrations
{
    public partial class new_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "hospitals",
                columns: new[] { "id", "hospital_name", "locid" },
                values: new object[] { 1, "Hospital A", 1 });

            migrationBuilder.InsertData(
                table: "hospitals",
                columns: new[] { "id", "hospital_name", "locid" },
                values: new object[] { 2, "Hospital B", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "hospitals",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "hospitals",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
