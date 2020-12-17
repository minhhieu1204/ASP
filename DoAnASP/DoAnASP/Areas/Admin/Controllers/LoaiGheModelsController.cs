using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnASP.Areas.Admin.Data;
using DoAnASP.Areas.Admin.Models;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;

namespace DoAnASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoaiGheModelsController : Controller
    {
        private readonly DPContext _context;

        public LoaiGheModelsController(DPContext context)
        {
            _context = context;
        }
        // GET: Admin/LoaiGheModels
        public async Task<IActionResult> Index()
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("User"));
            ViewBag.Username = us.SelectToken("Username").ToString();
            return View(await _context.loaiGheModels.ToListAsync());
        }

        // GET: Admin/LoaiGheModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("User"));
            ViewBag.Username = us.SelectToken("Username").ToString();
            if (id == null)
            {
                return NotFound();
            }

            var loaiGheModel = await _context.loaiGheModels
                .FirstOrDefaultAsync(m => m.IdLoaiGhe == id);
            if (loaiGheModel == null)
            {
                return NotFound();
            }

            return View(loaiGheModel);
        }

        // GET: Admin/LoaiGheModels/Create
        public IActionResult Create()
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("User"));
            ViewBag.Username = us.SelectToken("Username").ToString();
            return View();
        }

        // POST: Admin/LoaiGheModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLoaiGhe,TenLoaiGhe,GiaLoaiGhe")] LoaiGheModel loaiGheModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiGheModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiGheModel);
        }

        // GET: Admin/LoaiGheModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("User"));
            ViewBag.Username = us.SelectToken("Username").ToString();
            if (id == null)
            {
                return NotFound();
            }

            var loaiGheModel = await _context.loaiGheModels.FindAsync(id);
            if (loaiGheModel == null)
            {
                return NotFound();
            }
            return View(loaiGheModel);
        }

        // POST: Admin/LoaiGheModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLoaiGhe,TenLoaiGhe,GiaLoaiGhe")] LoaiGheModel loaiGheModel)
        {
            if (id != loaiGheModel.IdLoaiGhe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiGheModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiGheModelExists(loaiGheModel.IdLoaiGhe))
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
            return View(loaiGheModel);
        }

        // GET: Admin/LoaiGheModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("User"));
            ViewBag.Username = us.SelectToken("Username").ToString();
            if (id == null)
            {
                return NotFound();
            }

            var loaiGheModel = await _context.loaiGheModels
                .FirstOrDefaultAsync(m => m.IdLoaiGhe == id);
            if (loaiGheModel == null)
            {
                return NotFound();
            }

            return View(loaiGheModel);
        }

        // POST: Admin/LoaiGheModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiGheModel = await _context.loaiGheModels.FindAsync(id);
            _context.loaiGheModels.Remove(loaiGheModel);
            HttpContext.Session.Remove("User");
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiGheModelExists(int id)
        {
            return _context.loaiGheModels.Any(e => e.IdLoaiGhe == id);
        }
    }
}
