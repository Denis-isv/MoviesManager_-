using System;
using System.Windows.Controls;
using System.Windows.Threading;
using MoviesManager_Останин.ViewModels;

namespace MoviesManager_Останин.View
{
    public partial class MoviesPage : Page
    {
        public MoviesPage(object Context)
        {
            InitializeComponent();
            DataContext = Context;
        }

        private void MoviesGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                // SaveChanges после того, как DataGrid завершит обновление привязок
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var vm = DataContext as VM_Movies;
                    vm?.moviesContext.SaveChanges();
                }), DispatcherPriority.Background);
            }
        }
    }
}