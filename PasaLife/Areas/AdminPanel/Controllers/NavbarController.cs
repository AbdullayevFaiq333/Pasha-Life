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
    public class NavbarController : Controller
    {
        private readonly AppDbContext _db;
        public NavbarController(AppDbContext db)
        { 
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<Navbar> navbars = await _db.Navbars.ToListAsync();
            return View(navbars);
        }
        #endregion

        #region Detail
        public IActionResult Detail()
        {
            return View();
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
        public async Task<IActionResult> Create(Navbar navbar,string urlId)
        {
            ViewBag.URLButtons = await _db.URLButtons.ToListAsync();
            if (!ModelState.IsValid)
                return NotFound();
            navbar.URL = urlId;
            await _db.Navbars.AddAsync(navbar);
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
            Navbar navbar = await _db.Navbars.FirstOrDefaultAsync(x => x.Id == id);
            if (navbar == null)
                return NotFound();
            return View(navbar);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,Navbar navbar, string urlId)
        {
            ViewBag.URLButtons = await _db.URLButtons.ToListAsync();
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            Navbar dbNavbar = await _db.Navbars.FirstOrDefaultAsync(x => x.Id == id);
            if (dbNavbar == null)
                return NotFound();
            dbNavbar.AzTitle = navbar.AzTitle;
            dbNavbar.RuTitle = navbar.RuTitle;
            dbNavbar.EnTitle = navbar.EnTitle;
            dbNavbar.URL =  urlId;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Navbar navbar = await _db.Navbars.FirstOrDefaultAsync(x => x.Id == id);
            if (navbar == null)
                return NotFound();
            navbar.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            Navbar navbar = await _db.Navbars.FirstOrDefaultAsync(x => x.Id == id);
            if (navbar == null)
                return NotFound();
            navbar.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var navbars = await _db.Navbars.FindAsync(id);

            if (navbars == null) return NotFound();

            _db.Navbars.Remove(navbars);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
