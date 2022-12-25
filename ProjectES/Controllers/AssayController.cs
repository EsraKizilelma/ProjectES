using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectES.Data;
using ProjectES.Models;

namespace ProjectES.Controllers
{
    public class AssayController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AssayController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Assay> a = _context.Assays.Include(aa => aa.Subj).ToList();

            var assay = (from aa in _context.Assays where aa.Subj != null select aa).ToList();



            return View(assay);
        }

        //public IActionResult Index()
        //{
        //    List<Assay> a = _context.Assays.Include(aa => aa.Subj).ToList();

        //    return View(a);
        //}

    }
}
