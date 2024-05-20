namespace Presentation.Model;

public interface IBook : IModel
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public float Fee { get; set; }
    public int State { get; set; }

    public void Add();
    public void Remove();
    public void Update();
}
