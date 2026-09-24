using Microsoft.EntityFrameworkCore;
using MoviesManager_Останин.Classes;
using MoviesManager_Останин.Context;
using MoviesManager_Останин.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace MoviesManager_Останин.ViewModels
{
    public class VM_Movies : Notification
    {
        public MoviesContext moviesContext = new MoviesContext();
        public ObservableCollection<Movie> Movies { get; set; }

        public VM_Movies()
        {
            Movies = new ObservableCollection<Movie>(
                moviesContext.Movies.Include(m => m.Genre).OrderBy(m => m.Title));
        }

        public RelayCommand OnAddMovie
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    var newMovie = new Movie
                    {
                        Title = "Новый фильм",
                        Year = 2024,
                        Description = "Описание",
                        GenreId = 1
                    };
                    Movies.Add(newMovie);
                    moviesContext.Movies.Add(newMovie);
                    moviesContext.SaveChanges();
                });
            }
        }
    }
}