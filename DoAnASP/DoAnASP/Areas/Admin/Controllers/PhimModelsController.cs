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
using System.IO;
using Newtonsoft.Json.Linq;
using DoAnASP.Hubs;

namespace DoAnASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhimModelsController : Controller
    {
        private readonly DPContext _context;

        public PhimModelsController(DPContext context)
        {
            _context = context;
        }
        public void updateMessage(string message)
        {
            NotificationHubs.messagesss = message;
        }
        private string username = null;
        // GET: Admin/PhimModels
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.phimModels.Include(s => s.loaiPhim);
            try
            {
                if (HttpContext.Session.GetString("User").ToString() == null)   
                {
                    HttpContext.Session.SetString("User", "Chưa đăng nhập");
                }
                else
                {

                    JObject us = JObject.Parse(HttpContext.Session.GetString("User"));
                    if (bool.Parse(us.SelectToken("LoaiTaiKhoan").ToString()) == true)
                    {
                        username = us.SelectToken("Username").ToString();
                        ViewBag.Username = username;
                        return View(await dPContext.ToListAsync());
                    }  
                }
            }
            catch (Exception e)
            {

                throw new Exception("Chưa Đăng nhập");
            }
            var url = Url.RouteUrl(new { area = "", action = "Index", controller = "Home" });
            return Redirect(url);
        }

        // GET: Admin/PhimModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.Username = username;
            if (id == null)
            {
                return NotFound();
            }

            var phimModel = await _context.phimModels
                .Include(p => p.loaiPhim)
                .FirstOrDefaultAsync(m => m.IdPhim == id);
            if (phimModel == null)
            {
                return NotFound();
            }

            return View(phimModel);
        }

        // GET: Admin/PhimModels/Create
        public IActionResult Create()
        {
            ViewBag.Username = username;
            ViewBag.TypeFilm = _context.loaiPhimModels.ToList();
            return View();
        }

        // POST: Admin/PhimModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPhim,TenPhim,ThoiLuong,HinhAnh,Mota,MaLoaiPhim")] PhimModel phimModel,IFormFile ful)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phimModel);
                await _context.SaveChangesAsync();
                var parth = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageAdmin/ImgPhim", phimModel.IdPhim + "." +
                ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1]);
                using (var stream = new FileStream(parth, FileMode.Create))
                {
                    await ful.CopyToAsync(stream);
                }

                phimModel.HinhAnh = phimModel.IdPhim + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
                _context.Update(phimModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TypeFilm = _context.loaiPhimModels.ToList();
            return View(phimModel);
        }

        // GET: Admin/PhimModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("User"));
            ViewBag.Username = us.SelectToken("Username").ToString();
            if (id == null)
            {
                return NotFound();
            }

            var phimModel = await _context.phimModels.FindAsync(id);
            if (phimModel == null)
            {
                return NotFound();
            }
            ViewData["MaLoaiPhim"] = new SelectList(_context.loaiPhimModels, "IdLoaiPhim", "TenLoaiPhim", phimModel.MaLoaiPhim);
            return View(phimModel);
        }

        // POST: Admin/PhimModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPhim,TenPhim,ThoiLuong,HinhAnh,Mota,MaLoaiPhim")] PhimModel phimModel,IFormFile ful,string hinhanh)
        {
            if (id != phimModel.IdPhim)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var parth = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageAdmin/ImgPhim", hinhanh);
                    System.IO.File.Delete(parth);
                    if (ful == null)
                    {
                        phimModel.HinhAnh = hinhanh;
                    }
                    else
                    {
                        parth = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageAdmin/ImgPhim", phimModel.IdPhim + "." +
                      ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1]);
                        using (var stream = new FileStream(parth, FileMode.Create))
                        {
                            await ful.CopyToAsync(stream);
                        }
                        phimModel.HinhAnh = phimModel.IdPhim + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
                    }
                    _context.Update(phimModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhimModelExists(phimModel.IdPhim))
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
            ViewData["MaLoaiPhim"] = new SelectList(_context.loaiPhimModels, "IdLoaiPhim", "TenLoaiPhim", phimModel.MaLoaiPhim);
            return View(phimModel);
        }

        // GET: Admin/PhimModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.Username = username;
            if (id == null)
            {
                return NotFound();
            }

            var phimModel = await _context.phimModels
                .Include(p => p.loaiPhim)
                .FirstOrDefaultAsync(m => m.IdPhim == id);
            if (phimModel == null)
            {
                return NotFound();
            }

            return View(phimModel);
        }

        // POST: Admin/PhimModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phimModel = await _context.phimModels.FindAsync(id);
            var parth = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageAdmin/ImgPhim", phimModel.HinhAnh);
            FileInfo file = new FileInfo(parth);
            file.Delete();
            _context.phimModels.Remove(phimModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhimModelExists(int id)
        {
            return _context.phimModels.Any(e => e.IdPhim == id);
        }
    }
}
