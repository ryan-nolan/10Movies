using System.Linq;
using System.Threading.Tasks;
using TenMovies.Web.Models.Core;

namespace TenMovies.Web.Models.Clients
{
    public interface IMovieApiClient
    {
        Task<Movie> GetMovieByIdAsync(int? id);
        Task<Movie> GetMovieByImdbIdAsync(string imdbId);
        Task<IQueryable<Movie>> GetMoviesBySearchTermAsync(string searchTerm);
    }
}
