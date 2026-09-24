using MoviesManager_Останин.Classes;
using MoviesManager_Останин.Models;
using MoviesManager_Останин.View;
using System.Collections.ObjectModel;

namespace MoviesManager_Останин.ViewModels
{
    public class VM_Movies : Notification
    {
        private VM_Pages parent;

        public VM_Movies(VM_Pages parent)
        {
            this.parent = parent;
        }

        public ObservableCollection<Movie> Movies => parent.Movies;

        public RelayCommand OnAddMovie
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    var movie = new Movie
                    {
                        Title = "Новый фильм",
                        Year = 2024,
                        Description = "Описание"
                    };
                    parent.db.Movies.Add(movie);
                    parent.db.SaveChanges();
                    parent.Movies.Add(movie);
                });
            }
        }

        public RelayCommand OnEditMovie
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (obj is Movie movie)
                    {
                        MainWindow.init.frame.Navigate(new MovieEditPage(new VM_MovieEdit(parent, movie)));
                    }
                });
            }
        }

        public RelayCommand OnDeleteMovie
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (obj is Movie movie)
                    {
                        parent.db.Movies.Remove(movie);
                        parent.db.SaveChanges();
                        parent.Movies.Remove(movie);
                    }
                });
            }
        }
    }
}