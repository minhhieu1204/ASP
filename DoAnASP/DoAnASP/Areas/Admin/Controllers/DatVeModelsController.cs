using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnASP.Areas.Admin.Data;
using DoAnASP.Areas.Admin.Models;

namespace DoAnASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DatVeModelsController : Controller
    {
        private readonly DPContext _context;

        public DatVeModelsController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/DatVeModels
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.datVeModels.Include(d => d.lichchieu);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/DatVeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datVeModel = await _context.datVeModels
                .Include(d => d.lichchieu)
                .FirstOrDefaultAsync(m => m.IdDatVe == id);
            if (datVeModel == null)
            {
                return NotFound();
            }

            return View(datVeModel);
        }

        // GET: Admin/DatVeModels/Create
        public IActionResult Create()
        {
            ViewData["Malichchieu"] = new SelectList(_context.lichChieuModels, "IdLichChieu", "IdLichChieu");
            return View();
        }

        // POST: Admin/DatVeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDatVe,SoGhe,NgayDat,Tonggia,Malichchieu,Makhachhang")] DatVeModel datVeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datVeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Malichchieu"] = new SelectList(_context.lichChieuModels, "IdLichChieu", "IdLichChieu", datVeModel.Malichchieu);
            return View(datVeModel);
        }

        // GET: Admin/DatVeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datVeModel = await _context.datVeModels.FindAsync(id);
            if (datVeModel == null)
            {
                return NotFound();
            }
            ViewData["Malichchieu"] = new SelectList(_context.lichChieuModels, "IdLichChieu", "IdLichChieu", datVeModel.Malichchieu);
            return View(datVeModel);
        }

        // POST: Admin/DatVeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDatVe,SoGhe,NgayDat,Tonggia,Malichchieu,Makhachhang")] DatVeModel datVeModel)
        {
            if (id != datVeModel.IdDatVe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datVeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatVeModelExists(datVeModel.IdDatVe))
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
            ViewData["Malichchieu"] = new SelectList(_context.lichChieuModels, "IdLichChieu", "IdLichChieu", datVeModel.Malichchieu);
            return View(datVeModel);
        }

        // GET: Admin/DatVeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datVeModel = await _context.datVeModels
                .Include(d => d.lichchieu)
                .FirstOrDefaultAsync(m => m.IdDatVe == id);
            if (datVeModel == null)
            {
                return NotFound();
            }

            return View(datVeModel);
        }

        // POST: Admin/DatVeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datVeModel = await _context.datVeModels.FindAsync(id);
            _context.datVeModels.Remove(datVeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatVeModelExists(int id)
        {
            return _context.datVeModels.Any(e => e.IdDatVe == id);
        }
    }
}
