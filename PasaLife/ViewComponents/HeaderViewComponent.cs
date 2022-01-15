using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using PasaLife.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.ViewComponents
{
    public class HeaderViewComponent: ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public HeaderViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var navbars = await _dbContext.Navbars.Where(x => x.IsDeactive == false).ToListAsync();
            var iconButton = await _dbContext.IconButtons.FirstOrDefaultAsync();
            var secondMenus = await _dbContext.SecondMenus.Where(x => x.IsDeactive == false).ToListAsync();
            var products = await _dbContext.Products.Where(x=>x.IsDeactive==false).ToListAsync();
            var onlineServices = await _dbContext.OnlineServices.Where(x => x.IsDeactive == false).ToListAsync();
            var informationCenters = await _dbContext.InformationCenters.Where(x => x.IsDeactive == false).ToListAsync();


            HeaderViewModel headerViewModel = new HeaderViewModel
            {
                Navbars = navbars,
                IconButton=iconButton,
                SecondMenus = secondMenus,
                Products = products,
                OnlineServices = onlineServices,
                InformationCenters = informationCenters,
            };
            return View(headerViewModel);
        }
    }
}
