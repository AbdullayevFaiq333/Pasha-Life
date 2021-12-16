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

     
    public class HomeCarouselController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public HomeCarouselController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<HomeCarousel> homeCarousels = await _db.HomeCarousels.ToListAsync();
            return View(homeCarousels);
        }
        #endregion    

        #region Create
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HomeCarousel homeCarousel)
        {
            if (!ModelState.IsValid)
                return NotFound();

            if (homeCarousel.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo cannot be empty");
                return View();
            }
            if (!homeCarousel.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "You must choose only Image");
                return View();
            }
            if (!homeCarousel.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Image size can be 2 MB");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var imgPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, homeCarousel.Photo);
            homeCarousel.Image = fileName;



            await _db.AddRangeAsync(homeCarousel);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");

        }
        #endregion

        #region Update

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            HomeCarousel homeCarousel = await _db.HomeCarousels.FirstOrDefaultAsync(x => x.Id == id);
            if (homeCarousel == null)
                return NotFound();

            return View(homeCarousel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, HomeCarousel homeCarousel)
        {
            if (id != homeCarousel.Id)
                return BadRequest();
            if (id == null)
                return NotFound();
            if (!ModelState.IsValid)
                return NotFound();
            HomeCarousel dBHomeCarousel = await _db.HomeCarousels.FirstOrDefaultAsync(x => x.Id == id);
            if (dBHomeCarousel == null)
                return NotFound();

            if (homeCarousel.Photo != null)
            {
                if (!homeCarousel.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Select photo.");
                    return View();
                }

                if (!homeCarousel.Photo.IsSizeAllowed(2048))
                {
                    ModelState.AddModelError("Photo", "Max size is 2 MB.");
                    return View();
                }

                var path = Path.Combine(_env.WebRootPath, "images", dBHomeCarousel.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }


                var imgPath = Path.Combine(_env.WebRootPath, "images");
                var fileName = await FileUtil.GenerateFileAsync(imgPath, homeCarousel.Photo);
                homeCarousel.Image = fileName;

                dBHomeCarousel.Image = homeCarousel.Image;
            }

           
            dBHomeCarousel.AzTitle = homeCarousel.AzTitle;
            dBHomeCarousel.RuTitle = homeCarousel.RuTitle;
            dBHomeCarousel.EnTitle = homeCarousel.EnTitle;
            dBHomeCarousel.DateTime = homeCarousel.DateTime;
            dBHomeCarousel.URL = homeCarousel.URL;

            


            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var homeCarousels = await _db.HomeCarousels.FindAsync(id);

            if (homeCarousels == null) return NotFound();

            _db.HomeCarousels.Remove(homeCarousels);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion



    }
}
