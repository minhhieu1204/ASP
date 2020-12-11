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
    public class ChiTietDatVeModelsController : Controller
    {
        private readonly DPContext _context;

        public ChiTietDatVeModelsController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/ChiTietDatVeModels
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.chiTietDatVeModels.Include(c => c.datVe);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/ChiTietDatVeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietDatVeModel = await _context.chiTietDatVeModels
                .Include(c => c.datVe)
                .FirstOrDefaultAsync(m => m.IdChiTietDatVe == id);
            if (chiTietDatVeModel == null)
            {
                return NotFound();
            }

            return View(chiTietDatVeModel);
        }

        // GET: Admin/ChiTietDatVeModels/Create
        public IActionResult Create()
        {
            ViewData["MaDatVe"] = new SelectList(_context.datVeModels, "IdDatVe", "IdDatVe");
            return View();
        }

        // POST: Admin/ChiTietDatVeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdChiTietDatVe,SoGhe,GiaVe,MaDatVe")] ChiTietDatVeModel chiTietDatVeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietDatVeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDatVe"] = new SelectList(_context.datVeModels, "IdDatVe", "IdDatVe", chiTietDatVeModel.MaDatVe);
            return View(chiTietDatVeModel);
        }

        // GET: Admin/ChiTietDatVeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietDatVeModel = await _context.chiTietDatVeModels.FindAsync(id);
            if (chiTietDatVeModel == null)
            {
                return NotFound();
            }
            ViewData["MaDatVe"] = new SelectList(_context.datVeModels, "IdDatVe", "IdDatVe", chiTietDatVeModel.MaDatVe);
            return View(chiTietDatVeModel);
        }

        // POST: Admin/ChiTietDatVeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdChiTietDatVe,SoGhe,GiaVe,MaDatVe")] ChiTietDatVeModel chiTietDatVeModel)
        {
            if (id != chiTietDatVeModel.IdChiTietDatVe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietDatVeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietDatVeModelExists(chiTietDatVeModel.IdChiTietDatVe))
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
            ViewData["MaDatVe"] = new SelectList(_context.datVeModels, "IdDatVe", "IdDatVe", chiTietDatVeModel.MaDatVe);
            return View(chiTietDatVeModel);
        }

        // GET: Admin/ChiTietDatVeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietDatVeModel = await _context.chiTietDatVeModels
                .Include(c => c.datVe)
                .FirstOrDefaultAsync(m => m.IdChiTietDatVe == id);
            if (chiTietDatVeModel == null)
            {
                return NotFound();
            }

            return View(chiTietDatVeModel);
        }

        // POST: Admin/ChiTietDatVeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiTietDatVeModel = await _context.chiTietDatVeModels.FindAsync(id);
            _context.chiTietDatVeModels.Remove(chiTietDatVeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietDatVeModelExists(int id)
        {
            return _context.chiTietDatVeModels.Any(e => e.IdChiTietDatVe == id);
        }
    }
}
