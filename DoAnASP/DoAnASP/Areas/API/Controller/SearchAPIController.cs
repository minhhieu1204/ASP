using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAnASP.Areas.Admin.Data;
using DoAnASP.Areas.Admin.Models;
using Newtonsoft.Json;

namespace DoAnASP.Areas.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchAPIController : ControllerBase
    {
        private readonly DPContext _context;

        public SearchAPIController(DPContext context)
        {
            _context = context;
        }

        // GET: api/SearchAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhimModel>>> GetphimModels()
        {
            return await _context.phimModels.ToListAsync();
        }

        [HttpGet("search")]
        public  String search(String keyword)
        {
            var data = from db in _context.phimModels
                       where db.TenPhim.Contains(keyword) || db.loaiPhim.TenLoaiPhim.Contains(keyword)
                       select new {
                           db.IdPhim,
                           db.TenPhim,
                           db.ThoiLuong,
                           db.HinhAnh,
                           db.LinkPhim,
                           db.loaiPhim.TenLoaiPhim
                       };
            return JsonConvert.SerializeObject(data);
        }

        // GET: api/SearchAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhimModel>> GetPhimModel(int id)
        {
            var phimModel = await _context.phimModels.FindAsync(id);

            if (phimModel == null)
            {
                return NotFound();
            }

            return phimModel;
        }

        // PUT: api/SearchAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhimModel(int id, PhimModel phimModel)
        {
            if (id != phimModel.IdPhim)
            {
                return BadRequest();
            }

            _context.Entry(phimModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhimModelExists(id))
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

        // POST: api/SearchAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]      
        public async Task<ActionResult<PhimModel>> PostPhimModel(PhimModel phimModel)
        {
            _context.phimModels.Add(phimModel);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhimModel", new { id = phimModel.IdPhim }, phimModel);
        }

        // DELETE: api/SearchAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhimModel>> DeletePhimModel(int id)
        {
            var phimModel = await _context.phimModels.FindAsync(id);
            if (phimModel == null)
            {
                return NotFound();
            }

            _context.phimModels.Remove(phimModel);
            await _context.SaveChangesAsync();

            return phimModel;
        }

        private bool PhimModelExists(int id)
        {
            return _context.phimModels.Any(e => e.IdPhim == id);
        }
    }
}
