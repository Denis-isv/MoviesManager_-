namespace MoviesManager_Останин.Models
{
    public class Genre : Classes.Notification
    {
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }
    }
}