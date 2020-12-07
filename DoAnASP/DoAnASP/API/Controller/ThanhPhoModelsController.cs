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

namespace DoAnASP.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThanhPhoModelsController : ControllerBase
    {
        private readonly DPContext _context;

        public ThanhPhoModelsController(DPContext context)
        {
            _context = context;
        }

        // GET: api/ThanhPhoModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThanhPhoModel>>> GetthanhPhoModels()
        {
            return await _context.thanhPhoModels.ToListAsync();
        }
        [HttpGet("root")]
        public String ShowFileInRootFolder()
        {
            var data = from db in _context.thanhPhoModels
                       select db;
            return JsonConvert.SerializeObject(data);
        }

        [HttpGet("quanhuyen")]
        public String ShowQuanHuyen(String id)
        {
            var data = from db in _context.quanHuyenModels
                       where db.MaThanhPho == int.Parse(id)
                         select db;
            return JsonConvert.SerializeObject(data);
        }

        [HttpGet("rap")]
        public String ShowRap(String id)
        {
            var data = from db in _context.rapModels
                       where db.MaQuanHuyen == int.Parse(id)
                       select db;
            return JsonConvert.SerializeObject(data);
        }

        // GET: api/ThanhPhoModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThanhPhoModel>> GetThanhPhoModel(int id)
        {
            var thanhPhoModel = await _context.thanhPhoModels.FindAsync(id);

            if (thanhPhoModel == null)
            {
                return NotFound();
            }

            return thanhPhoModel;
        }

        // PUT: api/ThanhPhoModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThanhPhoModel(int id, ThanhPhoModel thanhPhoModel)
        {
            if (id != thanhPhoModel.IdThanhPho)
            {
                return BadRequest();
            }

            _context.Entry(thanhPhoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThanhPhoModelExists(id))
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

        // POST: api/ThanhPhoModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ThanhPhoModel>> PostThanhPhoModel(ThanhPhoModel thanhPhoModel)
        {
            _context.thanhPhoModels.Add(thanhPhoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThanhPhoModel", new { id = thanhPhoModel.IdThanhPho }, thanhPhoModel);
        }

        // DELETE: api/ThanhPhoModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ThanhPhoModel>> DeleteThanhPhoModel(int id)
        {
            var thanhPhoModel = await _context.thanhPhoModels.FindAsync(id);
            if (thanhPhoModel == null)
            {
                return NotFound();
            }

            _context.thanhPhoModels.Remove(thanhPhoModel);
            await _context.SaveChangesAsync();

            return thanhPhoModel;
        }

        private bool ThanhPhoModelExists(int id)
        {
            return _context.thanhPhoModels.Any(e => e.IdThanhPho == id);
        }
    }
}
