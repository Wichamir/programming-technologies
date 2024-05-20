namespace Data;

public interface IEvent
{
    public int EventId { get; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateTime OccurenceTime { get; set; }
}
