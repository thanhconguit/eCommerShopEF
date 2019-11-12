using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using eCommerceShop.Data.Repository;
using eCommerceShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace eCommerceShop.Controllers
{
    public class AccountController : Controller
    {

        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        public AccountController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public IActionResult Register()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel model)
        {
            if (await _userRepository.CreateAsync(model.Register)) return RedirectToAction("Index", "Home");
            else throw new Exception("This username have already used !");
        }
        public IActionResult Login()
        {
            return View("Users/Register.cshtml", new LoginViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userRepository.CanSignInAsync(model.Login);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Role, user.Role.Name)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");
            }
            else throw new Exception("Wrong username or password");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}