using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lap_trinh_web_b5.Migrations.BookDb
{
    /// <inheritdoc />
    public partial class ThemChuDeVanHoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Van hoc" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Title", "Author", "Price", "Description", "Image", "CategoryId" },
                values: new object[,]
                {
                    {
                        1,
                        "Cho toi xin mot ve di tuoi tho",
                        "Nguyen Nhat Anh",
                        61000m,
                        "Tac pham van hoc viet ve ky uc tuoi tho, tinh ban va nhung dieu binh di trong cuoc song.",
                        "cho-toi-xin-mot-ve-di-tuoi-tho.jpg",
                        1
                    },
                    {
                        2,
                        "Mat biec",
                        "Nguyen Nhat Anh",
                        85000m,
                        "Cau chuyen tinh yeu trong treo, day tiec nuoi cua Ngan va Ha Lan.",
                        "mat-biec.jpg",
                        1
                    },
                    {
                        3,
                        "Toi thay hoa vang tren co xanh",
                        "Nguyen Nhat Anh",
                        78000m,
                        "Cau chuyen ve tuoi tho, gia dinh va tinh cam anh em o mot lang que mien Trung.",
                        "toi-thay-hoa-vang-tren-co-xanh.jpg",
                        1
                    }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);
        }
    }
}


