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

    public class InformationCenterController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public InformationCenterController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env; 
        }
         
        #region Index
        public async Task<IActionResult> Index()
        {
            List<InformationCenter> informationCenter = await _db.InformationCenters.
                                                              Include(x=>x.Rules).
                                                              Include(x => x.News).
                                                              Include(x => x.FAQs).ToListAsync();
            return View(informationCenter);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var informationCenter = await _db.InformationCenters.FindAsync(id);
            return View(informationCenter);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            //var categories= _db.cate
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( InformationCenter informationCenter,string type)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (informationCenter.Photo == null)
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil seçin !");
                return View();
            }
            if (!informationCenter.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "You must choose only Image");
                return View();
            }
            if (!informationCenter.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Image size can be 2 MB");
                return View();
            }
            var iconSPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(iconSPath, informationCenter.Photo);

            informationCenter.Image = fileName;
            informationCenter.Type = type;

            await _db.InformationCenters.AddAsync(informationCenter);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            InformationCenter informationCenter = await _db.InformationCenters.FirstOrDefaultAsync(x => x.Id == id);
            if (informationCenter == null)
                return NotFound();

            return View(informationCenter);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,  InformationCenter informationCenter)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            InformationCenter dBinformationCenter = await _db.InformationCenters.FirstOrDefaultAsync(x => x.Id == id);
            if (dBinformationCenter == null)
                return NotFound();

            if (informationCenter.Photo!=null)
            {

            if (!informationCenter.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Select photo.");
                return View();
            }

            if (!informationCenter.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Max size is 2 MB.");
                return View();
            }

            var path = Path.Combine(_env.WebRootPath, "images", dBinformationCenter.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }


            var imgPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, informationCenter.Photo);
            informationCenter.Image = fileName;

            dBinformationCenter.Image = informationCenter.Image;

            }





            dBinformationCenter.URL = informationCenter.URL;
            dBinformationCenter.AzTitle = informationCenter.AzTitle;
            dBinformationCenter.RuTitle = informationCenter.RuTitle; 
            dBinformationCenter.EnTitle = informationCenter.EnTitle;
            dBinformationCenter.AzDescription = informationCenter.AzDescription;
            dBinformationCenter.RuDescription = informationCenter.RuDescription;
            dBinformationCenter.EnDescription = informationCenter.EnDescription;

            dBinformationCenter.AzSeoTitle = informationCenter.AzSeoTitle;
            dBinformationCenter.RuSeoTitle = informationCenter.RuSeoTitle;
            dBinformationCenter.EnSeoTitle = informationCenter.EnSeoTitle;
            dBinformationCenter.AzSeoDescription = informationCenter.AzSeoDescription;
            dBinformationCenter.RuSeoDescription = informationCenter.RuSeoDescription;
            dBinformationCenter.EnSeoDescription = informationCenter.EnSeoDescription;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            InformationCenter informationCenter = await _db.InformationCenters.FirstOrDefaultAsync(x => x.Id == id);
            if (informationCenter == null)
                return NotFound();
            informationCenter.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            InformationCenter informationCenter = await _db.InformationCenters.FirstOrDefaultAsync(x => x.Id == id);
            if (informationCenter == null)
                return NotFound();
            informationCenter.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
                return NotFound();

            var ınformationCenter = await _db.InformationCenters.FindAsync(id); 

            if (ınformationCenter == null)
                return NotFound();



            var fAQ = await _db.FAQs.Where(x => x.InformationCenterId == id).ToListAsync();
            _db.RemoveRange(fAQ);

            var rule = await _db.Rules.Where(x => x.InformationCenterId == id).ToListAsync();
            _db.RemoveRange(rule);

            var news = await _db.News.Where(x => x.InformationCenterId == id).ToListAsync();
            _db.RemoveRange(news);




            _db.InformationCenters.Remove(ınformationCenter);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
