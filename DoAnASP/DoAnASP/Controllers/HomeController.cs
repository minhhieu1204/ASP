using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DoAnASP.Areas.Admin.Data;
using DoAnASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DoAnASP.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly DPContext _context;

        public HomeController(DPContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var dPContext = _context.phimModels.Include(p => p.loaiPhim);
            return View(await dPContext.ToListAsync());
        }

      
      
    }
}
