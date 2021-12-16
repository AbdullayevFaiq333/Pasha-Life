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


    public class ProductWordController : Controller
    {
        private readonly AppDbContext _db;
        public ProductWordController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<ProductWord> productWords = await _db.ProductWords.ToListAsync();
            return View(productWords);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var productWords = await _db.ProductWords.FindAsync(id);
            return View(productWords);
        }
        #endregion

        #region Create
        public IActionResult Create(int proId)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int proId, ProductWord productWord)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            productWord.ProductId = proId;
            
            await _db.ProductWords.AddAsync(productWord);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index","Product");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            ProductWord productWord = await _db.ProductWords.FirstOrDefaultAsync(x => x.Id == id);
            if (productWord == null)
                return NotFound();
            return View(productWord);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, ProductWord productWord)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            ProductWord dbProductWord = await _db.ProductWords.FirstOrDefaultAsync(x => x.Id == id);
            if (dbProductWord == null)
                return NotFound();
            dbProductWord.AzTitle = productWord.AzTitle;
            dbProductWord.RuTitle = productWord.RuTitle;
            dbProductWord.EnTitle = productWord.EnTitle;
            
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            ProductWord productWord = await _db.ProductWords.FirstOrDefaultAsync(x => x.Id == id);
            if (productWord == null)
                return NotFound();
            productWord.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            ProductWord productWord = await _db.ProductWords.FirstOrDefaultAsync(x => x.Id == id);
            if (productWord == null)
                return NotFound();
            productWord.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var productWords = await _db.ProductWords.FindAsync(id);

            if (productWords == null) return NotFound();

            _db.ProductWords.Remove(productWords);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }
        #endregion


    }
}
