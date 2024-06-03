using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Service;

namespace PresentationTests
{
    public class TestService : IServiceApi
    {
        private Dictionary<int, string> users;
        private Dictionary<int, Tuple<int, int, DateTime>> events;
        private Dictionary<int, Tuple<string, int, float>> books;

        public TestService()
        {
            users = new Dictionary<int, string>();
            events = new Dictionary<int, Tuple<int, int, DateTime>>();
            books = new Dictionary<int, Tuple<string, int, float>>();
        }

        public void AddUser(int userId, string firstName, string lastName)
        {
            string fullName = $"{firstName} {lastName}";
            users.Add(userId, fullName);
        }

        public void RemoveUser(int userId)
        {
            users.Remove(userId);
        }

        public void UpdateUser(int userId, string firstName, string lastName)
        {
            if (users.ContainsKey(userId))
            {
                string fullName = $"{firstName} {lastName}";
                users[userId] = fullName;
            }
        }

        public void AddEvent(int eventId, int userId, int bookId, DateTime occurrenceTime)
        {
            Tuple<int, int, DateTime> eventData = new Tuple<int, int, DateTime>(userId, bookId, occurrenceTime);
            events.Add(eventId, eventData);
        }

        public void RemoveEvent(int eventId)
        {
            events.Remove(eventId);
        }

        public void UpdateEvent(int eventId, int userId, int bookId, DateTime occurrenceTime)
        {
            if (events.ContainsKey(eventId))
            {
                Tuple<int, int, DateTime> eventData = new Tuple<int, int, DateTime>(userId, bookId, occurrenceTime);
                events[eventId] = eventData;
            }
        }

        public void AddBook(int bookId, string title, int state, float fee = 0f)
        {
            Tuple<string, int, float> bookData = new Tuple<string, int, float>(title, state, fee);
            books.Add(bookId, bookData);
        }

        public void RemoveBook(int bookId)
        {
            books.Remove(bookId);
        }

        public void UpdateBook(int bookId, string title, int state, float fee)
        {
            if (books.ContainsKey(bookId))
            {
                Tuple<string, int, float> bookData = new Tuple<string, int, float>(title, state, fee);
                books[bookId] = bookData;
            }
        }

        public string GetUserFirstName(int userId)
        {
            if (users.ContainsKey(userId))
            {
                string fullName = users[userId];
                string[] nameParts = fullName.Split(' ');
                return nameParts[0];
            }
            return null;
        }

        public string GetUserLastName(int userId)
        {
            if (users.ContainsKey(userId))
            {
                string fullName = users[userId];
                string[] nameParts = fullName.Split(' ');
                return nameParts[1];
            }
            return null;
        }

        public int GetEventUserId(int eventId)
        {
            if (events.ContainsKey(eventId))
            {
                Tuple<int, int, DateTime> eventData = events[eventId];
                return eventData.Item1;
            }
            return -1;
        }

        public int GetEventBookId(int eventId)
        {
            if (events.ContainsKey(eventId))
            {
                Tuple<int, int, DateTime> eventData = events[eventId];
                return eventData.Item2;
            }
            return -1;
        }

        public DateTime GetOccuranceTime(int eventId)
        {
            if (events.ContainsKey(eventId))
            {
                Tuple<int, int, DateTime> eventData = events[eventId];
                return eventData.Item3;
            }
            return DateTime.MinValue;
        }

        public string GetBookTitle(int bookId)
        {
            if (books.ContainsKey(bookId))
            {
                Tuple<string, int, float> bookData = books[bookId];
                return bookData.Item1;
            }
            return null;
        }

        public float GetBookFee(int bookId)
        {
            if (books.ContainsKey(bookId))
            {
                Tuple<string, int, float> bookData = books[bookId];
                return bookData.Item3;
            }
            return 0f;
        }

        public int GetBookState(int bookId)
        {
            if (books.ContainsKey(bookId))
            {
                Tuple<string, int, float> bookData = books[bookId];
                return bookData.Item2;
            }
            return -1;
        }
    }
}
