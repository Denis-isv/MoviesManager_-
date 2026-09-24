using System.Windows.Controls;

namespace MoviesManager_Останин.View
{
    public partial class MovieEditPage : Page
    {
        public MovieEditPage(object Context)
        {
            InitializeComponent();
            DataContext = Context;
        }
    }
}