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
    public class LichChieuModelsAPIController : ControllerBase
    {
        private readonly DPContext _context;

        public LichChieuModelsAPIController(DPContext context)
        {
            _context = context;
        }

        // GET: api/LichChieuModelsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LichChieuModel>>> GetlichChieuModels()
        {
            return await _context.lichChieuModels.ToListAsync();
        }

        // GET: api/LichChieuModelsAPI/5
        [HttpGet("Getphim")]
        public string GetLichChieuModel(int id,int marap,int ngay)
        {
            string ngaysosanh = ngay.ToString();
            var ds = from a in _context.lichChieuModels
                     where a.MaPhim == id && a.NgayChieu.ToString().Contains(ngaysosanh)
                     select a;
            var dscombine = from s in _context.phongModels
                            join k in ds on s.IdPhong equals k.MaPhong 
                            where s.MaRap==marap
                            select new
                            {
                                k.IdLichChieu,
                                s.TenPhong,
                                k.GioBatDau,
                                Soluong=s.lstGhe.Count

                            };
            return JsonConvert.SerializeObject(dscombine);
        }

        // PUT: api/LichChieuModelsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLichChieuModel(int id, LichChieuModel lichChieuModel)
        {
            if (id != lichChieuModel.IdLichChieu)
            {
                return BadRequest();
            }

            _context.Entry(lichChieuModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LichChieuModelExists(id))
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

        // POST: api/LichChieuModelsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LichChieuModel>> PostLichChieuModel(LichChieuModel lichChieuModel)
        {
            _context.lichChieuModels.Add(lichChieuModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLichChieuModel", new { id = lichChieuModel.IdLichChieu }, lichChieuModel);
        }

        // DELETE: api/LichChieuModelsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LichChieuModel>> DeleteLichChieuModel(int id)
        {
            var lichChieuModel = await _context.lichChieuModels.FindAsync(id);
            if (lichChieuModel == null)
            {
                return NotFound();
            }

            _context.lichChieuModels.Remove(lichChieuModel);
            await _context.SaveChangesAsync();

            return lichChieuModel;
        }

        private bool LichChieuModelExists(int id)
        {
            return _context.lichChieuModels.Any(e => e.IdLichChieu == id);
        }
    }
}
