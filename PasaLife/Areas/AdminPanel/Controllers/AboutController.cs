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
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;
        public AboutController(AppDbContext db) 
        {
            _db = db;
        }
        
        #region Index
        public async Task<IActionResult> Index()
        {
            List<About> abouts = await _db.Abouts.ToListAsync();
            return View(abouts);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var about = await _db.Abouts.FindAsync(id);
            return View(about);
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            About about = await _db.Abouts.FirstOrDefaultAsync(x => x.Id == id);
            if (about == null)
                return NotFound();
            return View(about);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, About about)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            About dbAbout = await _db.Abouts.FirstOrDefaultAsync(x => x.Id == id);
            if (dbAbout == null)
                return NotFound();

            dbAbout.AzTitle = about.AzTitle;
            dbAbout.RuTitle = about.RuTitle;
            dbAbout.EnTitle = about.EnTitle;
            dbAbout.AzDescription= about.AzDescription;
            dbAbout.RuDescription = about.RuDescription;
            dbAbout.EnDescription = about.EnDescription;

            dbAbout.AzSeoTitle = about.AzSeoTitle;
            dbAbout.RuSeoTitle = about.RuSeoTitle;
            dbAbout.EnSeoTitle = about.EnSeoTitle;
            dbAbout.AzSeoDescription = about.AzSeoDescription;
            dbAbout.RuSeoDescription = about.RuSeoDescription;
            dbAbout.EnSeoDescription = about.EnSeoDescription;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion
    }
}
