using TenMovies.Web.Models.MovieModels;

namespace TenMovies.Web.Repositories
{
    public interface IMovieRepository
    {
        Movie GetMovieById(int id);
        Movie CreateMovie(Movie m);
        Movie DeleteMovieById(int id);
        Movie DeleteMovie(Movie m);
        int SaveChanges();

    }
}
