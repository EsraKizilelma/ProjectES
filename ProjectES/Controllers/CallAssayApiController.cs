using ProjectES.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;

namespace ProjectES.Controllers
{
    public class CallAssayApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
			
			List<Assay> Assays = new List<Assay>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7169/api/AssayApi");
            string resString = await response.Content.ReadAsStringAsync();
			Assays = JsonConvert.DeserializeObject<List<Assay>>(resString);
            return View(Assays);
        }
        //List<Assay> a = _context.Assays.Include(aa => aa.Subj).ToList();

        //var assay = (from aa in _context.Assays where aa.Subj != null select aa).ToList();
        //    return View(assay);
    }
}
