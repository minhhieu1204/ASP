using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnASP.Areas.Admin.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnASP.Controllers
{
    public class SingleController : Controller
    {
        private readonly DPContext _context;

        public SingleController(DPContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
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
        
    }
}
