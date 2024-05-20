using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Data;

namespace ServiceTests
{
    internal class TestDataService : Service.IServiceApi
    {
        private List<IUser> users;
        private List<IEvent> events;
        private List<IBook> books;

        public TestDataService()
        {
            users = new List<IUser>();
            events = new List<IEvent>();
            books = new List<IBook>();
        }

        public void AddUser(int userId, string firstName, string lastName)
        {
            IUser user = new TestUser(userId, firstName, lastName);
            users.Add(user);
        }

        public void RemoveUser(int userId)
        {
            IUser user = users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                users.Remove(user);
            }
        }

        public IUser? GetUser(int userId)
        {
            return users.FirstOrDefault(u => u.UserId == userId);
        }

        public void AddEvent(int eventId, int userId, int bookId, DateTime occurrenceTime)
        {
            IEvent evnt = new TestEvent(eventId, userId, bookId, occurrenceTime);
            events.Add(evnt);
        }

        public void RemoveEvent(int eventId)
        {
            IEvent evnt = events.FirstOrDefault(e => e.EventId == eventId);
            if (evnt != null)
            {
                events.Remove(evnt);
            }
        }

        public IEvent? GetEvent(int eventId)
        {
            return events.FirstOrDefault(e => e.EventId == eventId);
        }

        public void AddBook(int bookId, string title, int state, float fee = 0f)
        {
            IBook book = new TestBook(bookId, title, state, fee);
            books.Add(book);
        }

        public void RemoveBook(int bookId)
        {
            IBook book = books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
            {
                books.Remove(book);
            }
        }

        public IBook? GetBook(int bookId)
        {
            return books.FirstOrDefault(b => b.BookId == bookId);
        }
    }

    internal class TestUser : IUser
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

    internal class TestEvent : IEvent
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

    internal class TestBook : IBook
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
