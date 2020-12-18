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
    public class LichChieuModelsController : Controller
    {
        private readonly DPContext _context;

        public LichChieuModelsController(DPContext context)
        {
            _context = context;
        }
        private string username = null;
        // GET: Admin/LichChieuModels
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
            var dPContext = _context.lichChieuModels.Include(s => s.giamGia);
            var dpcontext = dPContext.Include(l => l.phong).Include(k=>k.phim);
            return View(await dpcontext.ToListAsync());
        }

        // GET: Admin/LichChieuModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichChieuModel = await _context.lichChieuModels
                .Include(l => l.giamGia)
                .FirstOrDefaultAsync(m => m.IdLichChieu == id);
            if (lichChieuModel == null)
            {
                return NotFound();
            }

            return View(lichChieuModel);
        }

        // GET: Admin/LichChieuModels/Create
        public IActionResult Create()
        {
            ViewBag.Username = username;
            ViewData["MaPhong"] = new SelectList(_context.phongModels, "IdPhong", "TenPhong");
            ViewData["MaPhim"] = new SelectList(_context.phimModels, "IdPhim", "TenPhim");
            ViewData["MaGiamGia"] = new SelectList(_context.giamGiaModels, "IdMaGiamGia", "IdMaGiamGia");
            return View();
        }

        // POST: Admin/LichChieuModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLichChieu,NgayChieu,GioBatDau,GioKetThuc,GiaVe,MaPhong,MaPhim,MaGiamGia")] LichChieuModel lichChieuModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lichChieuModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaGiamGia"] = new SelectList(_context.giamGiaModels, "IdMaGiamGia", "IdMaGiamGia", lichChieuModel.MaGiamGia);
            return View(lichChieuModel);
        }

        // GET: Admin/LichChieuModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Username = username;
            if (id == null)
            {
                return NotFound();
            }

            var lichChieuModel = await _context.lichChieuModels.FindAsync(id);
            if (lichChieuModel == null)
            {
                return NotFound();
            }
            ViewData["MaGiamGia"] = new SelectList(_context.giamGiaModels, "IdMaGiamGia", "IdMaGiamGia", lichChieuModel.MaGiamGia);
            return View(lichChieuModel);
        }

        // POST: Admin/LichChieuModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLichChieu,NgayChieu,GioBatDau,GioKetThuc,GiaVe,MaPhong,MaPhim,MaGiamGia")] LichChieuModel lichChieuModel)
        {
            if (id != lichChieuModel.IdLichChieu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lichChieuModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LichChieuModelExists(lichChieuModel.IdLichChieu))
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
            ViewData["MaGiamGia"] = new SelectList(_context.giamGiaModels, "IdMaGiamGia", "IdMaGiamGia", lichChieuModel.MaGiamGia);
            return View(lichChieuModel);
        }

        // GET: Admin/LichChieuModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.Username = username;
            if (id == null)
            {
                return NotFound();
            }

            var lichChieuModel = await _context.lichChieuModels
                .Include(l => l.giamGia)
                .FirstOrDefaultAsync(m => m.IdLichChieu == id);
            if (lichChieuModel == null)
            {
                return NotFound();
            }

            return View(lichChieuModel);
        }

        // POST: Admin/LichChieuModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lichChieuModel = await _context.lichChieuModels.FindAsync(id);
            _context.lichChieuModels.Remove(lichChieuModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LichChieuModelExists(int id)
        {
            return _context.lichChieuModels.Any(e => e.IdLichChieu == id);
        }
    }
}
