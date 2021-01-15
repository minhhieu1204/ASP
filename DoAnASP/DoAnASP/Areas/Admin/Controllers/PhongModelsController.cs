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
    public class PhongModelsController : Controller
    {
        private readonly DPContext _context;

        public PhongModelsController(DPContext context)
        {
            _context = context;
        }
        private string username = null;
        // GET: Admin/PhongModels
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
            var dPContext = _context.phongModels.Include(p => p.rap);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/PhongModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongModel = await _context.phongModels
                .Include(p => p.rap)
                .FirstOrDefaultAsync(m => m.IdPhong == id);
            if (phongModel == null)
            {
                return NotFound();
            }

            return View(phongModel);
        }

        // GET: Admin/PhongModels/Create
        public IActionResult Create()
        {
            ViewBag.Username = username;
            ViewData["MaRap"] = new SelectList(_context.rapModels, "IdRap", "DiaChiRap");
            return View();
        }

        // POST: Admin/PhongModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPhong,TenPhong,MaRap")] PhongModel phongModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phongModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaRap"] = new SelectList(_context.rapModels, "IdRap", "DiaChiRap", phongModel.MaRap);
            return View(phongModel);
        }

        // GET: Admin/PhongModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongModel = await _context.phongModels.FindAsync(id);
            if (phongModel == null)
            {
                return NotFound();
            }
            ViewBag.Username = username;
            ViewData["MaRap"] = new SelectList(_context.rapModels, "IdRap", "DiaChiRap", phongModel.MaRap);
            return View(phongModel);
        }

        // POST: Admin/PhongModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPhong,TenPhong,MaRap")] PhongModel phongModel)
        {
            if (id != phongModel.IdPhong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phongModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongModelExists(phongModel.IdPhong))
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
            ViewData["MaRap"] = new SelectList(_context.rapModels, "IdRap", "DiaChiRap", phongModel.MaRap);
            return View(phongModel);
        }

        // GET: Admin/PhongModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongModel = await _context.phongModels
                .Include(p => p.rap)
                .FirstOrDefaultAsync(m => m.IdPhong == id);
            if (phongModel == null)
            {
                return NotFound();
            }
            ViewBag.Username = username;
            return View(phongModel);
        }

        // POST: Admin/PhongModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phongModel = await _context.phongModels.FindAsync(id);
            _context.phongModels.Remove(phongModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongModelExists(int id)
        {
            return _context.phongModels.Any(e => e.IdPhong == id);
        }
    }
}
