using ProjectES.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectES.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssayApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AssayApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<List<Assay>>> Get()
        {
            var y = await _context.Assays.ToListAsync();
            if (y is null)
            {
                return NoContent();
            }
            return y;

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assay>> Get(int id)
        {
            var y = await _context.Assays.FirstOrDefaultAsync(x=>x.AssayId==id);
            if (y is null)
            {
                return NoContent();
            }
            return y;
        }
    }
}
