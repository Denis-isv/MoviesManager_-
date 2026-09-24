using MoviesManager_Останин.Classes;
using MoviesManager_Останин.Models;
using MoviesManager_Останин.View;
using System.Collections.ObjectModel;
using System.Linq;

namespace MoviesManager_Останин.ViewModels
{
    public class VM_MovieEdit : Notification
    {
        private VM_Pages parent;

        public Movie Movie { get; set; }
        public ObservableCollection<GenreSelection> GenreSelections { get; set; }

        public VM_MovieEdit(VM_Pages parent, Movie movie)
        {
            this.parent = parent;
            this.Movie = movie;

            GenreSelections = new ObservableCollection<GenreSelection>();
            foreach (var g in parent.Genres)
            {
                GenreSelections.Add(new GenreSelection
                {
                    Genre = g,
                    IsSelected = movie.Genres.Any(mg => mg.Id == g.Id)
                });
            }
        }

        public RelayCommand OnSave
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Movie.Genres.Clear();
                    foreach (var sel in GenreSelections.Where(s => s.IsSelected))
                    {
                        var g = parent.Genres.First(x => x.Id == sel.Genre.Id);
                        Movie.Genres.Add(g);
                    }

                    Movie.RefreshGenres();
                    parent.db.SaveChanges();

                    MainWindow.init.frame.Navigate(new MoviesPage(parent.vm_movies));
                });
            }
        }

        public RelayCommand OnCancel
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    MainWindow.init.frame.Navigate(new MoviesPage(parent.vm_movies));
                });
            }
        }
    }

    public class GenreSelection : Notification
    {
        public Genre Genre { get; set; }

        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set { isSelected = value; OnPropertyChanged(); }
        }
    }
}