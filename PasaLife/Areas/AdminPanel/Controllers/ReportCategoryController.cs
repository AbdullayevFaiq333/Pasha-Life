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


    public class ReportCategoryController : Controller
    {
        private readonly AppDbContext _db;
        public ReportCategoryController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<ReportCategory> reportCategories = await _db.ReportCategories.ToListAsync();
            return View(reportCategories);
        }
        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _db.ReportCategories.ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReportCategory reportCategory)
        {
            ViewBag.Categories = await _db.ReportCategories.ToListAsync();
            if (!ModelState.IsValid)
                return NotFound();
            await _db.ReportCategories.AddAsync(reportCategory);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            ReportCategory reportCategory = await _db.ReportCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (reportCategory == null)
                return NotFound();
            return View(reportCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, ReportCategory reportCategory)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            ReportCategory dbReportCategory = await _db.ReportCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (dbReportCategory == null)
                return NotFound();
            dbReportCategory.AzName = reportCategory.AzName;
            dbReportCategory.RuName = reportCategory.RuName;
            dbReportCategory.EnName = reportCategory.EnName;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            ReportCategory reportCategory = await _db.ReportCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (reportCategory == null)
                return NotFound();
            reportCategory.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            ReportCategory reportCategory = await _db.ReportCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (reportCategory == null)
                return NotFound();
            reportCategory.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var reportCategories = await _db.ReportCategories.FindAsync(id);

            if (reportCategories == null) return NotFound();

            _db.ReportCategories.Remove(reportCategories);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
