﻿using System;
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
    public class JobsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JobsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("AllPublish/{id}")]
        public async Task<ActionResult<IEnumerable<Jobs>>> GetTaining(string id)
        {
            return await _context.Jobs.Where(a => a.sponser != id).ToListAsync();
        }
        // GET: api/Tainings1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Jobs>>> GetAllpublish(string id)
        {
            return await _context.Jobs.Where(a => a.sponser == id).ToListAsync();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaining(int id, Jobs taining)
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
        public async Task<ActionResult<Jobs>> PostTaining(Jobs taining)
        {
            _context.Jobs.Add(taining);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaining", new { id = taining.id }, taining);
        }

        // DELETE: api/Tainings1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Jobs>> DeleteTaining(int id)
        {
            var taining = await _context.Jobs.FindAsync(id);
            if (taining == null)
            {
                return NotFound();
            }

            _context.Jobs.Remove(taining);
            await _context.SaveChangesAsync();

            return taining;
        }

        private bool TainingExists(int id)
        {
            return _context.Jobs.Any(e => e.id == id);
        }
    }
}
