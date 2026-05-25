namespace lap_trinh_web_b5.Models
{
    public class Grade
    {
        public int GradeId { get; set; }

        public string GradeName { get; set; } = string.Empty;

        public List<Student> Students { get; set; } = new();
    }
}
