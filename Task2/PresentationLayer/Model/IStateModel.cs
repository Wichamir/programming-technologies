namespace Presentation.Model;

public interface IState
{
    public int BookId { get; }
    public int Quantity { get; set; }
}
