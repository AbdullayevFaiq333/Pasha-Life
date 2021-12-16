using AdminPanel.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using PasaLife.Helpers;
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

    public class AwardSeoController : Controller
    {
        private readonly AppDbContext _db;
        public AwardSeoController(AppDbContext db)
        {
            _db = db;
        }


        #region Index
        public async Task<IActionResult> Index()
        {
            List<AwardSeo> awardSeos = await _db.AwardSeos.ToListAsync();
            return View(awardSeos);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            AwardSeo awardSeo = await _db.AwardSeos.FirstOrDefaultAsync(x => x.Id == id);
            return View(awardSeo);
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            AwardSeo awardSeo = await _db.AwardSeos.FirstOrDefaultAsync(x => x.Id == id);
            if (awardSeo == null)
                return NotFound();

            return View(awardSeo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, AwardSeo awardSeo)
        {

            if (id != awardSeo.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return NotFound();

            if (id == null)
                return NotFound();
            AwardSeo dbAwardSeo = await _db.AwardSeos.FirstOrDefaultAsync(x => x.Id == id);
            if (dbAwardSeo == null)
                return NotFound();

            dbAwardSeo.AzSeoTitle = awardSeo.AzSeoTitle;
            dbAwardSeo.RuSeoTitle = awardSeo.RuSeoTitle;
            dbAwardSeo.EnSeoTitle = awardSeo.EnSeoTitle;
            dbAwardSeo.AzSeoDescription = awardSeo.AzSeoDescription;
            dbAwardSeo.RuSeoDescription = awardSeo.RuSeoDescription;
            dbAwardSeo.EnSeoDescription = awardSeo.EnSeoDescription;         




            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion



    }
}
