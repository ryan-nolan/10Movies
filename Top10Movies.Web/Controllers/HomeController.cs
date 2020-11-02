using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Top10Movies.Web.Models.Clients;
using Top10Movies.Web.Models.ViewModels;

namespace Top10Movies.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieApiClient _movieApiClient;

        public HomeController(ILogger<HomeController> logger, IMovieApiClient movieApiClient)
        {
            _logger = logger;
            _movieApiClient = movieApiClient;
        }

        public IActionResult Index(string searchTerm)
        {
            Top10MoviesListViewModel ViewModel = null;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                ViewModel = new Top10MoviesListViewModel()
                {
                    Movies = _movieApiClient.GetMoviesBySearchTermAsync(searchTerm).Result
                    //Movie = _movieRepository.GetMovieByImdbIdAsync("tt13143964").Result
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
