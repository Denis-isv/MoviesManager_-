using Microsoft.EntityFrameworkCore;
using MoviesManager_Останин.Classes;
using MoviesManager_Останин.Models;

namespace MoviesManager_Останин.Context
{
    public class MoviesContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public MoviesContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.connection, ServerVersion.Parse(Config.version));
        }
    }
}