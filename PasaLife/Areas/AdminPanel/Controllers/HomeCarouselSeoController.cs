using AdminPanel.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using PasaLife.Helpers;
using PasaLife.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]

    public class HomeCarouselSeoController : Controller
    {
        private readonly AppDbContext _db;
        public HomeCarouselSeoController(AppDbContext db)
        {
            _db = db;
        }


        #region Index
        public async Task<IActionResult> Index()
        {
            List<HomeCarouselSeo> homeCarouselSeos = await _db.HomeCarouselSeos.ToListAsync();
            return View(homeCarouselSeos);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            HomeCarouselSeo homeCarouselSeo = await _db.HomeCarouselSeos.FirstOrDefaultAsync(x => x.Id == id);
            return View(homeCarouselSeo);
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            HomeCarouselSeo homeCarouselSeo = await _db.HomeCarouselSeos.FirstOrDefaultAsync(x => x.Id == id);
            if (homeCarouselSeo == null)
                return NotFound();

            return View(homeCarouselSeo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, HomeCarouselSeo homeCarouselSeo)
        {

            if (id != homeCarouselSeo.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return NotFound();

            if (id == null)
                return NotFound();
            HomeCarouselSeo dbHomeCarouselSeo = await _db.HomeCarouselSeos.FirstOrDefaultAsync(x => x.Id == id);
            if (dbHomeCarouselSeo == null)
                return NotFound();

            dbHomeCarouselSeo.AzSeoTitle = homeCarouselSeo.AzSeoTitle;
            dbHomeCarouselSeo.RuSeoTitle = homeCarouselSeo.RuSeoTitle;
            dbHomeCarouselSeo.EnSeoTitle = homeCarouselSeo.EnSeoTitle;
            




            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion



    }
}
