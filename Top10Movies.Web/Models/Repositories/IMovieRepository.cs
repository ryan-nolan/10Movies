using Top10Movies.Web.Models.Core;

namespace Top10Movies.Web.Models.Repositories
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
