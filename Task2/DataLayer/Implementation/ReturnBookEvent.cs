namespace Data.Implementation;

internal class ReturnBookEvent : IEvent
{
    public int EventId { get; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateTime OccurenceTime { get; }
    
    public ReturnBookEvent(int eid, int uid, int bid, DateTime time)
    {
        EventId = eid;
        UserId = uid;
        BookId = bid;
        OccurenceTime = time;
    }
}
