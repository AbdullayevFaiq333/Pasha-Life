using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
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
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<HomeCenter> homeCenters = await _db.HomeCenters.Where(x => x.IsDeactive == false).ToListAsync();
            var homeCarousels=await _db.HomeCarousels.ToListAsync();

            var homeCarouselSeo = await _db.HomeCarouselSeos.FirstOrDefaultAsync();



            ViewBag.AzSeoTitle = homeCarouselSeo.AzSeoTitle;
            ViewBag.RuSeoTitle = homeCarouselSeo.RuSeoTitle;
            ViewBag.EnSeoTitle = homeCarouselSeo.EnSeoTitle;
 




            HomeViewModel headerViewModel = new HomeViewModel
            {
                Left = homeCenters.Find(x => x.Id == 1),
                Right = homeCenters.Find(x => x.Id == 2),
                Bottom = homeCenters.Find(x => x.Id == 3),
                HomeCarousels= homeCarousels,
            };


           


            return View(headerViewModel);
        }
        public IActionResult SetLanguage(string culture, string url)
        {
            try
            {
                Response.Cookies.Append(
               CookieRequestCultureProvider.DefaultCookieName,
               CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
               new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
                return LocalRedirect(url);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
                throw;
            }

        }
    }
}
