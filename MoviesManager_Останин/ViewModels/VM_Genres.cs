using MoviesManager_Останин.Classes;
using MoviesManager_Останин.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace MoviesManager_Останин.ViewModels
{
    public class VM_Genres : Notification
    {
        private VM_Pages parent;

        public VM_Genres(VM_Pages parent)
        {
            this.parent = parent;
        }

        public ObservableCollection<Genre> Genres => parent.Genres;

        public RelayCommand OnAddGenre
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    var genre = new Genre { Name = "Новый жанр" };
                    parent.db.Genres.Add(genre);
                    parent.db.SaveChanges();
                    parent.Genres.Add(genre);
                });
            }
        }

        public RelayCommand OnDeleteGenre
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (obj is Genre genre)
                    {
                        foreach (var movie in parent.Movies.ToList())
                        {
                            if (movie.Genres.Any(g => g.Id == genre.Id))
                            {
                                var toRemove = movie.Genres.First(g => g.Id == genre.Id);
                                movie.Genres.Remove(toRemove);
                                movie.RefreshGenres();
                            }
                        }

                        parent.db.Genres.Remove(genre);
                        parent.db.SaveChanges();
                        parent.Genres.Remove(genre);
                    }
                });
            }
        }
    }
}