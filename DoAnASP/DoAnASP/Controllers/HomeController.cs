using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DoAnASP.Areas.Admin.Data;
using DoAnASP.Areas.Admin.Models;
using DoAnASP.Commont;
using DoAnASP.Hubs;
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

        public void updateMessage(string message)
        {
            NotificationHubs.messagesss = message;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.PhimCuoi = _context.phimModels;
            try
            {
                if (HttpContext.Session.GetString("User").ToString() == null)
                {
                    HttpContext.Session.SetString("User", "Chưa đăng nhập");
                }
                else
                {
                    JObject us = JObject.Parse(HttpContext.Session.GetString("User"));
                    ViewBag.Username = us.SelectToken("Username").ToString();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Chưa Đăng nhập");
            }

            ViewBag.Loginsai = "Bạn nhập sai tài khoản mời nhập lại";
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
            var r = _context.userModels.FirstOrDefault(m => m.Username == userModel.Username && m.Password == StringProcess.CreateMD5Hash(userModel.Password));
            if (r==null)
            {
              return  RedirectToAction("Login", "Home");
            }
            var str = JsonConvert.SerializeObject(r);
            HttpContext.Session.SetString("User", str);
            i++;
            if (r.LoaiTaiKhoan == true)
            {
                var url = Url.RouteUrl(new { controller = "PhimModels", action = "Index", area = "Admin" });
                return Redirect(url);
            }
            return RedirectToAction("Index", "Home");
        }
      
      
    }
}
