using System;

namespace Presentation.Model;

public interface IEvent : IModel
{
    public int EventId { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateTime OccurenceTime { get; set; }
}
