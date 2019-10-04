using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CisEng.Data;
using CisEng.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CisEng.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
   [EnableCors("allowcors")]
    public class CisStudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment _environment;
        public CisStudentsController(AppDbContext context,IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }



        // GET: api/CisStudents
        [EnableCors("allowcors")]
        [HttpGet, DisableRequestSizeLimit]

        public async Task<ActionResult<IEnumerable<CisStudent>>> GetCisStudent()
        {
            return await _context.CisStudent.ToListAsync();
        }

        // GET: api/CisStudents/5
      
        [EnableCors("allowcors")]
        [DisableRequestSizeLimit]
        [HttpGet("{id}")]
        public async Task<ActionResult<CisStudent>> GetCisStudent(int id)
        {
            var cisStudent = await _context.CisStudent.FindAsync(id);

            if (cisStudent == null)
            {
                return NotFound();
            }

            return cisStudent;
        }

        // PUT: api/CisStudents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCisStudent(int id, CisStudent cisStudent)
        {
            if (id != cisStudent.Id)
            {
                return BadRequest();
            }

            _context.Entry(cisStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CisStudentExists(id))
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

        // POST: api/CisStudents
       
        [HttpPost]
        public async Task<ActionResult<CisStudent>> PostCisStudent(CisStudent cisStudent)
        {
          
            _context.CisStudent.Add(cisStudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCisStudent", new { id=cisStudent.Id }, cisStudent);
        }

        // DELETE: api/CisStudents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CisStudent>> DeleteCisStudent(int id)
        {
            var cisStudent = await _context.CisStudent.FindAsync(id);
            if (cisStudent == null)
            {
                return NotFound();
            }

            _context.CisStudent.Remove(cisStudent);
            await _context.SaveChangesAsync();

            return cisStudent;
        }

        private bool CisStudentExists(int id)
        {
            return _context.CisStudent.Any(e => e.Id == id);
        }
    }
}
