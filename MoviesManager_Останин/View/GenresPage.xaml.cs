using System.Windows.Controls;

namespace MoviesManager_Останин.View
{
    public partial class GenresPage : Page
    {
        public GenresPage(object Context)
        {
            InitializeComponent();
            DataContext = Context;
        }
    }
}