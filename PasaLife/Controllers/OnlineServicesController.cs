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
    public class OnlineServicesController : Controller
    {
        private readonly AppDbContext _db;

        public OnlineServicesController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<OnlineService> onlineServices = await _db.OnlineServices.Where(x => x.IsDeactive == false).ToListAsync();
            return View(onlineServices);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            OnlineService onlineService = await _db.OnlineServices.Include(x=>x.ITPlatforms).FirstOrDefaultAsync(x=>x.Id==id);


            ViewBag.AzSeoTitle = onlineService.AzSeoTitle;
            ViewBag.RuSeoTitle = onlineService.RuSeoTitle;
            ViewBag.EnSeoTitle = onlineService.EnSeoTitle;
            ViewBag.AzSeoDescription = onlineService.AzSeoDescription;
            ViewBag.RuSeoDescription = onlineService.RuSeoDescription;
            ViewBag.EnSeoDescription = onlineService.EnSeoDescription;


            if (onlineService == null)
            {
                return BadRequest();
            }
            return View(onlineService);
        }
        public IActionResult OnlinePayment()
        {
            return View();

        }



    }
}
