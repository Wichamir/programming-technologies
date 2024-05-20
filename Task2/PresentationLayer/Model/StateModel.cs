namespace Presentation.Model;

internal class State : IState
{
    public int BookId { get; }
    public int Quantity { get; set; }

    public State() { }

    public State(int bid, int quantity)
    {
        BookId = bid;
        Quantity = quantity;
    }
}