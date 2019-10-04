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
    public class AllpublicpostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AllpublicpostsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Allpublicposts
        [HttpGet]
        public  IActionResult GetPosts()
        {
            return new JsonResult(_context.Posts.Where(a=>a.PostPrivte=="false"));
        }

       
    }
}
