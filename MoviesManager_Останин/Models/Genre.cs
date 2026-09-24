using MoviesManager_Останин.Classes;
using System.Collections.Generic;

namespace MoviesManager_Останин.Models
{
    public class Genre : Notification
    {
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }

        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}