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
    public class FooterViewComponent: ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public FooterViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footers = await _dbContext.Footers.ToListAsync();
            var socialMedias = await _dbContext.SocialMedias.ToListAsync();
            FooterViewModel footerViewModel = new FooterViewModel
            {
                Footers = footers,
                SocialMedias = socialMedias,
            };
            return View(footerViewModel);
        }
    }
}
