using System;
using System.Collections.Generic;
using TenMovies.Web.Models.MovieModels;

namespace TenMovies.Web.Repositories
{
    public interface IMovieListRepository
    {
        IEnumerable<Movie> GetAllMoviesInMovieList(int movieListId);
        IEnumerable<MovieList> GetAllMoviesLists();
        IEnumerable<MovieList> GetAllListsForUser(Guid userGuid);

        void AddList(MovieList list);
        MovieList GetListById(int id);
        bool IsDuplicate(int movieId, int listId);
        MovieList GetListByMovieId(int movieId);
        MovieList DeleteListById(int movieListId);
        IEnumerable<MovieList> GetAllNonePrivateLists();
        bool IsFullList(int listId);
    }
}
