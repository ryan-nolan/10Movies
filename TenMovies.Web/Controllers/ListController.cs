using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using TenMovies.Web.Models.MovieModels;
using TenMovies.Web.Models.User;
using TenMovies.Web.Models.ViewModels;
using TenMovies.Web.Repositories;
using TenMovies.Web.Services;

namespace TenMovies.Web.Controllers
{
    [Authorize]
    public class ListController : Controller
    {
        private readonly IMovieListRepository _efMovieListRepository;
        private readonly IMovieRepository _efMovieRepository;
        private readonly IMovieApiService _movieApiService;

        public ListController(IMovieListRepository efMovieListRepository, IMovieRepository efMovieRepository, IMovieApiService movieApiService)
        {
            _efMovieListRepository = efMovieListRepository;
            _efMovieRepository = efMovieRepository;
            _movieApiService = movieApiService;
        }

        public IActionResult CreateNewList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewList([Bind] MovieList list)
        {
            list.UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            list.OwnerUsername = User.FindFirstValue(ClaimTypes.Name);
            list.DateCreated = DateTime.Now;

            if (ModelState.IsValid)
            {
                _efMovieListRepository.AddList(list);
                return RedirectToAction("Profile", "User");
            }
            return View();
        }

        public IActionResult ViewList(int movieListId)
        {
            MoviesAndListViewModel moviesAndListView = new MoviesAndListViewModel
            {
                Movies = _efMovieListRepository.GetAllMoviesInMovieList(movieListId),
                MovieList = _efMovieListRepository.GetListById(movieListId)
            };

            if (moviesAndListView.MovieList.IsPrivate 
                && moviesAndListView.MovieList.UserId != Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return Forbid();
            }
            return View(moviesAndListView);
        }


        public async Task<IActionResult> AddMovieToList(int movieId)
        {
            var movie = await _movieApiService.GetMovieByIdAsync(movieId);
            return View(movie);
        }
    }
}
