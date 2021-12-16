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


    public class ProductChartController : Controller
    {
        private readonly AppDbContext _db;
        public ProductChartController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<ProductChart> productCharts = await _db.ProductCharts.ToListAsync();
            return View(productCharts);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var productChart = await _db.ProductCharts.FindAsync(id);
            return View(productChart);
        }
        #endregion

        #region Create
        public IActionResult Create(int? proId)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? proId,ProductChart productChart)
        {
            productChart.IsDeactive = false;
            if (!ModelState.IsValid)
            {
                return View();
            }
            productChart.ProductId = (int)proId;
            await _db.ProductCharts.AddAsync(productChart);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            ProductChart productChart = await _db.ProductCharts.FirstOrDefaultAsync(x => x.Id == id);
            if (productChart == null)
                return NotFound();
            return View(productChart);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, ProductChart productChart)
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            ProductChart dbProductChart = await _db.ProductCharts.FirstOrDefaultAsync(x => x.Id == id);
            if (dbProductChart == null)
                return NotFound();
            dbProductChart.AzTitle = productChart.AzTitle;
            dbProductChart.RuTitle = productChart.RuTitle;
            dbProductChart.EnTitle = productChart.EnTitle;
            dbProductChart.AzDescription = productChart.AzDescription;
            dbProductChart.RuDescription = productChart.RuDescription;
            dbProductChart.EnDescription = productChart.EnDescription;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            ProductChart productChart = await _db.ProductCharts.FirstOrDefaultAsync(x => x.Id == id);
            if (productChart == null)
                return NotFound();
            productChart.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
                return NotFound();
            ProductChart productChart = await _db.ProductCharts.FirstOrDefaultAsync(x => x.Id == id);
            if (productChart == null)
                return NotFound();
            productChart.IsDeactive = false;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null) return NotFound();

            var productCharts = await _db.ProductCharts.FindAsync(id);

            if (productCharts == null) return NotFound();

            _db.ProductCharts.Remove(productCharts);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }
        #endregion


    }
}
