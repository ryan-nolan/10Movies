using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using TenMovies.Web.Models;
using TenMovies.Web.Models.Entities;
using TenMovies.Web.Models.Services;
using TenMovies.Web.Models.ViewModels;

namespace TenMovies.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View(new UserCredentials());
        }
        [HttpPost]
        public IActionResult Index(UserCredentials user)
        {
            var authResponse = _userService.Authenticate(new AuthenticateRequest
            {
                Username = user.Username,
                Password = user.Password
            });

            if (authResponse?.Token == null)
                return Unauthorized();
            return Ok(authResponse.Token);
        }
    }
}
