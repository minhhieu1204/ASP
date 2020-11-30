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
    public class LoaiPhimModelsController : Controller
    {
        private readonly DPContext _context;

        public LoaiPhimModelsController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiPhimModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.loaiPhimModels.ToListAsync());
        }

        // GET: Admin/LoaiPhimModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiPhimModel = await _context.loaiPhimModels
                .FirstOrDefaultAsync(m => m.IdLoaiPhim == id);
            if (loaiPhimModel == null)
            {
                return NotFound();
            }

            return View(loaiPhimModel);
        }

        // GET: Admin/LoaiPhimModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiPhimModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLoaiPhim,TenLoaiPhim")] LoaiPhimModel loaiPhimModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiPhimModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiPhimModel);
        }

        // GET: Admin/LoaiPhimModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiPhimModel = await _context.loaiPhimModels.FindAsync(id);
            if (loaiPhimModel == null)
            {
                return NotFound();
            }
            return View(loaiPhimModel);
        }

        // POST: Admin/LoaiPhimModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLoaiPhim,TenLoaiPhim")] LoaiPhimModel loaiPhimModel)
        {
            if (id != loaiPhimModel.IdLoaiPhim)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiPhimModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiPhimModelExists(loaiPhimModel.IdLoaiPhim))
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
            return View(loaiPhimModel);
        }

        // GET: Admin/LoaiPhimModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiPhimModel = await _context.loaiPhimModels
                .FirstOrDefaultAsync(m => m.IdLoaiPhim == id);
            if (loaiPhimModel == null)
            {
                return NotFound();
            }

            return View(loaiPhimModel);
        }

        // POST: Admin/LoaiPhimModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiPhimModel = await _context.loaiPhimModels.FindAsync(id);
            _context.loaiPhimModels.Remove(loaiPhimModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiPhimModelExists(int id)
        {
            return _context.loaiPhimModels.Any(e => e.IdLoaiPhim == id);
        }
    }
}
