using Microsoft.AspNetCore.Mvc;
using ProjectES.Data;
using ProjectES.Models;

namespace ProjectES.Controllers
{
    public class Subject2Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        public Subject2Controller(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Subject> a = _context.Subjects.ToList();
            return View(a);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("SubjectName,SubjectType")]Subject a)
        {
            _context.Add(a);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
