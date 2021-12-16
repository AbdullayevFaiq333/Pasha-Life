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


    public class NewsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public NewsController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        
        #region Index
        public async Task<IActionResult> Index()
        {
            List<New> news = await _db.News.ToListAsync();
            return View(news);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var neww = await _db.News.Include(x => x.NewsDetail).FirstOrDefaultAsync(x => x.Id == id);
            return View(neww);

        }
        #endregion

        #region Create
        public IActionResult Create(int? infId)
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? infId,New neww)
        {
            if (!ModelState.IsValid)
                return NotFound();

            if (neww.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo cannot be empty");
                return View();
            }
            if (!neww.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "You must choose only Image");
                return View();
            }
            if (!neww.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Image size can be 2 MB");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var imgPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, neww.Photo);
            neww.Image = fileName;



            neww.InformationCenterId = infId;
            await _db.News.AddAsync(neww);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "InformationCenter");


        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            New neww = await _db.News.Include(x => x.NewsDetail)
                                     .FirstOrDefaultAsync(x => x.Id == id);
            if (neww == null)
                return NotFound();


            
            return View(neww);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,  New neww)
        {
            
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            New dbNew = await _db.News.Include(x => x.NewsDetail).
                                       FirstOrDefaultAsync(x => x.Id == id);
            if (dbNew == null)
                return NotFound();

            if (dbNew == null)
                return NotFound();

            if (neww.Photo!=null)
            {

            if (!neww.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Select photo.");
                return View();
            }

            if (!neww.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Max size is 2 MB.");
                return View();
            }

            var path = Path.Combine(_env.WebRootPath, "images", dbNew.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }


            var imgPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, neww.Photo);
            neww.Image = fileName;




            dbNew.Image = neww.Image;
            }




            dbNew.AzTitle = neww.AzTitle;
            dbNew.RuTitle = neww.RuTitle;
            dbNew.EnTitle = neww.EnTitle;
            dbNew.NewsDetail.AzDescription = neww.NewsDetail.AzDescription;
            dbNew.NewsDetail.RuDescription = neww.NewsDetail.RuDescription;
            dbNew.NewsDetail.EnDescription = neww.NewsDetail.EnDescription;
            dbNew.DateTime = neww.DateTime;


            dbNew.AzSeoTitle = neww.AzSeoTitle;
            dbNew.RuSeoTitle = neww.RuSeoTitle;
            dbNew.EnSeoTitle = neww.EnSeoTitle;
            dbNew.NewsDetail.AzSeoDescription = neww.NewsDetail.AzSeoDescription;
            dbNew.NewsDetail.RuSeoDescription = neww.NewsDetail.RuSeoDescription;
            dbNew.NewsDetail.EnSeoDescription = neww.NewsDetail.EnSeoDescription;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "InformationCenter");


        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            New neww = await _db.News.FirstOrDefaultAsync(x => x.Id == id);
            if (neww == null)
                return NotFound();
            neww.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "InformationCenter");

        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            New neww = await _db.News.FirstOrDefaultAsync(x => x.Id == id);
            if (neww == null)
                return NotFound();
            neww.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "InformationCenter");


        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var news = await _db.News.FindAsync(id);

            if (news == null) return NotFound();

            _db.News.Remove(news);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
