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
            var navbars = await _dbContext.Navbars.ToListAsync();
            var iconButton = await _dbContext.IconButtons.FirstOrDefaultAsync();

            HeaderViewModel headerViewModel = new HeaderViewModel
            {
                Navbars = navbars,
                IconButton=iconButton,
            };
            return View(headerViewModel);
        }
    }
}
