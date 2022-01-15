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


    public class FAQController : Controller
    {
        private readonly AppDbContext _db;
        public FAQController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<FAQ> fAQs = await _db.FAQs.ToListAsync();
            return View(fAQs);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var fAQ = await _db.FAQs.FindAsync(id);
            return View(fAQ);
        }
        #endregion

        #region Create
        public async Task<IActionResult> Create(int? proId,int? infId)
        {
            ViewBag.Categories = await _db.FAQCategories.ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? proId, int? infId, FAQ fAQ,int? catId)
        {
            ViewBag.Categories = await _db.FAQCategories.ToListAsync();
            if (!ModelState.IsValid)
            {
                return View();
            } 
            if (proId!=null)
                fAQ.ProductId = proId;
            if (infId != null)
                fAQ.InformationCenterId = infId;
            if (catId == null)
            {
                ModelState.AddModelError("", "Zəhmət olmasa kateqoriyanı qeyd edin");
                return View();
            }
            fAQ.FAQCategoryId = (int)catId;
            await _db.FAQs.AddAsync(fAQ);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            FAQ fAQ = await _db.FAQs.FirstOrDefaultAsync(x => x.Id == id);
            if (fAQ == null)
                return NotFound();
            return View(fAQ);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, FAQ fAQ)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            FAQ dbFAQ = await _db.FAQs.FirstOrDefaultAsync(x => x.Id == id);
            if (dbFAQ == null)
                return NotFound();
            dbFAQ.AzTitle = fAQ.AzTitle;
            dbFAQ.RuTitle = fAQ.RuTitle;
            dbFAQ.EnTitle = fAQ.EnTitle;
            dbFAQ.AzDescription = fAQ.AzDescription;
            dbFAQ.RuDescription = fAQ.RuDescription;
            dbFAQ.EnDescription = fAQ.EnDescription;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            FAQ fAQ = await _db.FAQs.FirstOrDefaultAsync(x => x.Id == id);
            if (fAQ == null)
                return NotFound();
            fAQ.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            FAQ fAQ = await _db.FAQs.FirstOrDefaultAsync(x => x.Id == id);
            if (fAQ == null)
                return NotFound();
            fAQ.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var fAQs = await _db.FAQs.FindAsync(id);

            if (fAQs == null) return NotFound();

            _db.FAQs.Remove(fAQs);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
