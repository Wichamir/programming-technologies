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
        ServiceApi = IServiceApi.CreateDataService("");
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
        ServiceApi.UpdateBook(BookId, Title, State, Fee);
    }
}
