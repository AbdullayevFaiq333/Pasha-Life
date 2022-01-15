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
    public class ProductItem4Controller : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ProductItem4Controller(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        #region Index
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Product");
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var productItem4 = await _db.ProductItem4s.FindAsync(id);
            return View(productItem4);
        }
        #endregion 

        #region Create
        public IActionResult Create(int proId)
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int proId, ProductItem4 productItem4)
        {
            if (!ModelState.IsValid)
                return NotFound();

            if (productItem4.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo cannot be empty");
                return View();
            }
            if (!productItem4.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "You must choose only Image");
                return View();
            }
            if (!productItem4.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Image size can be 2 MB");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var imgPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, productItem4.Photo);
            productItem4.Image = fileName;



            productItem4.ProductId = proId;
            await _db.ProductItem4s.AddAsync(productItem4);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
            //await _db.AddRangeAsync(productItem4);

        }
        #endregion

        #region Update

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            ProductItem4 productItem4 = await _db.ProductItem4s.FirstOrDefaultAsync(x => x.Id == id);
            if (productItem4 == null)
                return NotFound();

            return View(productItem4);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, ProductItem4 productItem4)
        {
            if (id != productItem4.Id)
                return BadRequest();
            if (id == null)
                return NotFound();
            if (!ModelState.IsValid)
                return NotFound();
            ProductItem4 dBProductItem4 = await _db.ProductItem4s.FirstOrDefaultAsync(x => x.Id == id);



            if (dBProductItem4 == null)
                return NotFound();

            if (productItem4.Photo != null)
            {
                if (!productItem4.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Select photo.");
                    return View();
                }

                if (!productItem4.Photo.IsSizeAllowed(2048))
                {
                    ModelState.AddModelError("Photo", "Max size is 2 MB.");
                    return View();
                }

                var path = Path.Combine(_env.WebRootPath, "images", dBProductItem4.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }


                var imgPath = Path.Combine(_env.WebRootPath, "images");
                var fileName = await FileUtil.GenerateFileAsync(imgPath, productItem4.Photo);
                productItem4.Image = fileName;

                dBProductItem4.Image = productItem4.Image;

            }

            dBProductItem4.Phone = productItem4.Phone;

            dBProductItem4.AzInfo = productItem4.AzInfo;
            dBProductItem4.RuInfo = productItem4.RuInfo;
            dBProductItem4.EnInfo = productItem4.EnInfo;

            dBProductItem4.AzTitle = productItem4.AzTitle;
            dBProductItem4.RuTitle = productItem4.RuTitle;
            dBProductItem4.EnTitle = productItem4.EnTitle;

            dBProductItem4.AzPhoneInfo = productItem4.AzPhoneInfo;
            dBProductItem4.RuPhoneInfo = productItem4.RuPhoneInfo;
            dBProductItem4.EnPhoneInfo = productItem4.EnPhoneInfo;

            dBProductItem4.AzDescription = productItem4.AzDescription;
            dBProductItem4.RuDescription = productItem4.RuDescription;
            dBProductItem4.EnDescription = productItem4.EnDescription;

            dBProductItem4.AzDescriptionBox = productItem4.AzDescriptionBox;
            dBProductItem4.RuDescriptionBox = productItem4.RuDescriptionBox;
            dBProductItem4.EnDescriptionBox = productItem4.EnDescriptionBox;


            





            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion
    }
}


