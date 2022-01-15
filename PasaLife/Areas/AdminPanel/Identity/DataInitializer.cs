using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using PasaLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PasaLife.Areas.AdminPanel.Identity
{
    public class DataInitializer
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
    public DataInitializer (AppDbContext dbContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public async Task SeedDataAsync()
        {
            await _dbContext.Database.MigrateAsync();

            var roles = new List<string>
             {
                 RoleConstants.AdminRole,
                 RoleConstants.ModeratorRole
             };
            foreach (var role in roles)
            {
                if (await _roleManager.RoleExistsAsync(role))
                    continue;

                await _roleManager.CreateAsync(new IdentityRole(role));          
            }
            var user = new User
            {
                Email = "pashalife@pashalife.az",
                UserName = "Admin",
                Name = "Admin",
                Surname = "Adminov",
                
            };
            var user2 = new User
            {
                Email = "pashalife@pashalife2.az",
                UserName = "Moderator",
                Name = "Moderator",
                Surname = "Moderator",

            };
            if (await _userManager.FindByEmailAsync(user.Email) == null)
            {
                await _userManager.CreateAsync(user, "Pashalife@123");
                await _userManager.AddToRoleAsync(user, RoleConstants.AdminRole);
                

            }
            if (await _userManager.FindByEmailAsync(user2.Email) == null)
            {
                await _userManager.CreateAsync(user2, "Pashalife2@123");
                await _userManager.AddToRoleAsync(user2, RoleConstants.ModeratorRole);

            }
            

        }
    }
}
