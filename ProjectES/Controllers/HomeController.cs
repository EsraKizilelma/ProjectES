﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}