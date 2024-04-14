namespace Data;

public interface IEvent
{
    public int EventId { get; }
    public int UserId { get; }
    public int BookId { get; }
    public DateTime OccurenceTime { get; }
}