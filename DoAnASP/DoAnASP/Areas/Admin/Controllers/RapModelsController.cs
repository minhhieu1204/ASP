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
    public class RapModelsController : Controller
    {
        private readonly DPContext _context;

        public RapModelsController(DPContext context)
        {
            _context = context;
        }
        private string username = null;
        // GET: Admin/RapModels
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
            var dPContext = _context.rapModels.Include(r => r.quanHuyen);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/RapModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapModel = await _context.rapModels
                .Include(r => r.quanHuyen)
                .FirstOrDefaultAsync(m => m.IdRap == id);
            if (rapModel == null)
            {
                return NotFound();
            }

            return View(rapModel);
        }

        // GET: Admin/RapModels/Create
        public IActionResult Create()
        {
            ViewBag.Username = username;
            ViewData["MaQuanHuyen"] = new SelectList(_context.quanHuyenModels, "IdQuanHuyen", "TenQuanHuyen");
            return View();
        }

        // POST: Admin/RapModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRap,TenRap,DiaChiRap,MaQuanHuyen")] RapModel rapModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rapModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaQuanHuyen"] = new SelectList(_context.quanHuyenModels, "IdQuanHuyen", "TenQuanHuyen", rapModel.MaQuanHuyen);
            return View(rapModel);
        }

        // GET: Admin/RapModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapModel = await _context.rapModels.FindAsync(id);
            if (rapModel == null)
            {
                return NotFound();
            }
            ViewBag.Username = username;
            ViewData["MaQuanHuyen"] = new SelectList(_context.quanHuyenModels, "IdQuanHuyen", "TenQuanHuyen", rapModel.MaQuanHuyen);
            return View(rapModel);
        }

        // POST: Admin/RapModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRap,TenRap,DiaChiRap,MaQuanHuyen")] RapModel rapModel)
        {
            if (id != rapModel.IdRap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rapModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RapModelExists(rapModel.IdRap))
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
            ViewData["MaQuanHuyen"] = new SelectList(_context.quanHuyenModels, "IdQuanHuyen", "TenQuanHuyen", rapModel.MaQuanHuyen);
            return View(rapModel);
        }

        // GET: Admin/RapModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.Username = username;
            if (id == null)
            {
                return NotFound();
            }

            var rapModel = await _context.rapModels
                .Include(r => r.quanHuyen)
                .FirstOrDefaultAsync(m => m.IdRap == id);
            if (rapModel == null)
            {
                return NotFound();
            }

            return View(rapModel);
        }

        // POST: Admin/RapModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rapModel = await _context.rapModels.FindAsync(id);
            _context.rapModels.Remove(rapModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RapModelExists(int id)
        {
            return _context.rapModels.Any(e => e.IdRap == id);
        }
    }
}
