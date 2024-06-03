using Service;

namespace Presentation.ViewModel
{
    internal class EventListViewModel : ViewModel<Model.Event>
    {
        public EventListViewModel() { }

        public EventListViewModel(IServiceApi serviceApi) : base(serviceApi)
        {
        }
    }
}
