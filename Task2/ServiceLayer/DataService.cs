using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;

namespace Service
{
    internal class DataService : IServiceApi
    {
        private readonly IDataApi dataApi;

        public DataService(IDataApi dataApi)
        {
            this.dataApi = dataApi;
        }

        public void AddUser(int userId, string firstName, string lastName)
        {
            dataApi.AddUser(userId, firstName, lastName);
        }

        public void RemoveUser(int userId)
        {
            dataApi.RemoveUser(userId);
        }

        public void AddEvent(int eventId, int userId, int bookId, DateTime occurrenceTime)
        {
            dataApi.AddEvent(eventId, userId, bookId, occurrenceTime);
        }

        public void RemoveEvent(int eventId)
        {
            dataApi.RemoveEvent(eventId);
        }

        public void AddBook(int bookId, string title, int state, float fee = 0f)
        {
            dataApi.AddBook(bookId, title, state, fee);
        }

        public void RemoveBook(int bookId)
        {
            dataApi.RemoveBook(bookId);
        }

        public string GetUserFirstName(int userId)
        {
            return dataApi.GetUserFirstName(userId);
        }

        public string GetUserLastName(int userId)
        {
            return dataApi.GetUserLastName(userId);
        }

        public int GetEventUserId(int eventId)
        {
            return dataApi.GetEventUserId(eventId);
        }

        public int GetEventBookId(int eventId)
        {
            return dataApi.GetEventBookId(eventId);
        }

        public DateTime GetOccuranceTime(int eventId)
        {
            return dataApi.GetOccuranceTime(eventId);
        }

        public string GetBookTitle(int bookId)
        {
            return dataApi.GetBookTitle(bookId);
        }

        public float GetBookFee(int bookId)
        {
            return dataApi.GetBookFee(bookId);
        }

        public int GetBookState(int bookId)
        {
            return dataApi.GetBookState(bookId);
        }

        public void UpdateUser(int userId, string firstName, string lastName)
        {
            dataApi.UpdateUser(userId, firstName, lastName);
        }

        public void UpdateEvent(int eventId, int userId, int bookId, DateTime occurrenceTime)
        {
            dataApi.UpdateEvent(eventId, userId, bookId, occurrenceTime);
        }

        public void UpdateBook(int bookId, string title, int state, float fee)
        {
            dataApi.UpdateBook(bookId, title, state, fee);
        }
    }
}
