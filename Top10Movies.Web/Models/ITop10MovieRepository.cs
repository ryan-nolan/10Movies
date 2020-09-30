using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Top10Movies.Web.Models
{
    public interface ITop10MovieRepository
    {
        IEnumerable<Movie> GetAllMoviesInTop10();
    }
}
