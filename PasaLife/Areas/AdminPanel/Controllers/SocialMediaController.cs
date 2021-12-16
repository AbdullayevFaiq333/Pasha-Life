using AdminPanel.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
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

    public class SocialMediaController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public SocialMediaController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<SocialMedia> socialMedias = await _db.SocialMedias.ToListAsync();
            return View(socialMedias);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SocialMedia socialMedia)
        {

            if (!ModelState.IsValid)
                return NotFound();
            
            if (socialMedia.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo cannot be empty");
                return View();
            }
            if (!socialMedia.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "You must choose only Image");
                return View();
            }
            if (!socialMedia.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Image size can be 2 MB");
                return View();
            }

            

            var iconSPath = Path.Combine(_env.WebRootPath, "style", "img");
            var fileName = await FileUtil.GenerateFileAsync(iconSPath, socialMedia.Photo);
            socialMedia.Icon = fileName;



            await _db.AddRangeAsync(socialMedia);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            SocialMedia socialMedia = await _db.SocialMedias.FirstOrDefaultAsync(x => x.Id == id);
            if (socialMedia == null)
                return NotFound();
            return View(socialMedia);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            SocialMedia dbSocialMedia = await _db.SocialMedias.FirstOrDefaultAsync(x => x.Id == id);
            if (dbSocialMedia == null)
                return NotFound();
           

              if (socialMedia.Photo != null)
            {
                


                if (!socialMedia.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Select photo.");
                    return View();
                }

                if (!socialMedia.Photo.IsSizeAllowed(2048))
                {
                    ModelState.AddModelError("Photo", "Max size is 2 MB.");
                    return View();
                }
                var path = Path.Combine(_env.WebRootPath,"style","img", dbSocialMedia.Icon);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                var iconSPath = Path.Combine(_env.WebRootPath, "style", "img");
                var fileName = await FileUtil.GenerateFileAsync(iconSPath, socialMedia.Photo);
                dbSocialMedia.Icon = fileName;
                dbSocialMedia.Icon = socialMedia.Icon;
            }

            dbSocialMedia.Url = socialMedia.Url;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            SocialMedia socialMedia = await _db.SocialMedias.FirstOrDefaultAsync(x => x.Id == id);
            if (socialMedia == null)
                return NotFound();
            socialMedia.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            SocialMedia socialMedia = await _db.SocialMedias.FirstOrDefaultAsync(x => x.Id == id);
            if (socialMedia == null)
                return NotFound();
            socialMedia.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var socialMedias = await _db.SocialMedias.FindAsync(id);

            if (socialMedias == null) return NotFound();

            _db.SocialMedias.Remove(socialMedias);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
