using System.ComponentModel.DataAnnotations;

namespace lap_trinh_web_b5.Models.Book
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Vui long nhap ten chu de")]
        [StringLength(100, ErrorMessage = "Ten chu de khong duoc qua 100 ky tu")]
        public string CategoryName { get; set; } = string.Empty;

        public List<Book> Books { get; set; } = new();
    }
}
