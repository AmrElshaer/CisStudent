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
    public class AppliesforTrainingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AppliesforTrainingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AppliesforTrainings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppliesforTraining>>> GetAppliesforTraining()
        {
            return await _context.AppliesforTraining.ToListAsync();
        }

        // GET: api/AppliesforTrainings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AppliesforTraining>>> GetAppliesforTraining(string id)
        {
            var appliesforTraining = await _context.AppliesforTraining.Where(a=>a.trainingid==id).ToListAsync();

            if (appliesforTraining == null)
            {
                return NotFound();
            }

            return appliesforTraining;
        }

        // PUT: api/AppliesforTrainings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppliesforTraining(int id, AppliesforTraining appliesforTraining)
        {
            if (id != appliesforTraining.id)
            {
                return BadRequest();
            }

            _context.Entry(appliesforTraining).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppliesforTrainingExists(id))
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

        // POST: api/AppliesforTrainings
        [HttpPost]
      
        public async Task<ActionResult<AppliesforTraining>> PostAppliesforTraining([Bind("trainingid,studentApplay,studentPublishtraining,Email")] AppliesforTraining appliesforTraining)
        {
            _context.AppliesforTraining.Add(appliesforTraining);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppliesforTraining", new { id = appliesforTraining.id }, appliesforTraining);
        }

        // DELETE: api/AppliesforTrainings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppliesforTraining>> DeleteAppliesforTraining(int id)
        {
            var appliesforTraining = await _context.AppliesforTraining.FindAsync(id);
            if (appliesforTraining == null)
            {
                return NotFound();
            }

            _context.AppliesforTraining.Remove(appliesforTraining);
            await _context.SaveChangesAsync();

            return appliesforTraining;
        }

        private bool AppliesforTrainingExists(int id)
        {
            return _context.AppliesforTraining.Any(e => e.id == id);
        }
    }
}
