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

    public class AwardController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public AwardController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
         
        #region Index
        public async Task<IActionResult> Index()
        {
            List<Award> awards = await _db.Awards.ToListAsync();
            return View(awards);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var award = await _db.Awards.FindAsync(id);
            return View(award);
        }
        #endregion 

        #region Create
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Award award)
        {
            if (!ModelState.IsValid)
                return NotFound();

            if (award.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo cannot be empty");
                return View();
            }
            if (!award.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "You must choose only Image");
                return View();
            }
            if (!award.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Image size can be 2 MB");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var imgPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, award.Photo);
            award.Image = fileName;





            await _db.AddRangeAsync(award);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");

        }
        #endregion

        #region Update

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            Award award = await _db.Awards.FirstOrDefaultAsync(x => x.Id == id);
            if (award == null)
                return NotFound();

            return View(award);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Award award)
        {
            if (id != award.Id)
                return BadRequest();         
            if (id == null)
                return NotFound();
            if (!ModelState.IsValid)
                return NotFound();
            Award dBaward = await _db.Awards.FirstOrDefaultAsync(x => x.Id == id);



            if (dBaward == null)
                return NotFound();

            if (award.Photo != null)
            {
                if (!award.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Select photo.");
                    return View();
                }

                if (!award.Photo.IsSizeAllowed(2048))
                {
                    ModelState.AddModelError("Photo", "Max size is 2 MB.");
                    return View();
                }

                var path = Path.Combine(_env.WebRootPath, "images", dBaward.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }


                var imgPath = Path.Combine(_env.WebRootPath, "images");
                var fileName = await FileUtil.GenerateFileAsync(imgPath, award.Photo);
                award.Image = fileName;

                dBaward.Image = award.Image;

            }

            dBaward.AzTitle = award.AzTitle;
            dBaward.RuTitle = award.RuTitle;
            dBaward.EnTitle = award.EnTitle;
            dBaward.AzDescription = award.AzDescription;
            dBaward.RuDescription = award.RuDescription;
            dBaward.EnDescription = award.EnDescription;




            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Award award = await _db.Awards.FirstOrDefaultAsync(x => x.Id == id);
            if (award == null)
                return NotFound();
            award.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            Award award = await _db.Awards.FirstOrDefaultAsync(x => x.Id == id);
            if (award == null)
                return NotFound();
            award.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var award = await _db.Awards.FindAsync(id);

            if (award == null) return NotFound();

            _db.Awards.Remove(award);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
    
    

