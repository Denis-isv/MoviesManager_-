using System.Windows.Controls;

namespace MoviesManager_Останин.View
{
    public partial class MoviesPage : Page
    {
        public MoviesPage(object Context)
        {
            InitializeComponent();
            DataContext = Context;
        }
    }
}