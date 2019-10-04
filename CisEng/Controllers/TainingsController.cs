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
    public class TainingsController : Controller
    {
        private readonly AppDbContext _context;

        public TainingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Tainings
     

        // GET: Tainings/Create
        public IActionResult Create(string Id)
        {
        
            ViewData["sponser"] = Id;
            return View();
        }

       
        [HttpPost]
        
        public async Task<IActionResult> Create([Bind("technology,place,time,sponser,Containt")] Taining taining)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taining);
                await _context.SaveChangesAsync();
                return  Redirect("http://localhost:4200/Training/" + taining.sponser);
            }
            return View(taining);
        }

       

    

    }
}
