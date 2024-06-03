using Service;
using System.Windows.Controls;

namespace Presentation.View
{
    /// <summary>
    /// Interaction logic for EventListView.xaml
    /// </summary>
    public partial class EventListView : UserControl
    {
        public EventListView()
        {
            InitializeComponent();
            DataContext = new ViewModel.EventListViewModel();
        }
    }
}
