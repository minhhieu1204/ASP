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
                if (HttpContext.Session.GetString("UserThuong").ToString() == null)
                {
                    HttpContext.Session.SetString("UserThuong", "Chưa đăng nhập");
                }
                else
                {
                    JObject us = JObject.Parse(HttpContext.Session.GetString("UserThuong"));
                    ViewBag.Username = us.SelectToken("Username").ToString();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Chưa Đăng nhập");
            }

            ViewBag.Loginsai = "Bạn nhập sai tài khoản mời nhập lại";
            var dpContext = _context.phimModels.Include(a=>a.loaiPhim);
            return View(await dpContext.ToListAsync());
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return Redirect("Login");
        }
        public async  Task<IActionResult> ListFlims()
        {
            var dPContext = _context.phimModels.Include(p => p.loaiPhim);
            return View(await dPContext.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(int remember, UserModel userModel)
        {
            if (remember == 1)
            {
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Append("username", userModel.Username, cookieOptions);
                Response.Cookies.Append("password", userModel.Password, cookieOptions);
            }
            else
            {
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Append("username", "", cookieOptions);
                Response.Cookies.Append("password", "", cookieOptions);
            }

            var r = _context.userModels.FirstOrDefault(m => m.Username == userModel.Username && m.Password == StringProcess.CreateMD5Hash(userModel.Password));
            if (r==null)
            {
              return  RedirectToAction("Login", "Home");
            }
            var str = JsonConvert.SerializeObject(r);
            if (userModel.Username == null) {
                HttpContext.Session.SetString("Userthuong","");
            }
            else
            {
                HttpContext.Session.SetString("Userthuong", userModel.Username);
            }

            i++;
            if (r.LoaiTaiKhoan == true)
            {
                HttpContext.Session.SetString("User", str);
                var url = Url.RouteUrl(new { controller = "PhimModels", action = "Index", area = "Admin" });
                return Redirect(url);
            }
            HttpContext.Session.SetString("UserThuong", str);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("IdUser,Username,Password,HoTen,NgaySinh,GioiTinh,DiaChi,SDT,LoaiTaiKhoan")] UserModel userModel)
        {
                userModel.Password = StringProcess.CreateMD5Hash(userModel.Password).ToString();
                _context.Add(userModel);
                await _context.SaveChangesAsync();
            if (userModel.Username == null)
            {
                HttpContext.Session.SetString("Userthuong", "");
            }
            else
            {
                HttpContext.Session.SetString("Userthuong", userModel.Username);
            }
            return RedirectToAction(nameof(Index));
           
        }
    }
}
