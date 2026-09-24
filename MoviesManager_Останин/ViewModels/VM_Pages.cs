using MoviesManager_Останин.Classes;
using MoviesManager_Останин.View;

namespace MoviesManager_Останин.ViewModels
{
    public class VM_Pages : Notification
    {
        public VM_Movies vm_movies { get; set; }
        public VM_Genres vm_genres { get; set; }

        public VM_Pages()
        {
            vm_movies = new VM_Movies();
            vm_genres = new VM_Genres();

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