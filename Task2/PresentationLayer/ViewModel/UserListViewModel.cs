using Service;

namespace Presentation.ViewModel
{
    internal class UserListViewModel : ViewModel<Model.User>
    {
        public UserListViewModel() { }

        public UserListViewModel(IServiceApi serviceApi) : base(serviceApi)
        {
        }
    }
}
