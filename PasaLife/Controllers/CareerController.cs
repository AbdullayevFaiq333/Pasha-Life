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
    public class CareerController : Controller
    {
        private readonly AppDbContext _db;

        public CareerController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var career = await _db.Careers.FirstOrDefaultAsync();
            var vacancies = await _db.Vacancies.Include(x => x.VacancyDetail).ToListAsync();

            
            ViewBag.AzSeoTitle = career.AzSeoTitle;
            ViewBag.RuSeoTitle = career.RuSeoTitle;
            ViewBag.EnSeoTitle = career.EnSeoTitle;
            ViewBag.AzSeoDescription = career.AzSeoDescription;
            ViewBag.RuSeoDescription = career.RuSeoDescription;
            ViewBag.EnSeoDescription = career.EnSeoDescription;

            CareerViewModel careerViewModel = new CareerViewModel
            {
                Career = career,
                Vacancies = vacancies,
            };
            return View(careerViewModel);
        }

        public async Task<IActionResult> CareerItem(int? id)
        {
            if (id == null)
                return NotFound();
            var vacancyDetail = await _db.VacancyDetails.Include(x => x.Vacancy).FirstOrDefaultAsync(z => z.VacancyId == id);
            if (vacancyDetail == null)
                return NotFound();


            ViewBag.AzSeoTitle = vacancyDetail.Vacancy.AzSeoTitle;
            ViewBag.RuSeoTitle = vacancyDetail.Vacancy.RuSeoTitle;
            ViewBag.EnSeoTitle = vacancyDetail.Vacancy.EnSeoTitle;
            ViewBag.AzSeoDescription = vacancyDetail.Vacancy.AzSeoDescription;
            ViewBag.RuSeoDescription = vacancyDetail.Vacancy.RuSeoDescription;
            ViewBag.EnSeoDescription = vacancyDetail.Vacancy.EnSeoDescription;

            return View(vacancyDetail);
        }
        public IActionResult CareerForm()
        {
            return View();
        }
    }
}
