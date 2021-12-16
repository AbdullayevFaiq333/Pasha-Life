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

    public class HomeCenterController : Controller
    {
        private readonly AppDbContext _db;
        public HomeCenterController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<HomeCenter> homeCenters = await _db.HomeCenters.ToListAsync();
            return View(homeCenters);
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.URLButtons = await _db.URLButtons.ToListAsync();

            if (id == null)
                return NotFound();
            HomeCenter homeCenter = await _db.HomeCenters.FirstOrDefaultAsync(x => x.Id == id);
            if (homeCenter == null)
                return NotFound();
            return View(homeCenter);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, HomeCenter homeCenter, string urlId)
        {
            ViewBag.URLButtons = await _db.URLButtons.ToListAsync();

            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            HomeCenter dbHomeCenter = await _db.HomeCenters.FirstOrDefaultAsync(x => x.Id == id);
            if (dbHomeCenter == null)
                return NotFound();
            dbHomeCenter.AzTitle = homeCenter.AzTitle;
            dbHomeCenter.RuTitle = homeCenter.RuTitle;
            dbHomeCenter.EnTitle = homeCenter.EnTitle;
            dbHomeCenter.URL =  urlId;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

      
    }
}
