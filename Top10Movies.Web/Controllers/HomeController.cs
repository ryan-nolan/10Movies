using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Top10Movies.Web.Models;
using Top10Movies.Web.Models.ViewModels;

namespace Top10Movies.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITop10MovieRepository _top10MoviesRepository;

        public HomeController(ILogger<HomeController> logger, ITop10MovieRepository repository)
        {
            _logger = logger;
            _top10MoviesRepository = repository;
        }

        public IActionResult Index(int ListId)
        {
            var ViewModel = new Top10MoviesListViewModel()
            {
                Movies = _top10MoviesRepository.GetAllMoviesInTop10() as List<Movie>
            };

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
