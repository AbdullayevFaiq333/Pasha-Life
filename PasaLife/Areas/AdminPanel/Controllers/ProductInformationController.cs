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

    public class ProductInformationController : Controller
    {
        private readonly AppDbContext _db;
        public ProductInformationController(AppDbContext db)
        {
            _db = db;
        }
        #region Index
        public async Task<IActionResult> Index()
        {
            List<ProductInformation> productInformations = await _db.ProductInformations.ToListAsync();
            return View(productInformations);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var productInformations = await _db.ProductInformations.FindAsync(id);
            return View(productInformations);
        }
        #endregion

        #region Create 
        public IActionResult Create(int proId)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int proId,ProductInformation productInformation)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            productInformation.ProductId = proId;
            await _db.ProductInformations.AddAsync(productInformation);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            ProductInformation productInformation = await _db.ProductInformations.FirstOrDefaultAsync(x => x.Id == id);
            if (productInformation == null)
                return NotFound();
            return View(productInformation);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, ProductInformation productInformation)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            ProductInformation dbProductInformation = await _db.ProductInformations.FirstOrDefaultAsync(x => x.Id == id);
            if (dbProductInformation == null)
                return NotFound();
            dbProductInformation.AzSectionTitle = productInformation.AzSectionTitle;
            dbProductInformation.RuSectionTitle = productInformation.RuSectionTitle;
            dbProductInformation.EnSectionTitle = productInformation.EnSectionTitle;
            dbProductInformation.AzTitle = productInformation.AzTitle;
            dbProductInformation.RuTitle = productInformation.RuTitle;
            dbProductInformation.EnTitle = productInformation.EnTitle;
            dbProductInformation.AzDescription = productInformation.AzDescription;
            dbProductInformation.RuDescription = productInformation.RuDescription;
            dbProductInformation.EnDescription = productInformation.EnDescription;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            ProductInformation productInformation = await _db.ProductInformations.FirstOrDefaultAsync(x => x.Id == id);
            if (productInformation == null)
                return NotFound();
            productInformation.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            ProductInformation productInformation = await _db.ProductInformations.FirstOrDefaultAsync(x => x.Id == id);
            if (productInformation == null)
                return NotFound();
            productInformation.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var productInformations = await _db.ProductInformations.FindAsync(id);

            if (productInformations == null) return NotFound();

            _db.ProductInformations.Remove(productInformations);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }
        #endregion


    }
}
