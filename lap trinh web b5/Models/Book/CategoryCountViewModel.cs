namespace lap_trinh_web_b5.Models.Book
{
    public class CategoryCountViewModel
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public int BookCount { get; set; }
    }
}
