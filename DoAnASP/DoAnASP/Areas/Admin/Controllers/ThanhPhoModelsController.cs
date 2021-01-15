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
    public class ThanhPhoModelsController : Controller
    {
        private readonly DPContext _context;

        public ThanhPhoModelsController(DPContext context)
        {
            _context = context;
        }
        private string username = null;
        // GET: Admin/ThanhPhoModels
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
            return View(await _context.thanhPhoModels.ToListAsync());
        }

        // GET: Admin/ThanhPhoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhPhoModel = await _context.thanhPhoModels
                .FirstOrDefaultAsync(m => m.IdThanhPho == id);
            if (thanhPhoModel == null)
            {
                return NotFound();
            }

            return View(thanhPhoModel);
        }

        // GET: Admin/ThanhPhoModels/Create
        public IActionResult Create()
        {
            ViewBag.Username = username;
            return View();
        }

        // POST: Admin/ThanhPhoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThanhPho,TenThanhPho")] ThanhPhoModel thanhPhoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thanhPhoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thanhPhoModel);
        }

        // GET: Admin/ThanhPhoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Username = username;
            if (id == null)
            {
                return NotFound();
            }

            var thanhPhoModel = await _context.thanhPhoModels.FindAsync(id);
            if (thanhPhoModel == null)
            {
                return NotFound();
            }
            return View(thanhPhoModel);
        }

        // POST: Admin/ThanhPhoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThanhPho,TenThanhPho")] ThanhPhoModel thanhPhoModel)
        {
            if (id != thanhPhoModel.IdThanhPho)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thanhPhoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThanhPhoModelExists(thanhPhoModel.IdThanhPho))
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
            return View(thanhPhoModel);
        }

        // GET: Admin/ThanhPhoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.Username = username;
            if (id == null)
            {
                return NotFound();
            }

            var thanhPhoModel = await _context.thanhPhoModels
                .FirstOrDefaultAsync(m => m.IdThanhPho == id);
            if (thanhPhoModel == null)
            {
                return NotFound();
            }

            return View(thanhPhoModel);
        }

        // POST: Admin/ThanhPhoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thanhPhoModel = await _context.thanhPhoModels.FindAsync(id);
            _context.thanhPhoModels.Remove(thanhPhoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThanhPhoModelExists(int id)
        {
            return _context.thanhPhoModels.Any(e => e.IdThanhPho == id);
        }
    }
}
