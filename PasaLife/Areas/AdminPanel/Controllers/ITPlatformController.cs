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


    public class ITPlatformController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ITPlatformController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<ITPlatform> iTPlatforms = await _db.ITPlatforms.ToListAsync();
            return View(iTPlatforms);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var iTPlatform = await _db.ITPlatforms.FindAsync(id);
            return View(iTPlatform);
        }
        #endregion

        #region Create
        public IActionResult Create(int onlId)
        {
            ViewBag.onlId = onlId;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int onlId, ITPlatform iTPlatform)
        {
            if (!ModelState.IsValid)
                return NotFound();

            if (iTPlatform.Photo == null)
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil seçin !");
                return View();
            }

            if (!iTPlatform.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "You must choose only Image");
                return View();
            }
            if (!iTPlatform.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Image size can be 2 MB");
                return View();
            }
            var path = Path.Combine(_env.WebRootPath, "style", "img");
            var fileName = await FileUtil.GenerateFileAsync(path, iTPlatform.Photo);
            iTPlatform.Image = fileName;


            iTPlatform.OnlineServiceId = onlId;
            await _db.ITPlatforms.AddAsync(iTPlatform);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index","onlineservice");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            ITPlatform iTPlatform = await _db.ITPlatforms.FirstOrDefaultAsync(x => x.Id == id);
            if (iTPlatform == null)
                return NotFound();

            return View(iTPlatform);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,  ITPlatform iTPlatform)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            ITPlatform dBiTPlatform = await _db.ITPlatforms.FirstOrDefaultAsync(x => x.Id == id);
            if (dBiTPlatform == null)
                return NotFound();

            if (iTPlatform.Photo!=null)
            {

            if (!iTPlatform.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Select photo.");
                return View();
            }

            if (!iTPlatform.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Max size is 2 MB.");
                return View();
            }
            var path = Path.Combine(_env.WebRootPath, "style", "img", dBiTPlatform.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            var imgPath = Path.Combine(_env.WebRootPath, "style", "img");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, iTPlatform.Photo);
            iTPlatform.Image = fileName;
            dBiTPlatform.Image = iTPlatform.Image;
            }


            dBiTPlatform.URL = iTPlatform.URL;
            dBiTPlatform.AzTitle = iTPlatform.AzTitle;
            dBiTPlatform.RuTitle = iTPlatform.RuTitle;
            dBiTPlatform.EnTitle = iTPlatform.EnTitle;
            dBiTPlatform.AzDescription = iTPlatform.AzDescription;
            dBiTPlatform.RuDescription = iTPlatform.RuDescription;
            dBiTPlatform.EnDescription = iTPlatform.EnDescription;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "onlineservice");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            ITPlatform iTPlatform = await _db.ITPlatforms.FirstOrDefaultAsync(x => x.Id == id);
            if (iTPlatform == null)
                return NotFound();
            iTPlatform.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            ITPlatform iTPlatform = await _db.ITPlatforms.FirstOrDefaultAsync(x => x.Id == id);
            if (iTPlatform == null)
                return NotFound();
            iTPlatform.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var iTPlatforms = await _db.ITPlatforms.FindAsync(id);

            if (iTPlatforms == null) return NotFound();

            _db.ITPlatforms.Remove(iTPlatforms);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
