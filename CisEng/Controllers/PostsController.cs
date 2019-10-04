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
    public class PostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostsController(AppDbContext context)
        {
            _context = context;
        }
     

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Posts>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Posts>>> GetPosts(string id)
        {
            var posts = await _context.Posts.Where(a=>a.CisStudentId==id).ToListAsync();

            if (posts == null)
            {
                return NotFound();
            }

            return posts;
        }
        [Route("privatePosts")]
        public IEnumerable<Posts> privatePosts(string id)
        {
            var posts = _context.Posts.Where(a => a.CisStudentId == id && a.PostPrivte == "true").ToList();

            if (posts.Count == 0)
            {
                return null;
            }

            return posts;
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosts(int id, Posts posts)
        {
            if (id != posts.Id)
            {
                return BadRequest();
            }

            _context.Entry(posts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostsExists(id))
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
        
        // POST: api/Posts
        [HttpPost]
        public async Task<ActionResult<Posts>> PostPosts(Posts posts)
        {

            var date = DateTime.Now;
            posts.dateTime = date;
            _context.Posts.Add(posts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosts", new { id = posts.Id }, posts);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Posts>> DeletePosts(int id)
        {
            var posts = await _context.Posts.FindAsync(id);
            if (posts == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(posts);
            await _context.SaveChangesAsync();

            return posts;
        }

        private bool PostsExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
