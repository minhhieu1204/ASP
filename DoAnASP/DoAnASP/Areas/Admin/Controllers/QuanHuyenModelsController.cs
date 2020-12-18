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
    public class QuanHuyenModelsController : Controller
    {
        private readonly DPContext _context;

        public QuanHuyenModelsController(DPContext context)
        {
            _context = context;
        }
        private string username = null;
        // GET: Admin/QuanHuyenModels
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
            var dPContext = _context.quanHuyenModels.Include(q => q.thanhPho);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/QuanHuyenModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanHuyenModel = await _context.quanHuyenModels
                .Include(q => q.thanhPho)
                .FirstOrDefaultAsync(m => m.IdQuanHuyen == id);
            if (quanHuyenModel == null)
            {
                return NotFound();
            }

            return View(quanHuyenModel);
        }

        // GET: Admin/QuanHuyenModels/Create
        public IActionResult Create()
        {
            ViewBag.Username = username;
            ViewData["MaThanhPho"] = new SelectList(_context.thanhPhoModels, "IdThanhPho", "TenThanhPho");
            return View();
        }

        // POST: Admin/QuanHuyenModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdQuanHuyen,TenQuanHuyen,MaThanhPho")] QuanHuyenModel quanHuyenModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanHuyenModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaThanhPho"] = new SelectList(_context.thanhPhoModels, "IdThanhPho", "TenThanhPho", quanHuyenModel.MaThanhPho);
            return View(quanHuyenModel);
        }

        // GET: Admin/QuanHuyenModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanHuyenModel = await _context.quanHuyenModels.FindAsync(id);
            if (quanHuyenModel == null)
            {
                return NotFound();
            }
            ViewBag.Username = username;
            ViewData["MaThanhPho"] = new SelectList(_context.thanhPhoModels, "IdThanhPho", "TenThanhPho", quanHuyenModel.MaThanhPho);
            return View(quanHuyenModel);
        }

        // POST: Admin/QuanHuyenModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdQuanHuyen,TenQuanHuyen,MaThanhPho")] QuanHuyenModel quanHuyenModel)
        {
            if (id != quanHuyenModel.IdQuanHuyen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanHuyenModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanHuyenModelExists(quanHuyenModel.IdQuanHuyen))
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
            ViewData["MaThanhPho"] = new SelectList(_context.thanhPhoModels, "IdThanhPho", "TenThanhPho", quanHuyenModel.MaThanhPho);
            return View(quanHuyenModel);
        }

        // GET: Admin/QuanHuyenModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.Username = username;
            if (id == null)
            {
                return NotFound();
            }

            var quanHuyenModel = await _context.quanHuyenModels
                .Include(q => q.thanhPho)
                .FirstOrDefaultAsync(m => m.IdQuanHuyen == id);
            if (quanHuyenModel == null)
            {
                return NotFound();
            }

            return View(quanHuyenModel);
        }

        // POST: Admin/QuanHuyenModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quanHuyenModel = await _context.quanHuyenModels.FindAsync(id);
            _context.quanHuyenModels.Remove(quanHuyenModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanHuyenModelExists(int id)
        {
            return _context.quanHuyenModels.Any(e => e.IdQuanHuyen == id);
        }
    }
}
