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
    public class GiamGiaModelsController : Controller
    {
        private readonly DPContext _context;

        public GiamGiaModelsController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/GiamGiaModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.giamGiaModels.ToListAsync());
        }

        // GET: Admin/GiamGiaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giamGiaModel = await _context.giamGiaModels
                .FirstOrDefaultAsync(m => m.IdMaGiamGia == id);
            if (giamGiaModel == null)
            {
                return NotFound();
            }

            return View(giamGiaModel);
        }

        // GET: Admin/GiamGiaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/GiamGiaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMaGiamGia,PhanTram")] GiamGiaModel giamGiaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giamGiaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giamGiaModel);
        }

        // GET: Admin/GiamGiaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giamGiaModel = await _context.giamGiaModels.FindAsync(id);
            if (giamGiaModel == null)
            {
                return NotFound();
            }
            return View(giamGiaModel);
        }

        // POST: Admin/GiamGiaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMaGiamGia,PhanTram")] GiamGiaModel giamGiaModel)
        {
            if (id != giamGiaModel.IdMaGiamGia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giamGiaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiamGiaModelExists(giamGiaModel.IdMaGiamGia))
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
            return View(giamGiaModel);
        }

        // GET: Admin/GiamGiaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giamGiaModel = await _context.giamGiaModels
                .FirstOrDefaultAsync(m => m.IdMaGiamGia == id);
            if (giamGiaModel == null)
            {
                return NotFound();
            }

            return View(giamGiaModel);
        }

        // POST: Admin/GiamGiaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giamGiaModel = await _context.giamGiaModels.FindAsync(id);
            _context.giamGiaModels.Remove(giamGiaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiamGiaModelExists(int id)
        {
            return _context.giamGiaModels.Any(e => e.IdMaGiamGia == id);
        }
    }
}
