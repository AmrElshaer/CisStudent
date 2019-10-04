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
    public class CommentApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommentApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CommentApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comments>>> GetPosts()
        {
            return await _context.Comments.ToListAsync();
        }

        // GET: api/CommentApi/5
        [HttpGet("{id}")]
        public IEnumerable<Comments> GetPosts(int id)
        {
            var posts =  _context.Comments.Where(a=>a.PostId==id.ToString());

            if (posts == null)
            {
                return null;
            }

            return posts;
        }

        // PUT: api/CommentApi/5
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

        // POST: api/CommentApi
        [HttpPost]
        public async Task<ActionResult<Posts>> PostPosts(Posts posts)
        {
            _context.Posts.Add(posts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosts", new { id = posts.Id }, posts);
        }

        // DELETE: api/CommentApi/5
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
