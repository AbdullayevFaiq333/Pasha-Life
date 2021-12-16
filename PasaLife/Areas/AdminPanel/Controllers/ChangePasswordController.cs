using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaLife.DAL;
using PasaLife.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PasaLife.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class ChangePasswordController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AppDbContext db;

        public ChangePasswordController(UserManager<User> userManager,
                             SignInManager<User> signInManager,
                           RoleManager<IdentityRole> roleManager,
                           AppDbContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var user = await userManager.FindByNameAsync(userName);
            if (user == null) return NotFound();
            ViewBag.UserName = user.Email;
            ViewBag.Id = user.Id;
            var role = await userManager.GetRolesAsync(user);
            var users = await  db.Users.ToListAsync();
            if (role.Count > 0)
            {
                ViewBag.role = role[0].ToString();
            }

            return View(users);
        }
        public async Task<IActionResult> Details(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if(user == null)
            {
                return View();
            }
            ChangePasswordRequest userMain = new ChangePasswordRequest()
            {
                Username=user.Email
                
            };
            return View(userMain);
        }
        [HttpPost]
        public async Task<IActionResult> Details(ChangePasswordRequest user)
        {
            var userMain = await userManager.FindByEmailAsync(user.Username);
            var token = await userManager.GeneratePasswordResetTokenAsync(userMain);

            var result = await userManager.ResetPasswordAsync(userMain, token, user.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("Password", "parol formati duzgun deyil");
                return View(user);
            }
        }
    }
}
