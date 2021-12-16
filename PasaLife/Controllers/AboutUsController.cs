using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly AppDbContext _db;

        public AboutUsController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            

            var about = await _db.Abouts.FirstOrDefaultAsync();

            ViewBag.AzSeoTitle = about.AzSeoTitle;
            ViewBag.RuSeoTitle = about.RuSeoTitle;
            ViewBag.EnSeoTitle = about.EnSeoTitle;
            ViewBag.AzSeoDescription = about.AzSeoDescription;
            ViewBag.RuSeoDescription = about.RuSeoDescription;
            ViewBag.EnSeoDescription = about.EnSeoDescription;

            return View(about);
        }
    }
}
