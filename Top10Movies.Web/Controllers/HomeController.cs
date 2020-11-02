using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Top10Movies.Web.Models;
using Top10Movies.Web.Models.Core;
using Top10Movies.Web.Models.Services;
using Top10Movies.Web.Models.ViewModels;

namespace Top10Movies.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IMovieListRepository _top10MoviesRepository;
        private readonly IMovieApiService _movieRepository;

        public HomeController(ILogger<HomeController> logger, IMovieApiService movieRepository)
        {
            _logger = logger;
            //_top10MoviesRepository = repository;
            _movieRepository = movieRepository;
        }

        public IActionResult Index(string searchTerm)
        {
            Top10MoviesListViewModel ViewModel = null;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                ViewModel = new Top10MoviesListViewModel()
                {
                    Movies = _movieRepository.GetMoviesBySearchTerm(searchTerm).Result
                    //Movie = _movieRepository.GetMovieByImdbId("tt13143964").Result
                };
            }

            return View(ViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
