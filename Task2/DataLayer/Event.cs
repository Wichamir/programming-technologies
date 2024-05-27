using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal partial class Event
    {
        public Event(int eventId, int userId, int bookId, DateTime occuranceTime)
        {
            EventId = eventId;
            UserId = userId;
            BookId = bookId;
            OccuranceTime = occuranceTime;
        }
    }
}
