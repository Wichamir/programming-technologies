namespace Data;

public interface IBook
{
    public int BookId { get; }
    public string Title { get; set; }
    public float Fee { get; set; }
    public int State { get; set; }
}
