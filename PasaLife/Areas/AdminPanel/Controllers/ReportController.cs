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


    public class ReportController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ReportController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<Report> Reports = await _db.Reports.ToListAsync();
            return View(Reports);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var Report = await _db.Reports.FindAsync(id);
            return View(Report);
        }
        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            var reportCategories = await _db.ReportCategories.ToListAsync();
            ViewBag.Categories = reportCategories;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Report Report, int? catId)
        {
            var reportCategories = await _db.ReportCategories.ToListAsync();
            ViewBag.Categories = reportCategories;
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (Report.File == null)
            {

                ModelState.AddModelError("File", "Select pdf.");
                return View();


            }
            if (catId == null)
            {
                ModelState.AddModelError("", "Zəhmət olmasa kateqoriyanı qeyd edin");
                return View();
            }
            //if (!Report.File.IsPdf())
            //{
            //    ModelState.AddModelError("File", "Select pdf.");
            //    return View();
            //}

            if (!Report.File.IsSizeAllowed(10000))
            {
                ModelState.AddModelError("File", "Max size is 10 MB.");
                return View();
            }
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var randomValue =  new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            var fileName = randomValue+ Report.File.FileName;
            Report.FileName = fileName;
            var iconSPath = Path.Combine(_env.WebRootPath, "files\\" +fileName);

            Report.Size= (Report.File.Length / 1048576.0).ToString() + " mb"; 
            Report.FileName = fileName;

            Report.ReportCategoryId = (int)catId;
            using (FileStream stream = new FileStream(iconSPath, FileMode.Create))
            {
                Report.File.CopyTo(stream);
              
               
            }
            await _db.Reports.AddAsync(Report);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            var reportCategories = await _db.ReportCategories.ToListAsync();
            ViewBag.Categories = reportCategories;
            if (id == null)
                return NotFound();
            Report Report = await _db.Reports.FirstOrDefaultAsync(x => x.Id == id);
          

            if (Report == null)
                return NotFound();
            return View(Report);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Report Report, int? catId)
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
            Report dbReport = await _db.Reports.FirstOrDefaultAsync(x => x.Id == id);
            if (dbReport == null)
                return NotFound();

            if (Report.File != null)
            {



                //if (!dbReport.File.IsPdf())
                //{
                //    ModelState.AddModelError("File", "Select pdf.");
                //    return View();
                //}

                if (!Report.File.IsSizeAllowed(8000))
                {
                    ModelState.AddModelError("File", "Max size is 8 MB.");
                    return View();
                }
                var path = Path.Combine(_env.WebRootPath, "files", dbReport.FileName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var randomValue = new string(Enumerable.Repeat(chars, 10)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
                var fileName = randomValue + Report.File.FileName;
                Report.FileName = fileName;
                var iconSPath = Path.Combine(_env.WebRootPath, "files\\" + fileName);
                
                
                dbReport.FileName = fileName;
                dbReport.Size = (Report.File.Length/ 1048576.0).ToString()+" mb";
                using (FileStream stream = new FileStream(iconSPath, FileMode.Create))
                {
                    Report.File.CopyTo(stream);


                }
            }
            dbReport.AzName = Report.AzName;
            dbReport.RuName = Report.RuName;
            dbReport.EnName = Report.EnName;
            dbReport.Year = Report.Year;
           
            dbReport.ReportCategoryId = (int)catId;
           
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Report Report = await _db.Reports.FirstOrDefaultAsync(x => x.Id == id);
            if (Report == null)
                return NotFound();
            Report.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            Report Report = await _db.Reports.FirstOrDefaultAsync(x => x.Id == id);
            if (Report == null)
                return NotFound();
            Report.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var Reports = await _db.Reports.FindAsync(id);

            if (Reports == null) return NotFound();

            _db.Reports.Remove(Reports);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
