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
    public class FollowusController : ControllerBase
    {
        private readonly AppDbContext _context;
       
        public FollowusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Followus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Followus>>> GetFollowus()
        {
            return await _context.Followus.ToListAsync();
        }

        // GET: api/Followus/5
        [HttpGet("{id}")]
        public  ActionResult<IEnumerable<Followus>> GetFollowus(string id)
        {
            var followus = _context.Followus.Where(a=>a.recever==id);

            if (followus == null)
            {
                return NotFound();
            }

            return new JsonResult(followus);
        }

        // PUT: api/Followus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFollowus(int id, Followus followus)
        {
            if (id != followus.id)
            {
                return BadRequest();
            }

            _context.Entry(followus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowusExists(id))
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

        // POST: api/Followus
        [HttpPost]
        public async Task<ActionResult<Followus>> PostFollowus(Followus followus)
        {
            _context.Followus.Add(followus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFollowus", new { id = followus.id }, followus);
        }
        [HttpGet]
        [Route("allacceptedfollow/{userid}")]
        public  ActionResult<IEnumerable<Followus>> allacceptedfollow(string userid)
        {
            if (userid==null)
            {
                return BadRequest();
            }

          var allacceptablefollows=  _context.Followus.Where(a => a.sender == userid && a.accept == "true");

          

            if (allacceptablefollows==null)
            {
                return NoContent();
            }
            return new JsonResult(allacceptablefollows);
        }
        [HttpGet]
        [Route("allfriends/{userid}")]
        public ActionResult<IEnumerable<Followus>> allfriends(string userid)
        {
            if (userid == null)
            {
                return BadRequest();
            }

            var allacceptablefollows = _context.Followus.Where(a => (a.sender == userid ||a.recever==userid)&& a.accept == "true");



            if (allacceptablefollows == null)
            {
                return NoContent();
            }
            return new JsonResult(allacceptablefollows);
        }
        public IEnumerable<Followus> allfriendsforprivate(string userid)
        {
            if (userid == null)
            {
                return null;
            }

            var allacceptablefollows = _context.Followus.Where(a => (a.sender == userid || a.recever == userid) && a.accept == "true");



            if (allacceptablefollows == null)
            {
                return null;
            }
            return allacceptablefollows;
        }
        // DELETE: api/Followus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Followus>> DeleteFollowus(int id)
        {
            var followus = await _context.Followus.FindAsync(id);
            if (followus == null)
            {
                return NotFound();
            }

            _context.Followus.Remove(followus);
            await _context.SaveChangesAsync();

            return followus;
        }

        private bool FollowusExists(int id)
        {
            return _context.Followus.Any(e => e.id == id);
        }
    }
}
