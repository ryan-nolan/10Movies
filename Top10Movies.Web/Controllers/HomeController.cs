using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Top10Movies.Web.Models.Services;
using Top10Movies.Web.Models.ViewModels;

namespace Top10Movies.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieApiService _movieApiService;

        public HomeController(ILogger<HomeController> logger, IMovieApiService movieApiService)
        {
            _logger = logger;
            _movieApiService = movieApiService;
        }

        public IActionResult Index() => View();
        
        public IActionResult Movies(string searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                MoviesViewModel viewModel = new MoviesViewModel()
                {
                    Movies = _movieApiService.GetMoviesBySearchTermAsync(searchTerm).Result,
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
