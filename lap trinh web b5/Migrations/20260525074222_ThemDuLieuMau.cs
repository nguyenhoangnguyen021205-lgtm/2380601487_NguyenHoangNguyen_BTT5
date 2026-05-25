using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lap_trinh_web_b5.Migrations
{
    /// <inheritdoc />
    public partial class ThemDuLieuMau : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeName" },
                values: new object[,]
                {
            { 1, "21DTHA1" },
            { 2, "21DTHA2" },
            { 3, "21DTHA3" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "LastName", "GradeId" },
                values: new object[,]
                {
            { 1, "Khuyen", "Bui", 1 },
            { 2, "Toan", "Nguyen", 1 }
                });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValues: new object[] { 1, 2, 3 });
        }

    }
}
