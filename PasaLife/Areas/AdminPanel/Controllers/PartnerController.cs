using AdminPanel;
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

    public class PartnerController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public PartnerController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        #region Index
        public IActionResult Index()
        {
            var partners = _db.Partners.ToList();
            return View(partners);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            Partner partner = await _db.Partners.FindAsync(id);
            return View(partner);
        }
        #endregion

        #region Create
        public IActionResult Create(int? proId)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? proId, Partner partner)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (partner.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo cannot be empty");
                return View();
            }
            if (!partner.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "You must choose only Image");
                return View();
            }
            if (!partner.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Image size can be 2 MB");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var imgPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, partner.Photo);
            partner.Image = fileName;



            partner.ProductId =  proId;
            await _db.Partners.AddAsync(partner);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            Partner partner = await _db.Partners.FirstOrDefaultAsync(x => x.Id == id);
            if (partner == null)
                return NotFound();

            return View(partner);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Partner partner)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            Partner dBPartner = await _db.Partners.FirstOrDefaultAsync(x => x.Id == id);
            if (dBPartner == null)
                return NotFound();


            if (partner.Photo!=null)
            {

            if (!partner.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Select photo.");
                return View();
            }

            if (!partner.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Max size is 2 MB.");
                return View();
            }

            var path = Path.Combine(_env.WebRootPath, "images", dBPartner.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }


            var imgPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, partner.Photo);
            partner.Image = fileName;
            }

            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Partner partner = await _db.Partners.FirstOrDefaultAsync(x => x.Id == id);
            if (partner == null)
                return NotFound();
            partner.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            Partner partner = await _db.Partners.FirstOrDefaultAsync(x => x.Id == id);
            if (partner == null)
                return NotFound();
            partner.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var partners = await _db.Partners.FindAsync(id);

            if (partners == null) return NotFound();

            _db.Partners.Remove(partners);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }
        #endregion





    }
}
