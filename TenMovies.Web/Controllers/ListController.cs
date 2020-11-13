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
            AddMovieToListViewModel addMovieToListViewModel = new AddMovieToListViewModel
            {
                MovieToAdd = await _movieApiService.GetMovieByIdAsync(movieId),
                UsersMovieLists =
                    _efMovieListRepository.GetAllListsForUser(
                        Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))),
            };
            return View(addMovieToListViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieToList([Bind] AddMovieToListViewModel movieToListViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_efMovieListRepository.IsDuplicate(movieToListViewModel.MovieId, movieToListViewModel.ListId))
                {
                    TempData["FailMessage"] = "This movie is already in the list";
                    return View(new AddMovieToListViewModel
                    {
                        MovieToAdd = await _movieApiService.GetMovieByIdAsync(movieToListViewModel.MovieId),
                        UsersMovieLists =
                            _efMovieListRepository.GetAllListsForUser(
                                Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))),
                    });
                }
                Movie m = await _movieApiService.GetMovieByIdAsync(movieToListViewModel.MovieId);
                m.MovieListId = movieToListViewModel.ListId;
                _efMovieRepository.AddMovie(m);
                return RedirectToAction("ViewList", "List", new { movieListId = movieToListViewModel.ListId });//Eventually redirect to their own list 
            }
            TempData["FailMessage"] = "MovieAddAttemptFailed";
            return View(new AddMovieToListViewModel
            {

                MovieToAdd = await _movieApiService.GetMovieByIdAsync(movieToListViewModel.MovieId),
                UsersMovieLists =
                    _efMovieListRepository.GetAllListsForUser(
                        Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))),
            });
        }
    }
}
