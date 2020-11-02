using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top10Movies.Web.Models.Core;

namespace Top10Movies.Web.Models.ViewModels
{
    public class MoviesViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public string SearchTerm { get; set; }
    }
}
