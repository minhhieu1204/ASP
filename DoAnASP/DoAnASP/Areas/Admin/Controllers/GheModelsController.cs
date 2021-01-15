using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnASP.Areas.Admin.Data;
using DoAnASP.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace DoAnASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GheModelsController : Controller
    {
        private readonly DPContext _context;

        public GheModelsController(DPContext context)
        {
            _context = context;
        }
        private string username = null;
        // GET: Admin/GheModels
        public async Task<IActionResult> Index()
        {
            try
            {
                if (HttpContext.Session.GetString("User").ToString() == null)
                {
                    HttpContext.Session.SetString("User", "Chưa đăng nhập");
                }
                else
                {
                    JObject us = JObject.Parse(HttpContext.Session.GetString("User"));
                    username = us.SelectToken("Username").ToString();
                    ViewBag.Username = username;

                }
            }
            catch (Exception e)
            {

                throw new Exception("Chưa Đăng nhập");
            }
            var dPContext = _context.gheModels.Include(g => g.loaiGhe).Include(g => g.phong);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/GheModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gheModel = await _context.gheModels
                .Include(g => g.loaiGhe)
                .Include(g => g.phong)
                .FirstOrDefaultAsync(m => m.IdGhe == id);
            if (gheModel == null)
            {
                return NotFound();
            }

            return View(gheModel);
        }

        // GET: Admin/GheModels/Create
        public IActionResult Create()
        {
            ViewBag.Username = username;
            ViewData["MaLoaiGhe"] = new SelectList(_context.loaiGheModels, "IdLoaiGhe", "TenLoaiGhe");
            ViewData["MaPhong"] = new SelectList(_context.phongModels, "IdPhong", "TenPhong");
            return View();
        }

        // POST: Admin/GheModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGhe,TenGhe,TrangThai,MaLoaiGhe,MaPhong")] GheModel gheModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gheModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoaiGhe"] = new SelectList(_context.loaiGheModels, "IdLoaiGhe", "TenLoaiGhe", gheModel.MaLoaiGhe);
            ViewData["MaPhong"] = new SelectList(_context.phongModels, "IdPhong", "TenPhong", gheModel.MaPhong);
            return View(gheModel);
        }

        // GET: Admin/GheModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gheModel = await _context.gheModels.FindAsync(id);
            if (gheModel == null)
            {
                return NotFound();
            }
            ViewData["MaLoaiGhe"] = new SelectList(_context.loaiGheModels, "IdLoaiGhe", "TenLoaiGhe", gheModel.MaLoaiGhe);
            ViewData["MaPhong"] = new SelectList(_context.phongModels, "IdPhong", "TenPhong", gheModel.MaPhong);
            return View(gheModel);
        }

        // POST: Admin/GheModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGhe,TenGhe,TrangThai,MaLoaiGhe,MaPhong")] GheModel gheModel)
        {
            ViewBag.Username = username;
            if (id != gheModel.IdGhe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gheModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GheModelExists(gheModel.IdGhe))
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
            ViewData["MaLoaiGhe"] = new SelectList(_context.loaiGheModels, "IdLoaiGhe", "TenLoaiGhe", gheModel.MaLoaiGhe);
            ViewData["MaPhong"] = new SelectList(_context.phongModels, "IdPhong", "TenPhong", gheModel.MaPhong);
            return View(gheModel);
        }

        // GET: Admin/GheModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.Username = username;
            if (id == null)
            {
                return NotFound();
            }

            var gheModel = await _context.gheModels
                .Include(g => g.loaiGhe)
                .Include(g => g.phong)
                .FirstOrDefaultAsync(m => m.IdGhe == id);
            if (gheModel == null)
            {
                return NotFound();
            }

            return View(gheModel);
        }

        // POST: Admin/GheModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gheModel = await _context.gheModels.FindAsync(id);
            _context.gheModels.Remove(gheModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GheModelExists(int id)
        {
            return _context.gheModels.Any(e => e.IdGhe == id);
        }
    }
}
