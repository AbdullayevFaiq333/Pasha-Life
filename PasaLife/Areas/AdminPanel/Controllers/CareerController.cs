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

    public class CareerController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public CareerController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }


        #region Index
        public async Task<IActionResult> Index()
        {
            List<Career> careers = await _db.Careers.ToListAsync();
            return View(careers);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var career = await _db.Careers.FindAsync(id);
            return View(career);
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            Career career = await _db.Careers.FirstOrDefaultAsync(x => x.Id == id);
            if (career == null)
                return NotFound();

            return View(career);
        }                 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Career career, int catId)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            Career dbCareer = await _db.Careers.FirstOrDefaultAsync(x => x.Id == id);
            if (dbCareer == null)
                return NotFound();
            if (career.Photo != null)
            {
                if (!career.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Select photo.");
                    return View();
                }

                if (!career.Photo.IsSizeAllowed(2048))
                {
                    ModelState.AddModelError("Photo", "Max size is 2 MB.");
                    return View();
                }

                var path = Path.Combine(_env.WebRootPath, "images", dbCareer.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }


                var imgPath = Path.Combine(_env.WebRootPath, "images");
                var fileName = await FileUtil.GenerateFileAsync(imgPath, career.Photo);
                career.Image = fileName;

                dbCareer.Image = career.Image;

            }

                
            dbCareer.AzTitle = career.AzTitle;
            dbCareer.EnTitle = career.EnTitle;
            dbCareer.RuTitle = career.RuTitle;
            dbCareer.AzDescription = career.AzDescription;
            dbCareer.EnDescription = career.EnDescription;
            dbCareer.RuDescription = career.RuDescription;


            dbCareer.AzSeoTitle = career.AzSeoTitle;
            dbCareer.EnSeoTitle = career.EnSeoTitle;
            dbCareer.RuSeoTitle = career.RuSeoTitle;
            dbCareer.AzSeoDescription = career.AzSeoDescription;
            dbCareer.EnSeoDescription = career.EnSeoDescription;
            dbCareer.RuSeoDescription = career.RuSeoDescription;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

    
    }
}
