using MoviesManager_Останин.Classes;
using System.Collections.Generic;
using System.Linq;

namespace MoviesManager_Останин.Models
{
    public class Movie : Notification
    {
        public int Id { get; set; }

        private string title;
        public string Title
        {
            get => title;
            set { title = value; OnPropertyChanged(); }
        }

        private int year;
        public int Year
        {
            get => year;
            set { year = value; OnPropertyChanged(); }
        }

        private string description;
        public string Description
        {
            get => description;
            set { description = value; OnPropertyChanged(); }
        }

        public List<Genre> Genres { get; set; } = new List<Genre>();

        public string GenresDisplay
        {
            get
            {
                if (Genres == null || Genres.Count == 0) return "—";
                return string.Join(", ", Genres.Select(g => g.Name));
            }
        }

        public void RefreshGenres()
        {
            OnPropertyChanged(nameof(GenresDisplay));
        }
    }
}