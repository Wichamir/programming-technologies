using Service;
using System.Windows.Controls;

namespace Presentation.View
{
    /// <summary>
    /// Interaction logic for BookListView.xaml
    /// </summary>
    public partial class BookListView : UserControl
    {
        public BookListView()
        {
            InitializeComponent();
            DataContext = new ViewModel.BookListViewModel();
        }
    }
}
