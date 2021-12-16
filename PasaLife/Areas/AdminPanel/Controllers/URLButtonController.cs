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


    public class URLButtonController : Controller
    {
        private readonly AppDbContext _db;
        public URLButtonController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<URLButton> uRLButtons = await _db.URLButtons.ToListAsync();
            return View(uRLButtons);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(URLButton uRLButton)
        {
            if (!ModelState.IsValid)
                return NotFound();
            await _db.URLButtons.AddAsync(uRLButton);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            URLButton uRLButton = await _db.URLButtons.FirstOrDefaultAsync(x => x.Id == id);
            if (uRLButton == null)
                return NotFound();
            return View(uRLButton);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, URLButton URLButton)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            URLButton dbURLButton = await _db.URLButtons.FirstOrDefaultAsync(x => x.Id == id);
            if (dbURLButton == null)
                return NotFound();
            dbURLButton.Name = URLButton.Name;
            dbURLButton.URL = URLButton.URL;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
                return NotFound();

            var uRLButton = await _db.URLButtons.FindAsync(id);

            if (uRLButton == null) 
                return NotFound();

            _db.URLButtons.Remove(uRLButton);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion


    }
}
