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
    public class responsetoresponesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public responsetoresponesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/responsetorespones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<responsetorespone>>> Getresponsetorespone()
        {
            return await _context.responsetorespone.ToListAsync();
        }

        // GET: api/responsetorespones/5
        [HttpGet("{id}")]
        public  IEnumerable<responsetorespone> Getresponsetorespone(string id)
        {
            var responsetorespone = _context.responsetorespone.Where(a=>a.idofresponse==id).ToArray();

            if (responsetorespone == null)
            {
                return null;
            }

            return responsetorespone;
        }

        // PUT: api/responsetorespones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putresponsetorespone(int id, responsetorespone responsetorespone)
        {
            if (id != responsetorespone.id)
            {
                return BadRequest();
            }

            _context.Entry(responsetorespone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!responsetoresponeExists(id))
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

        // POST: api/responsetorespones
        [HttpPost]
        public async Task<ActionResult<responsetorespone>> Postresponsetorespone(responsetorespone responsetorespone)
        {
            _context.responsetorespone.Add(responsetorespone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getresponsetorespone", new { id = responsetorespone.id }, responsetorespone);
        }

        // DELETE: api/responsetorespones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<responsetorespone>> Deleteresponsetorespone(int id)
        {
            var responsetorespone = await _context.responsetorespone.FindAsync(id);
            if (responsetorespone == null)
            {
                return NotFound();
            }

            _context.responsetorespone.Remove(responsetorespone);
            await _context.SaveChangesAsync();

            return responsetorespone;
        }

        private bool responsetoresponeExists(int id)
        {
            return _context.responsetorespone.Any(e => e.id == id);
        }
    }
}
