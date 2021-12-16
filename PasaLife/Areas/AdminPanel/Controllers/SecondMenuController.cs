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


    public class SecondMenuController : Controller
    {

        private readonly AppDbContext _db;
        public SecondMenuController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<SecondMenu> secondMenus = await _db.SecondMenus.ToListAsync();
            return View(secondMenus);

        }
        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            ViewBag.URLButtons = await _db.URLButtons.ToListAsync();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SecondMenu secondMenus, string urlId)
        {
            ViewBag.URLButtons = await _db.URLButtons.ToListAsync();

            if (!ModelState.IsValid)
                return NotFound();
            secondMenus.URL = urlId;

            await _db.SecondMenus.AddAsync(secondMenus);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.URLButtons = await _db.URLButtons.ToListAsync();

            if (id == null)
                return NotFound();
            SecondMenu secondMenus = await _db.SecondMenus.FirstOrDefaultAsync(x => x.Id == id);
            if (secondMenus == null)
                return NotFound();
            return View(secondMenus);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, SecondMenu secondMenus, string urlId)
        {
            ViewBag.URLButtons = await _db.URLButtons.ToListAsync();

            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            SecondMenu dbSecondMenu = await _db.SecondMenus.FirstOrDefaultAsync(x => x.Id == id);
            if (dbSecondMenu == null)
                return NotFound();
            dbSecondMenu.AzTitle = secondMenus.AzTitle;
            dbSecondMenu.RuTitle = secondMenus.RuTitle;
            dbSecondMenu.EnTitle = secondMenus.EnTitle;
            dbSecondMenu.URL = urlId;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            SecondMenu secondMenus = await _db.SecondMenus.FirstOrDefaultAsync(x => x.Id == id);
            if (secondMenus == null)
                return NotFound();
            secondMenus.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            SecondMenu secondMenus = await _db.SecondMenus.FirstOrDefaultAsync(x => x.Id == id);
            if (secondMenus == null)
                return NotFound();
            secondMenus.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var secondMenus = await _db.SecondMenus.FindAsync(id);

            if (secondMenus == null) return NotFound();

            _db.SecondMenus.Remove(secondMenus);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
