using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using PasaLife.Models;
using PasaLife.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDbContext _db;

        public ReportController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var reports = await _db.Reports.Include(x=>x.ReportCategory).Where(x => x.IsDeactive == false).ToListAsync();
            var reportCategories = await _db.ReportCategories.Include(x => x.Reports).Where(x => x.IsDeactive == false).ToListAsync();
            foreach (var report in reports)
            {
                report.Size = report.Size.Substring(0, 4) + "mb";
            }

            ReportViewModel reportViewModel = new ReportViewModel
            {
                Reports = reports,
                ReportCategories=reportCategories
            };


            return View(reportViewModel);
        }
        
    }
}
