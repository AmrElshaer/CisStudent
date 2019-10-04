using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CisEng.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class ImageController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;
        public ImageController(IHostingEnvironment environment)
        {
         
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
           
        }
        // GET: api/Image
        [HttpGet]
       
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Image/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Image



        [EnableCors("allowcors")]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Image()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine(_environment.WebRootPath, "upload");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        // PUT: api/Image/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
