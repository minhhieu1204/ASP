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
    public class UserModelsController : Controller
    {
        private readonly DPContext _context;

        public UserModelsController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/UserModels
        public async Task<IActionResult> Index()
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("User"));
            ViewBag.Username = us.SelectToken("Username").ToString();
            return View(await _context.userModels.ToListAsync());
        }

        // GET: Admin/UserModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("User"));
            ViewBag.Username = us.SelectToken("Username").ToString();
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.userModels
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // GET: Admin/UserModels/Create
        public IActionResult Create()
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("User"));
            ViewBag.Username = us.SelectToken("Username").ToString();
            return View();
        }

        // POST: Admin/UserModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,Username,Password,HoTen,NgaySinh,GioiTinh,DiaChi,SDT,LoaiTaiKhoan")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                userModel.Password = StringProcess.CreateMD5Hash(userModel.Password).ToString();
                _context.Add(userModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: Admin/UserModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("User"));
            ViewBag.Username = us.SelectToken("Username").ToString();
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.userModels.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            return View(userModel);
        }

        // POST: Admin/UserModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,Username,Password,HoTen,NgaySinh,GioiTinh,DiaChi,SDT,LoaiTaiKhoan")] UserModel userModel)
        {
            if (id != userModel.IdUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(userModel.IdUser))
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
            return View(userModel);
        }

        // GET: Admin/UserModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("User"));
            ViewBag.Username = us.SelectToken("Username").ToString();
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.userModels
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // POST: Admin/UserModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userModel = await _context.userModels.FindAsync(id);
            _context.userModels.Remove(userModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelExists(int id)
        {
            return _context.userModels.Any(e => e.IdUser == id);
        }
    }
}
