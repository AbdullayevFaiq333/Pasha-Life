using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.ViewComponents
{
    public class SecondMenuViewComponent: ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public SecondMenuViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var secondMenus = await _dbContext.SecondMenus.ToListAsync();
            
            return View(secondMenus);
        }
    }
}
