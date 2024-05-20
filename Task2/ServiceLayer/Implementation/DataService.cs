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

        public void AddEvent(int eventId, int userId, int bookId, IDataApi.EventMode mode, DateTime occurrenceTime)
        {
            dataApi.AddEvent(eventId, userId, bookId, mode, occurrenceTime);
        }

        public void RemoveEvent(int eventId)
        {
            dataApi.RemoveEvent(eventId);
        }

        public IEvent? GetEvent(int eventId)
        {
            return dataApi.GetEvent(eventId);
        }

        public void AddBook(int bookId, string title, float fee = 0f)
        {
            dataApi.AddBook(bookId, title, fee);
        }

        public void RemoveBook(int bookId)
        {
            dataApi.RemoveBook(bookId);
        }

        public IBook? GetBook(int bookId)
        {
            return dataApi.GetBook(bookId);
        }

        public void UpdateState(int bookId, int quantity)
        {
            dataApi.UpdateState(bookId, quantity);
        }

        public IState GetState(int bookId)
        {
            return dataApi.GetState(bookId);
        }
    }
}
