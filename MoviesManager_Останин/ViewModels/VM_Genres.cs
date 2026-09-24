using MoviesManager_Останин.Classes;
using MoviesManager_Останин.Context;
using MoviesManager_Останин.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace MoviesManager_Останин.ViewModels
{
    public class VM_Genres : Notification
    {
        public MoviesContext moviesContext = new MoviesContext();
        public ObservableCollection<Genre> Genres { get; set; }

        public VM_Genres()
        {
            Genres = new ObservableCollection<Genre>(
                moviesContext.Genres.OrderBy(g => g.Name));
        }

        public RelayCommand OnAddGenre
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    var newGenre = new Genre { Name = "Новый жанр" };
                    Genres.Add(newGenre);
                    moviesContext.Genres.Add(newGenre);
                    moviesContext.SaveChanges();
                });
            }
        }
    }
}