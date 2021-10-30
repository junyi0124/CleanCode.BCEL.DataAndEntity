using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWebApplication.Data.Migrations
{
    public partial class Has6Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Bio", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, 22, "", false, "Alice" },
                    { 2, 22, "", true, "Bob" },
                    { 3, 21, "", false, "Ivy" },
                    { 4, 27, "", true, "Admin" },
                    { 5, 31, "", true, "Chief" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
