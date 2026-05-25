using lap_trinh_web_b5.Models;
using Microsoft.AspNetCore.Mvc;

namespace lap_trinh_web_b5.Controllers
{
    public class GradeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GradeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Grade> listGrade = _context.Grades.ToList();
            return View(listGrade);
        }
    }
}
