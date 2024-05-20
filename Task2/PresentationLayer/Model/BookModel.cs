using Service;

namespace Presentation.Model;

internal class Book : IBook
{
    public IServiceApi ServiceApi { get; set; }
    public int BookId { get; set; }
    public string Title { get; set; }
    public float Fee { get; set; }
    public int State { get; set; }

    public Book()
    {
    }

    public Book(IServiceApi serviceApi)
    {
        ServiceApi = serviceApi;
    }

    public void Add()
    {
        ServiceApi.AddBook(BookId, Title, State, Fee);
    }

    public void Remove()
    {
        ServiceApi.RemoveBook(BookId);
    }

    public void Update()
    {
        var book = ServiceApi.GetBook(BookId);
        book.Title = Title;
        book.Fee = Fee;
        book.State = State;
    }
}
