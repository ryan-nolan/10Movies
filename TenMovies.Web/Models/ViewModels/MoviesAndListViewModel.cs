using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenMovies.Web.Models.MovieModels;

namespace TenMovies.Web.Models.ViewModels
{
    public class MoviesAndListViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public MovieList MovieList { get; set; }
    }
}
