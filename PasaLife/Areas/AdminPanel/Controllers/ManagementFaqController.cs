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


    public class ManagementFaqController : Controller
    {
        private readonly AppDbContext _db;
        public ManagementFaqController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<ManagementFaq> managementFaqs = await _db.ManagementFaqs.ToListAsync();
            return View(managementFaqs);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var managementFaq = await _db.ManagementFaqs.FindAsync(id);
            return View(managementFaq);
        }
        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _db.ManagementCategories.ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? catId, ManagementFaq managementFaq)
        {
            ViewBag.Categories = await _db.ManagementCategories.ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (catId == null)
            {
                ModelState.AddModelError("", "Zəhmət olmasa kateqoriyanı qeyd edin");
                return View();
            }

            managementFaq.ManagementCategoryId = (int)catId;
            await _db.ManagementFaqs.AddAsync(managementFaq);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            ManagementFaq managementFaq = await _db.ManagementFaqs.FirstOrDefaultAsync(x => x.Id == id);
            if (managementFaq == null)
                return NotFound();
            return View(managementFaq);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, ManagementFaq managementFaq)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            ManagementFaq dbManagementFaq = await _db.ManagementFaqs.FirstOrDefaultAsync(x => x.Id == id);
            if (dbManagementFaq == null)
                return NotFound();
            dbManagementFaq.AzTitle = managementFaq.AzTitle;
            dbManagementFaq.RuTitle = managementFaq.RuTitle;
            dbManagementFaq.EnTitle = managementFaq.EnTitle;
            dbManagementFaq.AzDescription = managementFaq.AzDescription;
            dbManagementFaq.RuDescription = managementFaq.RuDescription;
            dbManagementFaq.EnDescription = managementFaq.EnDescription;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            ManagementFaq managementFaq = await _db.ManagementFaqs.FirstOrDefaultAsync(x => x.Id == id);
            if (managementFaq == null)
                return NotFound();
            managementFaq.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            ManagementFaq managementFaq = await _db.ManagementFaqs.FirstOrDefaultAsync(x => x.Id == id);
            if (managementFaq == null)
                return NotFound();
            managementFaq.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var managementFaqs = await _db.ManagementFaqs.FindAsync(id);

            if (managementFaqs == null) return NotFound();

            _db.ManagementFaqs.Remove(managementFaqs);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
