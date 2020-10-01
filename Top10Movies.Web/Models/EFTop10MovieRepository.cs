using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Top10Movies.Web.Models
{
    public class EFTop10MovieRepository : IMovieListRepository
    {
        public EFTop10MovieRepository()
        {

        }
        public IEnumerable<Movie> GetAllMoviesInTop10()
        {
            throw new NotImplementedException();
        }
    }
}
