using System;

namespace Presentation.Model;

internal class RentBookEvent : IEvent
{
    public int EventId { get; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateTime OccurenceTime { get; }

    public RentBookEvent(int eid, int uid, int bid, DateTime time)
    {
        EventId = eid;
        UserId = uid;
        BookId = bid;
        OccurenceTime = time;
    }
}
