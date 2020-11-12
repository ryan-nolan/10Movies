﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TenMovies.Web.Data;
using TenMovies.Web.Models.User;
using TenMovies.Web.Models.ViewModels;

namespace TenMovies.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }

        [Authorize]
        public string AuthTest()
        {
            return "You are authorized";
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind] UserRegisterViewModel userViewModel)
        {
            var user = await _userManager.FindByNameAsync(userViewModel.Username);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, userViewModel.Password, true, false);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Profile));
                }
            }

            TempData["LoginAttempt"] = "FAILED";
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([Bind] UserRegisterViewModel userViewModel)
        {
            var user = new User
            {
                UserName = userViewModel.Username,
                Email = "",

            };

            var result = await _userManager.CreateAsync(user, userViewModel.Password);
            if (result.Succeeded)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, userViewModel.Password, true, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction(nameof(Profile));
                }
            }
            TempData["LoginAttempt"] = "FAILED";
            return RedirectToAction(nameof(Register));
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
