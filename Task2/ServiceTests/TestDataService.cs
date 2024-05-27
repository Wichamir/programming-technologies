using Service;

namespace ServiceTests
{
    internal class TestDataService : IServiceApi
    {
        private List<TestUser> users;
        private List<TestEvent> events;
        private List<TestBook> books;

        public TestDataService()
        {
            users = new List<TestUser>();
            events = new List<TestEvent>();
            books = new List<TestBook>();
        }

        public void AddUser(int userId, string firstName, string lastName)
        {
            TestUser user = new TestUser(userId, firstName, lastName);
            users.Add(user);
        }

        public void RemoveUser(int userId)
        {
            TestUser user = users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                users.Remove(user);
            }
        }

        public void AddEvent(int eventId, int userId, int bookId, DateTime occurrenceTime)
        {
            TestEvent evnt = new TestEvent(eventId, userId, bookId, occurrenceTime);
            events.Add(evnt);
        }

        public void RemoveEvent(int eventId)
        {
            TestEvent evnt = events.FirstOrDefault(e => e.EventId == eventId);
            if (evnt != null)
            {
                events.Remove(evnt);
            }
        }

        public void AddBook(int bookId, string title, int state, float fee = 0f)
        {
            TestBook book = new TestBook(bookId, title, state, fee);
            books.Add(book);
        }

        public void RemoveBook(int bookId)
        {
            TestBook book = books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
            {
                books.Remove(book);
            }
        }

        public string GetUserFirstName(int userId)
        {
            TestUser user = users.FirstOrDefault(u => u.UserId == userId);
            return user?.FirstName ?? string.Empty;
        }

        public string GetUserLastName(int userId)
        {
            TestUser user = users.FirstOrDefault(u => u.UserId == userId);
            return user?.LastName ?? string.Empty;
        }

        public int GetEventUserId(int eventId)
        {
            TestEvent evnt = events.FirstOrDefault(e => e.EventId == eventId);
            return evnt?.UserId ?? 0;
        }

        public int GetEventBookId(int eventId)
        {
            TestEvent evnt = events.FirstOrDefault(e => e.EventId == eventId);
            return evnt?.BookId ?? 0;
        }

        public DateTime GetOccuranceTime(int eventId)
        {
            TestEvent evnt = events.FirstOrDefault(e => e.EventId == eventId);
            return evnt?.OccurenceTime ?? DateTime.MinValue;
        }

        public string GetBookTitle(int bookId)
        {
            TestBook book = books.FirstOrDefault(b => b.BookId == bookId);
            return book?.Title ?? string.Empty;
        }

        public float GetBookFee(int bookId)
        {
            TestBook book = books.FirstOrDefault(b => b.BookId == bookId);
            return book?.Fee ?? 0f;
        }

        public int GetBookState(int bookId)
        {
            TestBook book = books.FirstOrDefault(b => b.BookId == bookId);
            return book?.State ?? 0;
        }

        public void UpdateUser(int userId, string firstName, string lastName)
        {
            TestUser user = users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                user.FirstName = firstName;
                user.LastName = lastName;
            }
        }

        public void UpdateEvent(int eventId, int userId, int bookId, DateTime occurrenceTime)
        {
            TestEvent evnt = events.FirstOrDefault(e => e.EventId == eventId);
            if (evnt != null)
            {
                evnt.UserId = userId;
                evnt.BookId = bookId;
                evnt.OccurenceTime = occurrenceTime;
            }
        }

        public void UpdateBook(int bookId, string title, int state, float fee)
        {
            TestBook book = books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
            {
                book.Title = title;
                book.State = state;
                book.Fee = fee;
            }
        }
    }

    internal class TestUser
    {
        public int UserId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public TestUser(int userId, string firstName, string lastName)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }
    }

    internal class TestEvent
    {
        public int EventId { get; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime OccurenceTime { get; set; }

        public TestEvent(int eventId, int userId, int bookId, DateTime occurrenceTime)
        {
            EventId = eventId;
            UserId = userId;
            BookId = bookId;
            OccurenceTime = occurrenceTime;
        }
    }

    internal class TestBook
    {
        public int BookId { get; }
        public string Title { get; set; }
        public float Fee { get; set; }
        public int State { get; set; }

        public TestBook(int bookId, string title, int state, float fee)
        {
            BookId = bookId;
            Title = title;
            State = state;
            Fee = fee;
        }
    }
}
