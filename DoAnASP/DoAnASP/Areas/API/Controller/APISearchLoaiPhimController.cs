using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnASP.Areas.Admin.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoAnASP.Areas.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class APISearchLoaiPhimController : ControllerBase
    {
        private readonly DPContext _context;

        public APISearchLoaiPhimController(DPContext context)
        {
            _context = context;
        }
        // GET: api/<APISearchLoaiPhimController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<APISearchLoaiPhimController>/5
        [HttpGet("GetData")]
        public string Get(string keyword)
        {
            var typeFilm = from s in _context.loaiPhimModels
                           where s.TenLoaiPhim.Contains(keyword)
                           select s;
            return JsonConvert.SerializeObject(typeFilm);
        }

        // POST api/<APISearchLoaiPhimController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<APISearchLoaiPhimController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APISearchLoaiPhimController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
