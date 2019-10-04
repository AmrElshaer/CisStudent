using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CisEng.Data;
using CisEng.Models;
using Microsoft.AspNetCore.Mvc;



namespace CisEng.Controllers
{
    public class ResponsetoResonseController : Controller
    {
        private readonly AppDbContext _context;

        public ResponsetoResonseController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create(string id, string idofresponse)
        {
            ViewData["idofstudent"] = id;
            ViewData["idofresponse"] = idofresponse;
            return View();
        }

        // POST: ResponsetoComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Create([Bind("id,idofresponse,idofstudent,Containt,time")] responsetorespone responsetoComment)
        {
            if (ModelState.IsValid)
            {
                _context.responsetorespone.Add(responsetoComment);
                await _context.SaveChangesAsync();
                return  Redirect("http://localhost:4200/HomePage/"+responsetoComment.idofstudent);
            }
            return View(responsetoComment);
        }

    }
}
