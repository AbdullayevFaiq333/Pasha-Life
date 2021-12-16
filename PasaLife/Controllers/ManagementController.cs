using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using PasaLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Controllers
{
    public class ManagementController : Controller
    {
        private readonly AppDbContext _db;

        public ManagementController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<ManagementCategory> managementCategories = await _db.ManagementCategories
                                                                     .Where(x => x.IsDeactive == false)
                                                                     .Include(x => x.Managements)
                                                                     .ThenInclude(x=>x.ManagementDetail)
                                                                     .ToListAsync();

            return View(managementCategories);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var managementDetail = await _db.ManagementDetail.Include(x=>x.Management).FirstOrDefaultAsync(z => z.ManagementId == id);

            if (managementDetail == null)
                return NotFound();

            ViewBag.AzSeoTitle = managementDetail.Management.AzSeoTitle;
            ViewBag.RuSeoTitle = managementDetail.Management.RuSeoTitle;
            ViewBag.EnSeoTitle = managementDetail.Management.EnSeoTitle;
            ViewBag.AzSeoDescription = managementDetail.AzSeoDescription;
            ViewBag.RuSeoDescription = managementDetail.RuSeoDescription;
            ViewBag.EnSeoDescription = managementDetail.EnSeoDescription;

            return View(managementDetail);
        }
    }
}
