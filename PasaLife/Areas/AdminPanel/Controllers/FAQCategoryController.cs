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


    public class FAQCategoryController : Controller 
    {
        private readonly AppDbContext _db;
        public FAQCategoryController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<FAQCategory> fAQCategories = await _db.FAQCategories.ToListAsync();
            return View(fAQCategories);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FAQCategory fAQCategory)
        {
            if (!ModelState.IsValid)
                return NotFound();
            await _db.FAQCategories.AddAsync(fAQCategory);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            FAQCategory fAQCategory = await _db.FAQCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (fAQCategory == null)
                return NotFound();
            return View(fAQCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, FAQCategory fAQCategory)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            FAQCategory dbFAQCategory = await _db.FAQCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (dbFAQCategory == null)
                return NotFound();
            dbFAQCategory.AzTitle = fAQCategory.AzTitle;
            dbFAQCategory.RuTitle = fAQCategory.RuTitle;
            dbFAQCategory.EnTitle = fAQCategory.EnTitle;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            FAQCategory fAQCategory = await _db.FAQCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (fAQCategory == null)
                return NotFound();
            fAQCategory.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            FAQCategory fAQCategory = await _db.FAQCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (fAQCategory == null)
                return NotFound();
            fAQCategory.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion
         
        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {

            if (id == null)
                return NotFound();

            var fAQCategory = await _db.FAQCategories.FindAsync(id);

            if (fAQCategory == null)
                return NotFound();



            var fAQ = await _db.FAQs.Where(x => x.FAQCategoryId == id).ToListAsync();
            _db.RemoveRange(fAQ);




            _db.FAQCategories.Remove(fAQCategory);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
