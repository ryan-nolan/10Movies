using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Top10Movies.Web.Models.ViewModels
{
    public class Top10MoviesListViewModel
    {
        public MovieList Top10MoviesList { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
