using AdminPanel.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PasaLife.Areas.AdminPanel.Identity;
using PasaLife.Models;
using PasaLife.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager,
                             SignInManager<User> signInManager,
                           RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        
        #region Login
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var existUser = await _userManager.FindByEmailAsync(login.Email);
            if (existUser == null)
            {
                ModelState.AddModelError("", "Email or password is incorrect");
                return View();
            }

            var loginResult = await _signInManager.PasswordSignInAsync(existUser, login.Passsword, login.RememberMe, true);
            if (!loginResult.Succeeded)
            {
                ModelState.AddModelError("", "Email or password is incorrect");
                return View();
            }

            return RedirectToAction("", "Dashboard");

        }
        #endregion

        #region Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        #endregion

        #region Register
        public IActionResult Register()
        {

            if (User.Identity.IsAuthenticated)
            {
                return View("Register", "Account");
            }
            return RedirectToAction("Login", "Account");


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var dbUser = await _userManager.FindByNameAsync(register.Username);
            if (dbUser != null)
            {
                ModelState.AddModelError("Username", "This username is already exist");
                return View();
            }

            var newUser = new User
            {
                UserName = register.Username,
                Name = register.Name,
                Email = register.Email,
                Surname = register.Surname

            };

            var identityResult = await _userManager.CreateAsync(newUser, register.Passsword);
            if (!identityResult.Succeeded)
            {
                foreach (var eror in identityResult.Errors)
                {
                    ModelState.AddModelError("", eror.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(newUser, RoleConstants.ModeratorRole);
            await _signInManager.SignInAsync(newUser, true);

            return RedirectToAction("", "Dashboard");
        }
        #endregion

        #region ForgotPassword

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPassword)
        {
            if (string.IsNullOrEmpty(forgotPassword.Email))
            {
                ModelState.AddModelError("Email", " Email boş ola bilməz");
                return View();
            }

            if (forgotPassword == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByEmailAsync(forgotPassword.Email);

            if (user == null)
            {
                ModelState.AddModelError("Email", "Belə profil mövcud deyil !");
                return View();
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            string href = Url.Action("ResetPassword", new { userEmail = forgotPassword.Email, token });
            var confirmationLink = Url.Action("ResetPassword", "Account", new { token, userEmail = forgotPassword.Email }, Request.Scheme);

            string url = "https://localhost:44302" + href;
            string subject = "ResetPassword";
            string msgBody = $"<a href={confirmationLink}>Şifrəni yenilə</a> ";
            string mail = forgotPassword.Email;

            await Helper.SendMessage(subject, msgBody, mail);
            TempData["Email"] = forgotPassword.Email;
            TempData["Token"] = token;

            return RedirectToAction("Login");
        }
        #endregion

        #region ResetPassword
        public IActionResult ResetPassword(string userEmail, string token)
        {
            if ((string)TempData["Email"] != userEmail || (string)TempData["Token"] != token)
            {
                return BadRequest();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string userEmail, string token, ResetPasswordViewModel resetPassword)
        {
            if (string.IsNullOrEmpty(userEmail))
                return NotFound();

            if (!ModelState.IsValid)
            {
                return View();
            }

            var dbUser = await _userManager.FindByEmailAsync(userEmail);
            if (dbUser == null)
            {
                return BadRequest();
            }

            var result = await _userManager.ResetPasswordAsync(dbUser, token, resetPassword.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            return RedirectToAction("Login");
        }
        #endregion

        #region CreateRole
        public async Task CreateRole()
        {
            if (!await _roleManager.RoleExistsAsync(RoleConstants.ModeratorRole))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = RoleConstants.ModeratorRole });
            };
            if (!await _roleManager.RoleExistsAsync(RoleConstants.AdminRole))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = RoleConstants.AdminRole });
            };
          
        }
        #endregion

    }
}
