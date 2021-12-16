using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Controllers
{
    public class AwardController : Controller
    {
        private readonly AppDbContext _db;

        public AwardController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var awards = await _db.Awards.Where(x=>x.IsDeactive==false).ToListAsync();
            var awardSeo = await _db.AwardSeos.FirstOrDefaultAsync();

            

            ViewBag.AzSeoTitle = awardSeo.AzSeoTitle;
            ViewBag.RuSeoTitle = awardSeo.RuSeoTitle;
            ViewBag.EnSeoTitle = awardSeo.EnSeoTitle;
            ViewBag.AzSeoDescription = awardSeo.AzSeoDescription;
            ViewBag.RuSeoDescription = awardSeo.RuSeoDescription;
            ViewBag.EnSeoDescription = awardSeo.EnSeoDescription;

            return View(awards);
        }
    }
}
