namespace lap_trinh_web_b5.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int GradeId { get; set; }

        public Grade? Grade { get; set; }
    }
}
