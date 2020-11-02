using System.Linq;
using System.Threading.Tasks;
using Top10Movies.Web.Models.Core;

namespace Top10Movies.Web.Models.Services
{
    public interface IMovieApiService
    {
        Task<Movie> GetMovieByIdAsync(int? id);
        Task<Movie> GetMovieByImdbIdAsync(string imdbId);
        Task<IQueryable<Movie>> GetMoviesBySearchTermAsync(string searchTerm);
    }
}