using MoviesManager_Останин.ViewModels;
using System.Windows;

namespace MoviesManager_Останин
{
    public partial class MainWindow : Window
    {
        public static MainWindow init;

        public MainWindow()
        {
            InitializeComponent();
            init = this;
            DataContext = new VM_Pages();
        }
    }
}