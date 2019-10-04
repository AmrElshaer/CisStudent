using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CisEng.Data;
using CisEng.Models;

namespace CisEng.Controllers
{
    public class ResponsetoCommentsController : Controller
    {
        private readonly AppDbContext _context;

        public ResponsetoCommentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ResponsetoComments
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResponsetoComment.ToListAsync());
        }

        // GET: ResponsetoComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsetoComment = await _context.ResponsetoComment
                .FirstOrDefaultAsync(m => m.id == id);
            if (responsetoComment == null)
            {
                return NotFound();
            }

            return View(responsetoComment);
        }

        // GET: ResponsetoComments/Create
        [HttpGet]
        public IActionResult Create(string id,string idofcomment)
        {
            ViewData["idofstudent"] = id;
            ViewData["idofcomment"] = idofcomment;
            return View();
        }

        // POST: ResponsetoComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public async Task<IActionResult> Create([Bind("id,idofcomment,idofstudent,Containt,time")] ResponsetoComment responsetoComment)
        {
            if (ModelState.IsValid)
            {

                 responsetoComment.idof = Guid.NewGuid().ToString();
                _context.Add(responsetoComment);
                await _context.SaveChangesAsync();
                return Redirect("http://localhost:4200/HomePage/" + responsetoComment.idofstudent);
            }
            return View(responsetoComment);
        }

        // GET: ResponsetoComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsetoComment = await _context.ResponsetoComment.FindAsync(id);
            if (responsetoComment == null)
            {
                return NotFound();
            }
            return View(responsetoComment);
        }

        // POST: ResponsetoComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,idofcomment,Containt,time")] ResponsetoComment responsetoComment)
        {
            if (id != responsetoComment.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsetoComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsetoCommentExists(responsetoComment.id))
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
            return View(responsetoComment);
        }

        // GET: ResponsetoComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsetoComment = await _context.ResponsetoComment
                .FirstOrDefaultAsync(m => m.id == id);
            if (responsetoComment == null)
            {
                return NotFound();
            }

            return View(responsetoComment);
        }

        // POST: ResponsetoComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var responsetoComment = await _context.ResponsetoComment.FindAsync(id);
            _context.ResponsetoComment.Remove(responsetoComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsetoCommentExists(int id)
        {
            return _context.ResponsetoComment.Any(e => e.id == id);
        }
    }
}
