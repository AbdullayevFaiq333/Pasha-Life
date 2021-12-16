using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using PasaLife.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Controllers
{
    public class AboutCompanyController : Controller
    {
        private readonly AppDbContext _db;

        public AboutCompanyController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var aboutCompany = await _db.AboutCompanies.FirstOrDefaultAsync();
            var aboutCompanyCart = await _db.AboutCompanyCarts.ToListAsync();

           

            ViewBag.AzSeoTitle = aboutCompany.AzSeoTitle;
            ViewBag.RuSeoTitle = aboutCompany.RuSeoTitle;
            ViewBag.EnSeoTitle = aboutCompany.EnSeoTitle;
            ViewBag.AzSeoDescription = aboutCompany.AzSeoDescription;
            ViewBag.RuSeoDescription = aboutCompany.RuSeoDescription;
            ViewBag.EnSeoDescription = aboutCompany.EnSeoDescription;

            AboutCompanyViewModel headerViewModel = new AboutCompanyViewModel
            {
                AboutCompany = aboutCompany,
                AboutCompanyCarts = aboutCompanyCart
            };

            return View(headerViewModel);
        }
    }
}
