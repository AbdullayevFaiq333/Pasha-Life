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

    public class ProductController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ProductController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db; 
            _env = env;
        }
        #region Index
        public async Task<IActionResult> Index()
        {
            var iconSPath = Path.Combine(_env.WebRootPath, "images\\");

            List<Product> products = await _db.Products
                                            .Include(x=>x.FAQs)
                                            .Include(x=>x.Customers)
                                            .Include(x=>x.Partners)
                                            .Include(x=>x.ProductCharts)
                                            .Include(x => x.ProductDetailTitle)
                                            .Include(x => x.ProductInformation)
                                            .Include(x => x.SimpleProduct)
                                            .Include(x=>x.ProductWords).ToListAsync();
            //var temp = products[products.Count - 1].ProductDetailTitle;
            //foreach (var product in products)
            //{
            //    product.Image = iconSPath + product.Image;

            //}
            return View(products);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound(); 

            var product = await _db.Products.FindAsync(id);
            return View(product);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Product Product,bool isSimple)
        {
            if (!ModelState.IsValid)
                return View();
            if (Product.Photo == null)
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa şəkil seçin !");
                return View();
            }
           
            if (!Product.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "You must choose only Image");
                return View();
            }
            if (!Product.Photo.IsSizeAllowed(2048))
            {
                ModelState.AddModelError("Photo", "Image size can be 2 MB");
                return View();
            }
            var iconSPath = Path.Combine(_env.WebRootPath, "images");
            var fileName = await FileUtil.GenerateFileAsync(iconSPath, Product.Photo);
            Product.Image = fileName;
            if (Product.VideoFile != null)
            {
                string folderv = Path.Combine(_env.WebRootPath, "video");
                Product.Video = await FileUtil.SaveFileAsync(folderv, Product.VideoFile);
            }
              
            Product.IsSimple = isSimple;
            await _db.Products.AddAsync(Product);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            Product Product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (Product == null)
                return NotFound();

            return View(Product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,  Product product)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            Product dBProduct = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (dBProduct == null)
                return NotFound();
            if (product.VideoFile !=null)
            {                
                dBProduct.Video = product.Video;
            }

            if (product.Photo != null)
            {

                if (!product.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Select photo.");
                    return View();
                }

                if (!product.Photo.IsSizeAllowed(2048))
                {
                    ModelState.AddModelError("Photo", "Max size is 2 MB.");
                    return View();
                }

                var path = Path.Combine(_env.WebRootPath, "images", dBProduct.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }


                var imgPath = Path.Combine(_env.WebRootPath, "images");
                var fileName = await FileUtil.GenerateFileAsync(imgPath, product.Photo);
                product.Image = fileName;

                dBProduct.Image = product.Image;                          


            }
           
            dBProduct.VideoUrl = product.VideoUrl;
            dBProduct.AzTitle2 = product.AzTitle2;
            dBProduct.RuTitle2 = product.RuTitle2;
            dBProduct.EnTitle2=product.EnTitle2;
            dBProduct.AzTitle = product.AzTitle;
            dBProduct.RuTitle = product.RuTitle;
            dBProduct.EnTitle = product.EnTitle;
            dBProduct.AzDetailDescription = product.AzDetailDescription;
            dBProduct.RuDetailDescription = product.RuDetailDescription;
            dBProduct.EnDetailDescription = product.EnDescription;
            dBProduct.AzDescription = product.AzDescription;
            dBProduct.RuDescription = product.RuDescription;
            dBProduct.EnDescription = product.EnDescription;

            dBProduct.AzSeoTitle = product.AzSeoTitle;
            dBProduct.RuSeoTitle = product.RuSeoTitle;
            dBProduct.EnSeoTitle = product.EnSeoTitle;
            dBProduct.AzSeoDescription = product.AzSeoDescription;
            dBProduct.RuSeoDescription = product.RuSeoDescription;
            dBProduct.EnSeoDescription = product.EnSeoDescription;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Product product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return NotFound();
            product.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            Product product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return NotFound();
            product.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion 

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {

            if (id == null) 
                return NotFound();

            var products = await _db.Products.FindAsync(id);

            if (products == null)  
                return NotFound();



            var productChart = await _db.ProductCharts.Where(x => x.ProductId == id).ToListAsync();
            _db.RemoveRange(productChart);

            var customer = await _db.Customers.Where(x => x.ProductId == id).ToListAsync();
            _db.RemoveRange(customer);

            var fAQ = await _db.FAQs.Where(x => x.ProductId == id).ToListAsync();
            _db.RemoveRange(fAQ);

            var partner = await _db.Partners.Where(x => x.ProductId == id).ToListAsync();
            _db.RemoveRange(partner);

            var productWord = await _db.ProductWords.Where(x => x.ProductId == id).ToListAsync();
            _db.RemoveRange(productWord);






            _db.Products.Remove(products);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion



    }
}
