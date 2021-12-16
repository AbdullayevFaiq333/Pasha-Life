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


    public class FooterController : Controller
    {
        private readonly AppDbContext _db;
        public FooterController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<Footer> footers = await _db.Footers.ToListAsync();
            return View(footers);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Footer footer)
        {
            if (!ModelState.IsValid)
                return NotFound();
            await _db.Footers.AddAsync(footer);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            Footer footer = await _db.Footers.FirstOrDefaultAsync(x => x.Id == id);
            if (footer == null)
                return NotFound();
            return View(footer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Footer footer)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            Footer dbFooter = await _db.Footers.FirstOrDefaultAsync(x => x.Id == id);
            if (dbFooter == null)
                return NotFound();
            dbFooter.AzTitle = footer.AzTitle;
            dbFooter.RuTitle = footer.RuTitle;
            dbFooter.EnTitle = footer.EnTitle;
            dbFooter.URL = footer.URL;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Footer footer = await _db.Footers.FirstOrDefaultAsync(x => x.Id == id);
            if (footer == null)
                return NotFound();
            footer.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            Footer footer = await _db.Footers.FirstOrDefaultAsync(x => x.Id == id);
            if (footer == null)
                return NotFound();
            footer.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
                return NotFound();

            var footer = await _db.Footers.FindAsync(id);

            if (footer == null)
                return NotFound();

            _db.Footers.Remove(footer);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
