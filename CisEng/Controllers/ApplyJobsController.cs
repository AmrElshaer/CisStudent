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
    public class ApplyJobsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ApplyJobsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AppliesforTrainings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplyJobs>>> GetAppliesforTraining()
        {
            return await _context.ApplyJobs.ToListAsync();
        }

        // GET: api/AppliesforTrainings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ApplyJobs>>> GetAppliesforTraining(string id)
        {
            var appliesforTraining = await _context.ApplyJobs.Where(a => a.trainingid == id).ToListAsync();

            if (appliesforTraining == null)
            {
                return NotFound();
            }

            return appliesforTraining;
        }

        // PUT: api/AppliesforTrainings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppliesforTraining(int id, ApplyJobs appliesforTraining)
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

        public async Task<ActionResult<ApplyJobs>> PostAppliesforTraining([Bind("trainingid,studentApplay,studentPublishtraining,Email")] ApplyJobs appliesforTraining)
        {
            _context.ApplyJobs.Add(appliesforTraining);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppliesforTraining", new { id = appliesforTraining.id }, appliesforTraining);
        }

        // DELETE: api/AppliesforTrainings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApplyJobs>> DeleteAppliesforTraining(int id)
        {
            var appliesforTraining = await _context.ApplyJobs.FindAsync(id);
            if (appliesforTraining == null)
            {
                return NotFound();
            }

            _context.ApplyJobs.Remove(appliesforTraining);
            await _context.SaveChangesAsync();

            return appliesforTraining;
        }

        private bool AppliesforTrainingExists(int id)
        {
            return _context.ApplyJobs.Any(e => e.id == id);
        }
    }
}
