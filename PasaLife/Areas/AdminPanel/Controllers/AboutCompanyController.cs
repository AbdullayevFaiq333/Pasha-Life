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

    public class AboutCompanyController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public AboutCompanyController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }


        #region Index
        public async Task<IActionResult> Index()
        {
            List<AboutCompany> aboutCompanies = await _db.AboutCompanies.ToListAsync();
            return View(aboutCompanies);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            AboutCompany aboutCompany = await _db.AboutCompanies.FindAsync(id);
            return View(aboutCompany);
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            AboutCompany aboutCompany = await _db.AboutCompanies.FirstOrDefaultAsync(x => x.Id == id);
            if (aboutCompany == null)
                return NotFound();

            return View(aboutCompany);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, AboutCompany aboutCompany)
        {
            
            if (id != aboutCompany.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return NotFound();

            if (id == null)
                return NotFound();
            AboutCompany dbAboutCompany = await _db.AboutCompanies.FirstOrDefaultAsync(x => x.Id == id); 
            if (dbAboutCompany == null)
                return NotFound();



            if (aboutCompany.Photo != null)
            {
                if (!aboutCompany.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Select photo.");
                    return View();
                }

                if (!aboutCompany.Photo.IsSizeAllowed(2048))
                {
                    ModelState.AddModelError("Photo", "Max size is 2 MB.");
                    return View();
                }

                var path = Path.Combine(_env.WebRootPath, "images", dbAboutCompany.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }


                var imgPath = Path.Combine(_env.WebRootPath, "images");
                var fileName = await FileUtil.GenerateFileAsync(imgPath, aboutCompany.Photo);
                aboutCompany.Image = fileName;

                dbAboutCompany.Image = aboutCompany.Image;
            }



            dbAboutCompany.AzTitle = aboutCompany.AzTitle;
            dbAboutCompany.RuTitle = aboutCompany.RuTitle;
            dbAboutCompany.EnTitle = aboutCompany.EnTitle;
            dbAboutCompany.AzDescription = aboutCompany.AzDescription;
            dbAboutCompany.RuDescription = aboutCompany.RuDescription;
            dbAboutCompany.EnDescription = aboutCompany.EnDescription;

            dbAboutCompany.AzSeoTitle = aboutCompany.AzSeoTitle;
            dbAboutCompany.RuSeoTitle = aboutCompany.RuSeoTitle;
            dbAboutCompany.EnSeoTitle = aboutCompany.EnSeoTitle;
            dbAboutCompany.AzSeoDescription = aboutCompany.AzSeoDescription;
            dbAboutCompany.RuSeoDescription = aboutCompany.RuSeoDescription;
            dbAboutCompany.EnSeoDescription = aboutCompany.EnSeoDescription;


            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion



    }
}
