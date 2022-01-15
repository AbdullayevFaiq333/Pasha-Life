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
    public class ProductItem5Controller : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ProductItem5Controller(AppDbContext db, IWebHostEnvironment env)
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

            var productItem5 = await _db.ProductItem5s.FindAsync(id);
            return View(productItem5);
        }
        #endregion 

        #region Create
        public IActionResult Create(int proId)
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int proId, ProductItem5 productItem5)
        {
            if (!ModelState.IsValid)
                return NotFound();

            if (productItem5.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo cannot be empty");
                return View();
            }
            if (!productItem5.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "You must choose only Image");
                return View();
            }
            if (!productItem5.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Image size can be 2 MB");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var imgPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, productItem5.Photo);
            productItem5.Image = fileName;



            productItem5.ProductId = proId;
            await _db.ProductItem5s.AddAsync(productItem5);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
            //await _db.AddRangeAsync(productItem5);

        }
        #endregion

        #region Update

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            ProductItem5 productItem5 = await _db.ProductItem5s.FirstOrDefaultAsync(x => x.Id == id);
            if (productItem5 == null)
                return NotFound();

            return View(productItem5);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, ProductItem5 productItem5)
        {
            if (id != productItem5.Id)
                return BadRequest();
            if (id == null)
                return NotFound();
            if (!ModelState.IsValid)
                return NotFound();
            ProductItem5 dBProductItem5 = await _db.ProductItem5s.FirstOrDefaultAsync(x => x.Id == id);



            if (dBProductItem5 == null)
                return NotFound();

            if (productItem5.Photo != null)
            {
                if (!productItem5.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Select photo.");
                    return View();
                }

                if (!productItem5.Photo.IsSizeAllowed(2048))
                {
                    ModelState.AddModelError("Photo", "Max size is 2 MB.");
                    return View();
                }

                var path = Path.Combine(_env.WebRootPath, "images", dBProductItem5.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }


                var imgPath = Path.Combine(_env.WebRootPath, "images");
                var fileName = await FileUtil.GenerateFileAsync(imgPath, productItem5.Photo);
                productItem5.Image = fileName;

                dBProductItem5.Image = productItem5.Image;

            }

            dBProductItem5.AzTitle = productItem5.AzTitle;
            dBProductItem5.RuTitle = productItem5.RuTitle;
            dBProductItem5.EnTitle = productItem5.EnTitle;

            dBProductItem5.AzDescription = productItem5.AzDescription;
            dBProductItem5.RuDescription = productItem5.RuDescription;
            dBProductItem5.EnDescription = productItem5.EnDescription;

            dBProductItem5.AzDescriptionBox = productItem5.AzDescriptionBox;
            dBProductItem5.RuDescriptionBox = productItem5.RuDescriptionBox;
            dBProductItem5.EnDescriptionBox = productItem5.EnDescriptionBox;

            dBProductItem5.AzInfo = productItem5.AzInfo;
            dBProductItem5.RuInfo = productItem5.RuInfo;
            dBProductItem5.EnInfo = productItem5.EnInfo;

            dBProductItem5.AzSecondTitle = productItem5.AzSecondTitle;
            dBProductItem5.RuSecondTitle = productItem5.RuSecondTitle;
            dBProductItem5.EnSecondTitle = productItem5.EnSecondTitle;

            dBProductItem5.AzSecondDescription = productItem5.AzSecondDescription;
            dBProductItem5.RuSecondDescription = productItem5.RuSecondDescription;
            dBProductItem5.EnSecondDescription = productItem5.EnSecondDescription;

            dBProductItem5.Phone = productItem5.Phone;           

            dBProductItem5.AzPhoneInfo = productItem5.AzPhoneInfo;
            dBProductItem5.RuPhoneInfo = productItem5.RuPhoneInfo;
            dBProductItem5.EnPhoneInfo = productItem5.EnPhoneInfo;




            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion
    }
}

