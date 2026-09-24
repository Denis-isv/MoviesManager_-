using System.ComponentModel.DataAnnotations.Schema;
using MoviesManager_Останин.Classes;

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

        public int GenreId { get; set; }

        private Genre genre;
        public Genre Genre
        {
            get => genre;
            set { genre = value; OnPropertyChanged(); }
        }
    }
}