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
    public class ProductItem3Controller : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ProductItem3Controller(AppDbContext db, IWebHostEnvironment env)
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

            var productItem3 = await _db.ProductItem3s.FindAsync(id);
            return View(productItem3);
        }
        #endregion 

        #region Create
        public IActionResult Create(int proId)
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int proId, ProductItem3 productItem3)
        {
            if (!ModelState.IsValid)
                return NotFound();

            if (productItem3.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo cannot be empty");
                return View();
            }
            if (!productItem3.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "You must choose only Image");
                return View();
            }
            if (!productItem3.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Image size can be 2 MB");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var imgPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, productItem3.Photo);
            productItem3.Image = fileName;



            productItem3.ProductId = proId;
            await _db.ProductItem3s.AddAsync(productItem3);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
            //await _db.AddRangeAsync(ProductItem3);

        }
        #endregion

        #region Update

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            ProductItem3 productItem3 = await _db.ProductItem3s.FirstOrDefaultAsync(x => x.Id == id);
            if (productItem3 == null)
                return NotFound();

            return View(productItem3);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, ProductItem3 productItem3)
        {
            if (id != productItem3.Id)
                return BadRequest();
            if (id == null)
                return NotFound();
            if (!ModelState.IsValid)
                return NotFound();
            ProductItem3 dBProductItem3 = await _db.ProductItem3s.FirstOrDefaultAsync(x => x.Id == id);



            if (dBProductItem3 == null)
                return NotFound();

            if (productItem3.Photo != null)
            {
                if (!productItem3.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Select photo.");
                    return View();
                }

                if (!productItem3.Photo.IsSizeAllowed(2048))
                {
                    ModelState.AddModelError("Photo", "Max size is 2 MB.");
                    return View();
                }

                var path = Path.Combine(_env.WebRootPath, "images", dBProductItem3.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                 
                var imgPath = Path.Combine(_env.WebRootPath, "images");
                var fileName = await FileUtil.GenerateFileAsync(imgPath, productItem3.Photo);
                productItem3.Image = fileName;

                dBProductItem3.Image = productItem3.Image;

            }
            dBProductItem3.AzInfo = productItem3.AzInfo;
            dBProductItem3.RuInfo = productItem3.RuInfo;
            dBProductItem3.EnInfo = productItem3.EnInfo;

            dBProductItem3.AzTitle = productItem3.AzTitle;
            dBProductItem3.RuTitle = productItem3.RuTitle;
            dBProductItem3.EnTitle = productItem3.EnTitle;

            dBProductItem3.AzDescription = productItem3.AzDescription;
            dBProductItem3.RuDescription = productItem3.RuDescription;
            dBProductItem3.EnDescription = productItem3.EnDescription;

            dBProductItem3.AzDescription2 = productItem3.AzDescription2;
            dBProductItem3.RuDescription2 = productItem3.RuDescription2;
            dBProductItem3.EnDescription2 = productItem3.EnDescription2;


            dBProductItem3.AzSecondTitle = productItem3.AzSecondTitle;
            dBProductItem3.RuSecondTitle = productItem3.RuSecondTitle;
            dBProductItem3.EnSecondTitle = productItem3.EnSecondTitle;

            dBProductItem3.AzSecondDescription = productItem3.AzSecondDescription;
            dBProductItem3.RuSecondDescription = productItem3.RuSecondDescription;
            dBProductItem3.EnSecondDescription = productItem3.EnSecondDescription;

            dBProductItem3.AzThirdTitle = productItem3.AzThirdTitle;
            dBProductItem3.RuThirdTitle = productItem3.RuThirdTitle;
            dBProductItem3.EnThirdTitle = productItem3.EnThirdTitle;

            dBProductItem3.AzThirdDescription = productItem3.AzThirdDescription;
            dBProductItem3.RuThirdDescription = productItem3.RuThirdDescription;
            dBProductItem3.EnThirdDescription = productItem3.EnThirdDescription;




            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion
    }
}

