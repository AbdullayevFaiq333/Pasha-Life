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
    public class ManagementController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ManagementController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<Management> managements = await _db.Managements.ToListAsync();
            return View(managements);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var management = await _db.Managements.Include(x => x.ManagementDetail).FirstOrDefaultAsync(x => x.Id == id);
            return View(management);

        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            ViewBag.Categories = _db.ManagementCategories.Where(x => !x.IsDeactive);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Management management, int? catId)
        {
            ViewBag.Categories = _db.ManagementCategories.Where(x => !x.IsDeactive);
            if (!ModelState.IsValid)
                return NotFound();
            if (management.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo cannot be empty");
                return View();
            }
            if (!management.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "You must choose only Image");
                return View();
            }
            if (!management.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Image size can be 2 MB");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var imgPath = Path.Combine(_env.WebRootPath, "images", "persons");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, management.Photo);
            management.Image = fileName;
            
            
            if (catId != 0)
            {
                management.ManagementCategoryId = (int)catId;

            }
            await _db.Managements.AddAsync(management);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            Management management = await _db.Managements.
                                          Include(x => x.ManagementDetail).
                                          FirstOrDefaultAsync(x => x.Id == id);
            if (management == null)
                return NotFound();
     

            ViewBag.Categories = _db.ManagementCategories.Where(x => !x.IsDeactive);
            return View(management);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,   Management management,int? catId)
        {
            ViewBag.Categories = _db.ManagementCategories.Where(x => !x.IsDeactive);
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            if (catId == null)
            {
                ModelState.AddModelError("", "Zəhmət olmasa kateqoriyanı qeyd edin");
                return View();
            }
            Management dbManagement = await _db.Managements.
                                         Include(x => x.ManagementDetail).
                                         FirstOrDefaultAsync(x => x.Id == id);
            if (dbManagement == null)
                return NotFound();

            if (management.Photo!=null)
            {

            if (!management.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Select photo.");
                return View();
            }

            if (!management.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Max size is 2 MB.");
                return View();
            }
            var path = Path.Combine(_env.WebRootPath, "images", dbManagement.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }


            var imgPath = Path.Combine(_env.WebRootPath, "images", "persons");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, management.Photo);
            management.Image = fileName;

            dbManagement.Image = management.Image;
            }



            dbManagement.AzFullName = management.AzFullName;
            dbManagement.RuFullName = management.RuFullName;
            dbManagement.EnFullName = management.EnFullName;
            dbManagement.AzPosition = management.AzPosition;
            dbManagement.RuPosition = management.RuPosition;
            dbManagement.EnPosition = management.EnPosition;
            dbManagement.ManagementDetail.AzDescription = management.ManagementDetail.AzDescription;
            dbManagement.ManagementDetail.RuDescription = management.ManagementDetail.RuDescription;
            dbManagement.ManagementDetail.EnDescription = management.ManagementDetail.EnDescription;

            dbManagement.AzFullName = management.AzFullName;
            dbManagement.RuFullName = management.RuFullName;
            dbManagement.EnFullName = management.EnFullName;
            dbManagement.ManagementDetail.AzDescription = management.ManagementDetail.AzDescription;
            dbManagement.ManagementDetail.RuDescription = management.ManagementDetail.RuDescription;
            dbManagement.ManagementDetail.EnDescription = management.ManagementDetail.EnDescription;


            dbManagement.AzSeoTitle = management.AzSeoTitle;
            dbManagement.RuSeoTitle = management.RuSeoTitle;
            dbManagement.EnSeoTitle = management.EnSeoTitle;
            dbManagement.ManagementDetail.AzSeoDescription = management.ManagementDetail.AzSeoDescription;
            dbManagement.ManagementDetail.RuSeoDescription = management.ManagementDetail.RuSeoDescription;
            dbManagement.ManagementDetail.EnSeoDescription = management.ManagementDetail.EnSeoDescription;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Management management = await _db.Managements.
                                          Include(x => x.ManagementDetail).
                                         FirstOrDefaultAsync(x => x.Id == id);

            
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
            Management management = await _db.Managements.
                                            Include(x => x.ManagementDetail).
                                           FirstOrDefaultAsync(x => x.Id == id);
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

            var managements = await _db.Managements.FindAsync(id);

            if (managements == null) return NotFound();

            _db.Managements.Remove(managements);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion


    }
}
