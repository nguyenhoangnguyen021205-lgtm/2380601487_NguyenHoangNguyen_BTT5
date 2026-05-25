using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace lap_trinh_web_b5.Models.Book
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui long nhap ten sach")]
        [StringLength(150, ErrorMessage = "Ten sach khong duoc qua 150 ky tu")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui long nhap tac gia")]
        [StringLength(100, ErrorMessage = "Ten tac gia khong duoc qua 100 ky tu")]
        public string Author { get; set; } = string.Empty;

        [Range(0, 100000000, ErrorMessage = "Gia sach phai lon hon hoac bang 0")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Vui long nhap mo ta")]
        public string Description { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Ten file anh khong duoc qua 100 ky tu")]
        public string? Image { get; set; }

        [Required(ErrorMessage = "Vui long chon chu de")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
