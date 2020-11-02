using Microsoft.EntityFrameworkCore;
using Top10Movies.Web.Models.Core;

namespace Top10Movies.Web.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieList> MovieLists { get; set; }
    }
}
