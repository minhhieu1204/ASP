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
    public class LoaiPhimModelsController : Controller
    {
        private readonly DPContext _context;

        public LoaiPhimModelsController(DPContext context)
        {
            _context = context;
        }
        private string username = null;
        // GET: Admin/LoaiPhimModels
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
                    username = us.SelectToken("IdUser").ToString();
                    ViewBag.Username = username;

                }
            }
            catch (Exception e)
            {

                throw new Exception("Chưa Đăng nhập");
            }
            return View(await _context.loaiPhimModels.ToListAsync());
        }

        // GET: Admin/LoaiPhimModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("User"));
            ViewBag.Username = us.SelectToken("Username").ToString();
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
            ViewBag.Username = username;
            JObject us = JObject.Parse(HttpContext.Session.GetString("User"));
            ViewBag.Username = us.SelectToken("Username").ToString();
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
            ViewBag.Username = username;
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
            ViewBag.Username = username;
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
