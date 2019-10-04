using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CisEng.Data;
using CisEng.Models;

namespace CisEng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tainings1Controller : ControllerBase
    {
        private readonly AppDbContext _context;

        public Tainings1Controller(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("AllPublish/{id}")]
        public async Task<ActionResult<IEnumerable<Taining>>> GetTaining(string id)
        {
            return await _context.Taining.Where(a => a.sponser != id).ToListAsync();
        }
        // GET: api/Tainings1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Taining>>> GetAllpublish(string id)
        {
            return await _context.Taining.Where(a=>a.sponser==id).ToListAsync();
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaining(int id, Taining taining)
        {
            if (id != taining.id)
            {
                return BadRequest();
            }

            _context.Entry(taining).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TainingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tainings1
        [HttpPost]
        public async Task<ActionResult<Taining>> PostTaining(Taining taining)
        {
            _context.Taining.Add(taining);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaining", new { id = taining.id }, taining);
        }

        // DELETE: api/Tainings1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Taining>> DeleteTaining(int id)
        {
            var taining = await _context.Taining.FindAsync(id);
            if (taining == null)
            {
                return NotFound();
            }

            _context.Taining.Remove(taining);
            await _context.SaveChangesAsync();

            return taining;
        }

        private bool TainingExists(int id)
        {
            return _context.Taining.Any(e => e.id == id);
        }
    }
}
