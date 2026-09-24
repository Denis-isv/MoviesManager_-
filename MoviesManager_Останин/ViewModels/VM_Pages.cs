using Microsoft.EntityFrameworkCore;
using MoviesManager_Останин.Classes;
using MoviesManager_Останин.Context;
using MoviesManager_Останин.Models;
using MoviesManager_Останин.View;
using System.Collections.ObjectModel;
using System.Linq;

namespace MoviesManager_Останин.ViewModels
{
    public class VM_Pages : Notification
    {
        public MoviesContext db = new MoviesContext();

        public ObservableCollection<Movie> Movies { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }

        public VM_Movies vm_movies { get; set; }
        public VM_Genres vm_genres { get; set; }

        public VM_Pages()
        {
            Genres = new ObservableCollection<Genre>(db.Genres.OrderBy(g => g.Name).ToList());
            Movies = new ObservableCollection<Movie>(db.Movies.Include(m => m.Genres).OrderBy(m => m.Title).ToList());

            vm_movies = new VM_Movies(this);
            vm_genres = new VM_Genres(this);

            MainWindow.init.frame.Navigate(new MoviesPage(vm_movies));
        }

        public RelayCommand OnShowMovies
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    MainWindow.init.frame.Navigate(new MoviesPage(vm_movies));
                });
            }
        }

        public RelayCommand OnShowGenres
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    MainWindow.init.frame.Navigate(new GenresPage(vm_genres));
                });
            }
        }
    }
}