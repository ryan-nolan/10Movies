using System.Collections.Generic;
using TenMovies.Web.Models.Core;

namespace TenMovies.Web.Models.ViewModels
{
    public class MoviesViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public string SearchTerm { get; set; }
    }
}
