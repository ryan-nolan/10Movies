using Microsoft.EntityFrameworkCore;
using TenMovies.Web.Models.MovieModels;

namespace TenMovies.Web.Data
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
