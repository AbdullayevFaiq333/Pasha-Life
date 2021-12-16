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
    public class ManagementCategoryController : Controller
    {
        private readonly AppDbContext _db;
        public ManagementCategoryController(AppDbContext db)
        { 
            _db = db;
        }

        #region  Index
        public async Task<IActionResult> Index()
        {
            List<ManagementCategory> managementCategories = await _db.ManagementCategories.ToListAsync();
            return View(managementCategories);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ManagementCategory managementCategory)
        {
            if (!ModelState.IsValid)
                return NotFound();
            await _db.ManagementCategories.AddAsync(managementCategory);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion
         
        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            ManagementCategory managementCategory = await _db.ManagementCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (managementCategory == null)
                return NotFound();
            return View(managementCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,ManagementCategory managementCategory)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            ManagementCategory dbManagementCategory = await _db.ManagementCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (dbManagementCategory == null)
                return NotFound();
            dbManagementCategory.AzName = managementCategory.AzName;
            dbManagementCategory.RuName = managementCategory.RuName;
            dbManagementCategory.EnName = managementCategory.EnName;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            ManagementCategory managementCategory = await _db.ManagementCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (managementCategory == null)
                return NotFound();
            managementCategory.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            ManagementCategory managementCategory = await _db.ManagementCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (managementCategory == null)
                return NotFound();
            managementCategory.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) 
                return NotFound();

            var managementCategories = await _db.ManagementCategories.FindAsync(id);

            if (managementCategories == null) 
                return NotFound();

            var management = await _db.Managements.Where(x => x.ManagementCategoryId == id).ToListAsync();
            _db.RemoveRange(management);

            _db.ManagementCategories.Remove(managementCategories);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
