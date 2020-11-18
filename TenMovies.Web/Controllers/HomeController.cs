using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TenMovies.Web.Models.ViewModels;
using TenMovies.Web.Repositories;
using TenMovies.Web.Services;

namespace TenMovies.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieApiService _movieApiService;
        private readonly IMovieListRepository _movieListRepository;

        public HomeController(ILogger<HomeController> logger, IMovieApiService movieApiService, IMovieListRepository movieListRepository)
        {
            _logger = logger;
            _movieApiService = movieApiService;
            _movieListRepository = movieListRepository;
        }

        public IActionResult Index()
        {
            return View(_movieListRepository.GetAllNonePrivateLists());
        }

        public IActionResult Movies(string searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                MoviesViewModel viewModel = new MoviesViewModel
                {
                    Movies = _movieApiService.GetMoviesBySearchTermAsync(searchTerm).Result.OrderByDescending(m => m.Popularity),
                    SearchTerm = searchTerm
                };
                return View(viewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
