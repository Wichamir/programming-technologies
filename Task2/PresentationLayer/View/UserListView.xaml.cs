using System.Windows.Controls;

namespace Presentation.View
{
    /// <summary>
    /// Interaction logic for UserListView.xaml
    /// </summary>
    public partial class UserListView : UserControl
    {
        public UserListView()
        {
            InitializeComponent();
            DataContext = new Presentation.ViewModel.UserListViewModel();
        }
    }
}
