using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using PasaLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]

    public class ProductDetailTitleController : Controller
    {
        private readonly AppDbContext _db;
        public ProductDetailTitleController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<ProductDetailTitle> productDetailTitles = await _db.ProductDetailTitles.ToListAsync();
            return View(productDetailTitles);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var productDetailTitle = await _db.ProductDetailTitles.FindAsync(id);
            return View(productDetailTitle);
        }
        #endregion

        #region Create
        public IActionResult Create(int proId)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int proId,ProductDetailTitle productDetailTitle)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            productDetailTitle.ProductId = proId;
            await _db.ProductDetailTitles.AddAsync(productDetailTitle);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            ProductDetailTitle productDetailTitle = await _db.ProductDetailTitles.FirstOrDefaultAsync(x => x.Id == id);
            if (productDetailTitle == null)
                return NotFound();
            return View(productDetailTitle);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, ProductDetailTitle productDetailTitle)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            ProductDetailTitle dbProductDetailTitle = await _db.ProductDetailTitles.FirstOrDefaultAsync(x => x.Id == id);
            if (dbProductDetailTitle == null)
                return NotFound();

            dbProductDetailTitle.AzFirstSection = productDetailTitle.AzFirstSection;
            dbProductDetailTitle.RuFirstSection = productDetailTitle.RuFirstSection;
            dbProductDetailTitle.EnFirstSection = productDetailTitle.EnFirstSection;
            dbProductDetailTitle.AzSecondSection = productDetailTitle.AzSecondSection;
            dbProductDetailTitle.RuSecondSection = productDetailTitle.RuSecondSection;
            dbProductDetailTitle.EnSecondSection = productDetailTitle.EnSecondSection;
            dbProductDetailTitle.AzThirdSection = productDetailTitle.AzThirdSection;
            dbProductDetailTitle.RuThirdSection = productDetailTitle.RuThirdSection;
            dbProductDetailTitle.EnThirdSection = productDetailTitle.EnThirdSection;
            dbProductDetailTitle.AzFourthSection = productDetailTitle.AzFourthSection;
            dbProductDetailTitle.RuFourthSection = productDetailTitle.RuFourthSection;
            dbProductDetailTitle.EnFourthSection = productDetailTitle.EnFourthSection;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            ProductDetailTitle productDetailTitle = await _db.ProductDetailTitles.FirstOrDefaultAsync(x => x.Id == id);
            if (productDetailTitle == null)
                return NotFound();
            productDetailTitle.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            ProductDetailTitle productDetailTitle = await _db.ProductDetailTitles.FirstOrDefaultAsync(x => x.Id == id);
            if (productDetailTitle == null)
                return NotFound();
            productDetailTitle.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var productDetailTitles = await _db.ProductDetailTitles.FindAsync(id);

            if (productDetailTitles == null) return NotFound();

            _db.ProductDetailTitles.Remove(productDetailTitles);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }
        #endregion

    }
}
