using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CisEng.Data;
using CisEng.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Collections;

namespace CisEng.Controllers
{
    public class CommentsController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly AppDbContext _context;

        public CommentsController(AppDbContext context,IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comments.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comments = await _context.Comments
                .FirstOrDefaultAsync(m => m.id == id);
            if (comments == null)
            {
                return NotFound();
            }

            return View(comments);
        }

        // GET: Comments/Create
        [HttpGet]
        public IActionResult Create(string studentId,string postId)
        {
            ViewData["studentId"] = studentId;
            ViewData["postId"] = postId;
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public async Task<IActionResult> Create(Comments comments)
        {
            if (ModelState.IsValid)
            {
                if (comments.comment.Contains("/uploads/"))
                {
                    comments.comment = comments.comment.Replace("/uploads/", "http://localhost:57761/uploads/");
                }

                _context.Add(comments);
                await _context.SaveChangesAsync();
                return Redirect("http://localhost:4200/HomePage/"+comments.StudentId);
            }
            return View(comments);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comments = await _context.Comments.FindAsync(id);
            if (comments == null)
            {
                return NotFound();
            }
            return View(comments);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,comment,StudentId,PostId,Time")] Comments comments)
        {
            if (id != comments.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentsExists(comments.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(comments);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comments = await _context.Comments
                .FirstOrDefaultAsync(m => m.id == id);
            if (comments == null)
            {
                return NotFound();
            }

            return View(comments);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comments = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(comments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentsExists(int id)
        {
            return _context.Comments.Any(e => e.id == id);
        }
    }
}
