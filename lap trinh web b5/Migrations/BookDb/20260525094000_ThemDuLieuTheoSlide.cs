using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lap_trinh_web_b5.Migrations.BookDb
{
    /// <inheritdoc />
    public partial class ThemDuLieuTheoSlide : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CategoryName",
                value: "Cuoc song");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 2, "Lap trinh" },
                    { 3, "Suc khoe" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Title", "Author", "Price", "Description", "Image", "CategoryId" },
                values: new object[]
                {
                    "ASP.NET Core Can Ban",
                    "Tran Van B",
                    135000m,
                    "Sach huong dan xay dung website MVC voi ASP.NET Core va Entity Framework Core.",
                    "aspnet-core-can-ban.jpg",
                    2
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Title", "Author", "Price", "Description", "Image", "CategoryId" },
                values: new object[,]
                {
                    {
                        4,
                        "Code Java Fundamentals",
                        "Nguyen Van A",
                        120000m,
                        "Sach nhap mon lap trinh Java, giai thich cu phap co ban va cach xay dung ung dung dau tien.",
                        "code-java-fundamentals.jpg",
                        2
                    }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Title", "Author", "Price", "Description", "Image", "CategoryId" },
                values: new object[]
                {
                    "Mat biec",
                    "Nguyen Nhat Anh",
                    85000m,
                    "Cau chuyen tinh yeu trong treo, day tiec nuoi cua Ngan va Ha Lan.",
                    "mat-biec.jpg",
                    1
                });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValues: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CategoryName",
                value: "Van hoc");
        }
    }
}
