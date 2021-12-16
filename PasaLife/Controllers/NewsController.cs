using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using PasaLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Controllers
{
    public class NewsController : Controller
    {
        private readonly AppDbContext _db;

        public NewsController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<New> news =await _db.News.Where(x => x.IsDeactive == false).Include(x => x.NewsDetail).ToListAsync();
            return View();
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var newsDetail =await _db.NewsDetails.Include(x => x.New).FirstOrDefaultAsync(z => z.NewId == id);
            
            if (newsDetail == null)
                return NotFound();

            ViewBag.AzSeoTitle = newsDetail.New.AzSeoTitle;
            ViewBag.RuSeoTitle = newsDetail.New.RuSeoTitle;
            ViewBag.EnSeoTitle = newsDetail.New.EnSeoTitle;
            ViewBag.AzSeoDescription = newsDetail.AzSeoDescription;
            ViewBag.RuSeoDescription = newsDetail.RuSeoDescription;
            ViewBag.EnSeoDescription = newsDetail.EnSeoDescription;

            return View(newsDetail);
        }
    }
}
