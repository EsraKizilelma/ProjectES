using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectES.Data;
using ProjectES.Models;
using System.Diagnostics;

namespace ProjectES.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		//public HomeController(ILogger<HomeController> logger)
		//{
		//	_logger = logger;
		//}
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Create([Bind("AssayId,AssayTitle,SubjectId")] Assay assay)
        {
            _context.Add(assay);
            _context.SaveChanges();
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", assay.SubjectId);
            return RedirectToAction("Privacy");
        }
        // GET: Kitap/Create
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName");
            return View();
        }


        //public IActionResult Index()
        //{
        //	return View();
        //}

        [Authorize]
		public IActionResult Privacy()
		{
            List<Assay> a = _context.Assays.Include(aa => aa.Subj).ToList();

            var assay = (from aa in _context.Assays where aa.Subj != null select aa).ToList();
            return View(assay);
        }
        public IActionResult Index()
		{
            
            return View();
        }
		//**********
		public IActionResult ChangeLanguage(string culture)
		{
			Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
				new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });
			return Redirect(Request.Headers["Referer"].ToString());
		}
		//**********

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}