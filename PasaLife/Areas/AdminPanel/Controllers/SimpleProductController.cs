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

    public class SimpleProductController : Controller
    {
        private readonly AppDbContext _db;
        public SimpleProductController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<SimpleProduct> simpleProducts = await _db.SimpleProducts.ToListAsync();
            return View(simpleProducts);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var simpleProduct = await _db.SimpleProducts.FindAsync(id);
            return View(simpleProduct);
        }
        #endregion

        #region Create
        public IActionResult Create(int? proId)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? proId,SimpleProduct simpleProduct)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            simpleProduct.ProductId = (int)proId;
            await _db.SimpleProducts.AddAsync(simpleProduct);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            SimpleProduct simpleProduct = await _db.SimpleProducts.FirstOrDefaultAsync(x => x.Id == id);
            if (simpleProduct == null)
                return NotFound();
            return View(simpleProduct);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, SimpleProduct simpleProduct)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            SimpleProduct dbSimpleProduct = await _db.SimpleProducts.FirstOrDefaultAsync(x => x.Id == id);
            if (dbSimpleProduct == null)
                return NotFound();
         
            dbSimpleProduct.AzDescription = simpleProduct.AzDescription;
            dbSimpleProduct.RuDescription = simpleProduct.RuDescription;
            dbSimpleProduct.EnDescription = simpleProduct.EnDescription;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index","Product" );

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            SimpleProduct SimpleProduct = await _db.SimpleProducts.FirstOrDefaultAsync(x => x.Id == id);
            if (SimpleProduct == null)
                return NotFound();
            SimpleProduct.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            SimpleProduct SimpleProduct = await _db.SimpleProducts.FirstOrDefaultAsync(x => x.Id == id);
            if (SimpleProduct == null)
                return NotFound();
            SimpleProduct.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var simpleProducts = await _db.SimpleProducts.FindAsync(id);

            if (simpleProducts == null) return NotFound();

            _db.SimpleProducts.Remove(simpleProducts);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }
        #endregion


    }
}
