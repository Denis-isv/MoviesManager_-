using Microsoft.EntityFrameworkCore;
using MoviesManager_Останин.Classes;
using MoviesManager_Останин.Models;
using System.Linq;

namespace MoviesManager_Останин.Context
{
    public class MoviesContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        private static bool _seeded = false;

        public MoviesContext()
        {
            Database.EnsureCreated();

            if (!_seeded)
            {
                if (!Genres.Any())
                {
                    Genres.AddRange(
                        new Genre { Name = "Комедия" },
                        new Genre { Name = "Драма" },
                        new Genre { Name = "Боевик" },
                        new Genre { Name = "Фантастика" }
                    );
                    SaveChanges();
                }
                _seeded = true;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.connection, ServerVersion.Parse(Config.version));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Genres)
                .WithMany(g => g.Movies)
                .UsingEntity(j => j.ToTable("MovieGenres"));
        }
    }
}