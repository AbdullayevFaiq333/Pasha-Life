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

    public class AboutCompanyCartController : Controller
    {
        private readonly AppDbContext _db;
        public AboutCompanyCartController(AppDbContext db)
        {
            _db = db;
        }


        #region Index
        public async Task<IActionResult> Index()
        {
            List<AboutCompanyCart> aboutCompanyCarts = await _db.AboutCompanyCarts.ToListAsync();
            return View(aboutCompanyCarts);
        }
        #endregion
        
        #region Create
        public IActionResult Create()
        {            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AboutCompanyCart aboutCompanyCart)
        {
            if (!ModelState.IsValid)
                return NotFound();

            await _db.AboutCompanyCarts.AddAsync(aboutCompanyCart);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            AboutCompanyCart aboutCompanyCart = await _db.AboutCompanyCarts.FirstOrDefaultAsync(x => x.Id == id);
            if (aboutCompanyCart == null)
                return NotFound();
            return View(aboutCompanyCart);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, AboutCompanyCart aboutCompanyCart)
        {
            ViewBag.URLButtons = await _db.URLButtons.ToListAsync();
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            AboutCompanyCart dbAboutCompanyCart = await _db.AboutCompanyCarts.FirstOrDefaultAsync(x => x.Id == id);
            if (dbAboutCompanyCart == null)
                return NotFound();
            dbAboutCompanyCart.AzTitle = aboutCompanyCart.AzTitle;
            dbAboutCompanyCart.RuTitle = aboutCompanyCart.RuTitle;
            dbAboutCompanyCart.EnTitle = aboutCompanyCart.EnTitle;

            dbAboutCompanyCart.Figures = aboutCompanyCart.Figures;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var aboutCompanyCart = await _db.AboutCompanyCarts.FindAsync(id);

            if (aboutCompanyCart == null) return NotFound();

            _db.AboutCompanyCarts.Remove(aboutCompanyCart);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
