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


    public class RuleCategoryController : Controller
    {
        private readonly AppDbContext _db;
        public RuleCategoryController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<RuleCategory> ruleCategories = await _db.RuleCategories.ToListAsync();
            return View(ruleCategories);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RuleCategory ruleCategory)
        {
            if (!ModelState.IsValid)
                return NotFound();
            await _db.RuleCategories.AddAsync(ruleCategory);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            RuleCategory ruleCategory = await _db.RuleCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (ruleCategory == null)
                return NotFound();
            return View(ruleCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, RuleCategory ruleCategory)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            RuleCategory dbRuleCategory = await _db.RuleCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (dbRuleCategory == null)
                return NotFound();
            dbRuleCategory.AzName = ruleCategory.AzName;
            dbRuleCategory.RuName = ruleCategory.RuName;
            dbRuleCategory.EnName = ruleCategory.EnName;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion
         
        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            RuleCategory ruleCategory = await _db.RuleCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (ruleCategory == null)
                return NotFound();
            ruleCategory.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            RuleCategory ruleCategory = await _db.RuleCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (ruleCategory == null)
                return NotFound();
            ruleCategory.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove 
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
                return NotFound();

            var ruleCategory = await _db.RuleCategories.FindAsync(id);

            if (ruleCategory == null)
                return NotFound();



            var rule = await _db.Rules.Where(x => x.RuleCategoryId == id).ToListAsync();
            _db.RemoveRange(rule);







            _db.RuleCategories.Remove(ruleCategory);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
