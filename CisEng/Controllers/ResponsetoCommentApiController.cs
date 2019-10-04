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
    public class ResponsetoCommentApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ResponsetoCommentApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ResponsetoCommentApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponsetoComment>>> GetResponsetoComment()
        {
            return await _context.ResponsetoComment.ToListAsync();
        }

        // GET: api/ResponsetoCommentApi/5
        [HttpGet("{id}")]
        public ActionResult<List<ResponsetoComment>> GetResponsetoComment(string id)
        {
            var responsetoComment =  _context.ResponsetoComment.Where(a=>a.idofcomment==id);

            if (responsetoComment == null)
            {
                return NotFound();
            }

            return responsetoComment.ToList();
        }

        // PUT: api/ResponsetoCommentApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResponsetoComment(int id, ResponsetoComment responsetoComment)
        {
            if (id != responsetoComment.id)
            {
                return BadRequest();
            }

            _context.Entry(responsetoComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResponsetoCommentExists(id))
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

        // POST: api/ResponsetoCommentApi
        [HttpPost]
        public async Task<ActionResult<ResponsetoComment>> PostResponsetoComment(ResponsetoComment responsetoComment)
        {
            _context.ResponsetoComment.Add(responsetoComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResponsetoComment", new { id = responsetoComment.id }, responsetoComment);
        }

        // DELETE: api/ResponsetoCommentApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponsetoComment>> DeleteResponsetoComment(int id)
        {
            var responsetoComment = await _context.ResponsetoComment.FindAsync(id);
            if (responsetoComment == null)
            {
                return NotFound();
            }

            _context.ResponsetoComment.Remove(responsetoComment);
            await _context.SaveChangesAsync();

            return responsetoComment;
        }

        private bool ResponsetoCommentExists(int id)
        {
            return _context.ResponsetoComment.Any(e => e.id == id);
        }
    }
}
