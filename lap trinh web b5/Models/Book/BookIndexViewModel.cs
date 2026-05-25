namespace lap_trinh_web_b5.Models.Book
{
    public class BookIndexViewModel
    {
        public List<Book> Books { get; set; } = new();

        public List<CategoryCountViewModel> Categories { get; set; } = new();

        public int? CurrentCategoryId { get; set; }
    }
}
