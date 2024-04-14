namespace Data.Implementation;

internal class Book : IBook
{
    public int BookId { get; }
    public string Title { get; set; }
    public float Fee { get; set; }

    public Book(int id, string title, float fee = 0f)
    {
        BookId = id;
        Title = title;
        Fee = fee;
    }
}
