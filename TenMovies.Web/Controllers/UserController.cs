using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TenMovies.Web.Models.Core.User;

namespace TenMovies.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Users()
        {
            var users = new User();
            return View(users.GetUsers());
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind] User user)
        {
            // username = anet  
            var users = new User();
            var allUsers = users.GetUsers().FirstOrDefault();
            //var dbUser = users.GetUsers().Any(u => u.Username == user.Username);

            if (users.GetUsers().Any(u => u.Username == user.Username))
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, users.GetUsers().First(u => u.Username == user.Username).EmailId),
                };

                var cookieAuthIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { cookieAuthIdentity });
                await HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(); 
            return RedirectToAction("Index", new RouteValueDictionary(new { area = "", controller = "Home", action = "Index" })); }
        }
    }
