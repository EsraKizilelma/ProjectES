using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectES.Data;
using ProjectES.Models;
using System.Drawing;

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
        //public IActionResult Create()
        //{

        //    return View();
        //}
        [HttpPost]
        public IActionResult Create([Bind("AssayId,AssayTitle,SubjectId")] Assay assay)
        {
            _context.Add(assay);
            _context.SaveChanges();
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", assay.SubjectId);
            return RedirectToAction("Index");
        }
        // GET: Kitap/Create
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName");
            return View();
        }

        // POST: Kitap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("AssayId,AssayTitle,SubjectId")] Assay assay)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(assay);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", assay.SubjectId);
        //    return View(assay);
        //}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Assays == null)
            {
                return NotFound();
            }

            var assay = await _context.Assays
                .FirstOrDefaultAsync(m => m.AssayId == id);
            if (assay == null)
            {
                return NotFound();
            }

            return View(assay);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Assays == null)
            {
                return NotFound();
            }

            var assay = await _context.Assays.FindAsync(id);
            if (assay == null)
            {
                return NotFound();
            }
            return View(assay);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectId,SubjectName,SubjectType")] Assay assay)
        {
            if (id != assay.AssayId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssayExists(assay.AssayId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(assay);
        }
        //**************


        // GET: Subject1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Assays == null)
            {
                return NotFound();
            }

            var assay = await _context.Assays
                .FirstOrDefaultAsync(m => m.AssayId == id);
            if (assay == null)
            {
                return NotFound();
            }

            return View(assay);
        }

        // POST: Subject1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Assays == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Assays'  is null.");
            }
            var assay = await _context.Assays.FindAsync(id);
            if (assay != null)
            {
                _context.Assays.Remove(assay);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssayExists(int id)
        {
            return _context.Assays.Any(e => e.AssayId == id);
        }
        //public IActionResult Index()
        //{
        //    List<Assay> a = _context.Assays.Include(aa => aa.Subj).ToList();

        //    return View(a);
        //}
        //
        ///lütfen bu da düzgün çalıssin 
    }
}
