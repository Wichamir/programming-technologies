namespace Data.Implementation;

internal class Book : IBook
{
    public int BookId { get; }
    public string Title { get; set; }
    public float Fee { get; set; }
    public int State { get; set; }

    public Book(int id, string title, int state, float fee = 0f)
    {
        BookId = id;
        Title = title;
        State = state;
        Fee = fee;
    }
}
