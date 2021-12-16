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

    public class OnlineServiceController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public OnlineServiceController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        #region Index
        public async Task<IActionResult> Index()
        {
            List<OnlineService> onlineServices = await _db.OnlineServices.Include(x=>x.ITPlatforms).ToListAsync();
            return View(onlineServices);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var onlineService = await _db.OnlineServices.FindAsync(id);
            return View(onlineService);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OnlineService onlineService)
        {
            if (!ModelState.IsValid)
                return NotFound();

           
            if (onlineService.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo cannot be empty");
                return View();
            }

            if (!onlineService.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "You must choose only Image");
                return View();
            }
            if (!onlineService.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Image size can be 2 MB");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var imgPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, onlineService.Photo);
            onlineService.Image = fileName;


            await _db.OnlineServices.AddAsync(onlineService);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            OnlineService onlineService = await _db.OnlineServices.FirstOrDefaultAsync(x => x.Id == id);
            if (onlineService == null)
                return NotFound();

            return View(onlineService);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, string imgCropped, OnlineService onlineService)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            OnlineService dBOnlineService = await _db.OnlineServices.FirstOrDefaultAsync(x => x.Id == id);
            if (dBOnlineService == null)
                return NotFound();

            if (onlineService.Photo!=null)
            {

            if (!onlineService.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Select photo.");
                return View();
            }

            if (!onlineService.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Max size is 2 MB.");
                return View();
            }

            var path = Path.Combine(_env.WebRootPath, "images", dBOnlineService.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }


            var imgPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, onlineService.Photo);
            onlineService.Image = fileName;
            dBOnlineService.Image = onlineService.Image;

            }


            dBOnlineService.URL = onlineService.URL;
            dBOnlineService.AzTitle = onlineService.AzTitle;
            dBOnlineService.RuTitle = onlineService.RuTitle;
            dBOnlineService.EnTitle = onlineService.EnTitle;
            dBOnlineService.AzDescription = onlineService.AzDescription;
            dBOnlineService.RuDescription = onlineService.RuDescription;
            dBOnlineService.EnDescription = onlineService.EnDescription;

            dBOnlineService.AzSeoTitle = onlineService.AzSeoTitle;
            dBOnlineService.RuSeoTitle = onlineService.RuSeoTitle;
            dBOnlineService.EnSeoTitle = onlineService.EnSeoTitle;
            dBOnlineService.AzSeoDescription = onlineService.AzSeoDescription;
            dBOnlineService.RuSeoDescription = onlineService.RuSeoDescription;
            dBOnlineService.EnSeoDescription = onlineService.EnSeoDescription;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Management management = await _db.Managements.FirstOrDefaultAsync(x => x.Id == id);
            if (management == null)
                return NotFound();
            management.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            Management management = await _db.Managements.FirstOrDefaultAsync(x => x.Id == id);
            if (management == null)
                return NotFound();
            management.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var onlineServices = await _db.OnlineServices.FindAsync(id);

            if (onlineServices == null) return NotFound();

            _db.OnlineServices.Remove(onlineServices);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
