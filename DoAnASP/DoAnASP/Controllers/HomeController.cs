using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DoAnASP.Areas.Admin.Data;
using DoAnASP.Areas.Admin.Models;
using DoAnASP.Commont;
using DoAnASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace DoAnASP.Controllers
{
    public class HomeController : Controller
    {

        static int i = 0;
        private readonly DPContext _context;

        public HomeController(DPContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("User"));
            ViewBag.Username = us.SelectToken("IdUser").ToString();
            var dPContext = _context.phimModels.Include(p => p.loaiPhim);
            return View(await dPContext.ToListAsync());
        }
        public IActionResult Login()
        {
            return View();
        }
        public async  Task<IActionResult> ListFlims()
        {
            var dPContext = _context.phimModels.Include(p => p.loaiPhim);
            return View(await dPContext.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserModel userModel)
        {
            var r = _context.userModels.Where(m => m.Username == userModel.Username && m.Password == StringProcess.CreateMD5Hash(userModel.Password)).ToList();
            if (r.Count == 0)
            {
                return View("Login");
            }
            var str = JsonConvert.SerializeObject(userModel);
            HttpContext.Session.SetString("User", str);
            i++;
            if (r[0].LoaiTaiKhoan == true)
            {
                var url = Url.RouteUrl(new { controller = "PhimModels", action = "Index", area = "Admin" });
                return Redirect(url);
            }
            return RedirectToAction("Index", "Home");
        }
      
      
    }
}
