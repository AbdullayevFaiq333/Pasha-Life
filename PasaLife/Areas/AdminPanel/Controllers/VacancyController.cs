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

    public class VacancyController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public VacancyController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        #region Index
        public async Task<IActionResult> Index()
        {

            List<Vacancy> vacancies = await _db.Vacancies.ToListAsync();

            return View(vacancies);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var vacancy = await _db.Vacancies.Include(x => x.VacancyDetail).FirstOrDefaultAsync(x => x.Id == id);
            return View(vacancy);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vacancy vacancy)
        {
            if (!ModelState.IsValid)
                return View();
           

            await _db.Vacancies.AddAsync(vacancy);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            Vacancy vacancy = await _db.Vacancies.Include(x => x.VacancyDetail)
                                     .FirstOrDefaultAsync(x => x.Id == id);
            if (vacancy == null)
                return NotFound();



            return View(vacancy);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Vacancy Vacancy)
        {

            if (!ModelState.IsValid)
                return NotFound();
            if (id == null)
                return NotFound();
            Vacancy dBVacancy = await _db.Vacancies.Include(x => x.VacancyDetail).
                                       FirstOrDefaultAsync(x => x.Id == id);
            if (dBVacancy == null)
                return NotFound();

            if (dBVacancy == null)
                return NotFound();

            dBVacancy.AzTitle = Vacancy.AzTitle;
            dBVacancy.RuTitle = Vacancy.RuTitle;
            dBVacancy.EnTitle = Vacancy.EnTitle;
            dBVacancy.AzDescription = Vacancy.AzDescription;
            dBVacancy.RuDescription = Vacancy.RuDescription;
            dBVacancy.EnDescription = Vacancy.EnDescription;
            dBVacancy.VacancyDetail.DateTime = Vacancy.VacancyDetail.DateTime;
            dBVacancy.VacancyDetail.AzDescription = Vacancy.VacancyDetail.AzDescription;
            dBVacancy.VacancyDetail.RuDescription = Vacancy.VacancyDetail.RuDescription;
            dBVacancy.VacancyDetail.EnDescription = Vacancy.VacancyDetail.EnDescription;

            dBVacancy.AzSeoTitle = Vacancy.AzSeoTitle;
            dBVacancy.RuSeoTitle = Vacancy.RuSeoTitle;
            dBVacancy.EnSeoTitle = Vacancy.EnSeoTitle;
            dBVacancy.AzSeoDescription = Vacancy.AzSeoDescription;
            dBVacancy.RuSeoDescription = Vacancy.RuSeoDescription;
            dBVacancy.EnSeoDescription = Vacancy.EnSeoDescription;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        #endregion

        #region Remove
        public async Task<IActionResult> Remove(int? id)
        {

            if (id == null)
                return NotFound();

            var vacancy = await _db.Vacancies.FindAsync(id);

            if (vacancy == null)
                return NotFound();



            var vacancyDetails = await _db.VacancyDetails.Where(x => x.VacancyId == id).ToListAsync();
            _db.RemoveRange(vacancyDetails);        


            _db.Vacancies.Remove(vacancy);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion



    }
}
