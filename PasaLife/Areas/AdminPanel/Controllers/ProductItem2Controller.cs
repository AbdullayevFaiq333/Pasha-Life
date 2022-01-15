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
    public class ProductItem2Controller : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ProductItem2Controller(AppDbContext db, IWebHostEnvironment env)
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

            var productItem2 = await _db.ProductItem2s.FindAsync(id);
            return View(productItem2);
        }
        #endregion 

        #region Create
        public IActionResult Create(int proId)
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int proId, ProductItem2 productItem2)
        {
            if (!ModelState.IsValid)
                return NotFound();

            if (productItem2.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo cannot be empty");
                return View();
            }
            if (!productItem2.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "You must choose only Image");
                return View();
            }
            if (!productItem2.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Image size can be 2 MB");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }



            if (productItem2.FirstBoxPhoto == null)
            {
                ModelState.AddModelError("Icon", "Photo cannot be empty");
                return View();
            }
            if (!productItem2.FirstBoxPhoto.IsImage())
            {
                ModelState.AddModelError("Icon", "You must choose only Image");
                return View();
            }
            if (!productItem2.FirstBoxPhoto.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Icon", "Image size can be 2 MB");
                return View();
            }

            if (productItem2.SecondBoxPhoto == null)
            {
                ModelState.AddModelError("Icon", "Photo cannot be empty");
                return View();
            }
            if (!productItem2.SecondBoxPhoto.IsImage())
            {
                ModelState.AddModelError("Icon", "You must choose only Image");
                return View();
            }
            if (!productItem2.SecondBoxPhoto.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Icon", "Image size can be 2 MB");
                return View();
            }



            var imgPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(imgPath, productItem2.Photo);
            var fileNameIcon = await FileUtil.GenerateFileAsync(imgPath, productItem2.FirstBoxPhoto);
            var fileNameIconSecond = await FileUtil.GenerateFileAsync(imgPath, productItem2.SecondBoxPhoto);


            productItem2.Image = fileName;
            productItem2.FirstBoxIcon = fileNameIcon;
            productItem2.SecondBoxIcon = fileNameIconSecond;
           



            productItem2.ProductId = proId;
            await _db.ProductItem2s.AddAsync(productItem2);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
            //await _db.AddRangeAsync(ProductItem2);

        }
        #endregion

        #region Update

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            ProductItem2 productItem2 = await _db.ProductItem2s.FirstOrDefaultAsync(x => x.Id == id);
            if (productItem2 == null)
                return NotFound();

            return View(productItem2);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, ProductItem2 productItem2)
        {
            if (id != productItem2.Id)
                return BadRequest();
            if (id == null)
                return NotFound();
            if (!ModelState.IsValid)
                return NotFound();
            ProductItem2 dBProductItem2 = await _db.ProductItem2s.FirstOrDefaultAsync(x => x.Id == id);



            if (dBProductItem2 == null)
                return NotFound();

           
                if (productItem2.Photo != null)
                {
                    if (productItem2.Photo == null)
                    {
                        ModelState.AddModelError("Photo", "Photo cannot be empty");
                        return View();
                    }
                    if (!productItem2.Photo.IsImage())
                    {
                        ModelState.AddModelError("Photo", "You must choose only Image");
                        return View();
                    }
                    if (!productItem2.Photo.IsSizeAllowed(2048))
                    {
                        ModelState.AddModelError("Photo", "Image size can be 2 MB");
                        return View();
                    }

                    if (!ModelState.IsValid)
                    {
                        return View();
                    }

                   
                        //if (productItem2.FirstBoxPhoto == null)
                        //{
                        //    ModelState.AddModelError("Icon", "Photo cannot be empty");
                        //    return View();
                        //}
                        //if (!productItem2.FirstBoxPhoto.IsImage())
                        //{
                        //    ModelState.AddModelError("Icon", "You must choose only Image");
                        //    return View();
                        //}
                        //if (!productItem2.FirstBoxPhoto.IsSizeAllowed(2048))
                        //{
                        //    ModelState.AddModelError("Icon", "Image size can be 2 MB");
                        //    return View();
                        //}

                    

                    
                        //if (productItem2.SecondBoxPhoto == null)
                        //{
                        //    ModelState.AddModelError("Icon", "Photo cannot be empty");
                        //    return View();
                        //}
                        //if (!productItem2.SecondBoxPhoto.IsImage())
                        //{
                        //    ModelState.AddModelError("Icon", "You must choose only Image");
                        //    return View();
                        //}
                        //if (!productItem2.SecondBoxPhoto.IsSizeAllowed(2048))
                        //{
                        //    ModelState.AddModelError("Icon", "Image size can be 2 MB");
                        //    return View();
                        //}
                    



                    var imgPath = Path.Combine(_env.WebRootPath, "images");
                    var fileName = await FileUtil.GenerateFileAsync(imgPath, productItem2.Photo);
                    //var fileNameIconSecond = await FileUtil.GenerateFileAsync(imgPath, productItem2.SecondBoxPhoto);
                    //var fileNameIcon = await FileUtil.GenerateFileAsync(imgPath, productItem2.FirstBoxPhoto);

                    productItem2.Image = fileName;
                    //productItem2.FirstBoxIcon = fileNameIcon;
                    //productItem2.SecondBoxIcon = fileNameIconSecond;

                    dBProductItem2.Image = productItem2.Image;
                    //dBProductItem2.FirstBoxIcon = productItem2.FirstBoxIcon;
                    //dBProductItem2.SecondBoxIcon = productItem2.SecondBoxIcon;


                }
                else if(productItem2.FirstBoxPhoto != null)
                {
                        if (productItem2.FirstBoxPhoto == null)
                        {
                            ModelState.AddModelError("Icon", "Photo cannot be empty");
                            return View();
                        }
                        if (!productItem2.FirstBoxPhoto.IsImage())
                        {
                            ModelState.AddModelError("Icon", "You must choose only Image");
                            return View();
                        }
                        if (!productItem2.FirstBoxPhoto.IsSizeAllowed(2048))
                        {
                            ModelState.AddModelError("Icon", "Image size can be 2 MB");
                            return View();
                        }
                        var imgPath = Path.Combine(_env.WebRootPath, "images");
                        var fileNameIcon = await FileUtil.GenerateFileAsync(imgPath, productItem2.FirstBoxPhoto);

                        productItem2.FirstBoxIcon = fileNameIcon;
                        dBProductItem2.FirstBoxIcon = productItem2.FirstBoxIcon;


                }
                else if (productItem2.SecondBoxPhoto != null)
                {
                        if (productItem2.SecondBoxPhoto == null)
                        {
                            ModelState.AddModelError("Icon", "Photo cannot be empty");
                            return View();
                        }
                        if (!productItem2.SecondBoxPhoto.IsImage())
                        {
                            ModelState.AddModelError("Icon", "You must choose only Image");
                            return View();
                        }
                        if (!productItem2.SecondBoxPhoto.IsSizeAllowed(2048))
                        {
                            ModelState.AddModelError("Icon", "Image size can be 2 MB");
                            return View();
                        }

                       var imgPath = Path.Combine(_env.WebRootPath, "images");
                       var fileNameIconSecond = await FileUtil.GenerateFileAsync(imgPath, productItem2.SecondBoxPhoto);

                       productItem2.SecondBoxIcon = fileNameIconSecond;
                       dBProductItem2.SecondBoxIcon = productItem2.SecondBoxIcon;


                }








            dBProductItem2.AzTitle = productItem2.AzTitle;
            dBProductItem2.RuTitle = productItem2.RuTitle;
            dBProductItem2.EnTitle = productItem2.EnTitle;

            dBProductItem2.AzDescription = productItem2.AzDescription;
            dBProductItem2.RuDescription = productItem2.RuDescription;
            dBProductItem2.EnDescription = productItem2.EnDescription;

            dBProductItem2.AzTitleBox = productItem2.AzTitleBox;
            dBProductItem2.RuTitleBox = productItem2.RuTitleBox;
            dBProductItem2.EnTitleBox = productItem2.EnTitleBox;

            dBProductItem2.AzFirstBoxInfo = productItem2.AzFirstBoxInfo;
            dBProductItem2.RuFirstBoxInfo = productItem2.RuFirstBoxInfo;
            dBProductItem2.EnFirstBoxInfo = productItem2.EnFirstBoxInfo;


            dBProductItem2.AzSecondBoxInfo = productItem2.AzSecondBoxInfo;
            dBProductItem2.RuSecondBoxInfo = productItem2.RuSecondBoxInfo;
            dBProductItem2.EnSecondBoxInfo = productItem2.EnSecondBoxInfo;

            dBProductItem2.AzImageTitle = productItem2.AzImageTitle;
            dBProductItem2.RuImageTitle = productItem2.RuImageTitle;
            dBProductItem2.EnImageTitle = productItem2.EnImageTitle;

            dBProductItem2.AzCondition = productItem2.AzCondition;
            dBProductItem2.RuCondition = productItem2.RuCondition;
            dBProductItem2.EnCondition = productItem2.EnCondition;

           



            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion
    }
}

