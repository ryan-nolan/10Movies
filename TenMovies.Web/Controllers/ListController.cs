﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using TenMovies.Web.Models.MovieModels;
using TenMovies.Web.Models.User;
using TenMovies.Web.Repositories;

namespace TenMovies.Web.Controllers
{
    [Authorize]
    public class ListController : Controller
    {
        private readonly IMovieListRepository _efMovieListRepository;

        public ListController(IMovieListRepository efMovieListRepository)
        {
            _efMovieListRepository = efMovieListRepository;
        }
        public IActionResult CreateNewList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewList([Bind] MovieList list)
        {
            list.UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (ModelState.IsValid)
            {
                _efMovieListRepository.AddList(list);
                return RedirectToAction("Profile", "User");
            }
            return View();
        }
    }
}