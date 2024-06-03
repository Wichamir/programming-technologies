using System;
using Service;

namespace Presentation.Model;

internal class Event : IEvent
{
    public IServiceApi ServiceApi { get; set; }
    public int EventId { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateTime OccurenceTime { get; set; }

    public Event()
    {
        ServiceApi = IServiceApi.CreateDataService("");
    }

    public Event(IServiceApi serviceApi, int eid, int uid, int bid, DateTime time)
    {
        EventId = eid;
        UserId = uid;
        BookId = bid;
        OccurenceTime = time;
        ServiceApi = serviceApi;
    }

    public void Add()
    {
        ServiceApi.AddEvent(EventId, UserId, BookId, OccurenceTime);
    }

    public void Remove()
    {
        ServiceApi.RemoveEvent(EventId);
    }

    public void Update()
    {
        ServiceApi.UpdateEvent(EventId, UserId, BookId, OccurenceTime);
    }
}
