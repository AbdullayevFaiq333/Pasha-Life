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
    public class ProductItem1Controller : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ProductItem1Controller(AppDbContext db, IWebHostEnvironment env)
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

            var productItem1 = await _db.ProductItem1s.FindAsync(id);
            return View(productItem1);
        }
        #endregion 

        #region Create
        public IActionResult Create(int proId)
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int proId, ProductItem1 productItem1)
        {
            if (!ModelState.IsValid)
                return NotFound();

            if (productItem1.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo cannot be empty");
                return View();
            }
            if (!productItem1.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "You must choose only Image");
                return View();
            }
            if (!productItem1.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Image size can be 2 MB");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var imgPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, productItem1.Photo);
            productItem1.Image = fileName;



            productItem1.ProductId = proId;
            await _db.ProductItem1s.AddAsync(productItem1);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
            //await _db.AddRangeAsync(productItem1);

        }
        #endregion

        #region Update

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            ProductItem1 productItem1 = await _db.ProductItem1s.FirstOrDefaultAsync(x => x.Id == id);
            if (productItem1 == null)
                return NotFound();

            return View(productItem1);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, ProductItem1 productItem1)
        {
            if (id != productItem1.Id)
                return BadRequest();
            if (id == null)
                return NotFound();
            if (!ModelState.IsValid)
                return NotFound();
            ProductItem1 dBProductItem1 = await _db.ProductItem1s.FirstOrDefaultAsync(x => x.Id == id);



            if (dBProductItem1 == null)
                return NotFound();

            if (productItem1.Photo != null)
            {
                if (!productItem1.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Select photo.");
                    return View();
                }

                if (!productItem1.Photo.IsSizeAllowed(2048))
                {
                    ModelState.AddModelError("Photo", "Max size is 2 MB.");
                    return View();
                }

                var path = Path.Combine(_env.WebRootPath, "images", dBProductItem1.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }


                var imgPath = Path.Combine(_env.WebRootPath, "images");
                var fileName = await FileUtil.GenerateFileAsync(imgPath, productItem1.Photo);
                productItem1.Image = fileName;

                dBProductItem1.Image = productItem1.Image;

            }

            dBProductItem1.Name = productItem1.Name;

            dBProductItem1.AzWork = productItem1.AzWork;
            dBProductItem1.RuWork = productItem1.RuWork;
            dBProductItem1.EnWork = productItem1.EnWork;

            dBProductItem1.AzInfo = productItem1.AzInfo;
            dBProductItem1.RuInfo = productItem1.RuInfo;
            dBProductItem1.EnInfo = productItem1.EnInfo;

            dBProductItem1.AzTitle = productItem1.AzTitle;
            dBProductItem1.RuTitle = productItem1.RuTitle;
            dBProductItem1.EnTitle = productItem1.EnTitle;
            
            dBProductItem1.AzDescription = productItem1.AzDescription;
            dBProductItem1.RuDescription = productItem1.RuDescription;
            dBProductItem1.EnDescription = productItem1.EnDescription;

            dBProductItem1.AzDescriptionBox = productItem1.AzDescriptionBox;
            dBProductItem1.RuDescriptionBox = productItem1.RuDescriptionBox;
            dBProductItem1.EnDescriptionBox = productItem1.EnDescriptionBox;

            dBProductItem1.AzEndDescription = productItem1.AzEndDescription;
            dBProductItem1.RuEndDescription = productItem1.RuEndDescription;
            dBProductItem1.EnEndDescription = productItem1.EnEndDescription;





            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion
    }
}
