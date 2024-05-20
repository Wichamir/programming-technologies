using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;
using Service.Implementation;

namespace Service
{
    public interface IServiceApi
    {
        public static IServiceApi CreateDataService(string connectionString)
        {
            return new DataService(IDataApi.CreateDataRepository(connectionString));
        }

        void AddUser(int userId, string firstName, string lastName);
        void RemoveUser(int userId);
        IUser? GetUser(int userId);

        void AddEvent(int eventId, int userId, int bookId, IDataApi.EventMode mode, DateTime occurrenceTime);
        void RemoveEvent(int eventId);
        IEvent? GetEvent(int eventId);

        void AddBook(int bookId, string title, float fee = 0f);
        void RemoveBook(int bookId);
        IBook? GetBook(int bookId);

        void UpdateState(int bookId, int quantity);
        IState GetState(int bookId);
    }
}
