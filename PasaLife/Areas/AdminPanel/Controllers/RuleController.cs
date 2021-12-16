using AdminPanel.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using PasaLife.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]


    public class RuleController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public RuleController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<Rule> Rules = await _db.Rules.ToListAsync();
            return View(Rules);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var Rule = await _db.Rules.FindAsync(id);
            return View(Rule);
        }
        #endregion

        #region Create
        public async Task<IActionResult> Create(int? infId)
        {
            ViewBag.Categories = await _db.RuleCategories.ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? infId,Rule Rule, int? catId)
        {
            ViewBag.Categories = await _db.RuleCategories.ToListAsync();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (catId == null)
            {

                ModelState.AddModelError("", "Zəhmət olmasa kateqoriyanı qeyd edin");
                return View();


            }
            if (Rule.File == null)
            {

                ModelState.AddModelError("File", "Select pdf.");
                return View();


            }
            //if (!Rule.File.IsPdf())
            //{
            //    ModelState.AddModelError("File", "Select pdf.");
            //    return View();
            //}

            if (!Rule.File.IsSizeAllowed(10000))
            {
                ModelState.AddModelError("File", "Max size is 10 MB.");
                return View();
            }

            var iconSPath = Path.Combine(_env.WebRootPath, "files");
            var fileName = await FileUtil.GenerateFileAsync(iconSPath, Rule.File);
            Rule.Size = (Rule.File.Length / 1048576.0).ToString() + " mb";
            Rule.FileName = fileName;
            Rule.RuleCategoryId =(int) catId;
            Rule.InformationCenterId = infId;
            await _db.Rules.AddAsync(Rule);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "InformationCenter");

        }

        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            

            if (id == null)
                return NotFound();
            Rule Rule = await _db.Rules.FirstOrDefaultAsync(x => x.Id == id);
            if (Rule == null)
                return NotFound();
            return View(Rule);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Rule Rule, int? catId)
        {
            
            if (!ModelState.IsValid)
                return NotFound();           
            if (id == null)
                return NotFound();
            if (catId == null)
            {
                ModelState.AddModelError("", "Zəhmət olmasa kateqoriyanı qeyd edin");
                return View();
            }
            Rule dbRule = await _db.Rules.FirstOrDefaultAsync(x => x.Id == id);
            if (dbRule == null)
                return NotFound();
            if (dbRule.File != null)
            {



                //if (!dbRule.File.IsPdf())
                //{
                //    ModelState.AddModelError("File", "Select pdf.");
                //    return View();
                //}

                if (!dbRule.File.IsSizeAllowed(8000))
                {
                    ModelState.AddModelError("File", "Max size is 8 MB.");
                    return View();
                }
                var path = Path.Combine(_env.WebRootPath, "files", dbRule.FileName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                var iconSPath = Path.Combine(_env.WebRootPath, "files");
                var fileName = await FileUtil.GenerateFileAsync(iconSPath, Rule.File);
                dbRule.FileName = fileName;
                dbRule.Size = (Rule.File.Length / 1048576.0).ToString() + " mb";
            }
            dbRule.AzName = Rule.AzName;
            dbRule.RuName = Rule.RuName;
            dbRule.EnName = Rule.EnName;


            dbRule.RuleCategoryId = (int)catId;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "InformationCenter");


        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Rule Rule = await _db.Rules.FirstOrDefaultAsync(x => x.Id == id);
            if (Rule == null)
                return NotFound();
            Rule.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "InformationCenter");

        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            Rule Rule = await _db.Rules.FirstOrDefaultAsync(x => x.Id == id);
            if (Rule == null)
                return NotFound();
            Rule.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "InformationCenter");


        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var Rules = await _db.Rules.FindAsync(id);

            if (Rules == null) return NotFound();

            _db.Rules.Remove(Rules);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
