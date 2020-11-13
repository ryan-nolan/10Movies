using TenMovies.Web.Models.MovieModels;

namespace TenMovies.Web.Repositories
{
    public interface IMovieRepository
    {
        Movie GetMovieById(int id);
        Movie AddMovie(Movie m);
        Movie DeleteMovieById(int id);
        Movie DeleteMovie(Movie m);

    }
}
