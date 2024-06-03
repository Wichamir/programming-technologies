using Service;

namespace Presentation.ViewModel
{
    internal class BookListViewModel : ViewModel<Model.Book>
    {
        public BookListViewModel() { }

        public BookListViewModel(IServiceApi serviceApi) : base(serviceApi)
        {
        }
    }
}
