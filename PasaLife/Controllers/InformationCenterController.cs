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
    public class InformationCenterController : Controller
    {
        private readonly AppDbContext _db;

        public InformationCenterController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<InformationCenter> informationCenters = await _db.InformationCenters.Where(x => x.IsDeactive == false).ToListAsync();
            return View(informationCenters);
        }

        public async Task<IActionResult> FAQ()
        {
            List<FAQ> fAQs = await _db.FAQs.Where(x => x.IsDeactive == false).ToListAsync();

            return View(fAQs);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            InformationCenter informationCenter = await _db.InformationCenters
                                                           .Where(x => x.IsDeactive == false)
                                                           .FirstOrDefaultAsync(x => x.Id == id);
            ViewBag.AzSeoTitle = informationCenter.AzSeoTitle;
            ViewBag.RuSeoTitle = informationCenter.RuSeoTitle;
            ViewBag.EnSeoTitle = informationCenter.EnSeoTitle;
            ViewBag.AzSeoDescription = informationCenter.AzSeoDescription;
            ViewBag.RuSeoDescription = informationCenter.RuSeoDescription;
            ViewBag.EnSeoDescription = informationCenter.EnSeoDescription;

            if (informationCenter == null)
            {
                return BadRequest();
            }



            
            //await _db.RuleCategories.Include(x => x.Rules).Where(x => x.Rules.Any(x => x.InformationCenterId == id && x.IsDeactive == false) && x.IsDeactive == false).ToListAsync();
            var ruleCategories = await _db.RuleCategories
                                          .Include(x=>x.Rules.Where(x=>x.InformationCenterId==id&&x.IsDeactive==false))
                                          .Where(x=>x.IsDeactive==false).ToListAsync();
            var FAQCategories = await _db.FAQCategories
                                         .Include(x => x.FAQs.Where(x => x.InformationCenterId == id && x.IsDeactive == false))
                                         .Where(x => x.IsDeactive == false).ToListAsync();
            

                //ruleCategories =ruleCategories.Where(x=>x.Rules.ToList()==).ToList();
            InformationVM information = new InformationVM
            {
                FAQCategories = FAQCategories,
                RuleCategories = ruleCategories,
                News = await _db.News.Where(x => x.IsDeactive == false && x.InformationCenterId==id)
                                     .Include(x => x.NewsDetail).ToListAsync(),
                Type = informationCenter.Type,
            };

            return View(information);
        }
    }
}
