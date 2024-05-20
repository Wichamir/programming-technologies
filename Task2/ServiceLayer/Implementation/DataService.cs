using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;

namespace Service.Implementation
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

        public IUser? GetUser(int userId)
        {
            return dataApi.GetUser(userId);
        }

        public void AddEvent(int eventId, int userId, int bookId, DateTime occurrenceTime)
        {
            dataApi.AddEvent(eventId, userId, bookId, occurrenceTime);
        }

        public void RemoveEvent(int eventId)
        {
            dataApi.RemoveEvent(eventId);
        }

        public IEvent? GetEvent(int eventId)
        {
            return dataApi.GetEvent(eventId);
        }

        public void AddBook(int bookId, string title, int state, float fee = 0f)
        {
            dataApi.AddBook(bookId, title, state, fee);
        }

        public void RemoveBook(int bookId)
        {
            dataApi.RemoveBook(bookId);
        }

        public IBook? GetBook(int bookId)
        {
            return dataApi.GetBook(bookId);
        }
    }
}
