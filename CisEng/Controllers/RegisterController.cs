using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CisEng.Data;
using CisEng.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CisEng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class RegisterController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public RegisterController(AppDbContext context)
        {
            _context = context;
           
        }
        [EnableCors("allowcors")]
        [HttpPost, DisableRequestSizeLimit]


        public CisStudent GetCanRegister(Register register)
        {
            var resuilt = this._context.CisStudent.FirstOrDefault(a => a.password == register.password && a.StudentEmail == register.studentEmail);
            if (resuilt != null)
            {
                return resuilt;
            }
            return null;
        }
       
    }
}